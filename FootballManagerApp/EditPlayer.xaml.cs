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
    /// Interaction logic for EditPlayer.xaml
    /// </summary>
    public partial class EditPlayer : Page
    {
        private Program _crudManager = new Program();
        public EditPlayer()
        {
            InitializeComponent();
            PlayersListBox.ItemsSource = CRUDManager.Program.RetrievePlayers();
            PositionBox.ItemsSource = CRUDManager.Program.RetrievePositions();
            Teamsbox.ItemsSource = CRUDManager.Program.RetrieveTeams();
            
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
            DOBText.Text = _crudManager.SelectedPlayer.DateOfBirth.ToString().Remove(_crudManager.SelectedPlayer.DateOfBirth.ToString().Length -8);
        }
        private void GetPosition(object sender, RoutedEventArgs e)
        {
            PositionBox.SelectedIndex = (int)(_crudManager.SelectedPlayer.PositionId)-1;
        }
        private void PlayersListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PlayersListBox.SelectedItem != null)
            {
                _crudManager.SetSelectedPlayer(PlayersListBox.SelectedItem);
                GetFirstNameText(sender,e);
                GetLastNameText(sender, e);
                GetNationalityText(sender, e);
                GetDOBText(sender, e);
                GetPosition(sender, e);
                SelectedTeamsBox.ItemsSource = CRUDManager.Program.GetSelectedTeams(_crudManager.SelectedPlayer);
            }

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (Teamsbox.SelectedItem != null)
            {
                if (SelectedTeamsBox.Items.Contains(Teamsbox.SelectedItem)==false)
                {
                    _crudManager.AddTeam((EF.Teams)Teamsbox.SelectedItem, _crudManager.SelectedPlayer);
                    SelectedTeamsBox.ItemsSource = null;
                    SelectedTeamsBox.ItemsSource = CRUDManager.Program.GetSelectedTeams(_crudManager.SelectedPlayer);
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
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedTeamsBox.SelectedItem != null)
            {
                _crudManager.RemoveTeam((EF.Teams)SelectedTeamsBox.SelectedItem, _crudManager.SelectedPlayer);
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
                DOBText.Text != "" && DOBText.Text != "YYYY/MM/DD" && PositionBox.SelectedItem != null)
            {
                _crudManager.SavePlayer(FirstNameText.Text, LastNameText.Text, NationalityText.Text,
                DOBText.Text, (EF.Positions)PositionBox.SelectedItem, _crudManager.SelectedPlayer);
            }
            MessageBox.Show("Player Saved!");
            
        }
    }
}
