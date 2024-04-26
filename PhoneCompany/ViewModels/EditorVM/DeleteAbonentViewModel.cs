using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using PhoneCompany.Services;
using PhoneCompany.Services.InteractionDataBase;

namespace PhoneCompany.ViewModels.EditorVM;

internal class DeleteAbonentViewModel : AbonentViewModelBase
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

    public DeleteAbonentViewModel()
    {
        GetPhoneNumbers();
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