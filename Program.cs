using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadatak2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TaksiSluzba sluzba = new TaksiSluzba("Taksi Centar", 2, 3);

          
            EAuto auto1 = new EAuto("Tesla Model S", 2020, 0.2, 0.15, new DateTime(2028, 12, 31));
            EAuto auto2 = new EAuto("Nissan Leaf", 2018, 0.18, 0.12, new DateTime(2026, 12, 31));
            EAuto auto3 = new EAuto("BMW i3", 2019, 0.22, 0.13, new DateTime(2027, 12, 31));
            AutoSUS auto4 = new AutoSUS("Toyota Corolla", 2017, 0.07, 1.5);
            AutoSUS auto5 = new AutoSUS("Honda Civic", 2016, 0.08, 6.6);
            AutoSUS auto6 = new AutoSUS("Ford Focus", 2015, 0.09, 1.4);
            AutoSUS preskupauto = new AutoSUS("Preskupi SUS", 2019, 10, 3.5);

            sluzba.Dodaj(auto1);
            sluzba.Dodaj(auto2);
            sluzba.Dodaj(auto3);
            sluzba.Dodaj(auto4);
            sluzba.Dodaj(auto5);
            sluzba.Dodaj(auto6);
            sluzba.Dodaj(preskupauto);

           

            sluzba.Prikazi();
            Console.WriteLine("");

            string putanja = "taksi_sluzba.txt";
            sluzba.PisiUFajl(putanja);


            TaksiSluzba novasluzba = new TaksiSluzba();
            sluzba.CitajIzFajl(putanja);


            novasluzba.izbacipreskupa();
            novasluzba.Prikazi();
            Console.WriteLine("");

            sluzba.sortiraj();
            sluzba.Prikazi();
            

            try
            {
                sluzba.proveribaterije();
                Console.WriteLine("Sve baterije su u dobrom stanju.");
            }
            catch (PotencijalnaEksplozija ex)
            {
                Console.WriteLine($"Greška: {ex.Message}");
            }
        }
    }
}
