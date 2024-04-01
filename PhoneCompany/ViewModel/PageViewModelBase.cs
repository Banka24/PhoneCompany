using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using PhoneCompany.Services;

namespace PhoneCompany.ViewModel;

public abstract class PageViewModelBase
{
    protected readonly IAbonentService AbonentService = new AbonentService();
    protected readonly ICityService CityService = new CityService();
    protected readonly IConversationService ConversationService = new ConversationService();

    private ICommand _updateCommand;
    public virtual ICommand UpdateCommand => _updateCommand ??= new RelayCommand<Button>(UpdatePageAsync);

    protected virtual Task EnterDataListAsync()
    {
        return Task.CompletedTask;
    }

    protected virtual void UpdatePageAsync(Button sender)
    {
    }
}