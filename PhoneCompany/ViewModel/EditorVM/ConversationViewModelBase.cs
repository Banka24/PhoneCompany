using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneCompany.Model.Entities;
using PhoneCompany.Services.InteractionDataBase;

namespace PhoneCompany.ViewModel.EditorVM;

public class ConversationViewModelBase : EditorPageViewModelBase
{
    //public override bool HasErrors => string.IsNullOrWhiteSpace(PhoneNumber) || PhoneNumber!.Length != 11 || !PhoneNumber.StartsWith("79");
    //                                   string.IsNullOrWhiteSpace(Inn) || Inn!.Length != 10 || string.IsNullOrWhiteSpace(Address);

    public IEnumerable<string> PhoneNumberList { get; set; } = [];
    public IEnumerable<string> CityTitleList { get; set; } = [];

    public ConversationViewModelBase()
    {
        Initial();
    }

    private async void Initial()
    {
        PhoneNumberList = await GetPhoneNumbersAsync();
        CityTitleList = await GetCityTitleAsync();
    }

    private async Task<List<string>> GetPhoneNumbersAsync()
    {
        var service = new AbonentService(new CompanyDbContext());
        return await service.GetPhoneNumbersAsync();
    }

    private async Task<List<string>> GetCityTitleAsync()
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

    private DateTime _data = DateTime.Now;

    public DateTime Data
    {
        get => _data;
        set
        {
            _data = value;
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

    protected static string MakePhoneNumberToFormat(string phoneNumber)
    {
        return $"+{phoneNumber[0]}({phoneNumber[1..4]}){phoneNumber[4..7]}-{phoneNumber[7..9]}-{phoneNumber[9..]}";
    }

    public override IEnumerable<string> GetErrors(string propertyName)
    {
        yield break;
        //switch (propertyName)
        //{
        //    case nameof(PhoneNumber):
        //        {
        //            if (string.IsNullOrWhiteSpace(PhoneNumber))
        //            {
        //                yield return "Это поле обязательно";
        //            }
        //            else if (PhoneNumber!.Length != 11 || PhoneNumber![0] is not '7')
        //            {
        //                yield return "Длина должна быть 11 символов и начинаться на 7";
        //            }

        //            break;
        //        }
        //    case nameof(Inn):
        //        {
        //            if (string.IsNullOrWhiteSpace(Inn))
        //            {
        //                yield return "Это поле обязательно";
        //            }
        //            else if (Inn!.Length != 10)
        //            {
        //                yield return "Длина должна быть 10 символов";
        //            }
        //            break;
        //        }
        //    case nameof(Address):
        //        {
        //            if (string.IsNullOrWhiteSpace(Address)) yield return "Это поле обязательно";
        //            break;
        //        }
        //}
    }
}