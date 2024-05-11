using System.Windows.Controls;
using PhoneCompany.ViewModels.EditorVM;

namespace PhoneCompany.Views.Editor.Pages;

/// <summary>
///     Логика взаимодействия для DeleteCityPage.xaml
/// </summary>
public partial class DeleteCityPage : Page
{
    public DeleteCityPage()
    {
        InitializeComponent();
        DataContext = new DeleteCityViewModel();
    }
}