using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using PhoneCompany.Model.Entities;

namespace PhoneCompany.Services.InteractionDataBase;

public class AbonentService(CompanyDbContext context)
{
    private static Abonent _lastFoundAbonent;

    public async Task<IEnumerable<Abonent>> GetDataAsync()
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
            context.Abonents.Add(MakeAbonent(phoneNumber, inn, address));
            return await context.TrySaveChangeAsync();
        }
    }

    public async Task<Abonent> GetAbonentAsync(string phoneNumber)
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
            var newAbonent = MakeAbonent(phoneNumber, inn, address);
            (_lastFoundAbonent.PhoneNumber, _lastFoundAbonent.Inn, _lastFoundAbonent.Address) = (newAbonent.PhoneNumber, newAbonent.Inn, newAbonent.Address);
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

    public async Task<List<string>> GetPhoneNumbersAsync()
    {
        using (context)
        {
            return await context.Abonents.Select(i => i.PhoneNumber).ToListAsync();
        }
    }

    private static Abonent MakeAbonent(in string phoneNumber, in string inn, in string address)
    {
        return new Abonent { PhoneNumber = phoneNumber, Inn = inn, Address = address };
    }
}