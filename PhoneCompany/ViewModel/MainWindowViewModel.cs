using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using PhoneCompany.Services;
using PhoneCompany.View.Pages;

namespace PhoneCompany.ViewModel;

public class MainWindowViewModel(Frame frame)
{
    private static readonly Dictionary<string, Page> Pages = new()
    {
        { "ConversationPage", new ConversationPage() },
        { "AbonentPage", new AbonentPage() },
        { "CityPage", new CityPage() }
    };

    private ICommand _changePageCommand;
    public ICommand ChangePageCommand => _changePageCommand ??= new RelayCommand<Button>(ChangePage);

    private void ChangePage(Button sender)
    {
        frame.Content = Pages[sender.Name];
    }
}