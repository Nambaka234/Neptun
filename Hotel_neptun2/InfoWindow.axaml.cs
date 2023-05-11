using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Hotel_neptun2
{
    public partial class InfoWindow : Window
    {
        public InfoWindow()
        {
            InitializeComponent();
            HostButton.Click += HostButton_Click;
            VhodButton.Click += VhodButton_Click;
            OnasButton.Click += OnasButton_Click;
        }

        private void OnasButton_Click(object? sender, RoutedEventArgs e)
        {
            O_nas o_Nas = new O_nas();
            o_Nas.Show();
            this.Hide();
        }

        private void VhodButton_Click(object? sender, RoutedEventArgs e)
        {
            SignWindow signWindow = new SignWindow();
            signWindow.Show();
            this.Hide();
        }

        private void HostButton_Click(object? sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }
    }
}
