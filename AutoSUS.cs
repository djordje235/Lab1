using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadatak2
{
    internal class AutoSUS :Auto
    {
        private double ltpokm; //potrošnja u litrima goriva po pređenom kilometru
        private double cenapolt; //cenu goriva po litru

        public AutoSUS()  : base() { }

        public AutoSUS(string naziv, int godina,double cenapokm,double cenapolt) : base(naziv,godina) 
        {
            this.ltpokm = cenapokm;
            this.cenapolt = cenapolt;
        }

        public override double cenaKilometra()
        {
            double vcena;
            vcena = ltpokm * cenapolt;
            int starost = DateTime.Now.Year - godina;
            double povecanje = starost * 0.1;
            return vcena * (povecanje + 1);
        }

        public override void Upis(string fajl)
        {
            base.Upis(fajl);
            using (StreamWriter sw = new StreamWriter(fajl, true))
            {
                sw.WriteLine(this.ltpokm);
                sw.WriteLine(this.cenapolt);
            }
        }

        public override void Citanje(string fajl)
        {
            base.Citanje(fajl);
            using (StreamReader sr = new StreamReader(fajl, true))
            {
                sr.ReadLine();
                string linija1 = sr.ReadLine();
                this.ltpokm = double.Parse(linija1);
                string linija2 = sr.ReadLine();
                this.cenapolt = double.Parse(linija2);
            }
        }




    }
}
