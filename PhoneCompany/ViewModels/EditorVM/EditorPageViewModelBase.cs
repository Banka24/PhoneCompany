using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PhoneCompany.ViewModels.EditorVM;

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
}