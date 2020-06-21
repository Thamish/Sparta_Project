using Microsoft.Win32;
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
using EF;
using CRUDManager;
using System.Linq;

namespace FootballManagerApp
{
    /// <summary>
    /// Interaction logic for EditTeam.xaml
    /// </summary>
    public partial class EditTeam : Page
    {
        private Program _crudManager = new Program();
        public EditTeam()
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
            TeamsList.ItemsSource = CRUDManager.Program.RetrieveTeams();
        }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MainPage());
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

        private void TeamsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TeamsList.SelectedItem != null)
            {
                _crudManager.SelectedPlayers.Clear();
                _crudManager.SetSelectedTeam(TeamsList.SelectedItem);
                SquadListBox.ItemsSource = null;
                foreach (var players in CRUDManager.Program.GetSelectedPlayers(_crudManager.SelectedTeam))
                {
                    _crudManager.SelectedPlayers.Add(CRUDManager.Program.GetPlayer(players));
                }
                SquadListBox.ItemsSource = null;
                SquadListBox.ItemsSource = _crudManager.SelectedPlayers;
                TeamNameText.Text = _crudManager.SelectedTeam.TeamName;
                MatchesPlayedText.Text = CRUDManager.Program.GetTeamStatistics(_crudManager.SelectedTeam).MatchesPlayed.ToString();
                WinsText.Text = CRUDManager.Program.GetTeamStatistics(_crudManager.SelectedTeam).Wins.ToString();
                DrawsText.Text = CRUDManager.Program.GetTeamStatistics(_crudManager.SelectedTeam).Draws.ToString();
                LossesText.Text = CRUDManager.Program.GetTeamStatistics(_crudManager.SelectedTeam).Losses.ToString();
                GoalsScoredText.Text = CRUDManager.Program.GetTeamStatistics(_crudManager.SelectedTeam).GoalsScored.ToString();
                GoalsConcededText.Text = CRUDManager.Program.GetTeamStatistics(_crudManager.SelectedTeam).GoalsConceded.ToString();
            }
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (TeamNameText.Text != "")
            {
                if (MatchesPlayedText.Text != "")
                {
                    if (WinsText.Text != "")
                    {
                        if (DrawsText.Text != "")
                        {
                            if (LossesText.Text != "")
                            {
                                if (GoalsConcededText.Text != "")
                                {
                                    if (GoalsScoredText.Text != "")
                                    {
                                        CRUDManager.Program.SaveTeam(_crudManager.SelectedTeam, TeamNameText.Text, Int32.Parse(MatchesPlayedText.Text),
                                            Int32.Parse(WinsText.Text), Int32.Parse(DrawsText.Text), Int32.Parse(LossesText.Text),
                                            Int32.Parse(GoalsScoredText.Text), Int32.Parse(GoalsConcededText.Text),_crudManager.SelectedPlayers);
                                        MessageBox.Show("Team Saved!");
                                        this.NavigationService.GoBack();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (PlayersListBox.SelectedItem != null)
            {
                if (_crudManager.SelectedPlayers.Contains(PlayersListBox.SelectedItem) == false)
                {

                    if (SquadListBox.Items.Count < 11)
                    {
                        _crudManager.SelectedPlayers.Add((Players)PlayersListBox.SelectedItem);
                        SquadListBox.ItemsSource = null;
                        SquadListBox.ItemsSource = _crudManager.SelectedPlayers;

                    }
                    else
                    {
                        MessageBox.Show("Team Full");
                    }
                }
                else
                {
                    MessageBox.Show("Player Already Added");
                }
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (SquadListBox.SelectedItem != null)
            {
                _crudManager.SelectedPlayers.Remove((Players)PlayersListBox.SelectedItem);
                SquadListBox.ItemsSource = null;
                SquadListBox.ItemsSource = _crudManager.SelectedPlayers;
            }
        }
    }
    
}
