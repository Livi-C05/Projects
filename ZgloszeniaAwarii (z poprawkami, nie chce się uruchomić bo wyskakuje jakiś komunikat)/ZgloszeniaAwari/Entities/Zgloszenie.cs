using System;

namespace ZgloszeniaAwari.Entities
{
    internal class Zgloszenie
    {
        public int Id { get; set; }
        public Osoba TworcaZgloszenia { get; set; }
        public int TworcaZgloszeniaId { get; set; }
        public Osoba PrzypisaneDo { get; set; }
        public int PrzypisaneDoId { get; set; }
        public Kategoria Kategoria { get; set; }
        public int KategoriaId { get; set; }
        public DateTime DataDodania { get; set; }
        public bool Wykonane { get; set; } = false;
        public int CzasPrzyjeciaId { get; set; } // Dodaj kolumnę CzasPrzyjeciaId
        public int CzasRozwiazaniaId { get; set; } // Dodaj kolumnę CzasRozwiazaniaId
        public int OsobaZglaszajacaId { get; set; } // Dodaj kolumnę OsobaZglaszajacaId

        public DateTime CzasPrzyjecia { get; set; }
        public DateTime? CzasRozwiazania { get; set; }
        public Osoba OsobaZglaszajaca { get; set; }
    }
}
