using System.Collections.Generic;

namespace PhoneCompany.ViewModel.EditorVM;

public class CityViewModelBase : EditorPageViewModelBase
{
    public override bool HasErrors => string.IsNullOrWhiteSpace(Title) || Title!.Length < 2 || Title!.Length > 50 || !char.IsUpper(Title[0]) || TariffDay < 0 || TariffNight < 0;

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

    private decimal _tariffDay;

    public decimal TariffDay
    {
        get => _tariffDay;
        set
        {
            _tariffDay = value;
            ValidateProperty();
            OnPropertyChanged();
        }
    }

    private decimal _tariffNight;

    public decimal TariffNight
    {
        get => _tariffNight;
        set
        {
            _tariffNight = value;
            ValidateProperty();
            OnPropertyChanged();
        }
    }
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
                if (TariffDay < 0) yield return "Напишите число больше 0";
                break;
            }
            case nameof(TariffNight):
            {
                if (TariffNight < 0) yield return "Напишите число больше 0";
                break;
            }
        }
    }
}