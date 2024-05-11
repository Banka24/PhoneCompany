using System.Threading.Tasks;
using System.Windows.Controls;
using PhoneCompany.Models;
using PhoneCompany.Services.InteractionDataBase;

namespace PhoneCompany.ViewModels.MainViewModel;

public class AbonentPageViewModel : PageViewModelBase
{
    public AbonentPageViewModel()
    {
        _ = GetInnsList();
    }

    public string Inn { get; set; }

    public System.Collections.ObjectModel.ObservableCollection<Abonent> AbonentsList { get; set; } = [];
    public System.Collections.ObjectModel.ObservableCollection<string> InnList { get; set; } = [];

    protected override async Task EnterDataListAsync()
    {
        var service = new AbonentService(new CompanyDbContext());
        await FillDataGrid(AbonentsList, await service.GetDataAsync());
    }

    protected override async void UpdateDataGridAsync(Button sender)
    {
        AbonentsList.Clear();
        await EnterDataListAsync();
    }

    protected override async void GetFilteredList(Button button)
    {
        if(string.IsNullOrWhiteSpace(Inn)) return;

        var service = new AbonentService(new CompanyDbContext());
        AbonentsList.Clear();
        await FillDataGrid(AbonentsList, await service.GetDataByInnAsync(Inn));
    }

    private async Task GetInnsList()
    {
        var service = new AbonentService(new CompanyDbContext());
        await FillDataGrid(InnList, await service.GetInnAsync());
    }
}