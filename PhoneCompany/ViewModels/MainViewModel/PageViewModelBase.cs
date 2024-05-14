using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using PhoneCompany.Services;

namespace PhoneCompany.ViewModels.MainViewModel;

/// <summary>
///     Базовый класс для всех страниц просмотра данных из таблиц Базы Данных
/// </summary>
public abstract class PageViewModelBase
{
    private ICommand _updateCommand;
    public ICommand UpdateCommand => _updateCommand ??= new RelayCommand<Button>(UpdateDataGridAsync);

    private ICommand _findCommand;
    public ICommand FindCommand => _findCommand ??= new RelayCommand<Button>(GetFilteredList);

    protected PageViewModelBase()
    {
        _ = EnterDataListAsync();
    }

    /// <summary>
    ///     Загрузка данных из Базы Данных в список для просмотра
    /// </summary>
    /// <returns>Список полученных данных</returns>
    protected abstract Task EnterDataListAsync();

    /// <summary>
    ///     Обновление страницы
    /// </summary>
    protected abstract void UpdateDataGridAsync(Button sender);

    /// <summary>
    ///     Заполнение DataGrid данными из списка
    /// </summary>
    protected virtual Task FillDataGrid<T>(ObservableCollection<T> dataGridName, in IEnumerable<T> dataList) where T : class
    {
        foreach (var item in dataList) dataGridName.Add(item);

        return Task.CompletedTask;
    }

    /// <summary>
    ///     Получение отфильтрованного списка
    /// </summary>
    protected abstract void GetFilteredList(Button button);
}