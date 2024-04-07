using PhoneCompany.Services.InteractionDataBase;

namespace PhoneCompany.ViewModel;

public abstract class ViewModelBase
{
    protected readonly AbonentService AbonentService = new();
    protected readonly CityService CityService = new();
    protected readonly ConversationService ConversationService = new();
}