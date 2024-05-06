using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using PhoneCompany.Models;
using PhoneCompany.Services;
using PhoneCompany.Services.InteractionDataBase;

namespace PhoneCompany.ViewModels.MainViewModel;

public class AbonentPageViewModel : PageViewModelBase
{
    public AbonentPageViewModel()
    {
        _ = GetInnsList();
    }

    public string Inn { get; set; }
    public ObservableCollection<Abonent> AbonentsList { get; set; } = [];
    public ObservableCollection<string> InnList { get; set; } = [];

    private ICommand _findCommand;
    public ICommand FindCommand => _findCommand ??= new RelayCommand<Button>(GetFilteredList);

    protected override async Task EnterDataListAsync()
    {
        var service = new AbonentService(new CompanyDbContext());
        var abonents = await service.GetDataAsync();
        foreach (var abonent in abonents) AbonentsList.Add(abonent);
    }

    protected override async void UpdatePageAsync(Button sender)
    {
        AbonentsList.Clear();
        await EnterDataListAsync();
    }

    private async void GetFilteredList(Button button)
    {
        if(string.IsNullOrWhiteSpace(Inn)) return;

        var service = new AbonentService(new CompanyDbContext());
        var abonentsFilterList = await service.GetDataByInnAsync(Inn);
        AbonentsList.Clear();
        
        foreach (var abonent in abonentsFilterList)
        {
            AbonentsList.Add(abonent);
        }
    }

    private async Task GetInnsList()
    {
        var service = new AbonentService(new CompanyDbContext());
        var inns = await service.GetInnAsync();
        
        foreach (var inn in inns)
        {
            InnList.Add(inn);
        }
    }
}