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
            var auth = new AutentifikacijaPotrosaca(autentifikacijaServis, potrosacServis);
            (bool uspesnost, Potrosac p) = auth.TryLogin(out Potrosac potrosac);
            //if (!uspesnost) return; 

            var meni = new IspisMenija(potrosacServis, auth);
            meni.PrikaziMeni(p);

            //ZAKOMENTARISANJE CTRL+K, ZATIM CTRL+C
            //UKLANJANJE KOMENTARA CTRL+K, ZATIM CTRL+U

            //PodsistemPotrosnje podsistemPotrosnje = new PodsistemPotrosnje("naziv", "naziv123s");

            //Console.WriteLine($"Podsistem potrosnje: {podsistemPotrosnje.NazivPodsistema}\t{podsistemPotrosnje.SifraPodsPotr}");

            //IPotrosaciRepository potrosaciRepository = new PotrosaciRepository();

            //IEnumerable<Potrosac> lista_potrosaca = potrosaciRepository.SviPotrosaci();

            //foreach (var item in lista_potrosaca)
            //{
            //    Console.WriteLine(item.ToString());
            //}

            //IAutentifikacijaServis autentifikacijaServis = new AutentifikacioniServis();

            //(bool uspesnoUlogovanje, Potrosac p) = autentifikacijaServis.Prijava("Katarina", "Kalauz", "08GR74");

            //Console.WriteLine(p.ToString());

            //IProizvodnjeRepository proizvodnjeRepository = new ProizvodnjeRepository();
            //IEnumerable<PodsistemProizvodnje> lista_podsistem = proizvodnjeRepository.SviPodsistemiProizvodnje();
            //IzaberiPodsistemIDopuniEnergiju i = new IzaberiPodsistemIDopuniEnergiju();
            //foreach (var item in lista_podsistem)
            //{
            //    Console.WriteLine(item.ToString());
            //}
            //bool uspesno = i.DopuniEnergiju(22);
            //Console.WriteLine(uspesno);
            //foreach(var item in lista_podsistem)
            //{
            //    Console.WriteLine(item.ToString());
            //}

            //double zahtevanaKolicinaKW = 1000;
            //PodsistemProizvodnje najboljiPodsistem = i.IzaberiNajboljiPodsistem(zahtevanaKolicinaKW);

            //Console.WriteLine("Najbolji podsistem je: \n");
            //Console.WriteLine(najboljiPodsistem.ToString());

            //IProizvodnjaServis garantovanaProizvodnjaServis = new GarantovanaProizvodnjaServis();
            //IProizvodnjaServis komercijalnaProizvodnjaServis = new KomercijalnaProizvodnjaServis();
            //var garantovanoEvidencija = new EvidencijaGarantovanoServis();
            //var komercijalnoEvidencija = new EvidencijaKomercijalnoServis();
            //IPotrosnjaServis ipotrosnja = new PotrosnjaServis(garantovanaProizvodnjaServis, komercijalnaProizvodnjaServis, garantovanoEvidencija, komercijalnoEvidencija);
            //PotrosacServis potrosacServis = new PotrosacServis(ipotrosnja);

            //var potrosaci = potrosaciRepository.SviPotrosaci();
            //foreach (var item in potrosaci)
            //{
            //    double trenutnoZaduzenje = potrosacServis.PregledTrenutnogZaduzenja(item.Id);
            //    Console.WriteLine("Trenutno zaduzenje potrosaca sa imenom i prezimenom: " + item.Ime + " " + item.Prezime + " " + trenutnoZaduzenje);

            //    bool uspesnost_zahteva = potrosacServis.PotrosacZahtev(item.Id, zahtevanaKolicinaKW);

            //    if (uspesnost_zahteva)
            //    {
            //        Console.WriteLine("Uspesno podnet zahtev");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Neuspesno podnet zahtev");
            //    }
            //}

            //var garProizvodnjaServis = new GarantovanaProizvodnjaServis();
            //var komProizvodnjaServis = new KomercijalnaProizvodnjaServis();

            //var potrosnjaServis = new PotrosnjaServis(garProizvodnjaServis, komProizvodnjaServis, garantovanoEvidencija, komercijalnoEvidencija);

            //foreach (var pot in potrosaci)
            //{
            //    {
            //        potrosnjaServis.EvidentirajPotrosnju(pot.Id, zahtevanaKolicinaKW);
            //    }
            //}

            //// Dodavanje nekoliko evidencija za test
            ////komercijalnoEvidencija.EvidentirajIsporuku("19.04.2024 14:32: Izdato je 120 kW.");
            ////komercijalnoEvidencija.EvidentirajIsporuku("19.04.2024 15:45: Izdato je 80 kW.");
            ////komercijalnoEvidencija.EvidentirajIsporuku("19.04.2024 16:20: Izdato je 200 kW.");

            //// Pristup listi evidencija
            //var komercijalneEvidencije = new EvidencijaKomercijalnoRepository();
            //var evidencije = komercijalneEvidencije.SviKomercijalniZapisi();

            //// Ispis evidencija na konzolu
            //Console.WriteLine("Lista komercijalnih evidencija:");
            //foreach (var evidencija in evidencije)
            //{
            //    Console.WriteLine(evidencija);
            //}
        }
    }
}
