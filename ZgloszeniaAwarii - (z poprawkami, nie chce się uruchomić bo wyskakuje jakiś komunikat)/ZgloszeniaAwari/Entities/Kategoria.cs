using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZgloszeniaAwari.Entities
{
    internal class Kategoria
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }

        public Zgloszenie Zgloszenie { get; set; }
        public int ZgloszenieId { get; set; }
    }
}