using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IspisServisi
{
    public class IspisServis : IIspisServis
    {
        public IspisServis() { }

        public void Ispisi(string ispis)
        {
            Console.WriteLine(ispis);
        }
    }
}
