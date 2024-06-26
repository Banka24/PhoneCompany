﻿using System.Windows.Controls;
using System.Windows.Input;
using System.Collections.ObjectModel;
using PhoneCompany.Services.InteractionDataBase;

namespace PhoneCompany.ViewModels.EditorVM;

public class DeleteAbonentViewModel : AbonentViewModelBase
{
    public DeleteAbonentViewModel()
    {
        GetPhoneNumbers();
    }

    private ICommand _deleteCommand;
    public ICommand DeleteCommand => _deleteCommand ??= new Services.RelayCommand<Button>(DeleteAbonent);

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