using System;
using System.Threading.Tasks;
using PhoneCompany.Services.InteractionDataBase;

namespace PhoneCompany;

/// <summary>
///     Логика взаимодействия для App.xaml
/// </summary>
public partial class App
{
    protected override async void OnActivated(EventArgs e)
    {
        await Task.Run(MakeConnectionDataBase);
    }

    private static void MakeConnectionDataBase()
    {
        using var context = new CompanyDbContext();
        context.Database.CreateIfNotExists();
    }
}