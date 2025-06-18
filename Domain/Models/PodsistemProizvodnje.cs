using Domain.Enums;
using Domain.Utils.RandomGen;

namespace Domain.Models
{
    public class PodsistemProizvodnje
    {
        public string _sifraPodsProiz = "";
        public string SifraPodsProiz
        {
            get { return _sifraPodsProiz; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Greska: sifra ne moze biti null!");
                }
                _sifraPodsProiz = value;
            }
        }
        public TipProizvodnje TipProizvodnje { get; set; }
        public string _lokacija = "";
        public string Lokacija
        {
            get { return _lokacija; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Greska: lokacija ne moze biti null!");
                }
                _lokacija = value;
            }
        }
        public double _preostalaKolicinaKW;
        public double PreostalaKolicinaKW
        {
            get { return _preostalaKolicinaKW; }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Greska: preostala kolicina ne moze biti negativna vrednost!");
                }
            }
        }

        public PodsistemProizvodnje(string sifraPodsProiz, TipProizvodnje tipProizvodnje, string lokacija, double minVrednost, double maxVrednost)
        {
            SifraPodsProiz = sifraPodsProiz;
            TipProizvodnje = tipProizvodnje;
            Lokacija = lokacija;
            PreostalaKolicinaKW = new Generator().Generisi(minVrednost, maxVrednost);
        }

        public PodsistemProizvodnje()
        {
        }

        public override string? ToString()
        {
            string s = SifraPodsProiz + " ";

            switch (TipProizvodnje)
            {
                case TipProizvodnje.ECOGREEN:
                    s += "ECOGREEN ";
                    break;

                case TipProizvodnje.CVRSTO_GORIVO:
                    s += "CVRSTO_GORIVO ";
                    break;

                case TipProizvodnje.HIDROELEKTRANA:
                    s += "HIDROELEKTRANA ";
                    break;
            }
            s += Lokacija + " " + PreostalaKolicinaKW;
            return s;

            //string tipProizvodnje = TipProizvodnje.ToString();

            //return $"{SifraPodsProiz} {tipProizvodnje} {Lokacija} {PreostalaKolicinaKW}";
        }
    }
}
