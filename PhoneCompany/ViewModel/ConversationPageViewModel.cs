using System.Collections.ObjectModel;
using System.Threading.Tasks;
using PhoneCompany.Model.Entities;
using PhoneCompany.Services;

namespace PhoneCompany.ViewModel;

public class ConversationPageViewModel : PageViewModelBase
{
    public ObservableCollection<Conversation> ConversationsList { get; set; } = [];

    public ConversationPageViewModel()
    {
        EnterDataListAsync();
    }

    protected override async Task EnterDataListAsync()
    {
        var conversationService = new ConversationService();
        var conversations = await conversationService.GetDataAsync();

        foreach (var conversation in conversations)
        {
            conversation.Price = await SetPriceAsync(conversation);
            ConversationsList.Add(conversation);
        }
    }

    public static async Task<decimal> SetPriceAsync(Conversation conversation)
    {
        var cityService = new CityService();
        var tariff = await cityService.GetTariffAsync(conversation);
        return conversation.NumberOfMinutes * tariff;
    }

    protected override async void UpdatePageAsync(object sender)
    {
        ConversationsList.Clear();
        await EnterDataListAsync();
    }
}