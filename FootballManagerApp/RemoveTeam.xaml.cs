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
    /// Interaction logic for RemoveTeam.xaml
    /// </summary>
    public partial class RemoveTeam : Page
    {
        public RemoveTeam()
        {
            InitializeComponent();
            TeamsListBox.ItemsSource = CRUDManager.Program.RetrieveTeams();
        }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MainPage());
        }

        private void RemoveTeamsButton_Click(object sender, RoutedEventArgs e)
        {
            if (TeamsListBox.SelectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Are You Sure?", "Confirmation", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        CRUDManager.Program.RemoveTeam((EF.Teams)TeamsListBox.SelectedItem);
                        MessageBox.Show("Team Removed", "Confirmation");
                        this.NavigationService.Navigate(new TeamOptions());
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
        }
        private void FilterTeam_TextChanged(object sender, TextChangedEventArgs e)
        {
            TeamsListBox.ItemsSource = null;
            TeamsListBox.ItemsSource = CRUDManager.Program.FilterTeams(FilterTeam.Text);
        }
    }
}
