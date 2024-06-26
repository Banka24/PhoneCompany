﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using PhoneCompany.Models;

namespace PhoneCompany.Services.InteractionDataBase;

/// <summary>
/// Сервис работы с таблицей Абоненты
/// </summary>
public class AbonentService(CompanyDbContext context)
{
    private static Abonent _lastFoundAbonent;

    /// <summary>
    /// Получение списка абонентов
    /// </summary>
    /// <returns>Список абонентов</returns>
    public async Task<List<Abonent>> GetDataAsync()
    {
        using (context)
        {
            return await context.Abonents.ToListAsync();
        }
    }

    /// <summary>
    /// Асинхронное получение списка абонентов с одинаковым ИНН
    /// </summary>
    /// <returns>Список абонентов</returns>
    public async Task<List<Abonent>> GetDataByInnAsync(string inn)
    {
        using (context)
        {
            return await context.Abonents.Where(i => i.Inn == inn).ToListAsync();
        }
    }

    /// <summary>
    /// Асинхронное добавление абонента в базу данных
    /// </summary>
    /// <returns>Вернёт true если получилось добавить, false если произошла ошибка</returns>
    public async Task<bool> AddAbonentAsync(string phoneNumber, string inn, string address)
    {
        using (context)
        {
            context.Abonents.Add(MakeAbonent(phoneNumber, inn, address));
            return await context.TrySaveChangeAsync();
        }
    }

    /// <summary>
    /// Асинхронное нахождение абонента по номеру телефона
    /// </summary>
    /// <returns>Найденный абонент</returns>
    /// <exception cref="ArgumentException"></exception>
    public async Task<Abonent> FindAbonentAsync(string phoneNumber)
    {
        using (context)
        {
            _lastFoundAbonent = await context.Abonents.FirstOrDefaultAsync(i => i.PhoneNumber == phoneNumber) ?? throw new Exception("Такого номера нет");
        }
        
        return _lastFoundAbonent;
    }

    /// <summary>
    /// Асинхронное редактирование информации об абоненте
    /// </summary>
    /// <returns>Вернёт true если получилось изменить и сохранить, false если произошла ошибка</returns>
    public async Task<bool> EditAbonentAsync(string phoneNumber, string inn, string address)
    {
        var newAbonent = MakeAbonent(phoneNumber, inn, address);

        using (context)
        {
            context.Abonents.Attach(_lastFoundAbonent);
            (_lastFoundAbonent.PhoneNumber, _lastFoundAbonent.Inn, _lastFoundAbonent.Address) = (newAbonent.PhoneNumber, newAbonent.Inn, newAbonent.Address);
            return await context.TrySaveChangeAsync();
        }
    }

    /// <summary>
    /// Асинхронное удаление абонента из базы данных
    /// </summary>
    /// <returns>Вернёт true если получилось удалить, false если произошла ошибка</returns>
    /// <exception cref="Exception"></exception>
    public async Task<bool> DeleteAbonentAsync(string phoneNumber)
    {
        using (context)
        {
            try
            {
                var abonent = await context.Abonents.FirstOrDefaultAsync(i => i.PhoneNumber == phoneNumber) ?? throw new Exception("Такого элемента нет");
                context.Abonents.Remove(abonent);
            }
            catch (Exception)
            {
                return false;
            }
            
            return await context.TrySaveChangeAsync();
        }
    }

    /// <summary>
    /// Асинхронное получение списка телефонных номеров
    /// </summary>
    /// <returns>Список телефонных номеров</returns>
    public async Task<List<string>> GetPhoneNumbersAsync()
    {
        using (context)
        {
            return await context.Abonents.Select(i => i.PhoneNumber).ToListAsync();
        }
    }

    /// <summary>
    /// Асинхронное получение списка ИНН
    /// </summary>
    /// <returns>Список ИНН</returns>
    public async Task<List<string>> GetInnAsync()
    {
        using (context)
        {
            return await context.Abonents.Select(i => i.Inn).Distinct().ToListAsync();
        }
    }

    private static Abonent MakeAbonent(in string phoneNumber, in string inn, in string address)
    {
        return new Abonent { PhoneNumber = phoneNumber, Inn = inn, Address = address };
    }
}