using System.Windows.Controls;
using PhoneCompany.ViewModels.EditorVM;

namespace PhoneCompany.Views.Editor.Pages;

/// <summary>
///     Логика взаимодействия для EditCityPage.xaml
/// </summary>
public partial class EditCityPage : Page
{
    public EditCityPage()
    {
        InitializeComponent();
        DataContext = new EditCityViewModel();
    }
}