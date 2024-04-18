using System.Collections.Generic;

namespace PhoneCompany.ViewModel.EditorVM;

public abstract class AbonentViewModelBase : EditorPageViewModelBase
{
    public override bool HasErrors => string.IsNullOrWhiteSpace(PhoneNumber) || PhoneNumber!.Length != 11 || !PhoneNumber.StartsWith('7') ||
                                      string.IsNullOrWhiteSpace(Inn) || Inn!.Length != 10 || string.IsNullOrWhiteSpace(Address);

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

    protected static string MakePhoneNumberToFormat(string phoneNumber)
    {
        return $"+{phoneNumber[0]}({phoneNumber[1..4]}){phoneNumber[4..7]}-{phoneNumber[7..9]}-{phoneNumber[9..]}";
    }

    public override IEnumerable<string> GetErrors(string propertyName)
    {
        switch (propertyName)
        {
            case nameof(PhoneNumber):
            {
                if (string.IsNullOrWhiteSpace(PhoneNumber))
                {
                    yield return "Это поле обязательно";
                }
                else if (PhoneNumber!.Length != 11 || PhoneNumber![0] is not '7')
                {
                    yield return "Длина должна быть 11 символов и начинаться на 7";
                }

                break;
            }
            case nameof(Inn):
            {
                if (string.IsNullOrWhiteSpace(Inn))
                {
                    yield return "Это поле обязательно";
                }
                else if (Inn!.Length != 10)
                {
                    yield return "Длина должна быть 10 символов";
                }
                break;
            }
            case nameof(Address):
            {
                if (string.IsNullOrWhiteSpace(Address)) yield return "Это поле обязательно";
                break;
            }
        }
    }
}