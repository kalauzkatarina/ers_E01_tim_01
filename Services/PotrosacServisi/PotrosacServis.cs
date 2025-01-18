using Domain.Models;
using Domain.Repositories.PotrosaciRepositories;
using Domain.Services;

namespace Services.PotrosacServisi
{
    public class PotrosacServis : IPotrosacServis
    {
        private IPotrosaciRepository potrosacRepository = new PotrosaciRepository();
        private readonly IPotrosnjaServis ipotrosnja;

        public PotrosacServis(IPotrosnjaServis ipotrosnja)
        {
            this.ipotrosnja = ipotrosnja;
        }
        public double PregledTrenutnogZaduzenja(Guid id)
        {
            Potrosac p = potrosacRepository.PronadjiPotrosac(id);

            if (p.Ime == "")
            {
                return 0.0;
            }
            return p.TrenutnoZaduzenje;
        }

        public bool PotrosacZahtev(Guid id, double kolicinaKW)
        {
            Potrosac p = potrosacRepository.PronadjiPotrosac(id);

            if (p.Ime == "")
            {
                return false;
            }
            return ipotrosnja.EvidentirajPotrosnju(id, kolicinaKW);
        }
    }
}
