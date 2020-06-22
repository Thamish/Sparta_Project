using System.Media;
using System.Windows;

namespace FootballManagerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new MainPage());
        }

        private void Sound_MediaEnded(object sender, RoutedEventArgs e)
        {
            Sound.Position = System.TimeSpan.Zero;
            Sound.Play();
        }
    }
}
