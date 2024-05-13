using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadatak2
{
    internal class PotencijalnaEksplozija :Exception
    {
        public PotencijalnaEksplozija(string message) : base(message) { }
    }
}
