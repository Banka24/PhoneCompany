using PhoneCompany.Services;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using PhoneCompany.Services.InteractionDataBase;

namespace PhoneCompany.ViewModel.EditorVM;

public class AddCityViewModel : CityViewModelBase
{
    private ICommand _addCityCommand;
    public ICommand AddCityCommand => _addCityCommand ??= new RelayCommand<Button>(AddCity);

    private async void AddCity(Button sender)
    {
        if (HasErrors)
        {
            ErrorMessage = "Заполните поля правильно";
            return;
        }
        await AddCityAsync();
    }

    private async Task AddCityAsync()
    {
        var service = new CityService(new CompanyDbContext());
        ErrorMessage = await service.AddCityAsync(Title, TariffDay, TariffNight) ? "Успешно" : "Неуспешно";
    }
}