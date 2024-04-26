using System.Windows.Controls;
using PhoneCompany.ViewModels.EditorVM;

namespace PhoneCompany.Views.Editor.Pages
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
