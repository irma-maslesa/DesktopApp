using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRIII
{
    class DBInMemory
    {
        public static List<Korisnik> registrovaniKorisnici { get; set; }
        public static List<string> Spolovi { get; set; }
        public static List<Predmet> NPP2018 { get; set; }

        static DBInMemory()
        {
            registrovaniKorisnici = new List<Korisnik>();

            Spolovi = new List<string>();
            Spolovi.Add("Muško");
            Spolovi.Add("Žensko");
            Spolovi.Add("Neodređeno");

            NPP2018 = new List<Predmet>();

            for (int i = 1; i < 21; i++)
                NPP2018.Add(new Predmet() { Id = i, Naziv = $"Predmet {i}" });
        }
    }
}
