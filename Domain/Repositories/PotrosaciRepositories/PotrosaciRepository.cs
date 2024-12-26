using Domain.Models;

namespace Domain.Repositories.PotrosaciRepositories
{
    public class PotrosaciRepository : IPotrosaciRepository
    {
        private static readonly List<Potrosac> potrosaci = [];

        static PotrosaciRepository()
        {
            potrosaci =
            [
                new Potrosac(Guid.NewGuid(), "Julijana", "Ristic", "07BN26", Enums.TipSnabdevanja.GARANTOVANO, 55, 500),
                new Potrosac(Guid.NewGuid(), "Katarina", "Kalauz", "08GR74", Enums.TipSnabdevanja.KOMERCIJALNO, 75, 1500)
            ];
        }

        public bool DodajPotrosaca(Potrosac potrosac)
        {
            foreach (Potrosac p in potrosaci)
            {
                // Id i Broj ugovora moraju biti jedinstveni
                if (p.Id == potrosac.Id || p.BrPotrosackogUgovora == potrosac.BrPotrosackogUgovora)
                    return false;
            }

            potrosaci.Add(potrosac);
            return true;
        }

        public Potrosac PronadjiPotrosac(Guid id)
        {
            foreach (var p in potrosaci)
            {
                if (p.Id == id)
                    return p;
            }
            return new Potrosac();
        }

        public IEnumerable<Potrosac> SviPotrosaci()
        {
            return potrosaci;
        }
    }
}
