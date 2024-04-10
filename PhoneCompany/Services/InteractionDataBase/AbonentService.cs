using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using PhoneCompany.Model.Entities;

namespace PhoneCompany.Services.InteractionDataBase;

public class AbonentService(CompanyDbContext context)
{
    private static Abonent _lastFoundAbonent;

    public async Task<List<Abonent>> GetDataAsync()
    {
        using (context)
        {
            return await context.Abonents.ToListAsync();
        }
    }

    public async Task<bool> AddAbonentAsync(string phoneNumber, string inn, string address)
    {
        using (context)
        {
            context.Abonents.Add(new Abonent { PhoneNumber = phoneNumber, Inn = inn, Address = address });
            return await context.TrySaveChangeAsync();
        }
    }

    public async Task<Abonent> GetAbonent(string phoneNumber)
    {
        using (context)
        {
            _lastFoundAbonent = await context.Abonents.FirstOrDefaultAsync(i => i.PhoneNumber == phoneNumber) ?? throw new Exception("Такого номера нет");
            return _lastFoundAbonent;
        }
    }

    public async Task<bool> EditAbonentAsync(string phoneNumber, string inn, string address)
    {
        using (context)
        {
            context.Abonents.Attach(_lastFoundAbonent);
            _lastFoundAbonent.PhoneNumber = phoneNumber;
            _lastFoundAbonent.Inn = inn;
            _lastFoundAbonent.Address = address;
            return await context.TrySaveChangeAsync();
        }
    }

    public async Task<bool> DeleteAbonentAsync(string phoneNumber)
    {
        using (context)
        {
            var abonent = await context.Abonents.FirstOrDefaultAsync(i => i.PhoneNumber == phoneNumber) ?? throw new Exception("Такого элемента нет");
            context.Abonents.Remove(abonent);
            return await context.TrySaveChangeAsync();
        }
    }
}