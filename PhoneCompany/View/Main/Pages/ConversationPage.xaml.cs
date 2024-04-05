using PhoneCompany.ViewModel.MainViewModel;

namespace PhoneCompany.View.Main.Pages;

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