using PhoneCompany.ViewModel;

namespace PhoneCompany.View.Pages;

/// <summary>
///     Логика взаимодействия для ConversationPage.xaml
/// </summary>
public partial class ConversationPage
{
    public ConversationPage()
    {
        InitializeComponent();
        DataContext = new ConversationPageViewModel();
    }
}