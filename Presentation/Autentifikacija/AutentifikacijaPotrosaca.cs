using Domain.Models;
using Domain.Services;
namespace Presentation.Autentifikacija
{
    public class AutentifikacijaPotrosaca
    {
        private readonly IAutentifikacijaServis autentifikacijaServis;


        public AutentifikacijaPotrosaca(IAutentifikacijaServis autentifikacijaServis)
        {
            this.autentifikacijaServis = autentifikacijaServis;
        }

        public (bool, Potrosac) TryLogin(out Potrosac potrosac)
        {
            potrosac = new Potrosac();
            bool uspesnaPrijava;
            string? korisnickoIme = "";
            string? lozinka = "";

            do
            {
                Console.WriteLine("Korisničko ime: ");
                korisnickoIme = Console.ReadLine()?.Trim() ?? "";
                Console.WriteLine("Lozinka (broj potrošackog ugovora): ");
                lozinka = Console.ReadLine()?.Trim() ?? "";

                (uspesnaPrijava, potrosac) = autentifikacijaServis.Prijava(korisnickoIme, lozinka);

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
