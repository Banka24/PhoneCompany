using System.Windows.Controls;
using PhoneCompany.ViewModel.EditorVM;

namespace PhoneCompany.View.Editor.Pages
{
    /// <summary>
    /// Логика взаимодействия для DeleteConversation.xaml
    /// </summary>
    public partial class DeleteConversation : Page
    {
        public DeleteConversation()
        {
            InitializeComponent();
            DataContext = new DeleteConversationViewModel();
        }
    }
}
