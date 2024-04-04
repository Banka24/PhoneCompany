using System.Windows.Controls;

namespace PhoneCompany.ViewModel
{
    public class EditorViewModel(Page currentPage)
    {
        public Page CurrentPage { get; set; } = currentPage;
    }
}
