using PhoneCompany.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using PhoneCompany.Services.InteractionDataBase;

namespace PhoneCompany.ViewModel.EditorVM;

public class AddCityViewModel : EditorPageViewModelBase
{
    public override bool HasErrors => string.IsNullOrWhiteSpace(Title) || Title!.Length < 2 || Title!.Length > 50 || !char.IsUpper(Title[0]) ||
                                      !decimal.TryParse(TariffDay, out var priceDay) || priceDay < 0 || !decimal.TryParse(TariffNight, out var price) || price < 0;

    private string _title;

    public string Title
    {
        get => _title;
        set
        {
            _title = value;
            ValidateProperty();
            OnPropertyChanged();
        }
    }

    private string _tariffDay;

    public string TariffDay
    {
        get => _tariffDay;
        set
        {
            _tariffDay = value;
            ValidateProperty();
            OnPropertyChanged();
        }
    }

    private string _tariffNight;

    public string TariffNight
    {
        get => _tariffNight;
        set
        {
            _tariffNight = value;
            ValidateProperty();
            OnPropertyChanged();
        }
    }

    private ICommand _addCityCommand;
    public ICommand AddCityCommand => _addCityCommand ??= new RelayCommand<Button>(AddAbonent);

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
                break;
            }
            case nameof(TariffDay):
            {
                if (!decimal.TryParse(TariffDay, out var price) || price < 0) yield return "Напишите число больше 0";
                break;
            }
            case nameof(TariffNight):
            {
                if (!decimal.TryParse(TariffNight, out var price) || price < 0) yield return "Напишите число больше 0";
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
        var service = new CityService(new CompanyDbContext());
        ErrorMessage = await service.AddCityAsync(Title, decimal.Parse(TariffDay), decimal.Parse(TariffNight)) ? "Успешно" : "Неуспешно";
    }
}