using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PhoneCompany.ViewModel.EditorVM;

public abstract class EditorPageViewModelBase : ViewModelBase, INotifyPropertyChanged, INotifyDataErrorInfo
{
    public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
    public virtual bool HasErrors { get; }
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected void ValidateProperty([CallerMemberName] string propertyName = null)
    {
        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
    }
    public virtual IEnumerable GetErrors(string propertyName)
    {
        return null!;
    }
}