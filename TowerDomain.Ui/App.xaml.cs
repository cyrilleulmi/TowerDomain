using System.Windows;
using TowerDomain.Ui.ViewModel;

namespace TowerDomain.Ui
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            MainWindow mWindow = new MainWindow();
            MainViewModel mainViewModel = new MainViewModel();

            mWindow.DataContext = mainViewModel;
            mWindow.ShowDialog();
            Application.Current.Shutdown();
        }
    }
}
