using Domain.Models;
using Domain.Repositories.PotrosaciRepositories;
using Domain.Services;

namespace Services.AutentifikacioniServisi
{
    public class AutentifikacioniServis : IAutentifikacijaServis
    {
        private static readonly IPotrosaciRepository potrosaciRepository = new PotrosaciRepository();

        static AutentifikacioniServis()
        {
            //jel trebam ovde nesto pisati?
        }
        
        public (bool, Potrosac) Prijava(string lozinka)
        {
            foreach (var p in potrosaciRepository.SviPotrosaci())
            {
                if (p.BrPotrosackogUgovora == lozinka) //ili ime+prezime ili brugovora
                {
                    return (true, p);
                }
            }
            return (false, new Potrosac());
        }
    }
}
