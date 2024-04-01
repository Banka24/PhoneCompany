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
    public ICommand ChangePageCommand => _changePageCommand ??= new RelayCommand(ChangePage);


    private void ChangePage(object sender)
    {
        if (sender is not Button button) return;
        frame.Content = Pages[button.Name];
    }
}