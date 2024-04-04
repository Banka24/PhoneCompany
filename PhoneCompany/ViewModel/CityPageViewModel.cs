﻿using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Controls;
using PhoneCompany.Model.Entities;

namespace PhoneCompany.ViewModel;

public class CityPageViewModel : PageViewModelBase
{
    public ObservableCollection<City> CitiesList { get; set; } = [];

    public CityPageViewModel()
    {
        EnterDataListAsync();
    }

    protected override async Task EnterDataListAsync()
    {
        var cities = await CityService.GetDataAsync();

        foreach (var city in cities) CitiesList.Add(city);
    }

    protected override async void UpdatePageAsync(Button sender)
    {
        CitiesList.Clear();
        await EnterDataListAsync();
    }
}