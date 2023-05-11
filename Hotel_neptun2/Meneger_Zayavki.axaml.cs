using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using System.Collections.Generic;
using System.Linq;
using System;
using Hotel_neptun2.database;

namespace Hotel_neptun2
{
    public partial class Meneger_Zayavki : Window
    {
        bool isAdmin = false;
        public Meneger_Zayavki()
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
            SearchTextBox.AddHandler(KeyUpEvent, SearchTextBox_TextInput, RoutingStrategies.Tunnel);
            SearchTextBox2.AddHandler(KeyUpEvent, SearchTextBox2_TextInput, RoutingStrategies.Tunnel);
            SearchTextBox3.AddHandler(KeyUpEvent, SearchTextBox3_TextInput, RoutingStrategies.Tunnel);
            SearchTextBox4.AddHandler(KeyUpEvent, SearchTextBox4_TextInput, RoutingStrategies.Tunnel);            
            SearchButton.Click += SearchButton_Click;
            BackButton.Click += BackButton_Click;

            LoadZayavka();
        }

        private void SearchButton_Click(object? sender, RoutedEventArgs e)
        {
            List<Zayavki> zayavkis = new List<Zayavki>();
            string SearchText = SearchTextBox.Text ?? "";
            string SearchText2 = SearchTextBox2.Text ?? "";
            string SearchText3 = SearchTextBox3.Text ?? "";
            string SearchText4 = SearchTextBox4.Text ?? "";            

            var Zayavki = Helper.neptun.Zayavkis.Select(x => new
            {
                x.Id,
                x.Nomer,
                x.FirstName,
                x.LastName,
                x.Patronimyc,
                x.DataZaezda,
                x.DataViezda,
                x.StatusZaprosa,
                x.CategoriyaNomera,
                x.DataBirthday,
                x.Email,
                x.Phone,
                x.KolVoProgivaushih
            });

            if (!string.IsNullOrEmpty(SearchText))
            {
                Zayavki = Zayavki.Where(x => x.FirstName.Contains(SearchText));
            }

            if (!string.IsNullOrEmpty(SearchText2))
            {
                //if (SearchTextBox2.Text == DateTime.ParseExact(SearchText2.Text, "dd.MM.yyyy"))
                //{
                DateTime dt = DateTime.Parse(SearchTextBox2.Text);
                Zayavki = Zayavki.Where(x => x.DataViezda == dt);
                //};
            }

            if (!string.IsNullOrEmpty(SearchText4))
            {
                //if (SearchTextBox2.Text == DateTime.ParseExact(SearchText2.Text, "dd.MM.yyyy"))
                //{
                DateTime dt = DateTime.Parse(SearchTextBox4.Text);
                Zayavki = Zayavki.Where(x => x.DataZaezda == dt);
                //};
            }

            if (!string.IsNullOrEmpty(SearchText3))
            {
                Zayavki = Zayavki.Where(x => x.Nomer.Contains(SearchText3));
            }

            switch (SortComboBox.SelectedIndex)
            {
                case 1:
                    Zayavki = Zayavki.Where(x => x.CategoriyaNomera == "�����������");
                    break;

                case 2:
                    Zayavki = Zayavki.Where(x => x.CategoriyaNomera == "����������");
                    break;

                case 3:
                    Zayavki = Zayavki.Where(x => x.CategoriyaNomera == "����������");
                    break;

                case 4:
                    Zayavki = Zayavki.Where(x => x.CategoriyaNomera == "��������");
                    break;
            }

            switch (FilterComboBox.SelectedIndex)
            {
                case 1:
                    Zayavki = Zayavki.Where(x => x.StatusZaprosa == "������");
                    break;

                case 2:
                    Zayavki = Zayavki.Where(x => x.StatusZaprosa == "�������������");
                    break;

                case 3:
                    Zayavki = Zayavki.Where(x => x.StatusZaprosa == "����������");
                    break;

                case 4:
                    Zayavki = Zayavki.Where(x => x.StatusZaprosa == "��������");
                    break;
            }

            ZayavkaListBox.Items = Zayavki.Select(x => new
            {
                x.Id,
                Nomer = "�����: " + x.Nomer,
                First_name = "�������: " + x.FirstName,
                Last_name = "���: " + x.LastName,
                Patronymic = "��������: " + x.Patronimyc,
                Kolvo_Chelovek = "���-�� �����������: " + x.KolVoProgivaushih,
                Data_birthday = "���� ��������: " + x.DataBirthday.ToString("dd-MM-yyyy"),
                Email = "Email: " + x.Email,
                Phone = "�������: " + x.Phone,
                Categoriya_nomera = "��������� ������: " + x.CategoriyaNomera,
                Data_zaezda = "���� ������: " + x.DataZaezda.ToString("dd-MM-yyyy HH:mm"),
                Data_viezda = "���� ������: " + x.DataViezda.ToString("dd-MM-yyyy HH:mm"),
                Status_zaprosa = "������ �������: " + x.StatusZaprosa,

                //Color = x.Cost == 500 ? Brushes.LightBlue : Brushes.LightGreen
            });
        }       

