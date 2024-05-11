using System.Windows.Controls;
using PhoneCompany.ViewModels.EditorVM;

namespace PhoneCompany.Views.Editor.Windows;

/// <summary>
///     Логика взаимодействия для Editor.xaml
/// </summary>
public partial class Editor
{
    public Editor(Page currentPage)
    {
        InitializeComponent();
        DataContext = new EditorViewModel(currentPage);
    }
}