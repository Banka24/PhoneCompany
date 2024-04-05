using PhoneCompany.ViewModel.MainViewModel;

namespace PhoneCompany.View.Main.Pages;

/// <summary>
///     Логика взаимодействия для CityPage.xaml
/// </summary>
public partial class CityPage
{
    public CityPage()
    {
        InitializeComponent();
        DataContext = new CityPageViewModel();
    }
}