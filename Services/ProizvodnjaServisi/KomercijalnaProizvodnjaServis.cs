using Domain.Models;
using Domain.Repositories.ProizvodnjeRepositories;
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

            if (kolicinaEnergije <= 0)
            {
                return false;
            }

            if (najboljiPodsistem.PreostalaKolicinaKW < 100) 
            {
                bool dopuna = utility.DopuniEnergiju(14);

                if (dopuna == false)
                {
                    return false;
                }
            }

            double smanjenaKolicinaEnergije = kolicinaEnergije * 0.99; 

            if (najboljiPodsistem.PreostalaKolicinaKW >= smanjenaKolicinaEnergije)
            {
                najboljiPodsistem.PreostalaKolicinaKW -= smanjenaKolicinaEnergije;
                return true;
            }
            return false;
        }
    }
}
