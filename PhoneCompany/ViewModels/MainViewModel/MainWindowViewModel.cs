using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using PhoneCompany.Services;
using PhoneCompany.Services.DictionaryHolder;

namespace PhoneCompany.ViewModels.MainViewModel;

public class MainWindowViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

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

    private bool _isDatabaseConnected;
    public bool IsDatabaseConnected
    {
        get => _isDatabaseConnected;
        set
        {
            _isDatabaseConnected = value;
            OnPropertyChanged();
        }
    }

    public bool IsButtonsEnabled => IsDatabaseConnected;

    public void SetIsDatabaseConnected(bool isConnected)
    {
        IsDatabaseConnected = isConnected;
        OnPropertyChanged(nameof(IsDatabaseConnected));
        OnPropertyChanged(nameof(IsButtonsEnabled));
    }

    private string _connectionText;
    public string ConnectionText
    {
        get => _connectionText;
        set
        {
            _connectionText = value;
            OnPropertyChanged();
        }
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void ChangePage(Button sender)
    {
        var pageHolder = new PageDictionaryHolder();
        CurrentPage = pageHolder.GetPage(sender.Name);
    }
    
    private void OpenEditor(Button sender)
    {
        if (CurrentPage is not null)
        {
            WindowManager.OpenEditor(sender.Name, CurrentPage.Title);
        }
    }
}