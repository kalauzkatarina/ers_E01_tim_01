using Domain.Models;
using Domain.Repositories.EvidencijeRepositories;
using Domain.Repositories.PotrosaciRepositories;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServisiPotrosnje
{
    public class PotrosnjaServis : IPotrosnjaServis
    {
        private IPotrosaciRepository potrosacRepository = new PotrosaciRepository();
       

        public bool EvidentirajPotrosnju(Guid id, double kolicinaKW)
        {
            Potrosac potrosac = potrosacRepository.PronadjiPotrosac(id);
            if (potrosac == null)
            {
                return false;
            }

            double cena;

            if (potrosac.NacinSnabdevanja.Equals("GARANTOVANO"))
            {
                cena = 22.72;

            }
            else if (potrosac.NacinSnabdevanja.Equals("KOMERCIJALNO"))
            {
                cena = 43.02;
            }
            else
            {
                return false;
            }
            double ukupnaCena = kolicinaKW * cena;
            potrosac.TrenutnoZaduzenje += ukupnaCena;
            return true;
        }
    }
}
