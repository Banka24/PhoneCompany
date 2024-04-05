using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PhoneCompany.Services.InteractionDataBase;

namespace PhoneCompany.ViewModel.EditorVM;

public abstract class EditorPageViewModelBase : INotifyPropertyChanged, INotifyDataErrorInfo
{
    protected readonly IAbonentService AbonentService = new AbonentService();
    protected readonly ICityService CityService = new CityService();
    protected readonly IConversationService ConversationService = new ConversationService();

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