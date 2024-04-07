using PhoneCompany.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using PhoneCompany.Services.InteractionDataBase;

namespace PhoneCompany.ViewModel.EditorVM;

internal class DeleteAbonentViewModel : EditorPageViewModelBase
{
    public override bool HasErrors => string.IsNullOrWhiteSpace(NumberPhone) || NumberPhone!.Length != 16 || !NumberPhone.StartsWith("+7(9") || NumberPhone[6] is not ')' ||
                                      NumberPhone[10] is not '-' || NumberPhone[13] is not '-';
    private string _numberPhone = string.Empty;
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

    private ICommand _deleteCommand;
    public ICommand DeleteCommand => _deleteCommand ??= new RelayCommand<Button>(DeleteAbonent);
    public override IEnumerable<string> GetErrors(string propertyName)
    {
        if (propertyName is not nameof(NumberPhone)) yield break;
        if (string.IsNullOrWhiteSpace(NumberPhone))
        {
            yield return "Это обязательное поле";
        }
        else if(NumberPhone!.Length != 16)
        {
            yield return "Длина должна быть 16 символов";
        }
        else if(!NumberPhone.StartsWith("+7(9") || NumberPhone[6] is not ')' || NumberPhone[10] is not '-' || NumberPhone[13] is not '-')
        {
            yield return "Введён неверный формат";
        }
    }

    private async void DeleteAbonent(Button sender)
    {
        if (HasErrors)
        {
            ErrorMessage = "Заполните поля правильно";
            return;
        }

        await DeleteAbonentAsync();
    }

    private async Task DeleteAbonentAsync()
    {
        var service = new AbonentService(new CompanyDbContext());
        ErrorMessage = await service.DeleteAbonentAsync(NumberPhone) ? "Успешно" : "Неуспешно";
    }
}