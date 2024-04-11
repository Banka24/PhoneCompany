using System.Windows.Controls;
using PhoneCompany.ViewModel.EditorVM;

namespace PhoneCompany.View.Editor.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditConversation.xaml
    /// </summary>
    public partial class EditConversation : Page
    {
        public EditConversation()
        {
            InitializeComponent();
            DataContext = new EditConversationViewModel();
        }
    }
}
