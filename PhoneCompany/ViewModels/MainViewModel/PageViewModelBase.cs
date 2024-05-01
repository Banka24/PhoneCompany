using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using PhoneCompany.Services;

namespace PhoneCompany.ViewModels.MainViewModel;

/// <summary>
/// Базовый класс для всех страниц просмотра данных из таблиц Базы Данных
/// </summary>
public abstract class PageViewModelBase
{
    private ICommand _updateCommand;
    public ICommand UpdateCommand => _updateCommand ??= new RelayCommand<Button>(UpdatePageAsync);

    protected PageViewModelBase()
    {
        _ = EnterDataListAsync();
    }

    /// <summary>
    /// Загрузка данных из Базы Данных в список для просмотра
    /// </summary>
    /// <returns>Список полученных данных</returns>
    protected abstract Task EnterDataListAsync();

    /// <summary>
    /// Обновление страницы
    /// </summary>
    protected abstract void UpdatePageAsync(Button sender);
}