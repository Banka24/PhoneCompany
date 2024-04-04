using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Controls;
using PhoneCompany.Model.Entities;

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
        var abonents = await AbonentService.GetDataAsync();

        foreach (var abonent in abonents) AbonentsList.Add(abonent);
    }

    protected override async void UpdatePageAsync(Button sender)
    {
        AbonentsList.Clear();
        await EnterDataListAsync();
    }
    
}