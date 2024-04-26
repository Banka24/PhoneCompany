using PhoneCompany.ViewModels.MainViewModel;

namespace PhoneCompany.Views.Main.Windows;

/// <summary>
///     Логика взаимодействия для MainWindow.xaml
/// </summary>
public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }
}