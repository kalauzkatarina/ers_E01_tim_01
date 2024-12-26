using Domain.Models;

namespace Domain.Repositories.ProizvodnjeRepositories
{
    public class ProizvodnjeRepository : IProizvodnjeRepository
    {
        private static List<PodsistemProizvodnje> podsistemiProizvodnje = new List<PodsistemProizvodnje>
        {
            new PodsistemProizvodnje("PP001", Enums.TipProizvodnje.HIDROELEKTRANA, "Đerdap", 50.00, 90.00),
            new PodsistemProizvodnje("PP002", Enums.TipProizvodnje.ECOGREEN, "Kovin", 500.00, 1500.00),
            new PodsistemProizvodnje("PP003", Enums.TipProizvodnje.CVRSTO_GORIVO, "Obrenovac", 400.00, 1000.00),
            new PodsistemProizvodnje("PP004", Enums.TipProizvodnje.HIDROELEKTRANA, "Bajina Bašta", 2000.00, 5000.00),
            new PodsistemProizvodnje("PP005", Enums.TipProizvodnje.ECOGREEN, "Subotica", 1200.00, 1800.00),
            new PodsistemProizvodnje("PP006", Enums.TipProizvodnje.CVRSTO_GORIVO, "Niš", 900.00, 2000.00)
        };
        public IEnumerable<PodsistemProizvodnje> SviPodsistemiProizvodnje()
        {
            return podsistemiProizvodnje;
        }

        //pronadji po sifri proizvodnju
        public PodsistemProizvodnje PronadjiPodsistem(string sifra)
        {
            foreach (var p in podsistemiProizvodnje)
            {
                if (p.SifraPodsProiz == sifra)
                {
                    return p;
                }
            }
            return new PodsistemProizvodnje();
        }
    };
}
