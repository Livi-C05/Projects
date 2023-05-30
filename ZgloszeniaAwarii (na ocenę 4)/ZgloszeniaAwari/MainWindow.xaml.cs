using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ZgloszeniaAwari.Entities;

namespace ZgloszeniaAwarii
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadZgloszenia();
        }

        private void btnDodajZgloszenie_Click(object sender, RoutedEventArgs e)
        {
            string ImieUzytkownika = tbImieUzytkownika.Text;
            string NazwiskoUzytkownika = tbNazwiskoUzytkownika.Text;
            string opisAwarii = tbOpisAwarii.Text;
            string ImiePrzypisane = tbImiePrzypisane.Text;
            string NazwiskoPrzypisane = tbNazwiskoPrzypisane.Text;
            string nazwaKategori = tbNazwaKategori.Text;
            if (string.IsNullOrEmpty(ImieUzytkownika) || string.IsNullOrEmpty(NazwiskoUzytkownika) ||
                string.IsNullOrEmpty(opisAwarii) || string.IsNullOrEmpty(ImiePrzypisane) ||
                string.IsNullOrEmpty(NazwiskoPrzypisane) || string.IsNullOrEmpty(nazwaKategori))
            {
                MessageBox.Show("Pola nie mogą być puste.");
                return;
            }
            using (ZgloszeniaAwariiDbContext context = new ZgloszeniaAwariiDbContext())
            {
                Osoba Tworca = new Osoba() { Imie = ImieUzytkownika, Nazwisko = NazwiskoUzytkownika };
                Osoba PrzypisanyDo = new Osoba() { Imie = ImiePrzypisane, Nazwisko = NazwiskoPrzypisane };
                Kategoria kategoria = new Kategoria() { Opis = opisAwarii, Nazwa = nazwaKategori };
                Zgloszenie Zgloszenie = new Zgloszenie()
                {
                    TworcaZgloszenia = Tworca,
                    PrzypisaneDo = PrzypisanyDo,
                    Kategoria = kategoria,
                    DataDodania = DateTime.Now
                };
                context.Zgloszenia.Add(Zgloszenie);
                context.SaveChanges();
                LoadZgloszenia();
            }
        }

        private void btnUsunZgloszenie_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int id = (int)button.Tag;
            using (ZgloszeniaAwariiDbContext context = new ZgloszeniaAwariiDbContext())
            {
                var doUsuniecia = context.Zgloszenia.FirstOrDefault(z => z.Id == id);
                context.Zgloszenia.Remove(doUsuniecia);
                context.SaveChanges();
            }
            LoadZgloszenia();
        }

        private void LoadZgloszenia()
        {
            using (ZgloszeniaAwariiDbContext context = new ZgloszeniaAwariiDbContext())
            {
                var listaZgloszen = context.Zgloszenia.Include(z => z.TworcaZgloszenia)
                    .Include(z => z.PrzypisaneDo).Include(z => z.Kategoria).ToList();
                dgZgloszenia.ItemsSource = listaZgloszen;
            }
        }
    }
}