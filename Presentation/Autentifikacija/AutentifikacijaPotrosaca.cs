using Domain.Models;
using Domain.Services;
namespace Presentation.Autentifikacija
{
    public class AutentifikacijaPotrosaca
    {
        private readonly IAutentifikacijaServis autentifikacijaServis;
        private readonly IPotrosacServis potrosacServis;


        public AutentifikacijaPotrosaca(IAutentifikacijaServis autentifikacijaServis, IPotrosacServis potrosacServis)
        {
            this.autentifikacijaServis = autentifikacijaServis;
            this.potrosacServis = potrosacServis;
        }

        public (bool,Potrosac) TryLogin(out Potrosac potrosac)
        {
            bool uspesnaPrijava;
            string lozinka;

            do
            {
                Console.WriteLine("Lozinka (broj potrošackog ugovora): ");
                lozinka = Console.ReadLine()?.Trim() ?? "";
                //Ova linija koda omogućava da se uneta lozinka pročita sa tastature,
                //uklone nepotrebni razmaci, a ako korisnik pritisne samo Enter bez unosa,
                //lozinka će biti prazan string, umesto null.

                (uspesnaPrijava, potrosac) = autentifikacijaServis.Prijava(lozinka);

                if (!uspesnaPrijava)
                {
                    Console.WriteLine("Neuspešna prijava, pokušajte ponovo.");
                
                }
            } while (!uspesnaPrijava);

            Console.WriteLine("Uspešno ste se prijavili.");
            return (uspesnaPrijava, potrosac);
        }
    }
}
