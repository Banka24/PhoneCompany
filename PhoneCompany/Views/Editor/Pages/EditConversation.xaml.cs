using System.Windows.Controls;
using PhoneCompany.ViewModels.EditorVM;

namespace PhoneCompany.Views.Editor.Pages
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
