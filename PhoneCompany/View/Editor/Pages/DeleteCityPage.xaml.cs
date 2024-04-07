using System.Windows.Controls;
using PhoneCompany.ViewModel.EditorVM;

namespace PhoneCompany.View.Editor.Pages
{
    /// <summary>
    /// Логика взаимодействия для DeleteCityPage.xaml
    /// </summary>
    public partial class DeleteCityPage : Page
    {
        public DeleteCityPage()
        {
            InitializeComponent();
            DataContext = new DeleteCityViewModel();
        }
    }
}
