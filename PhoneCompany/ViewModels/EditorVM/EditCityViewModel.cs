using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using PhoneCompany.Services;
using PhoneCompany.Services.InteractionDataBase;

namespace PhoneCompany.ViewModels.EditorVM;

public class EditCityViewModel : CityViewModelBase
{
    private ICommand _findCityCommand;
    public ICommand FindCityCommand => _findCityCommand ??= new RelayCommand<Button>(FindCommand);

    private ICommand _editCityCommand;
    public ICommand EditCityCommand => _editCityCommand ??= new RelayCommand<Button>(EditCommand);

    private async void FindCommand(Button button)
    {
        if (string.IsNullOrWhiteSpace(Title) || Title!.Length < 2 || Title!.Length > 50 || !char.IsUpper(Title[0]))
        {
            ErrorMessage = "Заполните поля правильно";
            return;
        }

        await FindCityAsync();
    }

    private async Task FindCityAsync()
    {
        var service = new CityService(new CompanyDbContext());
        var city = await service.GetCityAsync(Title);
        TariffDay = city.TariffDay;
        TariffNight = city.TariffNight;
    }

    private async void EditCommand(Button button)
    {
        var service = new CityService(new CompanyDbContext());
        ErrorMessage = await service.EditCityAsync(Title, TariffDay, TariffNight) ? "Успешно" : "Неуспешно";
    }
}