﻿using System.Linq;
using System.Collections.Generic;

namespace PhoneCompany.ViewModels.EditorVM;

/// <summary>
/// Базовый класс для всех ViewModel связанных с редактированием абонента
/// </summary>
public abstract class AbonentViewModelBase : EditorPageViewModelBase
{
    public override bool HasErrors => string.IsNullOrWhiteSpace(PhoneNumber) || PhoneNumber!.Length != 11 || !PhoneNumber.StartsWith('7') ||
                                      string.IsNullOrWhiteSpace(Inn) || Inn!.Length != 13 || string.IsNullOrWhiteSpace(Address) || Inn.Any(c => !char.IsDigit(c));
    
    private string _phoneNumber = "7";
    public string PhoneNumber
    {
        get => _phoneNumber;
        set
        {
            _phoneNumber = value;
            ValidateProperty();
            OnPropertyChanged();
        }
    }

    private string _inn;
    public string Inn
    {
        get => _inn;
        set
        {
            _inn = value;
            ValidateProperty();
            OnPropertyChanged();
        }
    }

    private string _address;
    public string Address
    {
        get => _address;
        set
        {
            _address = value;
            ValidateProperty();
            OnPropertyChanged();
        }
    }

    public override IEnumerable<string> GetErrors(string propertyName)
    {
        switch (propertyName)
        {
            case nameof(Inn):
            {
                if (string.IsNullOrWhiteSpace(Inn))
                {
                    yield return "Это поле обязательно";
                }
                else if (Inn!.Length != 13)
                {
                    yield return "Длина должна быть 13 символов";
                }
                else if (Inn.Any(c => !char.IsDigit(c)))
                {
                    yield return "В ИНН должны быть только цифры";
                }
                break;
            }
            case nameof(Address):
            {
                if (string.IsNullOrWhiteSpace(Address))
                {
                    yield return "Это поле обязательно";
                }
                break;
            }
        }
    }
}