using System;
using PhoneCompany.Migrations;
using System.Windows;

namespace PhoneCompany;

/// <summary>
///     Логика взаимодействия для App.xaml
/// </summary>
public partial class App : Application
{
    protected override async void OnActivated(EventArgs e)
    {
        var con = new ContextInitializer();
        await con.MakeSeed();
    }
}