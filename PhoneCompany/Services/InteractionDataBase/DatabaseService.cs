using PhoneCompany.ViewModels.MainViewModel;
using System;
using System.Threading.Tasks;

namespace PhoneCompany.Services.InteractionDataBase
{
    public static class DatabaseService
    {
        public static async Task UpdateStatus(object element)
        {
            if(element is not MainWindowViewModel viewModel) return;
            viewModel!.SetIsDatabaseConnected(true);
            viewModel.ConnectionText = "Подключено";
            await Task.Delay(1500);
            viewModel.ConnectionText = string.Empty;
        }

        public static bool MakeConnectionDataBase()
        {
            using var context = new CompanyDbContext();
            try
            {
                context.Database.CreateIfNotExists();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
