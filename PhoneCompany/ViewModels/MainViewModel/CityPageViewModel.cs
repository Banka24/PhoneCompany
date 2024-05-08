using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using PhoneCompany.Models;
using PhoneCompany.Services;
using PhoneCompany.Services.InteractionDataBase;

namespace PhoneCompany.ViewModels.MainViewModel;

public class CityPageViewModel : PageViewModelBase
{
    public CityPageViewModel()
    {
        _ = GetTitleCitiesList();
    }

    public string Title { get; set; }
    public ObservableCollection<City> CitiesList { get; set; } = [];
    public ObservableCollection<string> TitleCitiesList { get; set; } = [];

    private ICommand _findCommand;
    public ICommand FindCommand => _findCommand ??= new RelayCommand<Button>(GetFilteredList);

    protected override async Task EnterDataListAsync()
    {
        var service = new CityService(new CompanyDbContext());
        var cities = await service.GetDataAsync();
        foreach (var city in cities)
        {
            CitiesList.Add(city);
        }
    }

    protected override async void UpdateDataGridAsync(Button sender)
    {
        CitiesList.Clear();
        await EnterDataListAsync();
    }

    private async void GetFilteredList(Button button)
    {
        if(string.IsNullOrWhiteSpace(Title)) return;

        var service = new CityService(new CompanyDbContext());
        var city = await service.GetDataByTitleAsync(Title);
        CitiesList.Clear();
        CitiesList.Add(city);
    }

    private async Task GetTitleCitiesList()
    {
        var service = new CityService(new CompanyDbContext());
        var titles = await service.GetCityTitleAsync();

        foreach (var title in titles)
        {
            TitleCitiesList.Add(title);
        }
    }
}