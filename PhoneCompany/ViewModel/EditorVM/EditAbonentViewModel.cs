using System.Threading.Tasks;
using PhoneCompany.Services;
using System.Windows.Controls;
using System.Windows.Input;
using PhoneCompany.Services.InteractionDataBase;

namespace PhoneCompany.ViewModel.EditorVM;

public class EditAbonentViewModel : AbonentViewModelBase
{
    private ICommand _findAbonentCommand;
    public ICommand FindAbonentCommand => _findAbonentCommand ??= new RelayCommand<Button>(FindCommand);

    private ICommand _editAbonentCommand;
    public ICommand EditAbonentCommand => _editAbonentCommand ??= new RelayCommand<Button>(EditCommand);

    private async void FindCommand(Button button)
    {
        if (string.IsNullOrWhiteSpace(PhoneNumber) || PhoneNumber!.Length != 11 || !PhoneNumber.StartsWith("79"))
        {
            ErrorMessage = "Заполните поля правильно";
            return;
        }

        await FindAbonentAsync();
    }

    private async Task FindAbonentAsync()
    {
        var service = new AbonentService(new CompanyDbContext());
        var abonent = await service.GetAbonentAsync(MakePhoneNumberToFormat(PhoneNumber));
        Inn = abonent.Inn;
        Address = abonent.Address;
    }

    private async void EditCommand(Button button)
    {
        var service = new AbonentService(new CompanyDbContext());
        ErrorMessage = await service.EditAbonentAsync(MakePhoneNumberToFormat(PhoneNumber), Inn, Address) ? "Успешно" : "Неуспешно";
    }
}