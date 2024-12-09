using Domain.Models;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.GarantovaniServisi
{
    public class GarantovaniServis : IGarantovanoServis
    {
        public void SmanjiEnergiju(PodsistemProizvodnje pp)
        {
            pp = pp.PreostalaKolicinaKW * 0.98;
        }
    }
}
