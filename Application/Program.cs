using Domain.Models;
using Domain.Repositories.EvidencijaKomercijalnoRepositories;
using Domain.Repositories.PotrosaciRepositories;
using Domain.Repositories.ProizvodnjeRepositories;
using Domain.Services;
using Domain.Utils.IzaberiPodsistemIDopuniEnergiju;
using Presentation.Autentifikacija;
using Presentation.Meni;
using Services.AutentifikacioniServisi;
using Services.EvidencijaServisi;
using Services.PotrosacServisi;
using Services.ProizvodnjaServisi;
using Services.ServisiPotrosnje;
using Services.ServisiProizvodnje;
using System.Buffers;

namespace Application
{
    public class Program
    {
        static void Main(string[] args)
        {
            //inicijalizacija servisa
            IAutentifikacijaServis autentifikacijaServis = new AutentifikacioniServis();
            IProizvodnjaServis garantovanaProizvodnjaServis = new GarantovanaProizvodnjaServis();
            IProizvodnjaServis komercijalnaProizvodnjaServis = new KomercijalnaProizvodnjaServis();
            IEvidencijaServis garantovanaEvidencija = new EvidencijaGarantovanoServis();
            IEvidencijaServis komercijalnaEvidencija = new EvidencijaKomercijalnoServis();
            IPotrosnjaServis potrosnjaServis = new PotrosnjaServis(garantovanaProizvodnjaServis, komercijalnaProizvodnjaServis, garantovanaEvidencija, komercijalnaEvidencija);
            IPotrosacServis potrosacServis = new PotrosacServis(potrosnjaServis);

            //obrada autentifikacije
            var auth = new AutentifikacijaPotrosaca(autentifikacijaServis);
            (bool uspesnost, Potrosac p) = auth.TryLogin(out Potrosac potrosac);
            //if (!uspesnost) return; 

            var meni = new IspisMenija(potrosacServis, auth);
            meni.PrikaziMeni(p);
            
        }
    }
}
