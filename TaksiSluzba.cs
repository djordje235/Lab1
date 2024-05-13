using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace zadatak2
{
    internal class TaksiSluzba
    {
        private string naziv;
        private double predjenikm; //ukupni
        private double ukupnacena; //ukupni
        private List<Auto> vozila;

        public TaksiSluzba() 
        {
            vozila = new List<Auto>();
        }

        public TaksiSluzba(string naziv, double predjenikm,double ukupnacena)
        {
            this.naziv = naziv;
            this.predjenikm = predjenikm;
            this.ukupnacena = ukupnacena;
            vozila = new List<Auto>();
        }

        public void Dodaj(Auto auto)
        {
            vozila.Add(auto);
        }

        public void izbacipreskupa()
        {
            double prosecnaCena = ukupnacena / predjenikm;

            for (int i = vozila.Count - 1; i >= 0; i--)
            {
                if (vozila[i].cenaKilometra() > prosecnaCena)
                {
                    vozila.RemoveAt(i);
                    i--;
                }
            }
        }

        public void sortiraj()
        {
            vozila.Sort();
        }

        public void proveribaterije()
        {
            foreach(Auto auto in vozila)
            {
                if(auto is EAuto eauto)
                {
                    if(eauto.Datum < DateTime.Now)
                    {
                        throw new PotencijalnaEksplozija("Rok trajanja baterije je istekao.");
                    }
                }
            }
        }

        public void PisiUFajl(string fajl)
        {
            
            using (StreamWriter sw = new StreamWriter(new FileStream(fajl,FileMode.Create)))
            {
                
                sw.WriteLine(this.naziv);
                sw.WriteLine(this.predjenikm);
                sw.WriteLine(this.ukupnacena);
            }
            
            foreach (Auto auto in vozila)
            {
                auto.Upis(fajl);
            }
        }

        public void CitajIzFajl(string fajl)
        {
            List<Auto> noviAutomobili = new List<Auto>(); 
            
            using (StreamReader sr = new StreamReader(new FileStream(fajl, FileMode.Open)))
            {
                naziv = sr.ReadLine();
                string linija1 = sr.ReadLine();
                this.predjenikm = double.Parse(linija1);
                string linija2 = sr.ReadLine();
                this.ukupnacena = double.Parse(linija2);
            }
            
            foreach (Auto auto in vozila.ToList()) 
            {
                auto.Citanje(fajl); 

           
                if (auto is EAuto)
                {
                    var eAuto = new EAuto();
                    eAuto.Citanje(fajl);
                    noviAutomobili.Add(eAuto);
                }
                else if (auto is AutoSUS)
                {
                    var autoSUS = new AutoSUS();
                    autoSUS.Citanje(fajl);
                    noviAutomobili.Add(autoSUS);
                }
            }

           
           
        }
       
        public void Prikazi()
        {
            foreach(Auto auto in vozila)
            {
                auto.prikazi();
               
            }
        }
    }
}
