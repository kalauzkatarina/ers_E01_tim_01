using Domain.Enums;
using Domain.Models;
using Domain.Repositories.EvidencijaKomercijalnoRepositories;
using Domain.Repositories.PotrosaciRepositories;
using Domain.Services;
using Presentation.Autentifikacija;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Meni
{
    public class IspisMenija
    {
        private readonly IPotrosacServis potrosacServis;
        private readonly AutentifikacijaPotrosaca autentifikacijaPotrosaca;
        private readonly IPotrosaciRepository potrosaciRepository = new PotrosaciRepository();

        private Potrosac trenutniPotrosac;

        public IspisMenija(IPotrosacServis potrosacServis, AutentifikacijaPotrosaca autentifikacijaPotrosaca)
        {
            this.potrosacServis = potrosacServis;
            this.autentifikacijaPotrosaca = autentifikacijaPotrosaca;
        }

        public void PrikaziMeni(Potrosac trenutniPotrosac)
        {
            Console.WriteLine("Dobrodošli u sistem za evidenciju potrošnje energije!\n");

            bool kraj = false;
            while (!kraj)
            {
                Console.WriteLine("\n1. Zahtev za dobijanje električne energije\n2. Prikaži trenutno zaduženje\n3. Unos novog potrošača\n4. Pregled svih potrošača\n5. Odjava");
                Console.WriteLine("Izaberite opciju: ");
                string opcija = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(opcija))
                    continue;

                switch(opcija)
                {
                    case "1":
                        {
                            //podnesi zahtev za dobijanje elektricne energije

                            double kolicinaEnergije;
                            Console.WriteLine("Unesite zahtevanu energiju: ");
                            kolicinaEnergije = double.Parse(Console.ReadLine());
                            bool uspesnostZahtevanja = potrosacServis.PotrosacZahtev(trenutniPotrosac.Id, kolicinaEnergije);

                            if (!uspesnostZahtevanja)
                            {
                                Console.WriteLine("Neuspešan zahtev za energiju!\n");
                                return;
                            }

                            Console.WriteLine("Uspešan zahtev energije.\n");
                            if(trenutniPotrosac.NacinSnabdevanja == TipSnabdevanja.KOMERCIJALNO)
                            {
                                IEvidencijaKomercijalnoRepository komercijalniZapisi = new EvidencijaKomercijalnoRepository();
                                var zapisi = komercijalniZapisi.SviKomercijalniZapisi();
                                foreach(var evidencija in zapisi)
                                {
                                    Console.WriteLine(evidencija);
                                }
                            }
                            break;
                        }

                    case "2" :
                        {
                            //pregled trenutnog zaduzenja
                            double trenutnoZaduzenje;
                            trenutnoZaduzenje = potrosacServis.PregledTrenutnogZaduzenja(trenutniPotrosac.Id);
                            Console.WriteLine("Trenutno zaduženje potrošača je: " + trenutnoZaduzenje);
                            break;
                        }

                    case "3" :
                        {
                            //unos novog potrosaca

                            //mi cemo dodeliti neki id, jer je Guid sto random generise

                            Console.WriteLine("Unesite ime i prezime potrošača: ");
                            string imeIPrezime = Console.ReadLine()?.Trim() ?? "";

                            Console.WriteLine("Unesite broj potrošačkog ugovora: ");
                            string brojPotrosackogUgovora = Console.ReadLine()?.Trim() ?? "";

                            Console.WriteLine("Unesite način snabdevanja (0 - GARANTOVANO, 1 -KOMERCIJALNO): ");
                            int odgovor = int.Parse(Console.ReadLine()?.Trim() ?? "");
                            TipSnabdevanja nacinSnabdevanja = new TipSnabdevanja();

                            switch (odgovor)
                            {
                                case 0:
                                    {
                                        nacinSnabdevanja = TipSnabdevanja.GARANTOVANO;
                                        break;
                                    }

                                case 1:
                                    {
                                        nacinSnabdevanja = TipSnabdevanja.KOMERCIJALNO;
                                        break;
                                    }
                            }

                            Console.WriteLine("Unesite ukupnu potrošnju energije potrošača: ");
                            double ukupnaPotrosnjaEnergije = double.Parse(Console.ReadLine()?.Trim() ?? "");

                            Console.WriteLine("Unesite trenutno zaduženje potrošača: ");
                            double trenutnoZaduzenje = double.Parse(Console.ReadLine()?.Trim() ?? "");

                            Potrosac noviPotrosac = new Potrosac(imeIPrezime, brojPotrosackogUgovora, nacinSnabdevanja, ukupnaPotrosnjaEnergije, trenutnoZaduzenje);
                            if (potrosaciRepository.DodajPotrosaca(noviPotrosac))
                            {
                                Console.WriteLine("Novi potrošač je uspešno dodat.\n");
                            } else
                            {
                                Console.WriteLine("Došlo je do grške pri unosu novog potrošača.\n");
                            }
                            break;
                        }
                    case "4":
                        {
                            //pregled svih potrosaca

                            IPotrosaciRepository potrosaciRepository = new PotrosaciRepository();
                            var sviPotrosaci = potrosaciRepository.SviPotrosaci();

                            foreach(var pot in sviPotrosaci)
                            {
                                Console.WriteLine(pot.ToString()); ;
                            }

                            break;
                        }

                    case "5":
                        {
                            Console.WriteLine("Odjavili ste se.\n");
                            kraj = true;
                            break;  
                        }
                    default:
                        {
                            Console.WriteLine("Nepoznata opcija. Pokušajte ponovo.");
                            continue;
                        }
                }
            }
        }
    }
}
