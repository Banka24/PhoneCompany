using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using PhoneCompany.Services.InteractionDataBase;

namespace PhoneCompany.ViewModels.EditorVM;

public class EditAbonentViewModel : AbonentViewModelBase
{
    public EditAbonentViewModel()
    {
        GetPhoneNumbers();
    }

    private ICommand _findAbonentCommand;
    public ICommand FindAbonentCommand => _findAbonentCommand ??= new Services.RelayCommand<Button>(FindCommand);

    private ICommand _editAbonentCommand;
    public ICommand EditAbonentCommand => _editAbonentCommand ??= new Services.RelayCommand<Button>(EditCommand);

    private bool _isButtonEnable;
    public bool IsButtonEnable
    {
        get => _isButtonEnable;
        set
        {
            _isButtonEnable = value;
            OnPropertyChanged();
        }
    }

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

    private async void FindCommand(Button button)
    {
        if (PhoneNumber is null)
        {
            ErrorMessage = "Заполните поля правильно";
            return;
        }

        IsButtonEnable = await FindAbonentAsync();
    }

    private async Task<bool> FindAbonentAsync()
    {
        var service = new AbonentService(new CompanyDbContext());
        Models.Abonent abonent;
        try
        {
            abonent = await service.FindAbonentAsync(PhoneNumber);
        }
        catch (System.Exception e)
        {
            ErrorMessage = e.Message;
            return false;
        }

        Inn = abonent.Inn;
        Address = abonent.Address;

        return true;
    }

    private async void EditCommand(Button button)
    {
        var service = new AbonentService(new CompanyDbContext());
        ErrorMessage = await service.EditAbonentAsync(PhoneNumber, Inn, Address) ? "Успешно" : "Неуспешно";
    }

    private async void GetPhoneNumbers()
    {
        var service = new AbonentService(new CompanyDbContext());
        await FillComboBox(PhoneNumberList, await service.GetPhoneNumbersAsync());
    }
}