using Domain.Enums;
using Domain.Utils.RandomGen;

namespace Domain.Models
{
    public class PodsistemProizvodnje
    {
        public string SifraPodsProiz { get; set; } = "";
        public TipProizvodnje TipProizvodnje { get; set; }
        public string Lokacija { get; set; } = "";
        public double PreostalaKolicinaKW { get; set; }

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
                    s += "ECOGREEN" + " ";
                    break;

                case TipProizvodnje.CVRSTO_GORIVO:
                    s += "CVRSTO_GORIVO" + " ";
                    break;

                case TipProizvodnje.HIDROELEKTRANA:
                    s += "HIDROELEKTRANA" + " ";
                    break;
            }
            s += Lokacija + " " + PreostalaKolicinaKW;
            return s;

            //string tipProizvodnje = TipProizvodnje.ToString();

            //return $"{SifraPodsProiz} {tipProizvodnje} {Lokacija} {PreostalaKolicinaKW}";
        }
    }
}
