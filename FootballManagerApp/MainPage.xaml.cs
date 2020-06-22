using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FootballManagerApp
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void PlayersButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PlayerOptions());
        }

        private void TeamsButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new TeamOptions());
        }

        private void Game_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Game());
        }

    }
}
