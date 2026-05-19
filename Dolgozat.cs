using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DolgozatCLI
{
    public class Dolgozat
    {
        public string nev {  get; set; }
        public int kor { get; set; }
        public int pontszam { get; set; }
        public Dolgozat(string nev, int kor, int pontszam)
        {
            this.nev = nev;
            this.kor = kor;
            this.pontszam = pontszam;
        }       
        public int erdemJegy()
        {
            if (pontszam >= 80) return 5;
            else if (pontszam >= 60) return 4;
            else if (pontszam >= 40) return 3;
            else if (pontszam >= 20) return 2;
            else return 1;
        }
    }
}
