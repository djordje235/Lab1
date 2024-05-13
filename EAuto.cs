using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadatak2
{
    internal class EAuto : Auto
    {
        private double kwhzakm; //potrebna količina električne energije u kWh za prelaženje jednog kilometra
        private double cenakwh; //cena električne energije po kWh
        private DateTime datum; //datum kad ističe rok trajanja baterije.

        public EAuto() : base() { }

        public EAuto(string naziv, int godina,double kwhzakm,double cenakwh,DateTime datum) : base(naziv,godina)
        {
            this.kwhzakm = kwhzakm;
            this.cenakwh = cenakwh;
            this.datum = datum;
        }

        public override double cenaKilometra()
        {
            double vcena;
            vcena = kwhzakm * cenakwh;
            int starost = DateTime.Now.Year - godina;
            double povecanje = starost * 0.05;
            return vcena * (povecanje + 1);
        }

        public override void Upis(string fajl)
        {
            base.Upis(fajl);
            using (StreamWriter sw = new StreamWriter(fajl, true))
            {
                sw.WriteLine(this.kwhzakm);
                sw.WriteLine(this.cenakwh);
            }
        }

        public override void Citanje(string fajl)
        {
            base.Citanje(fajl);
            using (StreamReader sr = new StreamReader(fajl, true))
            {
                sr.ReadLine();
                string linija1 = sr.ReadLine();
                this.kwhzakm = double.Parse(linija1);
                string linija2 = sr.ReadLine();
                this.cenakwh = double.Parse(linija2);
            }
        }

        public DateTime Datum
        {
            get { return datum; }
        }

       
    }
}
