using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using PhoneCompany.Model.Entities;

namespace PhoneCompany.Services;

public class AbonentService : InteractionService, IAbonentService
{
    public async Task<IEnumerable<Abonent>> GetDataAsync()
    {
        return await Context.Abonents.ToListAsync();
    }

    public async Task<bool> AddAbonent(string phoneNumber, string inn, string address)
    {
        var abonent = new Abonent { PhoneNumber = phoneNumber, Inn = inn, Address = address };
        Context.Abonents.Add(abonent);
        return await Context.TrySaveChangeAsync();
    }
}