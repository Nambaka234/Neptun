using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Linq;

namespace Hotel_neptun2
{
    public partial class DeleteWindow : Window
    {
        bool isAdmin = false;
        public DeleteWindow()
        {
            InitializeComponent();
            InitializeWindow();
            DataContext = isAdmin;
            this.isAdmin = isAdmin;
        }

        private void InitializeWindow()
        {
            LoadDelete();
        }

        private void LoadDelete()
        {
            var Sotrudnikis = Helper.neptun.Sotrudnikis.Select(x => new
            {
                x.Id
            });
        }

        private void YesButton_Click(object? sender, RoutedEventArgs e)
        {
            int button = (int)(sender as Button).Tag;

            Helper.neptun.Sotrudnikis.Remove(Helper.neptun.Sotrudnikis.Find(button));
            Helper.neptun.SaveChanges();
            LoadDelete();
            this.Hide();
        }

        private void NoButton_Click(object? sender, RoutedEventArgs e)
        {
            Admin_Sotrudniki admin_Sotrudniki = new Admin_Sotrudniki();
            admin_Sotrudniki.Show();
            this.Hide();
        }
    }
}
