using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using PhoneCompany.Services;

namespace PhoneCompany.ViewModel.MainViewModel;

public abstract class PageViewModelBase : ViewModelBase
{
    private ICommand _updateCommand;
    public ICommand UpdateCommand => _updateCommand ??= new RelayCommand<Button>(UpdatePageAsync);
    protected abstract Task EnterDataListAsync();
    protected abstract void UpdatePageAsync(Button sender);
}