using Domain.Models;
using Domain.Services;
using Domain.Utils.IzaberiPodsistemIDopuniEnergiju;

namespace Services.ProizvodnjaServisi
{
    public class KomercijalnaProizvodnjaServis : IProizvodnjaServis
    {
        private readonly IzaberiPodsistemIDopuniEnergiju utility;

        public KomercijalnaProizvodnjaServis()
        {
            utility = new IzaberiPodsistemIDopuniEnergiju();
        }
        public bool ObradiZahtev(double kolicinaEnergije)
        {
            PodsistemProizvodnje najboljiPodsistem = utility.IzaberiNajboljiPodsistem(kolicinaEnergije);

            if (najboljiPodsistem.SifraPodsProiz == "")
            {
                return false;
            }

            if (najboljiPodsistem.PreostalaKolicinaKW < 100) //PITANJE: Da li trebam samo pozvati dopuniEnergiju, ili samo kada kod najboljeg podsistema opadne ispod 100 KW
                                                             //Jer mislim da sve dok ima dovoljno energije da isporuci taj najbolji, on ce se birati. Nisam sigurna da li ovo treba ovako.
            {
                bool dopuna = utility.DopuniEnergiju(14);

                if (dopuna == false)
                {
                    return false;
                }
            }

            double smanjenaKolicinaEnergije = kolicinaEnergije * 0.99; //smanjujemo za 2% zbog nesavrsenosti provodnika

            if (najboljiPodsistem.PreostalaKolicinaKW >= smanjenaKolicinaEnergije)
            {
                najboljiPodsistem.PreostalaKolicinaKW -= smanjenaKolicinaEnergije;
                return true;
            }
            return false;
        }
    }
}
