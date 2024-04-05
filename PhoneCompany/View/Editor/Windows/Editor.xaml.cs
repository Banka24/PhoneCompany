using System.Windows.Controls;
using PhoneCompany.ViewModel.EditorVM;

namespace PhoneCompany.View.Editor.Windows
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
