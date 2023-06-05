using System;
using System.Windows;
using ZgloszeniaAwari.Entities;

namespace ZgloszeniaAwarii
{
    public partial class AddIncidentWindow : Window
    {
        public AddIncidentWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string userFirstName = tbUserFirstName.Text;
            string userLastName = tbUserLastName.Text;
            string incidentDescription = tbIncidentDescription.Text;
            string assignedFirstName = tbAssignedFirstName.Text;
            string assignedLastName = tbAssignedLastName.Text;

            // Sprawdzenie, czy pola nie są puste
            if (string.IsNullOrEmpty(userFirstName) || string.IsNullOrEmpty(userLastName) ||
                string.IsNullOrEmpty(incidentDescription) || string.IsNullOrEmpty(assignedFirstName) ||
                string.IsNullOrEmpty(assignedLastName))
            {
                MessageBox.Show("Pola nie mogą być puste.");
                return;
            }

            using (ZgloszeniaAwariiDbContext context = new ZgloszeniaAwariiDbContext())
            {
                // Utworzenie obiektów Osoba, Kategoria i Zgloszenie
                Osoba creator = new Osoba() { Imie = userFirstName, Nazwisko = userLastName };
                Osoba assignedTo = new Osoba() { Imie = assignedFirstName, Nazwisko = assignedLastName };
                Kategoria category = new Kategoria() { Opis = incidentDescription };
                Zgloszenie incident = new Zgloszenie()
                {
                    TworcaZgloszenia = creator,
                    PrzypisaneDo = assignedTo,
                    Kategoria = category,
                    DataDodania = DateTime.Now,
                    CzasPrzyjecia = DateTime.Now, // Dodajemy czas przyjęcia zgłoszenia
                    CzasRozwiazania = null, // Inicjalnie ustawiamy czas rozwiązania na null
                    OsobaZglaszajaca = creator // Przypisujemy osobę zgłaszającą
                };

                // Dodanie zgłoszenia do bazy danych
                context.Zgloszenia.Add(incident);
                context.SaveChanges();

                MessageBox.Show("Zgłoszenie zostało dodane.");

                // Zamknięcie okna dialogowego po dodaniu zgłoszenia
                Close();
            }
        }
    }
}
