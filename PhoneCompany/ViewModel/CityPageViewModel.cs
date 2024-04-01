using System.Collections.ObjectModel;
using System.Threading.Tasks;
using PhoneCompany.Model.Entities;
using PhoneCompany.Services;

namespace PhoneCompany.ViewModel;

public class CityPageViewModel : PageViewModelBase
{
    public ObservableCollection<City> CitiesList { get; set; } = [];

    public CityPageViewModel()
    {
        EnterDataListAsync();
    }

    protected override async Task EnterDataListAsync()
    {
        var cityService = new CityService();
        var cities = await cityService.GetDataAsync();

        foreach (var city in cities) CitiesList.Add(city);
    }

    protected override async void UpdatePageAsync(object sender)
    {
        CitiesList.Clear();
        await EnterDataListAsync();
    }
}