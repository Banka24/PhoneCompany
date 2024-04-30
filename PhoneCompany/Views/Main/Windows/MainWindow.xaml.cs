using System.Windows;
using PhoneCompany.ViewModels.MainViewModel;

namespace PhoneCompany.Views.Main.Windows;

/// <summary>
///     Логика взаимодействия для MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }
}