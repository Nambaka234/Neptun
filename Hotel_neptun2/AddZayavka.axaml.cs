using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.X11;
using Hotel_neptun2.database;
using System;
using System.Linq;

namespace Hotel_neptun2
{
    public partial class AddZayavka : Window
    {
        public string nomera;
        public string statusi;
        public string category;

        public Zayavki zayavki;
        public AddZayavka()
        {
            InitializeComponent();
            SaveButton.Click += AddButton_Click;
            BackButton.Click += BackButton_Click;
            SelectDateButton1.Click += SelectDateButton_Click1;
            SelectDate2Button.Click += SelectDate2Button_Click;
            SelectCategoryButton.Click += SelectCategoryButton_Click;
            SelectNomerButton.Click += SelectNomerButton_Click;
            SelectStatusButton.Click += SelectStatusButton_Click;
            SelectStatusButton2.Click += SelectStatusButton2_Click;
        }

        int idApplication;
        public AddZayavka(int Id)
        {
            InitializeComponent();
            SaveButton.Click += SaveButton_Click;
            BackButton.Click += BackButton_Click;
            SelectDateButton1.Click += SelectDateButton_Click1;
            SelectDate2Button.Click += SelectDate2Button_Click;
            SelectCategoryButton.Click += SelectCategoryButton_Click;
            SelectNomerButton.Click += SelectNomerButton_Click;
            SelectStatusButton.Click += SelectStatusButton_Click;
            SelectStatusButton2.Click += SelectStatusButton2_Click;
            Categoriya_Nomera_ComboBox.SelectionChanged += Categoriya_Nomera_ComboBox_SelectionChanged;
            Status_Zayavki_ComboBox.SelectionChanged += Status_Zayavki_ComboBox_SelectionChanged;
            Ponravivchiysa_nomer_ComboBox.SelectionChanged += Ponravivchiysa_nomer_ComboBox_SelectionChanged;

            this.idApplication = Id;
            zayavki = Helper.neptun.Zayavkis.Find(Id);

            DataContext = zayavki;
            AddCategory();
        }

        private void SelectStatusButton2_Click(object? sender, RoutedEventArgs e)
        {
            status2.Text = ((ComboBoxItem)Status_Zayavki_ComboBox.SelectedItem).Content.ToString();
        }

        private void SelectStatusButton_Click(object? sender, RoutedEventArgs e)
        {
            status.Text = ((ComboBoxItem)Status_Zaprosa_ComboBox.SelectedItem).Content.ToString();
        }

        private void SelectNomerButton_Click(object? sender, RoutedEventArgs e)
        {
            nomer.Text = ((ComboBoxItem)Ponravivchiysa_nomer_ComboBox.SelectedItem).Content.ToString();
        }

        private void SelectCategoryButton_Click(object? sender, RoutedEventArgs e)
        {
            categoriya_nomera.Text = ((ComboBoxItem)Categoriya_Nomera_ComboBox.SelectedItem).Content.ToString();
        }

        private void Ponravivchiysa_nomer_ComboBox_SelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            AddCategory();
        }

