using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Hotel_neptun2
{
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
            SotrudnikButton.Click += SotrudnikButton_Click;
            KlientButton.Click += KlientButton_Click;
            NomerButton.Click += NomerButton_Click;
            BackButton.Click += BackButton_Click;
        }

        private void NomerButton_Click(object? sender, RoutedEventArgs e)
        {
            Admin_Nomera admin_Nomera = new Admin_Nomera();
            admin_Nomera.Show();
            this.Hide();
        }

        private void KlientButton_Click(object? sender, RoutedEventArgs e)
        {
            Admin_Klients admin_Klients = new Admin_Klients();
            admin_Klients.Show();
            this.Hide();
        }

        private void SotrudnikButton_Click(object? sender, RoutedEventArgs e)
        {
            Admin_Sotrudniki admin_Sotrudniki = new Admin_Sotrudniki();
            admin_Sotrudniki.Show();
            this.Hide();
        }

        private void BackButton_Click(object? sender, RoutedEventArgs e)
        {
            Auterling auterling = new Auterling();
            auterling.Show();
            this.Hide();
        }
    }
}
