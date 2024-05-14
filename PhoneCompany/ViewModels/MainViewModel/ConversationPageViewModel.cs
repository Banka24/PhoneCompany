using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Controls;
using PhoneCompany.Models;
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

    protected override async Task EnterDataListAsync()
    {
        var service = new ConversationService(new CompanyDbContext());
        await FillDataGridAsync(await service.GetDataAsync());
    }

    protected override async void UpdateDataGridAsync(Button sender)
    {
        ConversationsList.Clear();
        await EnterDataListAsync();
    }

    protected override async void GetFilteredList(Button button)
    {
        if (string.IsNullOrWhiteSpace(PhoneNumber)) return;

        var service = new ConversationService(new CompanyDbContext());
        ConversationsList.Clear();
        await FillDataGrid(ConversationsList, await service.GetDataByPhoneNumberAsync(PhoneNumber));
    }

    private async Task FillDataGridAsync(IEnumerable<Conversation> conversations)
    {
        foreach (var conversation in conversations)
        {
            conversation.Price = await SetPriceAsync(conversation);
            ConversationsList.Add(conversation);
        }
    }

    private static async Task<decimal> SetPriceAsync(Conversation conversation)
    {
        var service = new CityService(new CompanyDbContext());
        return conversation.NumberOfMinutes * await service.GetTariffAsync(conversation);
    }

    private async Task GetPhoneNumberList()
    {
        var service = new AbonentService(new CompanyDbContext());
        await FillDataGrid(PhoneNumberList, await service.GetPhoneNumbersAsync());
    }
}