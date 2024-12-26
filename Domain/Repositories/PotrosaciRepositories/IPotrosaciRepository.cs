using Domain.Models;

namespace Domain.Repositories.PotrosaciRepositories
{
    public interface IPotrosaciRepository
    {
        bool DodajPotrosaca(Potrosac potrosac);
        Potrosac PronadjiPotrosac(Guid id);

        IEnumerable<Potrosac> SviPotrosaci();
    }
}
