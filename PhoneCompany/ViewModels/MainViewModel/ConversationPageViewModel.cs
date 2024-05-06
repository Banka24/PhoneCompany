using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using PhoneCompany.Models;
using PhoneCompany.Services;
using PhoneCompany.Services.InteractionDataBase;

namespace PhoneCompany.ViewModels.MainViewModel;

public class ConversationPageViewModel : PageViewModelBase
{
    public ConversationPageViewModel()
    {
        _ = GetPhoneNumberList();
    }

    public string PhoneNumber { get; set; }
    public ObservableCollection<Conversation> ConversationsList { get; set; } = [];
    public ObservableCollection<string> PhoneNumberList { get; set; } = [];

    private ICommand _findCommand;
    public ICommand FindCommand => _findCommand ??= new RelayCommand<Button>(GetFilteredList);

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

    private async void GetFilteredList(Button button)
    {
        if(string.IsNullOrWhiteSpace(PhoneNumber)) return;

        var service = new ConversationService(new CompanyDbContext());
        var conversationFilterList = await service.GetDataByPhoneNumberAsync(PhoneNumber);
        ConversationsList.Clear();
        foreach (var conversation in conversationFilterList)
        {
            conversation.Price = await SetPriceAsync(conversation);
            ConversationsList.Add(conversation);
        }
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
        var phoneNumbers = await service.GetPhoneNumbersAsync();

        foreach (var number in phoneNumbers)
        {
            PhoneNumberList.Add(number);
        }
    }
}