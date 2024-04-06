using System.Windows.Controls;
using PhoneCompany.ViewModel.EditorVM;

namespace PhoneCompany.View.Editor.Pages
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
