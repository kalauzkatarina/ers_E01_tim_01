using Domain.Models;
using Domain.Repositories.PotrosaciRepositories;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.PotrosacServisi
{
    public class PotrosacServis : IPotrosacServis
    {
        private IPotrosaciRepository potrosacRepository = new PotrosaciRepository();
        public double PregledTrenutnogZaduzenja(Guid id)
        {
            Potrosac potrosac = potrosacRepository.PronadjiPotrosac(id);

            if(potrosac == null ) 
            {
                return 0.0;
            }
            return potrosac.TrenutnoZaduzenje;
        }
    }
}
