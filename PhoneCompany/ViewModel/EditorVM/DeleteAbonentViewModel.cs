using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneCompany.Services;
using System.Windows.Controls;
using System.Windows.Input;
using PhoneCompany.Services.InteractionDataBase;

namespace PhoneCompany.ViewModel.EditorVM;

internal class DeleteAbonentViewModel : AbonentViewModelBase
{
    public IEnumerable<string> PhoneNumberList { get; set; } = [];

    public DeleteAbonentViewModel()
    {
        Initial();
    }

    private async void Initial()
    {
        PhoneNumberList = await GetPhoneNumbers();
    }

    private static async Task<IEnumerable<string>> GetPhoneNumbers()
    {
        var service = new AbonentService(new CompanyDbContext());
        return await service.GetPhoneNumbersAsync();
    }

    private ICommand _deleteCommand;
    public ICommand DeleteCommand => _deleteCommand ??= new RelayCommand<Button>(DeleteAbonent);

    private async void DeleteAbonent(Button sender)
    {
        if (PhoneNumber is null)
        {
            ErrorMessage = "Заполните поля правильно";
            return;
        }

        var service = new AbonentService(new CompanyDbContext());
        ErrorMessage = await service.DeleteAbonentAsync(PhoneNumber) ? "Успешно" : "Неуспешно";
    }
}