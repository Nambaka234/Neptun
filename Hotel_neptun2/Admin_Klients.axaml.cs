using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using System.Collections.Generic;
using System.Linq;

namespace Hotel_neptun2
{
    public partial class Admin_Klients : Window
    {
        bool isAdmin = false;
        public Admin_Klients()
        {
            InitializeComponent();
            InitializeWindow();
            DataContext = isAdmin;
            this.isAdmin = isAdmin;
        }

        private void InitializeWindow()
        {
            SortComboBox.SelectionChanged += SortComboBox_SelectionChanged;
            AddKlientButton.Click += AddKlientButton_Click;
            SearchTextBox.AddHandler(KeyUpEvent, SearchTextBox_TextInput, RoutingStrategies.Tunnel);
            BackButton.Click += BackButton_Click;

            LoadKlient();
        }

        private void LoadKlient()
        {
            List<Klient> klients = new List<Klient>();
            string SearchText = SearchTextBox.Text ?? "";

            var Klients = Helper.neptun.Clients.Select(x => new
            {
                x.Id,
                x.FirstName,
                x.LastName,
                x.Patronyc,
                x.DataBirthday,
                x.Adress,
                x.Email,
                x.Phone,
                x.PassportDannie,
                x.DataProgivaniya
            });

            if (!string.IsNullOrEmpty(SearchText))
            {
                Klients = Klients.Where(x => x.FirstName.Contains(SearchText) || x.LastName.Contains(SearchText) || x.PassportDannie.Contains(SearchText));
            }

            if (SortComboBox.SelectedIndex == 0)
            {
                Klients = Klients.OrderBy(x => x.FirstName);
            }
            else
            {
                Klients = Klients.OrderByDescending(x => x.FirstName);
            }

            KlientListBox.Items = Klients.Select(x => new
            {
                x.Id,
                First_name = "Фамилия: " + x.FirstName,
                Last_name = "Имя: " + x.LastName,
                Patronymic = "Отчество: " + x.Patronyc,
                Data_birthday = "Дата рождения: " + x.DataBirthday.Value.ToString("dd-MM-yyyy"),
                Adress = "Адрес: " + x.Adress,
                Email = "Email: " + x.Email,
                Phone = "Телефон: " + x.Phone,
                Pasport_dannie = "Документация: " + x.PassportDannie,
                Data_progivaniya = "Дата проживания: " + x.DataProgivaniya.Value.ToString("dd-MM-yyyy")
            });
        }

        private void SearchTextBox_TextInput(object? sender, KeyEventArgs e)
        {
            LoadKlient();
        }

        private void RedactKlientButton_Click(object? sender, RoutedEventArgs e)
        {
            int button = (int)(sender as Button).Tag;

            AddKlient addKlient = new AddKlient(button);
            addKlient.Show();
            this.Hide();
            LoadKlient();
        }

        private void DeleteKlientButton_Click(object? sender, RoutedEventArgs e)
        {
            int button = (int)(sender as Button).Tag;

            Helper.neptun.Clients.Remove(Helper.neptun.Clients.Find(button));
            Helper.neptun.SaveChanges();
            this.Hide();
            LoadKlient();
        }

        private void AddKlientButton_Click(object? sender, RoutedEventArgs e)
        {
            AddKlient addKlient = new AddKlient();
            addKlient.Show();
            this.Hide();
        }

        private void LostFocus_SelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            LoadKlient();
        }

        private void SortComboBox_SelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            LoadKlient();
        }

        private void BackButton_Click(object? sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            this.Hide();
        }
    }
}
