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
    /// Interaction logic for AddTeam.xaml
    /// </summary>
    public partial class AddTeam : Page
    {
        private Program _crudManager = new Program();
        public AddTeam()
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
            
        }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MainPage());
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (PlayersListBox.SelectedItem != null)
            {
                if (_crudManager.SelectedPlayers.Contains((EF.Players)PlayersListBox.SelectedItem) == false)
                {
                    if (SelectedPlayersListBox.Items.Count < 11)
                    {
                        _crudManager.SelectedPlayers.Add((EF.Players)PlayersListBox.SelectedItem);
                        SelectedPlayersListBox.ItemsSource = null;
                        SelectedPlayersListBox.ItemsSource = _crudManager.SelectedPlayers;
                        PlayersListBox.SelectedItem = null;
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
            if (SelectedPlayersListBox.SelectedItem != null)
            {
                _crudManager.SelectedPlayers.Remove((EF.Players)SelectedPlayersListBox.SelectedItem);
                SelectedPlayersListBox.ItemsSource = null;
                SelectedPlayersListBox.ItemsSource = _crudManager.SelectedPlayers;
            }
        }

        private void TeamNameText_Click(object sender, RoutedEventArgs e)
        {
            TeamNameText.Text = "";
            TeamNameText.Foreground = new SolidColorBrush(Colors.Black);
        }
        private void SubmitTeam_Click(object sender, RoutedEventArgs e)
        {
            if (TeamNameText.Text != "" && TeamNameText.Text != "Team Name")
            {
                CRUDManager.Program.SubmitTeam(TeamNameText.Text, _crudManager.SelectedPlayers);
            }
            MessageBox.Show("Team Added");
            this.NavigationService.Navigate(new TeamOptions());
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
