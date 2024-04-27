using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Controls;
using PhoneCompany.Models;
using PhoneCompany.Services.InteractionDataBase;

namespace PhoneCompany.ViewModels.MainViewModel;

public class ConversationPageViewModel : PageViewModelBase
{
    public string PhoneNumber { get; set; }
    public ObservableCollection<Conversation> ConversationsList { get; set; } = [];
    public IEnumerable<string> PhoneNumberList { get; set; } = [];

    public ConversationPageViewModel()
    {
        EnterDataListAsync();
        GetPhoneNumberList();
    }

    protected override async Task EnterDataListAsync()
    {
        var service = new ConversationService(new CompanyDbContext());
        var conversations = await service.GetDataAsync();

        foreach (var conversation in conversations)
        {
            conversation.Price = await SetPriceAsync(conversation);
            ConversationsList.Add(conversation);
        }
    }

    protected override async void UpdatePageAsync(Button sender)
    {
        ConversationsList.Clear();
        await EnterDataListAsync();
    }

    private static async Task<decimal> SetPriceAsync(Conversation conversation)
    {
        var service = new CityService(new CompanyDbContext());
        var tariff = await service.GetTariffAsync(conversation);
        return conversation.NumberOfMinutes * tariff;
    }
    private async Task GetPhoneNumberList()
    {
        var service = new AbonentService(new CompanyDbContext());
        PhoneNumberList = await service.GetPhoneNumbersAsync();
    }
}