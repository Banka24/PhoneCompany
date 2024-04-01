using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using PhoneCompany.Model.Entities;

namespace PhoneCompany.Services;

public class AbonentService : InteractionService
{
    public async Task<IEnumerable<Abonent>> GetDataAsync()
    {
        return await Context.Abonents.ToListAsync();
    }
}