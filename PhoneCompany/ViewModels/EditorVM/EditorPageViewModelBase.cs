using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace PhoneCompany.ViewModels.EditorVM;

/// <summary>
/// Базовый класс для всех ViewModel страниц редактора
/// </summary>
public abstract class EditorPageViewModelBase : INotifyPropertyChanged, INotifyDataErrorInfo
{
    public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
    public event PropertyChangedEventHandler PropertyChanged;

    public virtual bool HasErrors { get; }

    private string _errorMessage;
    public string ErrorMessage
    {
        get => _errorMessage;
        set
        {
            _errorMessage = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Получение списка ошибок
    /// </summary>
    /// <returns>Список ошибок</returns>
    public abstract IEnumerable GetErrors(string propertyName);

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected void ValidateProperty([CallerMemberName] string propertyName = null)
    {
        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
    }

    /// <summary>
    /// Заполнение ComboBox данными из списка
    /// </summary>
    /// <returns>Список данных</returns>
    protected virtual Task FillComboBox<T>(ObservableCollection<T> dataGridName, in System.Collections.Generic.IEnumerable<T> dataList) where T : class
    {
        foreach (var item in dataList)
        {
            dataGridName.Add(item);
        }

        return Task.CompletedTask;
    }
}