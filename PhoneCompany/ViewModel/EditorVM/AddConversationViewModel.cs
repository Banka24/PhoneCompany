using System.Collections.Generic;
using PhoneCompany.Services.InteractionDataBase;
using PhoneCompany.Services;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace PhoneCompany.ViewModel.EditorVM;

public class AddConversationViewModel : ConversationViewModelBase
{
    public IEnumerable<string> TimeOfDayList { get; set; } = ["День", "Ночь"];
    private ICommand _addConversationCommand;
    public ICommand AddConversationCommand => _addConversationCommand ??= new RelayCommand<Button>(AddConversation);

    private async void AddConversation(Button sender)
    {
        if (HasErrors)
        {
            ErrorMessage = "Заполните поля правильно";
            return;
        }

        await AddConversationAsync();
    }

    //public as

    private async Task AddConversationAsync()
    {
        var service = new ConversationService(new CompanyDbContext());
        ErrorMessage = await service.AddConversationAsync(PhoneNumber, CityTitle, MakeDateTimeToFormat(), NumberOfMinutes, TimeOfDay) ? "Успешно" : "Неуспешно";
    }
}