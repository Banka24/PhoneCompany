using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using PhoneCompany.Model.Entities;

namespace PhoneCompany.Services.InteractionDataBase;

public class AbonentService(CompanyDbContext context)
{
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
            context.Abonents.Add(new Abonent { PhoneNumber = phoneNumber, Inn = inn, Address = address });
            return await context.TrySaveChangeAsync();
        }
    }

    public Task<bool> EditAbonentAsync(string phoneNumber)
    {
        return null;
    }

    public async Task<bool> DeleteAbonentAsync(string phoneNumber)
    {
        using (context)
        {
            var abonent = await context.Abonents.Where(i => i.PhoneNumber == phoneNumber).FirstOrDefaultAsync() ?? throw new Exception("Такого элемента нет");
            context.Abonents.Remove(abonent);
            return await context.TrySaveChangeAsync();
        }
    }
}