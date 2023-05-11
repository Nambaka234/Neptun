using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media;
using Hotel_neptun2.database;
using System.Collections.Generic;
using System.Linq;

namespace Hotel_neptun2
{
    public partial class Admin_Nomera : Window
    {
        bool isAdmin = false;
        public Admin_Nomera()
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
            AddNomerButton.Click += AddNomerButton_Click;
            SearchTextBox.AddHandler(KeyUpEvent, SearchTextBox_TextInput, RoutingStrategies.Tunnel);
            BackButton.Click += BackButton_Click;

            LoadNomer();
        }

        private void LoadNomer()
        {
            List<NomeraOtel> nomera = new List<NomeraOtel>();
            string SearchText = SearchTextBox.Text ?? "";

            var Nomers = Helper.neptun.NomeraOtels.Select(x => new
            {
                x.IdNomera,
                x.Mainimage,
                x.Description,
                x.IdClassNomera,
                x.Cost,
                x.Nomer
            });

            if (!string.IsNullOrEmpty(SearchText))
            {
                Nomers = Nomers.Where(x => x.Nomer.Contains(SearchText));
            }

            if (SortComboBox.SelectedIndex == 0)
            {
                Nomers = Nomers.OrderBy(x => x.Cost);
            }
            else
            {
                Nomers = Nomers.OrderByDescending(x => x.Cost);
            }

            switch (FilterComboBox.SelectedIndex)
            {
                case 1:
                    Nomers = Nomers.Where(x => x.IdClassNomera == 1);
                    break;

                case 2:
                    Nomers = Nomers.Where(x => x.IdClassNomera == 2);
                    break;

                case 3:
                    Nomers = Nomers.Where(x => x.IdClassNomera == 3);
                    break;

                case 4:
                    Nomers = Nomers.Where(x => x.IdClassNomera == 4);
                    break;
            }

            NomerListBox.Items = Nomers.Select(x => new
            {
                x.IdNomera,
                x.IdClassNomera,
                Description = x.Description,
                x.Mainimage,
                Cost = x.Cost,
                Nomer = x.Nomer,

                Color = x.IdClassNomera == 1 ? Brushes.LightBlue : Brushes.LightGreen
            });
        }

        private void SearchTextBox_TextInput(object? sender, KeyEventArgs e)
        {
            LoadNomer();
        }

        private void AddNomerButton_Click(object? sender, RoutedEventArgs e)
        {
            AddNomer addNomer = new AddNomer();
            addNomer.Show();
            this.Hide();
        }

        private void RedactNomerButton_Click(object? sender, RoutedEventArgs e)
        {
            int button = (int)(sender as Button).Tag;

            AddNomer addNomer = new AddNomer(button);
            addNomer.Show();
            LoadNomer();
            this.Hide();
        }

        private void LostFocus_SelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            LoadNomer();
        }

        private void SortComboBox_SelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            LoadNomer();
        }

        private void BackButton_Click(object? sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            this.Hide();
        }
    }
}
