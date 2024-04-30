using System.Threading.Tasks;
using PhoneCompany.ViewModels.MainViewModel;

namespace PhoneCompany.Services.InteractionDataBase;
/// <summary>
/// Сервис для Базы Данных
/// </summary>
public static class DatabaseService
{
    /// <summary>
    /// Обновляет статус подключения к Базе Данных
    /// </summary>
    public static async Task UpdateStatus(object element)
    {
        if (element is not MainWindowViewModel viewModel) return;
        viewModel!.SetIsDatabaseConnected(true);
        viewModel.ConnectionText = "Подключено";
        await Task.Delay(1500);
        viewModel.ConnectionText = string.Empty;
    }

    /// <summary>
    /// Создаёт подключение к Базе Данных
    /// </summary>
    public static void MakeConnectionDataBase()
    {
        using var context = new CompanyDbContext();
        context.Database.CreateIfNotExists();
    }
}