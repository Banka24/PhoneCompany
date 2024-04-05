using PhoneCompany.ViewModel.EditorVM;

namespace PhoneCompany.View.Editor.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddAbonentPage.xaml
    /// </summary>
    public partial class AddAbonentPage
    {
        public AddAbonentPage()
        {
            InitializeComponent();
            DataContext = new AddAbonentViewModel();
        }
    }
}
