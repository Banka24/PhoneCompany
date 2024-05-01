using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Controls;
using PhoneCompany.Models;
using PhoneCompany.Services.InteractionDataBase;

namespace PhoneCompany.ViewModels.MainViewModel;

public class CityPageViewModel : PageViewModelBase
{
    public ObservableCollection<City> CitiesList { get; set; } = [];
    
    protected override async Task EnterDataListAsync()
    {
        var service = new CityService(new CompanyDbContext());
        var cities = await service.GetDataAsync();
        foreach (var city in cities) CitiesList.Add(city);
    }

    protected override async void UpdatePageAsync(Button sender)
    {
        CitiesList.Clear();
        await EnterDataListAsync();
    }
}