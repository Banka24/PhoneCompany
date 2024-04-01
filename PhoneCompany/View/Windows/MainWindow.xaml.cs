using PhoneCompany.ViewModel;

namespace PhoneCompany.View.Windows;

/// <summary>
///     Логика взаимодействия для MainWindow.xaml
/// </summary>
public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel(MainFrame);
    }
}