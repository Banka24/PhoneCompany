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
        await Task.Run(DatabaseService.MakeConnectionDataBase);
        await DatabaseService.UpdateStatus(Current.MainWindow?.DataContext);
    }
}