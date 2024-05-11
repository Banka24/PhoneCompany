using System.Threading.Tasks;
using System.Windows.Controls;
using PhoneCompany.Services.InteractionDataBase;

namespace PhoneCompany.ViewModels.EditorVM;

public class DeleteConversationViewModel : ConversationViewModelBase
{
    private System.Windows.Input.ICommand _saveConversationCommand;
    public System.Windows.Input.ICommand SaveConversationCommand => _saveConversationCommand ??= new Services.RelayCommand<Button>(DeleteCommand);

    private async void DeleteCommand(Button button)
    {
        if (HasErrors)
        {
            ErrorMessage = "Заполните поля правильно";
            return;
        }

        await DeleteConversationAsync();
    }

    private async Task DeleteConversationAsync()
    {
        var service = new ConversationService(new CompanyDbContext());
        ErrorMessage = await service.DeleteConversationAsync(PhoneNumber, CityTitle, MakeDateTimeToFormat()) ? "Успешно" : "Неуспешно";
    }
}