        private void Status_Zayavki_ComboBox_SelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            AddCategory();
        }

        private void Categoriya_Nomera_ComboBox_SelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            AddCategory();
        }

        private void AddCategory()
        {
            ComboBoxItem Ponravivchiysa_nomer = (ComboBoxItem)Ponravivchiysa_nomer_ComboBox.SelectedItem;
            ComboBoxItem Categoriya_Nomera = (ComboBoxItem)Categoriya_Nomera_ComboBox.SelectedItem;
            ComboBoxItem Status_Zayavki = (ComboBoxItem)Status_Zaprosa_ComboBox.SelectedItem;

            string nomera = Ponravivchiysa_nomer.ToString();
            string category = Categoriya_Nomera.ToString();
            string statusi = Status_Zayavki.ToString();

            switch (Categoriya_Nomera_ComboBox.SelectedIndex)
            {
                case 0:
                    category = "Одноместный";
                    break;

                case 1:
                    category = "Двуместный";
                    break;

                case 2:
                    category = "Улучшенный";
                    break;

                case 3:
                    category = "Семейный";
                    break;
            }

            switch (Status_Zaprosa_ComboBox.SelectedIndex)
            {
                case 0:
                    statusi = "Заявка";
                    break;

                case 1:
                    statusi = "Забронировано";
                    break;

                case 2:
                    statusi = "Проживание";
                    break;

                case 3:
                    statusi = "Свободен";
                    break;
            }

            switch (Ponravivchiysa_nomer_ComboBox.SelectedIndex)
            {
                case 0:
                    nomera = "101";
                    break;

                case 1:
                    nomera = "102";
                    break;

                case 2:
                    nomera = "103";
                    break;

                case 3:
                    nomera = "104";
                    break;

                case 4:
                    nomera = "105";
                    break;

                case 5:
                    nomera = "106";
                    break;

                case 6:
                    nomera = "107";
                    break;

                case 7:
                    nomera = "108";
                    break;

                case 8:
                    nomera = "109";
                    break;

                case 9:
                    nomera = "110";
                    break;

                case 10:
                    nomera = "201";
                    break;

                case 11:
                    nomera = "202";
                    break;

                case 12:
                    nomera = "203";
                    break;

                case 13:
                    nomera = "204";
                    break;

                case 14:
                    nomera = "205";
                    break;

                case 15:
                    nomera = "206";
                    break;

                case 16:
                    nomera = "207";
                    break;

                case 17:
                    nomera = "208";
                    break;

                case 18:
                    nomera = "209";
                    break;

                case 19:
                    nomera = "210";
                    break;

                case 20:
                    nomera = "211";
                    break;

                case 21:
                    nomera = "212";
                    break;

                case 22:
                    nomera = "213";
                    break;

                case 23:
                    nomera = "214";
                    break;

                case 24:
                    nomera = "215";
                    break;
            }
        }

        private void SaveButton_Click(object? sender, RoutedEventArgs e)
        {
            var redaction = Helper.neptun.Zayavkis.Find(idApplication);

            switch (Categoriya_Nomera_ComboBox.SelectedIndex)
            {
                case 0:
                    redaction.CategoriyaNomera =  "Одноместный";
                    break;

                case 1:
                    redaction.CategoriyaNomera = "Двуместный";
                    break;

                case 2:
                    redaction.CategoriyaNomera = "Улучшенный";
                    break;

                case 3:
                    redaction.CategoriyaNomera = "Семейный";
                    break;
            }


            switch (Status_Zaprosa_ComboBox.SelectedIndex)
            {
                case 0:
                    redaction.StatusZayavki = "Заявка";
                    break;

                case 1:
                    redaction.StatusZayavki = "Забронировано";
                    break;

                case 2:
                    redaction.StatusZayavki = "Проживание";
                    break;

                case 3:
                    redaction.StatusZayavki = "Свободен";
                    break;
            }

            switch (Ponravivchiysa_nomer_ComboBox.SelectedIndex)
            {
                case 0:
                    redaction.Nomer = "101";
                    break;

                case 1:
                    redaction.Nomer = "102";
                    break;

                case 2:
                    redaction.Nomer = "103";
                    break;

                case 3:
                    redaction.Nomer = "104";
                    break;

                case 4:
                    redaction.Nomer = "105";
                    break;

                case 5:
                    redaction.Nomer = "106";
                    break;

                case 6:
                    redaction.Nomer = "107";
                    break;

                case 7:
                    redaction.Nomer = "108";
                    break;

                case 8:
                    redaction.Nomer = "109";
                    break;

                case 9:
                    redaction.Nomer = "110";
                    break;

                case 10:
                    redaction.Nomer = "201";
                    break;

                case 11:
                    redaction.Nomer = "202";
                    break;

                case 12:
                    redaction.Nomer = "203";
                    break;

                case 13:
                    redaction.Nomer = "204";
                    break;

                case 14:
                    redaction.Nomer = "205";
                    break;

                case 15:
                    redaction.Nomer = "206";
                    break;

                case 16:
                    redaction.Nomer = "207";
                    break;

                case 17:
                    redaction.Nomer = "208";
                    break;

                case 18:
                    redaction.Nomer = "209";
                    break;

                case 19:
                    redaction.Nomer = "210";
                    break;

                case 20:
                    redaction.Nomer = "211";
                    break;

                case 21:
                    redaction.Nomer = "212";
                    break;

                case 22:
                    redaction.Nomer = "213";
                    break;

                case 23:
                    redaction.Nomer = "214";
                    break;

                case 24:
                    redaction.Nomer = "215";
                    break;
            }

            switch (Status_Zayavki_ComboBox.SelectedIndex)
            {
                case 0:
                    redaction.StatusZayavki = "Одобрена";
                    break;

                case 1:
                    redaction.StatusZayavki = "Отклонена";
                    break;

                case 2:
                    redaction.StatusZayavki = "На рассмотрении";
                    break;                
            }



            Helper.neptun.SaveChanges();
           
            this.Hide();
            Meneger_Zayavki meneger_Zayavki = new Meneger_Zayavki();
            meneger_Zayavki.Show();
        }

        private void SelectDate2Button_Click(object? sender, RoutedEventArgs e)
        {
            Data_Viezda.Text = dataviezda.SelectedDate.Value.ToString("dd-MM-yyyy");
        }

        private void SelectDateButton_Click1(object? sender, RoutedEventArgs e)
        {
            Data_Zaezda.Text = datazaezda.SelectedDate.Value.ToString("dd-MM-yyyy");
        }

        private void BackButton_Click(object? sender, RoutedEventArgs e)
        {
            Klient klient = new Klient();
            klient.Show();
            this.Hide();
        }

        DatePicker birthDatePicker = new DatePicker();

        private void AddButton_Click(object? sender, RoutedEventArgs e)
        {          
            zayavki = new Zayavki();
            NeptunContext database = new NeptunContext();
            var query6 =
                from kl in database.Zayavkis
                select kl.Id;

            zayavki.Id = Convert.ToInt32(query6.LongCount()) + 1;
            zayavki.FirstName = First_name.Text;
            zayavki.LastName = Lats_name.Text;
            zayavki.Patronimyc = Patronymic.Text;
            zayavki.Nomer = nomer.Text;
            zayavki.CategoriyaNomera = categoriya_nomera.Text;
            zayavki.Email = Email.Text;
            zayavki.Phone = Phone.Text;
            zayavki.KolVoProgivaushih = Kolichestvo_progivaushih.Text;
            zayavki.DataBirthday = Convert.ToDateTime(data_birthday.Text);
            zayavki.DataZaezda = Convert.ToDateTime(Data_Zaezda.Text);
            zayavki.DataViezda = Convert.ToDateTime(Data_Viezda.Text);
            zayavki.StatusZaprosa = status.Text;
            zayavki.StatusZayavki = status2.Text;

            Helper.neptun.Add(zayavki);
            Helper.neptun.SaveChanges();
            this.Hide();
            Klient klient = new Klient();
            klient.Show();
        }
    }
}
