using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Hotel_neptun2.database;
using System.Collections.Generic;
using System.Linq;

namespace Hotel_neptun2
{
    public partial class Klient : Window
    {
        bool isAdmin = false;
        public Klient()
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
            AddZayavkaButton.Click += AddZayavkaButton_Click;
            AddKlientButton.Click += AddKlientButton_Click;
            BackButton.Click += BackButton_Click;

            LoadNomer();
        }

        private void AddKlientButton_Click(object? sender, RoutedEventArgs e)
        {
            AddKlient addKlient = new AddKlient();
            addKlient.Show();
            this.Hide();
        }

        private void AddZayavkaButton_Click(object? sender, RoutedEventArgs e)
        {
            AddZayavka addZayavka = new AddZayavka();
            addZayavka.Show();
            this.Hide();
        }

        private void LoadNomer()
        {
            List<Clientnomer> nomera = new List<Clientnomer>();

            var Nomers = Helper.neptun.NomeraOtels.Select(x => new
            {
                x.Mainimage,
                x.Nomer,
                x.Description, 
                x.IdClassNomera,
                x.Cost
            });

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
                Nomer = x.Nomer,
                x.Mainimage,
                Description = x.Description,
                Cost = x.Cost,

                Color = x.Cost == 500 ? Brushes.LightBlue : Brushes.LightGreen
            });
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
            SignWindow signWindow = new SignWindow();
            signWindow.Show();
            this.Hide();
        }
    }
}
