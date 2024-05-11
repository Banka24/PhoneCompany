using System.Threading.Tasks;
using System.Windows.Controls;
using PhoneCompany.Models;
using PhoneCompany.Services.InteractionDataBase;

namespace PhoneCompany.ViewModels.MainViewModel;

public class CityPageViewModel : PageViewModelBase
{
    public CityPageViewModel()
    {
        _ = GetTitleCitiesList();
    }

    public string Title { get; set; }

    public System.Collections.ObjectModel.ObservableCollection<City> CitiesList { get; set; } = [];
    public System.Collections.ObjectModel.ObservableCollection<string> TitleCitiesList { get; set; } = [];

    protected override async Task EnterDataListAsync()
    {
        var service = new CityService(new CompanyDbContext());
        await FillDataGrid(CitiesList, await service.GetDataAsync());
    }

    protected override async void UpdateDataGridAsync(Button sender)
    {
        CitiesList.Clear();
        await EnterDataListAsync();
    }

    protected override async void GetFilteredList(Button button)
    {
        if(string.IsNullOrWhiteSpace(Title)) return;

        var service = new CityService(new CompanyDbContext());
        CitiesList.Clear();
        CitiesList.Add(await service.GetCityByTitleAsync(Title));
    }

    private async Task GetTitleCitiesList()
    {
        var service = new CityService(new CompanyDbContext());
        await FillDataGrid(TitleCitiesList, await service.GetCityTitleAsync());
    }
}