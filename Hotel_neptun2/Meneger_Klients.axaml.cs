using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using System.Collections.Generic;
using System.Linq;

namespace Hotel_neptun2
{
    public partial class Meneger_Klients : Window
    {
        bool isAdmin = false;
        public Meneger_Klients()
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
                x.FirstName,
                x.LastName,
                x.Patronyc,
                x.DataBirthday,
                x.Adress,
                x.Email,
                x.Phone,
                x.PassportDannie
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
                First_name = "Фамилия: " + x.FirstName,
                Last_name = "Имя: " + x.LastName,
                Patronymic = "Отчество: " + x.Patronyc,
                Data_birthday = "Дата рождения: " + x.DataBirthday.Value.ToString("dd-MM-yyyy"),
                Adress = "Адрес: " + x.Adress,
                Email = "Email: " + x.Email,
                Phone = "Телефон: " + x.Phone,
                Pasport_dannie = "Документ уд. личность: " + x.PassportDannie
            });
        }

        private void SearchTextBox_TextInput(object? sender, KeyEventArgs e)
        {
            LoadKlient();
        }

        //private async void RedactSotrudnikButton_Click(object? sender, RoutedEventArgs e)
        //{
        //    int button = (int)(sender as Button).Tag;

        //    AddKlient addKlient = new AddKlient(button);
        //    await addKlient.ShowDialog(this);
        //    LoadKlient();
        //}

        //private void DeleteSotrudnikButton_Click(object? sender, RoutedEventArgs e)
        //{
        //    int button = (int)(sender as Button).Tag;

        //    Helper.neptun.Sotrudnikis.Remove(Helper.neptun.Sotrudnikis.Find(button));
        //    Helper.neptun.SaveChanges();
        //    LoadKlient();
        //}

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
            Meneger meneger = new Meneger();
            meneger.Show();
            this.Hide();
        }
    }
}
