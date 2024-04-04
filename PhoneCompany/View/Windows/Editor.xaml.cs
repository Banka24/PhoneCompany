using System.Windows.Controls;
using PhoneCompany.ViewModel;

namespace PhoneCompany.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для Editor.xaml
    /// </summary>
    public partial class Editor
    {
        public Editor(Page currentPage)
        {
            InitializeComponent();
            DataContext = new EditorViewModel(currentPage);
        }
    }
}
