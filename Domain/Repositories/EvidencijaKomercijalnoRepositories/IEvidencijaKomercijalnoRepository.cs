namespace Domain.Repositories.EvidencijaKomercijalnoRepositories
{
    public interface IEvidencijaKomercijalnoRepository
    {
        public bool DodajZapis(string zapis);
        public IEnumerable<string> SviKomercijalniZapisi();

    }
}
