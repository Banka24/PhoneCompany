using System.Windows.Controls;
using PhoneCompany.ViewModel.EditorVM;

namespace PhoneCompany.View.Editor.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditAbonentPage.xaml
    /// </summary>
    public partial class EditAbonentPage : Page
    {
        public EditAbonentPage()
        {
            InitializeComponent();
            DataContext = new EditAbonentViewModel();
        }
    }
}
