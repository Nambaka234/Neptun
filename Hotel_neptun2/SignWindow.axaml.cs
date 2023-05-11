using Avalonia.Controls;
using Avalonia.Interactivity;
using Hotel_neptun2.database;

namespace Hotel_neptun2
{
    public partial class SignWindow : Window
    {
        public SignWindow()
        {
            InitializeComponent();
            AuterlingButton.Click += AuterlingButton_Click;
            KlientButton.Click += KlientButton_Click;
            BackButton.Click += BackButton_Click;
        }

        private void KlientButton_Click(object? sender, RoutedEventArgs e)
        {
            Klient klient = new Klient();
            klient.Show();
            this.Hide();
        }

        private void AuterlingButton_Click(object? sender, RoutedEventArgs e)
        {
            Auterling auterling = new Auterling();
            auterling.Show();
            this.Hide();
        }

        private void BackButton_Click(object? sender, RoutedEventArgs e)
        {
            InfoWindow infoWindow = new InfoWindow();
            infoWindow.Show();
            this.Hide();
        }
    }
}
