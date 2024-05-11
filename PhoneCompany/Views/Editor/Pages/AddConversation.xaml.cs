using System.Windows.Controls;
using PhoneCompany.ViewModels.EditorVM;

namespace PhoneCompany.Views.Editor.Pages;

/// <summary>
///     Логика взаимодействия для AddConversation.xaml
/// </summary>
public partial class AddConversation : Page
{
    public AddConversation()
    {
        InitializeComponent();
        DataContext = new AddConversationViewModel();
    }
}