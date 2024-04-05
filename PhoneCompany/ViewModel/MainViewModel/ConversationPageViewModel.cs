using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Controls;
using PhoneCompany.Model.Entities;

namespace PhoneCompany.ViewModel.MainViewModel;

public class ConversationPageViewModel : PageViewModelBase
{
    public ObservableCollection<Conversation> ConversationsList { get; set; } = [];

    public ConversationPageViewModel()
    {
        EnterDataListAsync();
    }

    protected override async Task EnterDataListAsync()
    {
        var conversations = await ConversationService.GetDataAsync();

        foreach (var conversation in conversations)
        {
            conversation.Price = await SetPriceAsync(conversation);
            ConversationsList.Add(conversation);
        }
    }

    public async Task<decimal> SetPriceAsync(Conversation conversation)
    {
        var tariff = await CityService.GetTariffAsync(conversation);
        return conversation.NumberOfMinutes * tariff;
    }

    protected override async void UpdatePageAsync(Button sender)
    {
        ConversationsList.Clear();
        await EnterDataListAsync();
    }
}