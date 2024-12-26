using Domain.Repositories.EvidencijaKomercijalnoRepositories;
using Domain.Services;

namespace Services.EvidencijaServisi
{
    public class EvidencijaKomercijalnoServis : IEvidencijaServis
    {
        private readonly IEvidencijaKomercijalnoRepository _repository = new EvidencijaKomercijalnoRepository();

        public bool EvidentirajIsporuku(string zapis)
        {
            _repository.DodajZapis(zapis);
            return true;
        }
    }
}
