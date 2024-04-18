using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using PhoneCompany.Model.Entities;
using PhoneCompany.Services;
using PhoneCompany.Services.InteractionDataBase;

namespace PhoneCompany.ViewModel.MainViewModel;

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

    private ICommand _findCommand;
    public ICommand FindCommand => _findCommand ??= new RelayCommand<Button>(GetFilteredList);

    private async void GetFilteredList(Button button)
    {
        var service = new ConversationService(new CompanyDbContext());
        var conversationFilterList = await service.GetDataAsync(PhoneNumber);
        ConversationsList.Clear();
        foreach (var conversation in conversationFilterList)
        {
            conversation.Price = await SetPriceAsync(conversation);
            ConversationsList.Add(conversation);
        }
    }

    private async Task GetPhoneNumberList()
    {
        var service = new AbonentService(new CompanyDbContext());
        PhoneNumberList = await service.GetPhoneNumbersAsync();
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

    public static async Task<decimal> SetPriceAsync(Conversation conversation)
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