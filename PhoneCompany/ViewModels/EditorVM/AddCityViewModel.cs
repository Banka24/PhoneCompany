using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using PhoneCompany.Services;
using PhoneCompany.Services.InteractionDataBase;

namespace PhoneCompany.ViewModels.EditorVM;

public class AddCityViewModel : CityViewModelBase
{
    private ICommand _addCityCommand;
    public ICommand AddCityCommand => _addCityCommand ??= new RelayCommand<Button>(AddCity);

    public override IEnumerable<string> GetErrors(string propertyName)
    {
        switch (propertyName)
        {
            case nameof(Title):
            {
                if (string.IsNullOrWhiteSpace(Title))
                {
                    yield return "Это поле обязательно";
                }
                else if (Title!.Length < 2 || Title!.Length > 50)
                {
                    yield return "Длина должна быть от 2 до 50 символов";
                }
                else if (!char.IsUpper(Title[0]))
                {
                    yield return "Напишите город с большой буквы";
                }
                else if(Title.Any(c => !char.IsLetter(c)))
                {
                    yield return "В названии города допустимы только буквы";
                }
                break;
            }
            default:
            {
                foreach (var error in base.GetErrors(propertyName))
                {
                    yield return error;
                }
                break;
            }
        }
    }
    private async void AddCity(Button sender)
    {
        if (HasErrors)
        {
            ErrorMessage = "Заполните поля правильно";
            return;
        }

        var service = new CityService(new CompanyDbContext());
        if (await service.CheckIsNewCity(Title))
        {
            ErrorMessage = "Такой город уже есть";
            return;
        }

        await AddCityAsync(service);
    }
    private async Task AddCityAsync(CityService service)
    {
        ErrorMessage = await service.AddCityAsync(Title, TariffDay, TariffNight) ? "Успешно" : "Неуспешно";
    }
}