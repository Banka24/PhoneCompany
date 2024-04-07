using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Controls;
using PhoneCompany.Model.Entities;
using PhoneCompany.Services;
using PhoneCompany.Services.InteractionDataBase;

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
        var service = new ConversationService(new CompanyDbContext());
        var conversations = await service.GetDataAsync();

        foreach (var conversation in conversations)
        {
            conversation.Price = await SetPriceAsync(conversation);
            ConversationsList.Add(conversation);
        }
    }

    public async Task<decimal> SetPriceAsync(Conversation conversation)
    {
        var service = new CityService(new CompanyDbContext());
        var tariff = await service.GetTariffAsync(conversation);
        return conversation.NumberOfMinutes * tariff;
    }

    protected override async void UpdatePageAsync(Button sender)
    {
        ConversationsList.Clear();
        await EnterDataListAsync();
    }
}