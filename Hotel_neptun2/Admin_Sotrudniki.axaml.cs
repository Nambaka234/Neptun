using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media;
using Hotel_neptun2.database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hotel_neptun2
{
    public partial class Admin_Sotrudniki : Window
    {
        bool isAdmin = false;
        public Admin_Sotrudniki()
        {

            InitializeComponent();
            InitializeWindow();
            DataContext = isAdmin;
            this.isAdmin = isAdmin;
        }

        private void InitializeWindow()
        {
            SortComboBox.SelectionChanged += SortComboBox_SelectionChanged;
            FilterComboBox.SelectionChanged += LostFocus_SelectionChanged;
            AddSotrudnikButton.Click += AddSotrudnikButton_Click;
            SearchTextBox.AddHandler(KeyUpEvent, SearchTextBox_TextInput, RoutingStrategies.Tunnel);
            BackButton.Click += BackButton_Click;

            LoadSotrudnik();
        }

        private void LoadSotrudnik()
        {
            List<Sotrudniki> sotrudnikis = new List<Sotrudniki>();
            string SearchText = SearchTextBox.Text ?? "";

            var Sotrudnikis = Helper.neptun.Sotrudnikis.Select(x => new
            {
                x.Id,
                x.FirstName,
                x.LastName,
                x.Patronymic,
                x.DataBirthday,
                x.Email,
                x.Phone,
                x.DataPriemaNaRabotu,
                x.Adress,
                x.DataUvolneniya,
                x.IdDolgnosti
            });

            if (!string.IsNullOrEmpty(SearchText))
            {
                Sotrudnikis = Sotrudnikis.Where(x => x.FirstName.Contains(SearchText) || x.LastName.Contains(SearchText) || x.Patronymic.Contains(SearchText));
            }

            if (SortComboBox.SelectedIndex == 0)
            {
                Sotrudnikis = Sotrudnikis.OrderBy(x => x.FirstName);
            }
            else
            {
                Sotrudnikis = Sotrudnikis.OrderByDescending(x => x.FirstName);
            }

            switch (FilterComboBox.SelectedIndex)
            {
                case 1:
                    Sotrudnikis = Sotrudnikis.Where(x => x.DataUvolneniya != null);
                    break;

                case 2:
                    Sotrudnikis = Sotrudnikis.Where(x => x.DataUvolneniya == null);
                    break;
            }

            SotrudnikListBox.Items = Sotrudnikis.Select(x => new
            {
                x.Id,
                First_name = "Фамилия: " + x.FirstName,
                Last_name = "Имя: " + x.LastName,
                Patronymic = "Отчество: " + x.Patronymic,
                Data_birthday = "Дата рождения: " + Convert.ToString(x.DataBirthday),
                Email = "Email: " + x.Email,
                Phone = "Телефон: " + x.Phone,
                Data_priema_na_rabotu = "Дата приема на работу: " + x.DataPriemaNaRabotu.ToString("dd-MM-yyyy"),
                Adress = "Адрес: " + x.Adress,
                Data_uvolneniya = "Дата увольнения: " + x.DataUvolneniya.Value.ToString("dd-MM-yyyy"),

                Color = x.DataUvolneniya != null ? Brushes.LightSalmon : Brushes.LightBlue
            });
        }

        private void SearchTextBox_TextInput(object? sender, KeyEventArgs e)
        {
            LoadSotrudnik();
        }

        private void RedactSotrudnikButton_Click(object? sender, RoutedEventArgs e)
        {
            int button = (int)(sender as Button).Tag;

            AddSotrudnik addSotrudnik = new AddSotrudnik(button);
            addSotrudnik.Show();
            this.Hide();
            LoadSotrudnik();
        }

        private void DeleteSotrudnikButton_Click(object? sender, RoutedEventArgs e)
        {
            DeleteWindow deleteWindow = new DeleteWindow();
            deleteWindow.Show();
            this.Hide();
            LoadSotrudnik();
        }

        private void AddSotrudnikButton_Click(object? sender, RoutedEventArgs e)
        {
            AddSotrudnik addSotrudnik = new AddSotrudnik();
            addSotrudnik.Show();
            this.Hide();
            LoadSotrudnik();
        }

        private void LostFocus_SelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            LoadSotrudnik();
        }

        private void SortComboBox_SelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            LoadSotrudnik();
        }

        private void BackButton_Click(object? sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            this.Hide();
        }
    }
}
