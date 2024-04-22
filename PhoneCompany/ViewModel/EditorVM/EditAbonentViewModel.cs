using System.Threading.Tasks;
using PhoneCompany.Services;
using System.Windows.Controls;
using System.Windows.Input;
using PhoneCompany.Services.InteractionDataBase;
using System.Collections.ObjectModel;

namespace PhoneCompany.ViewModel.EditorVM;

public class EditAbonentViewModel : AbonentViewModelBase
{
    private ObservableCollection<string> _phoneNumberList = [];
    public ObservableCollection<string> PhoneNumberList
    {
        get => _phoneNumberList;
        set
        {
            _phoneNumberList = value;
            OnPropertyChanged();
        }
    }

    public EditAbonentViewModel()
    {
        GetPhoneNumbers();
    }

    private ICommand _findAbonentCommand;
    public ICommand FindAbonentCommand => _findAbonentCommand ??= new RelayCommand<Button>(FindCommand);

    private ICommand _editAbonentCommand;
    public ICommand EditAbonentCommand => _editAbonentCommand ??= new RelayCommand<Button>(EditCommand);

    private async void FindCommand(Button button)
    {
        if (PhoneNumber is null)
        {
            ErrorMessage = "Заполните поля правильно";
            return;
        }

        await FindAbonentAsync();
    }

    private async Task FindAbonentAsync()
    {
        var service = new AbonentService(new CompanyDbContext());
        var abonent = await service.GetAbonentAsync(PhoneNumber);
        Inn = abonent.Inn;
        Address = abonent.Address;
    }

    private async void EditCommand(Button button)
    {
        var service = new AbonentService(new CompanyDbContext());
        ErrorMessage = await service.EditAbonentAsync(PhoneNumber, Inn, Address) ? "Успешно" : "Неуспешно";
    }
    private async void GetPhoneNumbers()
    {
        var service = new AbonentService(new CompanyDbContext());
        var phoneNumbers = await service.GetPhoneNumbersAsync();
        foreach (var phoneNumber in phoneNumbers)
        {
            PhoneNumberList.Add(phoneNumber);
        }
    }
}