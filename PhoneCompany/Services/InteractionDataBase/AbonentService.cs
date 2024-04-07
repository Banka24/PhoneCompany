using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using PhoneCompany.Model.Entities;

namespace PhoneCompany.Services.InteractionDataBase;

public class AbonentService : InteractionService
{
    public async Task<IEnumerable<Abonent>> GetDataAsync()
    {
        return await Context.Abonents.ToListAsync();
    }

    public async Task<bool> AddAbonentAsync(string phoneNumber, string inn, string address)
    {
        Context.Abonents.Add(new Abonent { PhoneNumber = phoneNumber, Inn = inn, Address = address });
        return await Context.TrySaveChangeAsync();
    }

    public Task<bool> EditAbonentAsync(string phoneNumber)
    {
        return null;
    }

    public async Task<bool> DeleteAbonentAsync(string phoneNumber)
    {
        var abonent = await Context.Abonents.Where(i => i.PhoneNumber == phoneNumber).FirstOrDefaultAsync() ?? throw new Exception("Такого элемента нет");
        Context.Abonents.Remove(abonent);
        return await Context.TrySaveChangeAsync();
    }

}