using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using PhoneCompany.Models;
using PhoneCompany.Services;
using PhoneCompany.Services.InteractionDataBase;

namespace PhoneCompany.ViewModels.EditorVM;

public class EditAbonentViewModel : AbonentViewModelBase
{
    public EditAbonentViewModel()
    {
        GetPhoneNumbers();
    }

    private ICommand _findAbonentCommand;
    public ICommand FindAbonentCommand => _findAbonentCommand ??= new RelayCommand<Button>(FindCommand);

    private ICommand _editAbonentCommand;
    public ICommand EditAbonentCommand => _editAbonentCommand ??= new RelayCommand<Button>(EditCommand);

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

    private async void FindCommand(Button button)
    {
        if (PhoneNumber is null)
        {
            ErrorMessage = "Заполните поля правильно";
            return;
        }

        if (await FindAbonentAsync())
        {
            IsButtonEnable = true;
        }
    }

    private async Task<bool> FindAbonentAsync()
    {
        var service = new AbonentService(new CompanyDbContext());
        Abonent abonent;
        try
        {
            abonent = await service.FindAbonentAsync(PhoneNumber);
        }
        catch (Exception)
        {
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
        var phoneNumbers = await service.GetPhoneNumbersAsync();
        foreach (var phoneNumber in phoneNumbers)
        {
            PhoneNumberList.Add(phoneNumber);
        }
    }
}