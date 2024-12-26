namespace Domain.Repositories.EvidencijaKomercijalnoRepositories
{
    public class EvidencijaKomercijalnoRepository : IEvidencijaKomercijalnoRepository
    {
        private static List<string> listaZapisaZaKomercijalno = [];

        public bool DodajZapis(string zapis)
        {
            if (zapis == null)
            {
                return false;
            }
            listaZapisaZaKomercijalno.Add(zapis);
            return true;
        }

        public IEnumerable<string> SviKomercijalniZapisi()
        {
            return listaZapisaZaKomercijalno;
        }
    }
}
