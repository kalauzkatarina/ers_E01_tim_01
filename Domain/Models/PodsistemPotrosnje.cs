using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PodsistemPotrosnje
    {
        public List<Potrosac> potrosaci = new List<Potrosac>();
        public string NazivPodsistema {  get; set; }
        public string SifraPodsPotr {  get; set; }

        public PodsistemPotrosnje(List<Potrosac> potrosaci, string nazivPodsistema, string sifraPodsPotr)
        {
            this.potrosaci = potrosaci;
            NazivPodsistema = nazivPodsistema;
            SifraPodsPotr = sifraPodsPotr;
        }

        public PodsistemPotrosnje() { }
    }
}
