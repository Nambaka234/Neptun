using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Hotel_neptun2.database;
using System.Collections.Generic;
using System.Linq;

namespace Hotel_neptun2
{
    public partial class MainWindow : Window
    {
        bool isAdmin = false;
        public MainWindow()
        {
            InitializeComponent();
            InitializeWindow();
            DataContext = isAdmin;
            this.isAdmin = isAdmin;
        }

        public static Bitmap Images;

        private void InitializeWindow()
        {
            SortComboBox.SelectionChanged += SortComboBox_SelectionChanged;
            FilterComboBox.SelectionChanged += LostFocus_SelectionChanged;
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
                x.Mainimage,
                x.Description,
                x.IdClassNomera,
                x.Cost
            });

            if (!string.IsNullOrEmpty(SearchText))
            {
                Nomers = Nomers.Where(x => x.Description.Contains(SearchText));
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
                Description = x.Description,
                x.Mainimage,
                Cost = x.Cost,

                Color = x.Cost == 500 ? Brushes.LightBlue : Brushes.LightGreen
            });
        }

        private void SearchTextBox_TextInput(object? sender, KeyEventArgs e)
        {
            LoadNomer();
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
            InfoWindow infoWindow = new InfoWindow();
            infoWindow.Show();
            this.Hide();
        }

        private void ImageButton_Click(object? sender, RoutedEventArgs e)
        {
            var Image = Helper.neptun.NomeraOtels.Where(x => x.IdNomera == 1).Select(b => b.Mainimage);
            Images = Image.ToList().ElementAt(0);

            Window1 window1 = new Window1();
            window1.Show();
            this.Hide();
        }
    }
}
