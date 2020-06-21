using CRUDManager;
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
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Page
    {
        private bool simed = false;
        private Simgame _crudManager = new Simgame(); 
        public Game()
        {
            InitializeComponent();
            Team1.ItemsSource = CRUDManager.Program.RetrieveTeams();
            Team2.ItemsSource = CRUDManager.Program.RetrieveTeams();
        }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MainPage());
        }
        private void Team1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Team1.SelectedItem != null)
            {
                _crudManager.SetSelectedTeam1(Team1.SelectedItem);
            }
        }

        private void Team2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Team2.SelectedItem != null)
            {
                _crudManager.SetSelectedTeam2(Team2.SelectedItem);
            }
        }

        private void Start_Button_Click(object sender, RoutedEventArgs e)
        {
            if (simed == false)
            {
                if (Team1.SelectedItem != null && Team1.SelectedItem != null)
                {
                    if (Team1.SelectedItem != Team2.SelectedItem)
                    {
                        var game = CRUDManager.Simgame.Simulate(_crudManager.SelectedTeam1,
                            CRUDManager.Simgame.GetRoster(CRUDManager.Simgame.GetSelectedPlayers(_crudManager.SelectedTeam1)),
                            _crudManager.SelectedTeam2, CRUDManager.Simgame.GetRoster
                            (CRUDManager.Simgame.GetSelectedPlayers(_crudManager.SelectedTeam2)));
                        ScoreBox.Text = game.Item2;
                        Displaybox.Text = game.Item1;
                        Displaybox2.Text = game.Item3;
                        simed = true;
                    }
                    else
                    {
                        MessageBox.Show("Select Two Different Teams!");
                    }
                }
                else
                {
                    MessageBox.Show("Teams Not Selected!");
                }
            }
        }
    }
}
