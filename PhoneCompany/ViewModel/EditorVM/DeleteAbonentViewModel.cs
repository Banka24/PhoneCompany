using PhoneCompany.Services;
using System.Windows.Controls;
using System.Windows.Input;
using PhoneCompany.Services.InteractionDataBase;

namespace PhoneCompany.ViewModel.EditorVM;

internal class DeleteAbonentViewModel : AbonentViewModelBase
{
    private ICommand _deleteCommand;
    public ICommand DeleteCommand => _deleteCommand ??= new RelayCommand<Button>(DeleteAbonent);
    
    private async void DeleteAbonent(Button sender)
    {
        if (string.IsNullOrWhiteSpace(PhoneNumber) || PhoneNumber!.Length != 11 || !PhoneNumber.StartsWith("79"))
        {
            ErrorMessage = "Заполните поля правильно";
            return;
        }

        var service = new AbonentService(new CompanyDbContext());
        ErrorMessage = await service.DeleteAbonentAsync(MakePhoneNumberToFormat(PhoneNumber)) ? "Успешно" : "Неуспешно";
    }
}