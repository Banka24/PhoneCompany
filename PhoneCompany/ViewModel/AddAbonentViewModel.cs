using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using PhoneCompany.Services;

namespace PhoneCompany.ViewModel;

public class AddAbonentViewModel : EditorPageViewModelBase
{
    public override bool HasErrors => string.IsNullOrWhiteSpace(NumberPhone) || NumberPhone!.Length != 11 || !NumberPhone.StartsWith('7') ||
                                      string.IsNullOrWhiteSpace(Inn) || Inn!.Length != 10 || string.IsNullOrWhiteSpace(Address);

    private string _numberPhone = "79";
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

    private string _errorMessage;

    public string ErrorMessage
    {
        get => _errorMessage;
        set
        {
            _errorMessage = value;
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

    private ICommand _addAbonentCommand;
    public ICommand AddAbonentCommand => _addAbonentCommand ??= new RelayCommand<Button>(AddAbonent);

    public override IEnumerable<string> GetErrors(string propertyName)
    {
        if (propertyName is nameof(NumberPhone))
        {
            if (string.IsNullOrWhiteSpace(NumberPhone))
            {
                yield return "Это поле обязательно";
            }

            else if (NumberPhone!.Length != 11 || NumberPhone![0] is not '7')
            {
                yield return "Длина должна быть 11 символов и начинаться на 7";
            }

        }
        else if (propertyName is nameof(Inn))
        {
            if (string.IsNullOrWhiteSpace(Inn))
            {
                yield return "Это поле обязательно";
            }
            else if (Inn!.Length != 10)
            {
                yield return "Длина должна быть 10 символов";
            }
        }
        else if (propertyName is nameof(Address))
        {
            if (string.IsNullOrWhiteSpace(Address))
            {
                yield return "Это поле обязательно";
            }
        }
    }

    private async void AddAbonent(Button sender)
    {
        if (HasErrors)
        {
            ErrorMessage = "Заполните поля правильно";
            return;
        }
        await AddAbonentAsync();
    }

    private async Task AddAbonentAsync()
    {
        NumberPhone = $"+{NumberPhone[0]}({NumberPhone[1..4]}){NumberPhone[4..7]}-{NumberPhone[7..9]}-{NumberPhone[9..]}";
        ErrorMessage = await AbonentService.AddAbonent(NumberPhone, Inn, Address) ? "Успешно" : "Неуспешно";
    }
}