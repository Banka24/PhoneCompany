﻿using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using PhoneCompany.Services;
using PhoneCompany.Services.InteractionDataBase;

namespace PhoneCompany.ViewModels.EditorVM;

public class EditConversationViewModel : ConversationViewModelBase
{
    private ICommand _saveConversationCommand;
    public ICommand SaveConversationCommand => _saveConversationCommand ??= new RelayCommand<Button>(SaveCommand);
    
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