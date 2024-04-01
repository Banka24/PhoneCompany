using PhoneCompany.ViewModel;

namespace PhoneCompany.View.Pages;

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