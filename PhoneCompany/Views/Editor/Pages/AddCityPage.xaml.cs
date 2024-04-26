using System.Windows.Controls;
using PhoneCompany.ViewModels.EditorVM;

namespace PhoneCompany.Views.Editor.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddCityPage.xaml
    /// </summary>
    public partial class AddCityPage : Page
    {
        public AddCityPage()
        {
            InitializeComponent();
            DataContext = new AddCityViewModel();
        }
    }
}
