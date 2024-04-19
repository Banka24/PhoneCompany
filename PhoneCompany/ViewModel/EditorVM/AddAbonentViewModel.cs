using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using PhoneCompany.Services;
using PhoneCompany.Services.InteractionDataBase;

namespace PhoneCompany.ViewModel.EditorVM;

public class AddAbonentViewModel : AbonentViewModelBase
{
    private ICommand _addAbonentCommand;
    public ICommand AddAbonentCommand => _addAbonentCommand ??= new RelayCommand<Button>(AddAbonent);

    private async void AddAbonent(Button sender)
    {
        if (HasErrors)
        {
            ErrorMessage = "Заполните поля правильно";
            return;
        }

        await AddAbonentAsync();
    }

    private async Task AddAbonentAsync()
    {
        var service = new AbonentService(new CompanyDbContext());
        ErrorMessage = await service.AddAbonentAsync(MakePhoneNumberToFormat(PhoneNumber), Inn, Address) ? "Успешно" : "Неуспешно";
    }
}