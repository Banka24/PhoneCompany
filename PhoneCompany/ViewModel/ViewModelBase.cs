using PhoneCompany.Services.InteractionDataBase;

namespace PhoneCompany.ViewModel;

public abstract class ViewModelBase
{
    protected readonly IAbonentService AbonentService = new AbonentService();
    protected readonly ICityService CityService = new CityService();
    protected readonly IConversationService ConversationService = new ConversationService();
}