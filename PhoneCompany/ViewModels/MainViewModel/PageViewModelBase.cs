using System.Threading.Tasks;
using System.Windows.Controls;

namespace PhoneCompany.ViewModels.MainViewModel;

/// <summary>
/// Базовый класс для всех страниц просмотра данных из таблиц Базы Данных
/// </summary>
public abstract class PageViewModelBase
{
    private System.Windows.Input.ICommand _updateCommand;
    public System.Windows.Input.ICommand UpdateCommand => _updateCommand ??= new Services.RelayCommand<Button>(UpdateDataGridAsync);

    private System.Windows.Input.ICommand _findCommand;
    public System.Windows.Input.ICommand FindCommand => _findCommand ??= new Services.RelayCommand<Button>(GetFilteredList);

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
    protected abstract void UpdateDataGridAsync(Button sender);

    /// <summary>
    /// Заполнение DataGrid данными из списка
    /// </summary>
    protected virtual Task FillDataGrid<T>(System.Collections.ObjectModel.ObservableCollection<T> dataGridName, in System.Collections.Generic.IEnumerable<T> dataList) where T : class
    {
        foreach (var item in dataList)
        {
            dataGridName.Add(item);
        }

        return Task.CompletedTask;
    }

    /// <summary>
    /// Получение отфильтрованного списка
    /// </summary>
    protected abstract void GetFilteredList(Button button);

}