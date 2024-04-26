using PhoneCompany.ViewModels.MainViewModel;

namespace PhoneCompany.Views.Main.Pages;

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