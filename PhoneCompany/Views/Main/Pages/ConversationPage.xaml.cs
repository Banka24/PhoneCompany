using PhoneCompany.ViewModels.MainViewModel;

namespace PhoneCompany.Views.Main.Pages;

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