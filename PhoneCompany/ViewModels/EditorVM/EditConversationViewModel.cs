using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using PhoneCompany.Models;
using PhoneCompany.Services.InteractionDataBase;

namespace PhoneCompany.ViewModels.EditorVM;

public class EditConversationViewModel : ConversationViewModelBase
{
    private ICommand _saveConversationCommand;
    public ICommand SaveConversationCommand => _saveConversationCommand ??= new Services.RelayCommand<Button>(SaveCommand);

    private ICommand _findConversationCommand;
    public ICommand FindConversationCommand => _findConversationCommand ??= new Services.RelayCommand<Button>(FindCommand);

    private bool _isButtonEnable;
    public bool IsButtonEnable
    {
        get => _isButtonEnable;
        set
        {
            _isButtonEnable = value;
            OnPropertyChanged();
        }
    }

    private async void FindCommand(Button button)
    {
        if (PhoneNumber is null || CityTitle is null)
        {
            ErrorMessage = "Заполните поля правильно";
            return;
        }

        IsButtonEnable = await FindConversationAsync();
    }

    private async Task<bool> FindConversationAsync()
    {
        var service = new ConversationService(new CompanyDbContext());
        Conversation conversation;
        try
        {
            conversation = await service.FindConversationAsync(PhoneNumber, CityTitle, MakeDateTimeToFormat());
        }
        catch (System.Exception e)
        {
            ErrorMessage = e.Message;
            return false;
        }

        NumberOfMinutes = conversation.NumberOfMinutes;

        return true;
    }

    private async void SaveCommand(Button button)
    {
        if (HasErrors)
        {
            ErrorMessage = "Заполните поля правильно";
            return;
        }

        await SaveConversationAsync();
    }
    
    private async Task SaveConversationAsync()
    {
        var service = new ConversationService(new CompanyDbContext());
        ErrorMessage = await service.EditConversationAsync(PhoneNumber, CityTitle, MakeDateTimeToFormat(), NumberOfMinutes, GetTimeOfDay()) ? "Успешно" : "Неуспешно";
    }
}