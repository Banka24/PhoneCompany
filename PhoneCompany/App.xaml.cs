using System;
using System.Threading.Tasks;
using System.Windows;
using PhoneCompany.Services.InteractionDataBase;
using PhoneCompany.ViewModels.MainViewModel;

namespace PhoneCompany;

/// <summary>
///     Логика взаимодействия для App.xaml
/// </summary>
public partial class App : Application
{
    protected override async void OnActivated(EventArgs e)
    {
        var viewmodel = Current.MainWindow?.DataContext as MainWindowViewModel;
        viewmodel!.ConnectionText = "Подключение к БД";
        viewmodel.SetIsDatabaseConnected(false);
        await Task.Run(MakeConnectionDataBase);
        viewmodel.SetIsDatabaseConnected(true);
        viewmodel.ConnectionText = "Подключено";
        await Task.Delay(3000);
        viewmodel.ConnectionText = string.Empty;
    }

    private static Task MakeConnectionDataBase()
    {
        using var context = new CompanyDbContext();
        context.Database.CreateIfNotExists();
        return Task.CompletedTask;
    }
}