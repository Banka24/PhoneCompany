using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using PhoneCompany.Model.Entities;

namespace PhoneCompany.Services.InteractionDataBase;

public class CityService(CompanyDbContext context)
{
    public async Task<IEnumerable<City>> GetDataAsync()
    {
        return await context.Cities.ToListAsync();
    }
    public async Task<decimal> GetTariffAsync(Conversation conversation)
    {
        var city = await context.Cities.FirstOrDefaultAsync(i => i.Id == conversation.CityId);
        return conversation.TimeOfDayId == 1 ? city!.TariffDay : city!.TariffNight;
    }
    public async Task<bool> AddCityAsync(string title, decimal tariffDay, decimal tariffNight)
    {
        context.Cities.Add(new City{ Title = title, TariffDay = tariffDay, TariffNight = tariffNight});
        return await context.TrySaveChangeAsync();
    }

    public Task<bool> EditCityAsync(string title)
    {
        return null;
    }

    public async Task<bool> DeleteCityAsync(string title)
    {
        var city = await context.Cities.Where(i => i.Title == title).FirstOrDefaultAsync() ?? throw new Exception("Такого элемента нет");
        context.Cities.Remove(city);
        return await context.TrySaveChangeAsync();
    }
}