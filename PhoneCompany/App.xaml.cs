using System;
using PhoneCompany.Services.InteractionDataBase;

namespace PhoneCompany;

/// <summary>
///     Логика взаимодействия для App.xaml
/// </summary>
public partial class App
{
    protected override async void OnActivated(EventArgs e)
    {
        var con = new ContextInitializer();
        await con.MakeSeed();
    }
}