using System.Windows.Controls;
using PhoneCompany.ViewModels.EditorVM;

namespace PhoneCompany.Views.Editor.Pages;

/// <summary>
///     Логика взаимодействия для EditAbonentPage.xaml
/// </summary>
public partial class EditAbonentPage : Page
{
    public EditAbonentPage()
    {
        InitializeComponent();
        DataContext = new EditAbonentViewModel();
    }
}