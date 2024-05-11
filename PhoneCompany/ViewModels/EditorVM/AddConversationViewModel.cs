using System.Threading.Tasks;
using System.Windows.Controls;
using PhoneCompany.Services.InteractionDataBase;

namespace PhoneCompany.ViewModels.EditorVM;

public class AddConversationViewModel : ConversationViewModelBase
{
    private System.Windows.Input.ICommand _addConversationCommand;
    public System.Windows.Input.ICommand AddConversationCommand => _addConversationCommand ??= new Services.RelayCommand<Button>(AddConversation);

    private async void AddConversation(Button sender)
    {
        if (HasErrors)
        {
            ErrorMessage = "Заполните поля правильно";
            return;
        }

        await AddConversationAsync();
    }

    private async Task AddConversationAsync()
    {
        var service = new ConversationService(new CompanyDbContext());
        ErrorMessage = await service.AddConversationAsync(PhoneNumber, CityTitle, MakeDateTimeToFormat(), NumberOfMinutes, GetTimeOfDay()) ? "Успешно" : "Неуспешно";
    }
}