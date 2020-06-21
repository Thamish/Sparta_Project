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
using EF;

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
            PositionBox.ItemsSource = CRUDManager.Program.RetrievePositions();
        }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MainPage());
        }

        private void FirstNameText_Click(object sender, RoutedEventArgs e)
        {
            if (FirstNameText.Text == "First Name")
            {
                FirstNameText.Text = "";
                FirstNameText.Foreground = new SolidColorBrush(Colors.Black);
            }
        }
        private void FirstNameLostFocus(object sender, RoutedEventArgs e)
        {
            if (FirstNameText.Text == "")
            {
                FirstNameText.Foreground = new SolidColorBrush(Colors.Gray);
                FirstNameText.Text = "First Name";
            }
        }
        private void LastNameText_Click(object sender, RoutedEventArgs e)
        {
            if (LastNameText.Text == "Last Name")
            {
                LastNameText.Text = "";
                LastNameText.Foreground = new SolidColorBrush(Colors.Black);
            }
        }
        private void LastNameLostFocus(object sender, RoutedEventArgs e)
        {
            if (LastNameText.Text == "")
            {
                LastNameText.Foreground = new SolidColorBrush(Colors.Gray);
                LastNameText.Text = "Last Name";
            }
        }
        private void NationalityText_Click(object sender, RoutedEventArgs e)
        {
            if (NationalityText.Text == "Nationality")
            {
                NationalityText.Text = "";
                NationalityText.Foreground = new SolidColorBrush(Colors.Black);
            }
        }
        private void NationalityLostFocus(object sender, RoutedEventArgs e)
        {
            if (NationalityText.Text == "")
            {
                NationalityText.Foreground = new SolidColorBrush(Colors.Gray);
                NationalityText.Text = "Nationality";
            }
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
                    if (CRUDManager.Program.GetTeamSize(_crudManager.SelectedTeam) < 11)
                    {
                        _crudManager.SelectedTeams.Add(_crudManager.SelectedTeam);
                        SelectedTeamsBox.ItemsSource = null;
                        SelectedTeamsBox.ItemsSource = _crudManager.SelectedTeams;
                    }
                    else
                    {
                        MessageBox.Show("Team Full");
                    }
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

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (LastNameText.Text == "Last Name")
            {
                LastNameText.Text = "";
            }
            if (FirstNameText.Text != "" && FirstNameText.Text != "First Name")
            {
                if (NationalityText.Text != "" && NationalityText.Text != "Nationality")
                {
                    if (DOBSelect.SelectedDate != null)
                    {
                        if (PositionBox.SelectedItem != null)
                        {
                            CRUDManager.Program.SubmitPlayer(FirstNameText.Text, LastNameText.Text, NationalityText.Text,
                            (DateTime)DOBSelect.SelectedDate, _crudManager.SelectedTeams, (EF.Positions)PositionBox.SelectedItem);
                            MessageBox.Show("Player Added!");
                            this.NavigationService.Navigate(new PlayerOptions());
                        }
                        else
                        {
                            MessageBox.Show("Player Not Added" + "\n" + "Position Not Selected!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Player Not Added" + "\n" + "Date of Birth Not Selected!");
                    }
                }
                else
                {
                    MessageBox.Show("Player Not Added" + "\n" + "Nationality Missing!");
                }
            }
            else
            {
                MessageBox.Show("Player Not Added" + "\n" + "First Name Missing!");
            }
        }

        private void FilterTeam_TextChanged(object sender, TextChangedEventArgs e)
        {
            TeamsBox.ItemsSource = null;
            TeamsBox.ItemsSource = CRUDManager.Program.FilterTeams(FilterTeam.Text);
        }
    }
}
