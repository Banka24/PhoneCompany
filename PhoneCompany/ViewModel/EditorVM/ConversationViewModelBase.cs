using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneCompany.Services.InteractionDataBase;

namespace PhoneCompany.ViewModel.EditorVM;

public class ConversationViewModelBase : EditorPageViewModelBase
{
    public override bool HasErrors => NumberOfMinutes < 0 || Time < TimeOnly.MinValue;

    public IEnumerable<string> PhoneNumberList { get; set; } = [];
    public IEnumerable<string> CityTitleList { get; set; } = [];
    public IEnumerable<string> TimeOfDayList { get; set; } = ["День", "Ночь"];

    public ConversationViewModelBase()
    {
        Initial();
    }

    private async void Initial()
    {
        PhoneNumberList = await GetPhoneNumbersAsync();
        CityTitleList = await GetCityTitleAsync();
    }

    private static async Task<IEnumerable<string>> GetPhoneNumbersAsync()
    {
        var service = new AbonentService(new CompanyDbContext());
        return await service.GetPhoneNumbersAsync();
    }

    private static async Task<IEnumerable<string>> GetCityTitleAsync()
    {
        var service = new CityService(new CompanyDbContext());
        return await service.GetCityTitleAsync();
    }

    private string _phoneNumber = "79";
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

    private string _cityTitle;

    public string CityTitle
    {
        get => _cityTitle;
        set
        {
            _cityTitle = value;
            ValidateProperty();
            OnPropertyChanged();
        }
    }

    private DateTime _date = DateTime.Now;

    public DateTime Date
    {
        get => _date;
        set
        {
            _date = value;
            ValidateProperty();
            OnPropertyChanged();
        }
    }

    private TimeOnly _time;

    public TimeOnly Time
    {
        get => _time;
        set
        {
            _time = value;
            ValidateProperty();
            OnPropertyChanged();
        }
    }

    private int _numberOfMinutes;

    public int NumberOfMinutes
    {
        get => _numberOfMinutes;
        set
        {
            _numberOfMinutes = value;
            ValidateProperty();
            OnPropertyChanged();
        }
    }

    private string _timeOfDay;

    public string TimeOfDay
    {
        get => _timeOfDay;
        set
        {
            _timeOfDay = value;
            ValidateProperty();
            OnPropertyChanged();
        }
    }

    protected DateTime MakeDateTimeToFormat()
    {
        return DateTime.Parse($"{Date:dd.MM.yyyy} {Time}");
    }

    public override IEnumerable<string> GetErrors(string propertyName)
    {
        if (propertyName is nameof(NumberOfMinutes) && NumberOfMinutes < 0)
        {
            yield return "Вызов не может длиться меньше 0 минут";
        }

        else if (propertyName is nameof(Time) && Time < TimeOnly.MinValue)
        {
            yield return "Проверьте данн";
        }
    }
}