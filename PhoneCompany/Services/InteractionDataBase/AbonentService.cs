using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using PhoneCompany.Model.Entities;

namespace PhoneCompany.Services.InteractionDataBase;

public class AbonentService : InteractionService, IAbonentService
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
}