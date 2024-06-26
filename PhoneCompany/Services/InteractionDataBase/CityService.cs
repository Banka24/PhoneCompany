﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using PhoneCompany.Models;

namespace PhoneCompany.Services.InteractionDataBase;

/// <summary>
/// Сервис работы с таблицей Города
/// </summary>
public class CityService(CompanyDbContext context)
{
    private static City _lastFoundCity;

    /// <summary>
    /// Получение списка городов
    /// </summary>
    /// <returns>Список городов</returns>
    public async Task<List<City>> GetDataAsync()
    {
        using (context)
        {
            return await context.Cities.OrderBy(i => i.Title).ToListAsync();
        }
    }

    /// <summary>
    /// Асинхронное информации о городе по его названию
    /// </summary>
    /// <returns>Город</returns>
    public async Task<City> GetCityByTitleAsync(string title)
    {
        using (context)
        {
            return await context.Cities.Where(i => i.Title == title).FirstAsync();
        }
    }

    /// <summary>
    /// Асинхронное получение тарифа
    /// </summary>
    /// <returns>Тариф</returns>
    /// <exception cref="Exception"></exception>
    public async Task<decimal> GetTariffAsync(Conversation conversation)
    {
        using (context)
        {
            var city = await context.Cities.FirstOrDefaultAsync(i => i.Id == conversation.CityId);
            return conversation.TimeOfDay switch
            {
                "День" => city!.TariffDay,
                "Ночь" => city!.TariffNight,
                _ => throw new Exception("Такого элемента не существует")
            };
        }
    }

    /// <summary>
    /// Асинхронное добавление города в базу данных
    /// </summary>
    /// <returns>Вернёт true если получилось добавить, false если произошла ошибка</returns>
    public async Task<bool> AddCityAsync(string title, decimal tariffDay, decimal tariffNight)
    {
        using (context)
        {
            context.Cities.Add(MakeCity(title, tariffDay, tariffNight));
            return await context.TrySaveChangeAsync();
        }
    }

    /// <summary>
    /// Асинхронное нахождение города по названию
    /// </summary>
    /// <returns>Город</returns>
    /// <exception cref="Exception"></exception>
    public async Task<City> FindCityAsync(string title)
    {
        using (context)
        {
            _lastFoundCity = await context.Cities.FirstOrDefaultAsync(city => city.Title == title) ?? throw new Exception("Такого города нет");
        }
        
        return _lastFoundCity;
    }

    /// <summary>
    /// Асинхронное получение название городов по алфавиту
    /// </summary>
    /// <returns>Список названий</returns>
    public async Task<List<string>> GetCityTitleAsync()
    {
        using (context)
        {
            return await context.Cities.OrderBy(i => i.Title).Select(i => i.Title).ToListAsync();
        }
    }

    /// <summary>
    /// Асинхронное редактирование информации о городе
    /// </summary>
    /// <returns>Вернёт true если получилось изменить и сохранить, false если произошла ошибка</returns>
    public async Task<bool> EditCityAsync(string title, decimal tariffDay, decimal tariffNight)
    {
        var newCity = MakeCity(title, tariffDay, tariffNight);

        using (context)
        {
            context.Cities.Attach(_lastFoundCity);
            (_lastFoundCity.Title, _lastFoundCity.TariffDay, _lastFoundCity.TariffNight) = (newCity.Title, newCity.TariffDay, newCity.TariffNight);
            return await context.TrySaveChangeAsync();
        }
    }

    /// <summary>
    /// Асинхронное удаление города из базы данных
    /// </summary>
    /// <returns>Вернёт true если получилось удалить, false если произошла ошибка</returns>
    /// <exception cref="Exception"></exception>
    public async Task<bool> DeleteCityAsync(string title)
    {
        using (context)
        {
            try
            {
                var city = await context.Cities.FirstOrDefaultAsync(i => i.Title == title) ?? throw new Exception("Такого элемента нет");
                context.Cities.Remove(city);
            }
            catch (Exception)
            {
                return false;
            }
            
            return await context.TrySaveChangeAsync();
        }
    }

    /// <summary>
    /// Проверяет, есть ли город с таким же названием
    /// </summary>
    /// <returns> Вернёт true если город с таким название есть, false, если такого города нет</returns>
    public async Task<bool> CheckIsNewCity(string title)
    {
        return await context.Cities.AnyAsync(city => city.Title == title);
    }

    private static City MakeCity(in string title, in decimal tariffDay, in decimal tariffNight)
    {
        return new City { Title = title, TariffDay = tariffDay, TariffNight = tariffNight };
    }
}