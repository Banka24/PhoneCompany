using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using PhoneCompany.Model.Entities;

namespace PhoneCompany.Services.InteractionDataBase;

public class CityService(CompanyDbContext context)
{
    private static City _lastFoundCity;

    public async Task<IEnumerable<City>> GetDataAsync()
    {
        using (context)
        {
            return await context.Cities.ToListAsync();
        }
    }
    public async Task<decimal> GetTariffAsync(Conversation conversation)
    {
        using (context)
        {
            var city = await context.Cities.FirstOrDefaultAsync(i => i.Id == conversation.CityId);
            return conversation.TimeOfDayId == 1 ? city!.TariffDay : city!.TariffNight;
        }
    }

    public async Task<bool> AddCityAsync(string title, decimal tariffDay, decimal tariffNight)
    {
        using (context)
        {
            context.Cities.Add(MakeCity(title, tariffDay, tariffNight));
            return await context.TrySaveChangeAsync();
        }
    }

    public async Task<City> GetCity(string title)
    {
        using (context)
        {
            _lastFoundCity = await context.Cities.FirstOrDefaultAsync(city => city.Title == title);
            return _lastFoundCity;
        }
    }

    public async Task<List<string>> GetCityTitleAsync()
    {
        using (context)
        {
            return await context.Cities.Select(i => i.Title).ToListAsync();
        }
    }

    public async Task<bool> EditCityAsync(string title, decimal tariffDay, decimal tariffNight)
    {
        using (context)
        {
            context.Cities.Attach(_lastFoundCity);
            _lastFoundCity = MakeCity(title, tariffDay, tariffNight);
            return await context.TrySaveChangeAsync();
        }
    }

    public async Task<bool> DeleteCityAsync(string title)
    {
        using (context)
        {
            var city = await context.Cities.FirstOrDefaultAsync(i => i.Title == title) ?? throw new Exception("Такого элемента нет");
            context.Cities.Remove(city);
            return await context.TrySaveChangeAsync();
        }
    }

    private static City MakeCity(in string title, in decimal tariffDay, in decimal tariffNight)
    {
        return new City { Title = title, TariffDay = tariffDay, TariffNight = tariffNight };
    }
}