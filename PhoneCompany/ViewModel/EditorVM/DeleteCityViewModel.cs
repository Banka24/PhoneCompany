using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using PhoneCompany.Services;
using PhoneCompany.Services.InteractionDataBase;

namespace PhoneCompany.ViewModel.EditorVM;

public class DeleteCityViewModel : EditorPageViewModelBase
{
    public override bool HasErrors => string.IsNullOrWhiteSpace(Title) || Title!.Length < 2 || Title!.Length > 50 || !char.IsUpper(Title[0]);
    private string _title = string.Empty;

    public string Title
    {
        get => _title;
        set
        {
            _title = value;
            ValidateProperty();
            OnPropertyChanged();
        }
    }

    private ICommand _deleteCommand;
    public ICommand DeleteCommand => _deleteCommand ??= new RelayCommand<Button>(DeleteCity);

    public override IEnumerable<string> GetErrors(string propertyName)
    {
        if (propertyName is not nameof(Title)) yield break;
        if (string.IsNullOrWhiteSpace(Title))
        {
            yield return "Это поле обязательно";
        }
        else if (Title!.Length < 2 || Title!.Length > 50)
        {
            yield return "Длина должна быть от 2 до 50 символов";
        }
        else if (!char.IsUpper(Title[0]))
        {
            yield return "Напишите город с большой буквы";
        }
    }

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