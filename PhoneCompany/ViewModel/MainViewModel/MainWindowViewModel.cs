using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using PhoneCompany.Services;

namespace PhoneCompany.ViewModel.MainViewModel;

public class MainWindowViewModel : INotifyPropertyChanged
{
    private ICommand _changePageCommand;
    public ICommand ChangePageCommand => _changePageCommand ??= new RelayCommand<Button>(ChangePage);

    private ICommand _openEditorCommand;
    public ICommand OpenEditorCommand => _openEditorCommand ??= new RelayCommand<Button>(OpenEditor);

    private Page _currentPage;
    public Page CurrentPage
    {
        get => _currentPage;
        private set
        {
            _currentPage = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    private void ChangePage(Button sender)
    {
        CurrentPage = PageDictionaryHolder.GetPage(sender.Name);
    }
    
    private void OpenEditor(Button sender)
    {
        if (CurrentPage is null) return;
        WindowManager.OpenWindow(sender.Name, CurrentPage.Title);
    }
}