using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using PhoneCompany.Services;
using PhoneCompany.Services.InteractionDataBase;

namespace PhoneCompany.ViewModels.EditorVM;

public class AddAbonentViewModel : AbonentViewModelBase
{
    private ICommand _addAbonentCommand;
    public ICommand AddAbonentCommand => _addAbonentCommand ??= new RelayCommand<Button>(AddAbonent);

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
                else if (PhoneNumber.Any(c => !char.IsDigit(c)))
                {
                    yield return "В номере должны быть только цифры";
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
        var service = new AbonentService(new CompanyDbContext());
        ErrorMessage = await service.AddAbonentAsync(MakePhoneNumberToFormat(PhoneNumber), Inn, Address) ? "Успешно" : "Неуспешно";
    }
    private static string MakePhoneNumberToFormat(string phoneNumber)
    {
        return $"+{phoneNumber[0]}({phoneNumber[1..4]}){phoneNumber[4..7]}-{phoneNumber[7..9]}-{phoneNumber[9..]}";
    }
}