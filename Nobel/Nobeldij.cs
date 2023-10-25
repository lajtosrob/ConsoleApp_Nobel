using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobel
{
    internal class Nobeldij
    {


        int evszam;
        string tipus;
        string keresztnev;
        string vezeteknev;

        public Nobeldij(int evszam, string tipus, string keresztnev, string vezeteknev)
        {
            this.evszam = evszam;
            this.tipus = tipus;
            this.keresztnev = keresztnev;
            this.vezeteknev = vezeteknev;
        }

        public int Evszam { get => evszam; set => evszam = value; }
        public string Tipus { get => tipus; set => tipus = value; }
        public string Keresztnev { get => keresztnev; set => keresztnev = value; }
        public string Vezeteknev { get => vezeteknev; set => vezeteknev = value; }

    }
}
