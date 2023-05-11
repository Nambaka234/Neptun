using Avalonia.Controls;
using Avalonia.Interactivity;
using Hotel_neptun2.database;
using System.Collections.Generic;
using System;
using System.Linq;
using System.IO;

namespace Hotel_neptun2
{
    public partial class AddNomer : Window
    {
        public NomeraOtel nomera;
        public AddNomer()
        {
            InitializeComponent();
            SaveButton.Click += AddButton_Click;
            BackButton.Click += BackButton_Click;
            SelectFileButton.Click += SelectFileButton_Click;
        }

        public AddNomer(int Id)
        {
            InitializeComponent();
            SaveButton.Click += SaveButton_Click;
            BackButton.Click += BackButton_Click;
            SelectFileButton.Click += SelectFileButton_Click;
            nomera = Helper.neptun.NomeraOtels.Find(Id);

            DataContext = nomera;
        }

        private void BackButton_Click(object? sender, RoutedEventArgs e)
        {
            Admin_Nomera admin_Nomera = new Admin_Nomera();
            admin_Nomera.Show();
            this.Hide();
        }

        private void SaveButton_Click(object? sender, RoutedEventArgs e)
        {
            Helper.neptun.SaveChanges();
            this.Hide();
        }

        private void AddButton_Click(object? sender, RoutedEventArgs e)
        {
            nomera = new NomeraOtel();
            NeptunContext database = new NeptunContext();
            var query6 =
                from nom in database.NomeraOtels
                select nom.IdNomera;

            nomera.IdNomera = Convert.ToInt32(query6.LongCount()) + 1;
            nomera.Description = Description.Text;
            nomera.Nomer = Nomer.Text;
            nomera.Cost = Decimal.Parse(Cost.Text);
            nomera.IdClassNomera = ClassComboBox.SelectedIndex + 1;
            nomera.Mainimagepeth = ImagePathTextBox.Text;

            Helper.neptun.Add(nomera);
            Helper.neptun.SaveChanges();
            this.Hide();
        }

        private readonly FileDialogFilter fileFilter = new FileDialogFilter()
        {
            Extensions = new List<string>() { "png", "jpg", "jpeg" },
            Name = "Image Files"
        };

        private async void SelectFileButton_Click(object? sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filters?.Add(fileFilter);

            string[]? result = await dialog.ShowAsync(this);
            if (result == null)
                return;

            string imageName = Path.GetFileName(result[0]);
            File.Copy(result[0], $"./images/{imageName}", true);
            nomera.Mainimagepeth = $"\\images\\{imageName}";
            ImagePathTextBox.Text = nomera.Mainimagepeth;
        }
    }
}
