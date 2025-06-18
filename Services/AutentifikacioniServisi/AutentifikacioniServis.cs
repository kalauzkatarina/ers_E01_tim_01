using Domain.Models;
using Domain.Repositories.PotrosaciRepositories;
using Domain.Services;

namespace Services.AutentifikacioniServisi
{
    public class AutentifikacioniServis : IAutentifikacijaServis
    {
        private static readonly IPotrosaciRepository potrosaciRepository;

        static AutentifikacioniServis()
        {
            potrosaciRepository = new PotrosaciRepository();
        }
        
        public (bool, Potrosac) Prijava(string korisnickoIme, string lozinka)
        {
            foreach (var p in potrosaciRepository.SviPotrosaci())
            {
                if (p.ImeIPrezime.Equals(korisnickoIme) && p.BrPotrosackogUgovora.Equals(lozinka)) //ili ime+prezime ili brugovora
                {
                    return (true, p);
                }
            }
            return (false, new Potrosac());
        }
    }
}
