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
using CRUDManager;

namespace FootballManagerApp
{
    /// <summary>
    /// Interaction logic for AddPlayer.xaml
    /// </summary>
    public partial class AddPlayer : Page
    {
        private Program _crudManager = new Program();
        public AddPlayer()
        {
            InitializeComponent();
            TeamsBox.ItemsSource = CRUDManager.Program.RetrieveTeams();
        }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MainPage());
        }

        private void FirstNameText_Click(object sender, RoutedEventArgs e)
        {
            FirstNameText.Text = "";
            FirstNameText.Foreground = new SolidColorBrush(Colors.Black);
        }
        private void LastNameText_Click(object sender, RoutedEventArgs e)
        {
            LastNameText.Text = "";
            LastNameText.Foreground = new SolidColorBrush(Colors.Black);
        }
        private void NationalityText_Click(object sender, RoutedEventArgs e)
        {
            NationalityText.Text = "";
            NationalityText.Foreground = new SolidColorBrush(Colors.Black);
        }
        private void DOBText_Click(object sender, RoutedEventArgs e)
        {
            DOBText.Text = "";
            DOBText.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void TeamsBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TeamsBox.SelectedItem != null)
            {
                _crudManager.SetSelectedTeam(TeamsBox.SelectedItem);
            }
        }
        private void SelectedTeamsBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectedTeamsBox.SelectedItem != null)
            {
                _crudManager.SetSelectedTeam(SelectedTeamsBox.SelectedItem);
            }
        }

        private void AddTeamButton_Click(object sender, RoutedEventArgs e)
        {
            if (_crudManager.SelectedTeam != null)
            {
                if (_crudManager.SelectedTeams.Contains(_crudManager.SelectedTeam) == false)
                {
                    _crudManager.SelectedTeams.Add(_crudManager.SelectedTeam);
                    SelectedTeamsBox.ItemsSource = null;
                    SelectedTeamsBox.ItemsSource = _crudManager.SelectedTeams;
                }
                else
                {
                    MessageBox.Show("Team Already Selected");
                }
            }
            else
            {
                MessageBox.Show("Team Not Selected");
            }
        }
        private void RemoveTeamButton_Click(object sender, RoutedEventArgs e)
        {
            if (_crudManager.SelectedTeam != null)
            {

                _crudManager.SelectedTeams.Remove(_crudManager.SelectedTeam);
                SelectedTeamsBox.ItemsSource = null;
                SelectedTeamsBox.ItemsSource = _crudManager.SelectedTeams;
            }
            else
            {
                MessageBox.Show("Team Not Selected");
            }
        }
    }
}
