using Avalonia.Controls;
using Avalonia.Interactivity;
using Hotel_neptun2.database;
using System;
using System.Linq;

namespace Hotel_neptun2
{
    public partial class AddKlient : Window
    {
        public Client klients;
        public AddKlient()
        {
            InitializeComponent();
            SaveButton.Click += AddButton_Click;
            BackButton.Click += BackButton_Click;
        }

        public AddKlient(int Id)
        {
            InitializeComponent();
            SaveButton.Click += SaveButton_Click;
            BackButton.Click += BackButton_Click;
            klients = Helper.neptun.Clients.Find(Id);

            DataContext = klients;
        }

        private void BackButton_Click(object? sender, RoutedEventArgs e)
        {
            Admin_Klients admin_Klients = new Admin_Klients();
            admin_Klients.Show();
            this.Hide();
        }

        private void SaveButton_Click(object? sender, RoutedEventArgs e)
        {
            Helper.neptun.SaveChanges();
            this.Hide();
        }

        private void AddButton_Click(object? sender, RoutedEventArgs e)
        {
            klients = new Client();
            NeptunContext database = new NeptunContext();
            var query6 =
                from kl in database.Clients
                select kl.Id;

            klients.Id = Convert.ToInt32(query6.LongCount()) + 1;
            klients.FirstName = First_name.Text;
            klients.LastName = Lats_name.Text;
            klients.Patronyc = Patronymic.Text;
            klients.DataBirthday = Convert.ToDateTime(data_birthday.Text);
            klients.Email = Email.Text;
            klients.Phone = Phone.Text;
            klients.Adress = Adress.Text;
            klients.PassportDannie = Passport_Dannie.Text;
            klients.DataProgivaniya = Convert.ToDateTime(Data_progivaniya.Text);

            Helper.neptun.Add(klients);
            Helper.neptun.SaveChanges();
            this.Hide();
        }
    }
}
