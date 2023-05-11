using Avalonia.Controls;
using Avalonia.Interactivity;
using Hotel_neptun2.database;
using System.Collections.Generic;
using System.Linq;

namespace Hotel_neptun2
{
    public partial class Auterling : Window
    {
        public Auterling()
        {
            InitializeComponent();
            SigninButton.Click += SigninButton_Click;
            BackButton.Click += BackButton_Click;
        }

        private void SigninButton_Click(object? sender, RoutedEventArgs e)
        {
            NeptunContext neptunContext = new NeptunContext();
            var users =
                from u in neptunContext.Sotrudnikis
                where LoginTextBox.Text == u.Login
                where PasswordTextBox.Text == u.Password
                select u.IdDolgnosti;
            List<int> ints = users.ToList();

            if (ints.Count() > 0)
            {
                int rol = ints.ElementAt(0);

                if (rol == 1)
                {
                    Meneger meneger = new Meneger();
                    meneger.Show();
                    this.Hide();
                }
                else if (rol == 2)
                {
                    Admin admin = new Admin();
                    admin.Show();
                    this.Hide();

                }
            }
            else
            {

            }
        }

        private void BackButton_Click(object? sender, RoutedEventArgs e)
        {
            SignWindow signWindow = new SignWindow();
            signWindow.Show();
            this.Hide();
        }
    }
}
