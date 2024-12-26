using Domain.Models;

namespace Domain.Repositories.ProizvodnjeRepositories
{
    public interface IProizvodnjeRepository
    {
        public IEnumerable<PodsistemProizvodnje> SviPodsistemiProizvodnje();
        public PodsistemProizvodnje PronadjiPodsistem(string sifra);

    }
}
