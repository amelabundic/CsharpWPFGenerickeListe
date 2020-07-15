using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpWPFKolekcija113
{
    class Trkac
    {
        public int Id { get; set; }

        public static int brojTrkaca = 0;

        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int BrojPobijeda { get; set; }
        public string Drzava { get; set; }

        public Trkac()
        {
            brojTrkaca++;
        }

        public override string ToString()
        {
            return $"{Id} {Ime} {Prezime}\n ";
        }
    }
}
