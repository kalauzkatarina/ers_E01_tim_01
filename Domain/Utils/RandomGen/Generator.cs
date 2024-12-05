using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Utils.RandomGen
{
    public class Generator
    {

        private readonly Random random = new Random();
        public double Generisi(double x, double y)
        {
            // x ce biti donja granica, y ce biti gornja granica
            //izmedju njih treba da se generise nasumican broj
            //random.NextDouble() generise nasumican broj u intervalu [0.0, 1.0)
            //y - x dobijemo neki opseg
            //random.NextDouble() * (y - x) skaliramo taj nas nasumican broj na odgovarajuci opseg
            //+x se dodaje, da bih bili sigurni da ce biti u tom opsegu nasumicna vrednost

            return random.NextDouble() * (y - x) + x;
        }
    }
}
