using System.Collections.ObjectModel;
using System.Threading.Tasks;
using PhoneCompany.Model.Entities;
using PhoneCompany.Services;

namespace PhoneCompany.ViewModel;

public sealed class AbonentPageViewModel : PageViewModelBase
{
    public ObservableCollection<Abonent> AbonentsList { get; set; } = [];

    public AbonentPageViewModel()
    {
        EnterDataListAsync();
    }

    protected override async Task EnterDataListAsync()
    {
        var abonentService = new AbonentService();
        var abonents = await abonentService.GetDataAsync();

        foreach (var abonent in abonents) AbonentsList.Add(abonent);
    }

    protected override async void UpdatePageAsync(object sender)
    {
        AbonentsList.Clear();
        await EnterDataListAsync();
    }
}