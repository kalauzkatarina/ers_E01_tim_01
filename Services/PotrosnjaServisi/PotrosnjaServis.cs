using Domain.Enums;
using Domain.Models;
using Domain.Repositories.PotrosaciRepositories;
using Domain.Services;
using Services.ProizvodnjaServisi;
using Services.ServisiProizvodnje;

namespace Services.ServisiPotrosnje
{
    public class PotrosnjaServis : IPotrosnjaServis
    {
        private IPotrosaciRepository potrosacRepository = new PotrosaciRepository();
        private readonly IProizvodnjaServis garantovanaProizvodnjaServis; //ovo je dodato
        private readonly IProizvodnjaServis komercijalnaProizvodnjaServis; //ovo je dodato
        private readonly IEvidencijaServis garantovanaEvidencija;
        private readonly IEvidencijaServis komercijalnaEvidencija;

        public PotrosnjaServis(IProizvodnjaServis garantovanaProizvodnjaServis, IProizvodnjaServis komercijalnaProizvodnjaServis, IEvidencijaServis garantovano, IEvidencijaServis komercijalno) 
        {
            this.garantovanaProizvodnjaServis = garantovanaProizvodnjaServis; //ovo je dodato
            this.komercijalnaProizvodnjaServis = komercijalnaProizvodnjaServis; //ovo je dodato
            this.garantovanaEvidencija = garantovano;
            this.komercijalnaEvidencija = komercijalno;
        }

        public bool EvidentirajPotrosnju(Guid id, double kolicinaKW)
        {
            double cena;
            Potrosac p = potrosacRepository.PronadjiPotrosac(id);

            if(p.Ime == "")
            {
                return false;
            }

            string zapis = $"{DateTime.Now:dd.MM.yyyy HH:mm}: Izdato je {kolicinaKW} kW.";


            if (p.NacinSnabdevanja == TipSnabdevanja.GARANTOVANO)
            {
                cena = 22.72;
                if (garantovanaProizvodnjaServis.ObradiZahtev(kolicinaKW)) //ovo je izmenjeno
                {
                    double ukupnaCena = kolicinaKW * cena;
                    p.TrenutnoZaduzenje += ukupnaCena;
                    garantovanaEvidencija.EvidentirajIsporuku(zapis);
                    return true;
                }
                return false;
            }
            else if (p.NacinSnabdevanja == TipSnabdevanja.KOMERCIJALNO)
            {
                cena = 43.02;
                if (komercijalnaProizvodnjaServis.ObradiZahtev(kolicinaKW)) //ovo je izmenjeno
                {
                    double ukupnaCena = kolicinaKW * cena;
                    p.TrenutnoZaduzenje += ukupnaCena;
                    komercijalnaEvidencija.EvidentirajIsporuku(zapis);
                    return true;
                }   
                return false;
            }
            return false;
        }
    }
}
