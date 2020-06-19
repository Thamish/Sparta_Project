using CRUDManager;
using EF;
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
    /// Interaction logic for EditPlayer.xaml
    /// </summary>
    public partial class EditPlayer : Page
    {
        private Program _crudManager = new Program();
        private List<Teams> _all_teams = CRUDManager.Program.RetrieveTeams();
        public EditPlayer()
        {
            InitializeComponent();
            List<Positions> positionslist = new List<Positions>();
            positionslist.Add(new Positions { PositionId = 6, PositionDescription = "All" });
            foreach (var position in CRUDManager.Program.RetrievePositions())
            {
                positionslist.Add(position);
            }
            Positionfilter.ItemsSource = positionslist;
            PlayersListBox.ItemsSource = CRUDManager.Program.RetrievePlayers();
            PositionBox.ItemsSource = CRUDManager.Program.RetrievePositions();
            Teamsbox.ItemsSource = _all_teams;
            
        }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MainPage());
        }

        private void GetFirstNameText(object sender, RoutedEventArgs e)
        {
            FirstNameText.Text = _crudManager.SelectedPlayer.FirstName;
        }
        private void GetLastNameText(object sender, RoutedEventArgs e)
        {
            LastNameText.Text = _crudManager.SelectedPlayer.LastName;
        }
        private void GetNationalityText(object sender, RoutedEventArgs e)
        {
            NationalityText.Text = _crudManager.SelectedPlayer.Nationality;
        }
        private void GetDOBText(object sender, RoutedEventArgs e)
        {
            DOBSelected.SelectedDate = _crudManager.SelectedPlayer.DateOfBirth;
        }
        private void GetPosition(object sender, RoutedEventArgs e)
        {
            PositionBox.SelectedIndex = (int)(_crudManager.SelectedPlayer.PositionId)-1;
        }
        private void PlayersListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PlayersListBox.SelectedItem != null)
            {
                _all_teams = CRUDManager.Program.RetrieveTeams();
                _crudManager.SetSelectedPlayer(PlayersListBox.SelectedItem);
                GetFirstNameText(sender,e);
                GetLastNameText(sender, e);
                GetNationalityText(sender, e);
                GetDOBText(sender, e);
                GetPosition(sender, e);
                SelectedTeamsBox.ItemsSource = CRUDManager.Program.GetSelectedTeams(_crudManager.SelectedPlayer);
                List<Teams> tempLis = new List<Teams>();
                foreach (Teams team in _all_teams)
                {
                    foreach (Teams selcetedTeam in CRUDManager.Program.GetSelectedTeams(_crudManager.SelectedPlayer))
                    {
                        if (team.TeamId == selcetedTeam.TeamId)
                        {
                            tempLis.Add(team);
                        }
                        
                    }
                }
                foreach (var team in tempLis)
                {
                    _all_teams.Remove(team);
                }
                Teamsbox.ItemsSource = null;
                Teamsbox.ItemsSource = _all_teams;

            }

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (Teamsbox.SelectedItem != null)
            {
                CRUDManager.Program.AddTeam((EF.Teams)Teamsbox.SelectedItem, _crudManager.SelectedPlayer);
                _all_teams.Remove((EF.Teams)Teamsbox.SelectedItem);
                SelectedTeamsBox.ItemsSource = null;
                Teamsbox.ItemsSource = _all_teams;
                SelectedTeamsBox.ItemsSource = CRUDManager.Program.GetSelectedTeams(_crudManager.SelectedPlayer);
            }
            else
            {
                MessageBox.Show("Team Not Selected");
            }
        }
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedTeamsBox.SelectedItem != null)
            {
                CRUDManager.Program.RemoveTeam((EF.Teams)SelectedTeamsBox.SelectedItem, _crudManager.SelectedPlayer);
                SelectedTeamsBox.ItemsSource = null;
                SelectedTeamsBox.ItemsSource = CRUDManager.Program.GetSelectedTeams(_crudManager.SelectedPlayer);
            }
            else
            {
                MessageBox.Show("Team Not Selected");
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (FirstNameText.Text != "" && FirstNameText.Text != "First Name" &&
                NationalityText.Text != "" && NationalityText.Text != "Nationality" &&
                DOBSelected.SelectedDate != null && PositionBox.SelectedItem != null)
            {
                CRUDManager.Program.SavePlayer(FirstNameText.Text, LastNameText.Text, NationalityText.Text,
                (DateTime)DOBSelected.SelectedDate, (EF.Positions)PositionBox.SelectedItem, _crudManager.SelectedPlayer);
            }
            MessageBox.Show("Player Saved!");
            this.NavigationService.GoBack();
            
        }
        private void FilterTeam_TextChanged(object sender, TextChangedEventArgs e)
        {
            Teamsbox.ItemsSource = null;
            Teamsbox.ItemsSource = CRUDManager.Program.FilterTeams(FilterTeam.Text);
        }
        private void FirstNameFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            PlayersListBox.ItemsSource = null;
            PlayersListBox.ItemsSource = CRUDManager.Program.FilterPlayers(FirstNamefilter.Text, (Positions)Positionfilter.SelectedItem);
        }

        private void Positionfilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PlayersListBox.ItemsSource = null;
            PlayersListBox.ItemsSource = CRUDManager.Program.FilterPlayers(FirstNamefilter.Text, (Positions)Positionfilter.SelectedItem);
        }
    }
}
