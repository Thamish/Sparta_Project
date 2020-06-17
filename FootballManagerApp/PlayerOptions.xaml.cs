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
    /// Interaction logic for PlayerOptions.xaml
    /// </summary>
    public partial class PlayerOptions : Page
    {
        public PlayerOptions()
        {
            InitializeComponent();
        }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MainPage());
        }
        private void AddPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddPlayer());
        }
        private void EditPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new EditPlayer());
        }
    }
}
