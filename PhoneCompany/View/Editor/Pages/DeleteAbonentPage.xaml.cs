using System.Windows.Controls;
using PhoneCompany.ViewModel.EditorVM;

namespace PhoneCompany.View.Editor.Pages
{
    /// <summary>
    /// Логика взаимодействия для DeleteAbonentPage.xaml
    /// </summary>
    public partial class DeleteAbonentPage : Page
    {
        public DeleteAbonentPage()
        {
            InitializeComponent();
            DataContext = new DeleteAbonentViewModel();
        }
    }
}
