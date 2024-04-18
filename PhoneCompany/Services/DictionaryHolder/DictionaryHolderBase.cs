using System.Windows.Controls;

namespace PhoneCompany.Services.DictionaryHolder
{
    public abstract class DictionaryHolderBase
    {
        public abstract Page GetPage(string namePage);
    }
}