        private void LoadZayavka()
        {
            List<Zayavki> zayavkis = new List<Zayavki>();
            string SearchText = SearchTextBox.Text ?? "";
            string SearchText2 = SearchTextBox2.Text ?? "";
            string SearchText3 = SearchTextBox3.Text ?? "";
            string SearchText4 = SearchTextBox4.Text ?? "";

            var Zayavki = Helper.neptun.Zayavkis.Select(x => new
            {
                x.Id,
                x.Nomer,
                x.FirstName,
                x.LastName,
                x.Patronimyc,
                x.DataZaezda,
                x.DataViezda,
                x.StatusZaprosa,
                x.CategoriyaNomera,
                x.DataBirthday,
                x.Email,
                x.Phone,
                x.KolVoProgivaushih
            });

            if (!string.IsNullOrEmpty(SearchText))
            {
                Zayavki = Zayavki.Where(x => x.FirstName.Contains(SearchText));
            }

            //if (!string.IsNullOrEmpty(SearchText2))
            //{
            //    if (SearchTextBox2.Text == @"\b(?<day>\d{1,2})-(?<month>\d{1,2})-(?<year>\d{2,4})")
            //    {
            //        DateTime dt = DateTime.Parse(SearchTextBox2.Text);
            //        Zayavki = Zayavki.Where(x => x.DataZaezda == dt);
            //    };
            //}

            if (!string.IsNullOrEmpty(SearchText3))
            {
                Zayavki = Zayavki.Where(x => x.Nomer.Contains(SearchText3));
            }            

            switch (SortComboBox.SelectedIndex)
            {
                case 1:
                    Zayavki = Zayavki.Where(x => x.CategoriyaNomera == "�����������");
                    break;

                case 2:
                    Zayavki = Zayavki.Where(x => x.CategoriyaNomera == "����������");
                    break;

                case 3:
                    Zayavki = Zayavki.Where(x => x.CategoriyaNomera == "����������");
                    break;

                case 4:
                    Zayavki = Zayavki.Where(x => x.CategoriyaNomera == "��������");
                    break;
            }

            switch (FilterComboBox.SelectedIndex)
            {
                case 1:
                    Zayavki = Zayavki.Where(x => x.StatusZaprosa == "������");
                    break;

                case 2:
                    Zayavki = Zayavki.Where(x => x.StatusZaprosa == "�������������");
                    break;

                case 3:
                    Zayavki = Zayavki.Where(x => x.StatusZaprosa == "����������");
                    break;

                case 4:
                    Zayavki = Zayavki.Where(x => x.StatusZaprosa == "��������");
                    break;
            }

            ZayavkaListBox.Items = Zayavki.Select(x => new
            {
                x.Id,
                Nomer = "�����: " + x.Nomer,
                First_name = "�������: " + x.FirstName,
                Last_name = "���: " + x.LastName,
                Patronymic = "��������: " + x.Patronimyc,
                Kolvo_Chelovek = "���-�� �����������: " + x.KolVoProgivaushih,
                Data_birthday = "���� ��������: " + x.DataBirthday.ToString("dd-MM-yyyy"),
                Email = "Email: " + x.Email,
                Phone = "�������: " + x.Phone,
                Categoriya_nomera = "��������� ������: " + x.CategoriyaNomera,
                Data_zaezda = "���� ������: " + x.DataZaezda.ToString("dd-MM-yyyy HH:mm"),
                Data_viezda = "���� ������: " + x.DataViezda.ToString("dd-MM-yyyy HH:mm"),
                Status_zaprosa = "������ �������: " + x.StatusZaprosa,

                //Color = x.Cost == 500 ? Brushes.LightBlue : Brushes.LightGreen
            });
        }

        private void SearchTextBox_TextInput(object? sender, KeyEventArgs e)
        {
            LoadZayavka();
        }

        private void SearchTextBox2_TextInput(object? sender, KeyEventArgs e)
        {
            LoadZayavka();
        }

        private void SearchTextBox3_TextInput(object? sender, KeyEventArgs e)
        {
            LoadZayavka();
        }

        private void SearchTextBox4_TextInput(object? sender, KeyEventArgs e)
        {
            LoadZayavka();
        }        

        private void LostFocus_SelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            LoadZayavka();
        }

        private void SortComboBox_SelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            LoadZayavka();
        }

        private void RedactZayavkaButton_Click(object? sender, RoutedEventArgs e)
        {
            int button = (int)(sender as Button).Tag;

            AddZayavka addZayavka = new AddZayavka(button);
            addZayavka.Show();
            this.Hide();
            LoadZayavka();
        }

        private void DeleteZayavkaButton_Click(object? sender, RoutedEventArgs e)
        {
            int button = (int)(sender as Button).Tag;

            Helper.neptun.Zayavkis.Remove(Helper.neptun.Zayavkis.Find(button));
            Helper.neptun.SaveChanges();
            LoadZayavka();
            this.Hide();
        }

        private void BackButton_Click(object? sender, RoutedEventArgs e)
        {
            Meneger meneger = new Meneger();
            meneger.Show();
            this.Hide();
        }
    }
}
