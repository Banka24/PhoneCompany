using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using PhoneCompany.Models;
using PhoneCompany.Services.InteractionDataBase;

namespace PhoneCompany.ViewModels.EditorVM;

public class EditCityViewModel : CityViewModelBase
{
    private ICommand _findCityCommand;
    public ICommand FindCityCommand => _findCityCommand ??= new Services.RelayCommand<Button>(FindCommand);

    private ICommand _editCityCommand;
    public ICommand EditCityCommand => _editCityCommand ??= new Services.RelayCommand<Button>(EditCommand);

    private bool _isButtonEnable;

    public bool IsButtonEnable
    {
        get => _isButtonEnable;
        set
        {
            _isButtonEnable = value;
            OnPropertyChanged();
        }
    }

    private async void FindCommand(Button button)
    {
        if (!HasErrors)
        {
            ErrorMessage = "Заполните поля правильно";
            return;
        }

        IsButtonEnable = await FindCityAsync();
    }

    private async Task<bool> FindCityAsync()
    {
        var service = new CityService(new CompanyDbContext());
        City city;
        try
        {
            city = await service.FindCityAsync(Title);
        }
        catch (System.Exception e)
        {
            ErrorMessage = e.Message;
            return false;
        }
        TariffDay = city.TariffDay;
        TariffNight = city.TariffNight;
        return true;
    }

    private async void EditCommand(Button button)
    {
        var service = new CityService(new CompanyDbContext());
        ErrorMessage = await service.EditCityAsync(Title, TariffDay, TariffNight) ? "Успешно" : "Неуспешно";
    }
}