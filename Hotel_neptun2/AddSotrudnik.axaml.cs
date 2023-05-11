using Avalonia.Controls;
using Avalonia.Interactivity;
using Hotel_neptun2.database;
using System;
using System.Linq;


namespace Hotel_neptun2
{
    public partial class AddSotrudnik : Window
    {
        public Sotrudniki sotrudniki;
        public AddSotrudnik()
        {
            InitializeComponent();
            SaveButton.Click += AddButton_Click;
            BackButton.Click += BackButton_Click;
        }

        public AddSotrudnik(int Id)
        {
            InitializeComponent();
            SaveButton.Click += SaveButton_Click;
            BackButton.Click += BackButton_Click;
            sotrudniki = Helper.neptun.Sotrudnikis.Find(Id);

            DataContext = sotrudniki;
        }

        private void BackButton_Click(object? sender, RoutedEventArgs e)
        {
            Admin_Sotrudniki admin_Sotrudniki = new Admin_Sotrudniki();
            admin_Sotrudniki.Show();
            this.Hide();
        }

        private void AddButton_Click(object? sender, RoutedEventArgs e)
        {
            DateTime dateOnly = Convert.ToDateTime(data_birthday.Text);
            sotrudniki = new Sotrudniki();
            NeptunContext database = new NeptunContext();
            var query6 =
                from so in database.Sotrudnikis
                select so.Id;

            sotrudniki.Id = Convert.ToInt32(query6.LongCount()) + 1;
            sotrudniki.IdDolgnosti = DolgnostComboBox.SelectedIndex + 1;
            sotrudniki.FirstName = First_name.Text;
            sotrudniki.LastName = Lats_name.Text;
            sotrudniki.Patronymic = Patronymic.Text;
            sotrudniki.DataBirthday = dateOnly;
            sotrudniki.Email = Email.Text;
            sotrudniki.Phone = Phone.Text;
            sotrudniki.DataPriemaNaRabotu = Convert.ToDateTime(data_priema_na_rabotu.Text);
            sotrudniki.Adress = Adress.Text;
            sotrudniki.Login = Login.Text;
            sotrudniki.Password = Password.Text;
            sotrudniki.DataUvolneniya = Convert.ToDateTime(Data_uvolneniya.Text);

            Helper.neptun.Add(sotrudniki);
            Helper.neptun.SaveChanges();
            this.Hide();
        }

        private void SaveButton_Click(object? sender, RoutedEventArgs e)
        {
            Helper.neptun.SaveChanges();
            this.Hide();
        }
    }
}
