using System.Windows.Controls;
using PhoneCompany.ViewModel.EditorVM;

namespace PhoneCompany.View.Editor.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddConversation.xaml
    /// </summary>
    public partial class AddConversation : Page
    {
        public AddConversation()
        {
            InitializeComponent();
            DataContext = new AddConversationViewModel();
        }
    }
}
