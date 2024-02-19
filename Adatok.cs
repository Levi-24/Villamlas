using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Villamlas
{
    internal class Adatok
    {
        public int nap { get; set; }
        public int[] orankentiAdatok { get; set; }

        public Adatok(int nap, string s)
        {
            var darabok = s.Split(';');
            this.nap = nap;
            this.orankentiAdatok = new int[darabok.Length];
            for (int i = 0; i < darabok.Length; i++)
            {
                orankentiAdatok[i] = int.Parse(darabok[i]);
            }
        }

        public override string ToString()
        {
            string adat = "";
            for (int i = 0; i < orankentiAdatok.Length; i++)
            {
                adat += orankentiAdatok[i] + " ";
            }

            return $"{nap}. {adat};";
        }
    }
}
