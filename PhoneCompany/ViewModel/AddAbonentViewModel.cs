using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PhoneCompany.ViewModel;

public class AddAbonentViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
{
    public bool HasErrors => !string.IsNullOrWhiteSpace(NumberPhone) || NumberPhone!.Length >= 3 && NumberPhone![..3] is not "+7(" || NumberPhone!.Length <= 16;

    public event PropertyChangedEventHandler PropertyChanged;
    public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

    private string _numberPhone = "+7(9__)___-__-__";

    public string NumberPhone
    {
        get => _numberPhone;
        set
        {
            _numberPhone = value;
            ValidateProperty();
            OnPropertyChanged();
        }
    }

    public IEnumerable GetErrors(string propertyName)
    {
        if (propertyName is nameof(NumberPhone))
        {
            if (string.IsNullOrWhiteSpace(NumberPhone))
            {
                yield return "Номер обязателен";
            }

            else if (NumberPhone!.Length >= 3 && NumberPhone![..3] is not "+7(")
            {
                yield return "Введен номер неверного формата";
            }

            else if (NumberPhone!.Length < 16)
            {
                yield return "Длина должна быть 11 символов";
            }
        }
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void ValidateProperty([CallerMemberName] string propertyName = null)
    {
        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
    }
}