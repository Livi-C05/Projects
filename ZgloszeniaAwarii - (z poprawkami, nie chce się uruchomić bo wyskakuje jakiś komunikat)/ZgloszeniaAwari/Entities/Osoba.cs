using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZgloszeniaAwari.Entities
{
    internal class Osoba
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public List<Zgloszenie> zgloszenia { get; set; } = new List<Zgloszenie>();
    }
}