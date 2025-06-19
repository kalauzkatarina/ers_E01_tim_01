using System.Runtime.CompilerServices;

namespace Domain.Models
{
    public class PodsistemPotrosnje
    {
        public string _nazivPodsistema = "";
        public string NazivPodsistema
        {
            get { return _nazivPodsistema; }
            set
            {
                if(value == null)
                {
                    throw new ArgumentNullException("Greska: naziv podsistema ne moze biti null!");
                }
                _nazivPodsistema = value;
            }
        }
        public string _sifraPodsPotr = "";
        public string SifraPodsPotr
        {
            get { return  _sifraPodsPotr; }
            set
            {
                if(value == null)
                {
                    throw new ArgumentNullException("Greska: sifra podsistema potrosnje ne moze biti null!");
                }
                _sifraPodsPotr = value;
            }
        }

        public PodsistemPotrosnje(string nazivPodsistema, string sifraPodsPotr)
        {
            NazivPodsistema = nazivPodsistema;
            SifraPodsPotr = sifraPodsPotr;
        }

        public PodsistemPotrosnje() { }

        public override string? ToString()
        {
            string s = NazivPodsistema + " " + SifraPodsPotr;
            return s;
        }
    }
}
