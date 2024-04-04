using PhoneCompany.ViewModel;

namespace PhoneCompany.View.Pages
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
