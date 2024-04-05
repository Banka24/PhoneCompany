using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using PhoneCompany.Services;
using PhoneCompany.View.Editor.Windows;

namespace PhoneCompany.ViewModel.MainViewModel;

public abstract class PageViewModelBase : ViewModelBase
{
    private ICommand _updateCommand;
    public ICommand UpdateCommand => _updateCommand ??= new RelayCommand<Button>(UpdatePageAsync);

    private ICommand _goEditorCommand;
    public ICommand GoEditorCommand => _goEditorCommand ??= new RelayCommand<Button>(GoToEditor);

    protected virtual Task EnterDataListAsync()
    {
        return Task.CompletedTask;
    }

    protected virtual void UpdatePageAsync(Button sender)
    {
    }
    protected static void GoToEditor(Button sender)
    {
        var window = new Editor(PageDictionaryHolder.GetPage(sender.Name));
        window.ShowDialog();
    }
}