using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}