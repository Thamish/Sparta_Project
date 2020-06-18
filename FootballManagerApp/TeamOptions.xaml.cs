using System;
using System.Collections.Generic;
using System.Text;
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
    /// Interaction logic for TeamOptions.xaml
    /// </summary>
    public partial class TeamOptions : Page
    {
        public TeamOptions()
        {
            InitializeComponent();
        }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MainPage());
        }
        private void AddTeamButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddTeam());
        }
        private void EditTeamButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new EditTeam());
        }

        private void RemoveTeamButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RemoveTeam());
        }
    }
}
