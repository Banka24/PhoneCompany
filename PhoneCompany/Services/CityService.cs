using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using PhoneCompany.Model.Entities;

namespace PhoneCompany.Services;

public class CityService : InteractionService
{
    public async Task<IEnumerable<City>> GetDataAsync()
    {
        return await Context.Cities.ToListAsync();
    }
    public async Task<decimal> GetTariffAsync(Conversation conversation)
    {
        var city = await Context.Cities.FirstOrDefaultAsync(i => i.Id == conversation.CityId);
        return conversation.TimeOfDayId == 1 ? city!.TariffDay : city!.TariffNight;
    }
}