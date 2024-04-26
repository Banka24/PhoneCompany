using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Controls;
using PhoneCompany.Models;
using PhoneCompany.Services.InteractionDataBase;

namespace PhoneCompany.ViewModels.MainViewModel;

public sealed class AbonentPageViewModel : PageViewModelBase
{
    public ObservableCollection<Abonent> AbonentsList { get; set; } = [];

    public AbonentPageViewModel()
    {
        EnterDataListAsync();
    }

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
}