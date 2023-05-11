using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Hotel_neptun2
{
    public partial class O_nas : Window
    {
        public O_nas()
        {
            InitializeComponent();
            BackButton.Click += BackButton_Click;
        }

        private void BackButton_Click(object? sender, RoutedEventArgs e)
        {
            InfoWindow infoWindow = new InfoWindow();
            infoWindow.Show();
            this.Hide();
        }
    }
}
