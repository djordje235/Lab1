using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadatak2
{
    internal abstract class Auto : IComparable<Auto>
    {
        protected string naziv;
        protected int godina; //godina proizvodnje

        public Auto() { }

        public Auto(string naziv, int godina)
        {
            this.naziv = naziv;
            this.godina = godina;
        }

        public abstract double cenaKilometra();

        public virtual void Upis(string fajl)
        {
            using (StreamWriter sw = new StreamWriter(fajl, true))
            {
                sw.WriteLine(this.naziv);
                sw.WriteLine(this.godina);
            }
        }

        public virtual void Citanje(string fajl)
        {
            using (StreamReader sr = new StreamReader(fajl, true))
            {
                 this.naziv = sr.ReadLine();
                 string linija = sr.ReadLine();
                 this.godina = int.Parse(linija);

            }
        }

        public int CompareTo(Auto other)
        {
            if (this.godina < other.godina) return -1;
            if (this.godina > other.godina) { return 1; }
            return 0;
        }

        public string Naziv
        {
            get { return naziv; }
        }

        public int Godina 
        { 
            get { return godina; } 
        }

        public void prikazi()
        {
            Console.WriteLine("Naziv: " + this.naziv);
            Console.WriteLine("Godina proizvodnje: " + this.godina);
        }


    }
}
