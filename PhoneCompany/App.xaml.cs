﻿using System;
using System.Threading.Tasks;
using System.Windows;
using PhoneCompany.Services.InteractionDataBase;

namespace PhoneCompany;

/// <summary>
///     Логика взаимодействия для App.xaml
/// </summary>
public partial class App : Application
{
    protected override async void OnActivated(EventArgs e)
    {
        if (!await Task.Run(DatabaseService.MakeConnectionDataBase)) return;
        await DatabaseService.UpdateStatus(Current.MainWindow?.DataContext);
    }
}