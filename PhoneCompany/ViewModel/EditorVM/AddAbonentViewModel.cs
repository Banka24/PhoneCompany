using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using PhoneCompany.Services;
using PhoneCompany.Services.InteractionDataBase;

namespace PhoneCompany.ViewModel.EditorVM;

public class AddAbonentViewModel : AbonentViewModelBase
{
    private ICommand _addAbonentCommand;
    public ICommand AddAbonentCommand => _addAbonentCommand ??= new RelayCommand<Button>(AddAbonent);

    private async void AddAbonent(Button sender)
    {
        if (HasErrors)
        {
            ErrorMessage = "Заполните поля правильно";
            return;
        }

        await AddAbonentAsync();
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
            default:
                base.GetErrors(propertyName);
                break;
        }
    }

    private async Task AddAbonentAsync()
    {
        var service = new AbonentService(new CompanyDbContext());
        ErrorMessage = await service.AddAbonentAsync(MakePhoneNumberToFormat(PhoneNumber), Inn, Address) ? "Успешно" : "Неуспешно";
    }
    private static string MakePhoneNumberToFormat(string phoneNumber)
    {
        return $"+{phoneNumber[0]}({phoneNumber[1..4]}){phoneNumber[4..7]}-{phoneNumber[7..9]}-{phoneNumber[9..]}";
    }
}