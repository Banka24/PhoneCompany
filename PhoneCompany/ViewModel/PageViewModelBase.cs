using System.Threading.Tasks;
using System.Windows.Input;
using PhoneCompany.Services;

namespace PhoneCompany.ViewModel;

public abstract class PageViewModelBase
{
    private ICommand _updateCommand;
    public virtual ICommand UpdateCommand => _updateCommand ??= new RelayCommand(UpdatePageAsync);

    protected virtual Task EnterDataListAsync()
    {
        return Task.CompletedTask;
    }

    protected virtual void UpdatePageAsync(object sender)
    {
    }
}