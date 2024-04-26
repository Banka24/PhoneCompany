using System.Windows.Controls;
using PhoneCompany.ViewModels.EditorVM;

namespace PhoneCompany.Views.Editor.Pages
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
