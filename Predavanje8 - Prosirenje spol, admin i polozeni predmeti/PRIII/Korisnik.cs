using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRIII
{
    public class Korisnik
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }

        public Image Slika { get; set; }

        public string Spol { get; set; }
        public bool Admin { get; set; }
        public List<PolozeniPredmet> Polozeni { get; set; } = new List<PolozeniPredmet>();
        public override string ToString()
        {
            return $"Korisnicko ime: {KorisnickoIme} ";
        }
    }
}
