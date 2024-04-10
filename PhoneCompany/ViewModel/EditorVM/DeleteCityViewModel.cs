using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using PhoneCompany.Services;
using PhoneCompany.Services.InteractionDataBase;

namespace PhoneCompany.ViewModel.EditorVM;

public class DeleteCityViewModel : CityViewModelBase
{
    private ICommand _deleteCommand;
    public ICommand DeleteCommand => _deleteCommand ??= new RelayCommand<Button>(DeleteCity);
    
    private async void DeleteCity(Button sender)
    {
        if (HasErrors)
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