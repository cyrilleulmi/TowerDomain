using System;
using System.Windows;
using System.Windows.Controls;
using TowerDomain.Ui.ViewModel;

namespace TowerDomain.Ui
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow 
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private MainViewModel context
        {
            get
            {
                return (MainViewModel)this.DataContext;
            }
        }

        private void CreateTower_Click(object sender, RoutedEventArgs e)
        {
            this.context.CreateTower();
        }

        private void UpgradeRange_Click(object sender, RoutedEventArgs e)
        {
            this.context.UpgradeRange();
        }

        private void UpgradeDamage_Click(object sender, RoutedEventArgs e)
        {
            this.context.UpgradeDamage();
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.context.ChangeSelectionTo((ITower)((ListView)sender).SelectedItem);
        }
    }
}
