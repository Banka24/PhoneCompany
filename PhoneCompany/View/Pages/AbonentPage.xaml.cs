using PhoneCompany.ViewModel;

namespace PhoneCompany.View.Pages;

/// <summary>
///     Логика взаимодействия для AbonentPage.xaml
/// </summary>
public partial class AbonentPage
{
    public AbonentPage()
    {
        InitializeComponent();
        DataContext = new AbonentPageViewModel();
    }
}