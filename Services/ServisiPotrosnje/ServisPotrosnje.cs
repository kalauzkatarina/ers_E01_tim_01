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
    public class ServisPotrosnje : IServisPotrosnje
    {
        private readonly IPotrosaciRepository potrosacRepository;
        private readonly IEvidencijeRepository evidencijaRepository;
        private readonly IServisProizvodnje servisProizvodnje;

        public ServisPotrosnje(IPotrosaciRepository potrosacRepository, IEvidencijeRepository evidencijaRepository, IServisProizvodnje servisProizvodnje)
        {
            this.potrosacRepository = potrosacRepository;
            this.evidencijaRepository = evidencijaRepository;
            this.servisProizvodnje = servisProizvodnje;
        }

        public void EvidentirajPotrosnju(Guid id, double kolicinaKW)
        {
            Potrosac potrosac = potrosacRepository.PronadjiPotrosac(id);
            if(potrosac == null)
            {
                Console.WriteLine("Potrosac nije pronadjen.");
                return;
            }

            double cena = 0;
            double ukupnaKolicina = kolicinaKW;

            if (potrosac.NacinSnabdevanja.Equals("GARANTOVANO"))
            {
                cena = 22.72;
                ukupnaKolicina *= 0.98; //preostala el.energija se smanjuje za 2%
            }
            else if (potrosac.NacinSnabdevanja.Equals("KOMERCIJALNO"))
            {
                cena = 43.02;
                ukupnaKolicina *= 0.99; //preostala el.energija se smanjuje za 1%
            }
        }


    }
}
