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

namespace FootballManagerApp
{
    /// <summary>
    /// Interaction logic for EditTeam.xaml
    /// </summary>
    public partial class EditTeam : Page
    {
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
    }
    
}
