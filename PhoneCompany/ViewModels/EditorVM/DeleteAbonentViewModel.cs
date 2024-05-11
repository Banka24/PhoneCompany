using System.Windows.Controls;
using PhoneCompany.Services.InteractionDataBase;

namespace PhoneCompany.ViewModels.EditorVM;

internal class DeleteAbonentViewModel : AbonentViewModelBase
{
    public DeleteAbonentViewModel()
    {
        GetPhoneNumbers();
    }

    private System.Windows.Input.ICommand _deleteCommand;
    public System.Windows.Input.ICommand DeleteCommand => _deleteCommand ??= new Services.RelayCommand<Button>(DeleteAbonent);

    private System.Collections.ObjectModel.ObservableCollection<string> _phoneNumberList = [];
    public System.Collections.ObjectModel.ObservableCollection<string> PhoneNumberList
    {
        get => _phoneNumberList;
        set
        {
            _phoneNumberList = value;
            OnPropertyChanged();
        }
    }
    
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

    private async void GetPhoneNumbers()
    {
        var service = new AbonentService(new CompanyDbContext());
        await FillComboBox(PhoneNumberList, await service.GetPhoneNumbersAsync());
    }
}