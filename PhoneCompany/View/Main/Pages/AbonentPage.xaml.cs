using PhoneCompany.ViewModel.MainViewModel;

namespace PhoneCompany.View.Main.Pages;

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