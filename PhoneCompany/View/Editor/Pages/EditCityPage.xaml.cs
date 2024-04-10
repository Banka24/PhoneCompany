using System.Windows.Controls;
using PhoneCompany.ViewModel.EditorVM;

namespace PhoneCompany.View.Editor.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditCityPage.xaml
    /// </summary>
    public partial class EditCityPage : Page
    {
        public EditCityPage()
        {
            InitializeComponent();
            DataContext = new EditCityViewModel();
        }
    }
}
