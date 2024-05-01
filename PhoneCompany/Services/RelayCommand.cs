using System;
using System.Windows.Input;

namespace PhoneCompany.Services;

/// <summary>
/// Модуль команд
/// </summary>
public class RelayCommand<T>(Action<T> execute, Func<T, bool> canExecute = null) : ICommand
{
    private readonly Action<T> _execute = execute ?? throw new ArgumentNullException(nameof(execute));

    public bool CanExecute(object parameter)
    {
        return canExecute?.Invoke((T)parameter) ?? true;
    }

    public void Execute(object parameter)
    {
        _execute((T)parameter);
    }

    public event EventHandler CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }
}