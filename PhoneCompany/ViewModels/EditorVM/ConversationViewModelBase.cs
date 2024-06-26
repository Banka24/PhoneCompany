﻿using System;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using PhoneCompany.Services.InteractionDataBase;

namespace PhoneCompany.ViewModels.EditorVM;

/// <summary>
/// Базовый класс для всех ViewModel связанных с редактированием телефонного разговора
/// </summary>
public class ConversationViewModelBase : EditorPageViewModelBase
{
    public ConversationViewModelBase()
    {
        Task.Run(async () =>
        {
            await GetPhoneNumbersAsync();
            await GetCityTitleAsync();
        });
    }

    public override bool HasErrors => NumberOfMinutes < 0 || Time < TimeSpan.MinValue;
    public ObservableCollection<string> PhoneNumberList { get; set; } = [];
    public ObservableCollection<string> CityTitleList { get; set; } = [];

    private string _phoneNumber = "7";
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

    private TimeSpan _time;
    public TimeSpan Time
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

    public override IEnumerable<string> GetErrors(string propertyName)
    {
        if (propertyName is nameof(NumberOfMinutes) && NumberOfMinutes < 0)
        {
            yield return "Вызов не может длиться меньше 0 минут";
        }

        else if (propertyName is nameof(Time) && Time < TimeSpan.MinValue)
        {
            yield return "Проверьте данные";
        }
    }

    protected DateTime MakeDateTimeToFormat()
    {
        return DateTime.Parse($"{Date:dd.MM.yyyy} {Time}");
    }

    /// <summary>
    /// Получение времени суток
    /// </summary>
    /// <returns>Время суток</returns>
    protected string GetTimeOfDay()
    {
        return Time.Hours is >= 6 and <= 22 ? "День" : "Ночь";
    }

    private async Task GetPhoneNumbersAsync()
    {
        var service = new AbonentService(new CompanyDbContext());
        await FillComboBox(PhoneNumberList, await service.GetPhoneNumbersAsync());
    }

    private async Task GetCityTitleAsync()
    {
        var service = new CityService(new CompanyDbContext());
        await FillComboBox(CityTitleList, await service.GetCityTitleAsync());
    }
}