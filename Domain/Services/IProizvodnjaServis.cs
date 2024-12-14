using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IProizvodnjaServis
    {
        public bool ObradiZahtev(double kolicinaEnergije);
        public bool DopuniEnergiju(string sifra);

        public PodsistemProizvodnje IzaberiNajboljiPodsistem(double kolicinaKW);
        
    }
}
