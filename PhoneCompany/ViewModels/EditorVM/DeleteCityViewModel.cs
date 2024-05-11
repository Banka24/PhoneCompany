using System.Threading.Tasks;
using System.Windows.Controls;
using PhoneCompany.Services.InteractionDataBase;

namespace PhoneCompany.ViewModels.EditorVM;

public class DeleteCityViewModel : CityViewModelBase
{
    private System.Windows.Input.ICommand _deleteCommand;
    public System.Windows.Input.ICommand DeleteCommand => _deleteCommand ??= new Services.RelayCommand<Button>(DeleteCity);
    
    private async void DeleteCity(Button sender)
    {
        if (Title is null)
        {
            ErrorMessage = "Заполните поля правильно";
            return;
        }

        await DeleteCityAsync();
    }

    private async Task DeleteCityAsync()
    {
        var service = new CityService(new CompanyDbContext());
        ErrorMessage = await service.DeleteCityAsync(Title) ? "Успешно" : "Неуспешно";
    }
}