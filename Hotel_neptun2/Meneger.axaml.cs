using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Hotel_neptun2
{
    public partial class Meneger : Window
    {
        public Meneger()
        {
            InitializeComponent();
            KlientButton.Click += KlientButton_Click;
            NomerButton.Click += NomerButton_Click;
            ZayavkiButton.Click += ZayavkiButton_Click;
            BackButton.Click += BackButton_Click;
        }

        private void ZayavkiButton_Click(object? sender, RoutedEventArgs e)
        {
            Meneger_Zayavki meneger_Zayavki = new Meneger_Zayavki();
            meneger_Zayavki.Show();
            this.Hide();
        }

        private void NomerButton_Click(object? sender, RoutedEventArgs e)
        {
            Meneger_Nomera meneger_Nomera = new Meneger_Nomera();
            meneger_Nomera.Show();
            this.Hide();
        }

        private void KlientButton_Click(object? sender, RoutedEventArgs e)
        {
            Meneger_Klients meneger_Klients = new Meneger_Klients();
            meneger_Klients.Show();
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
