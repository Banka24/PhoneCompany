using PhoneCompany.ViewModels.MainViewModel;

namespace PhoneCompany.Views.Main.Pages;

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