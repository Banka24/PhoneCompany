using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using PhoneCompany.Model.Entities;

namespace PhoneCompany.Services.InteractionDataBase;

public class CityService : InteractionService, ICityService
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
    public async Task<bool> AddCityAsync(string title, decimal tariffDay, decimal tariffNight)
    {
        Context.Cities.Add(new City{ Title = title, TariffDay = tariffDay, TariffNight = tariffNight});
        return await Context.TrySaveChangeAsync();
    }
}