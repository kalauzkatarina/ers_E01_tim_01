using Domain.Models;

namespace Domain.Services
{
    public interface IAutentifikacijaServis
    {
        public (bool, Potrosac) Prijava(string ime, string prezime, string lozinka);
    }
}
