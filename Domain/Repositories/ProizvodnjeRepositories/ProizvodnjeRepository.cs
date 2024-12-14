using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.ProizvodnjeRepositories
{
    public class ProizvodnjeRepository : IProizvodnjeRepository
    {
        private static List<PodsistemProizvodnje> podsistemiProizvodnje = new List<PodsistemProizvodnje>
        {
            new PodsistemProizvodnje("PP001", Enums.TipProizvodnje.HIDROELEKTRANA, "Đerdap", 1000.00, 2000.00),
            new PodsistemProizvodnje("PP002", Enums.TipProizvodnje.ECOGREEN, "Kovin", 500.00, 1500.00)
        };
        public IEnumerable<PodsistemProizvodnje> SviPodsistemiProizvodnje()
        {
            return podsistemiProizvodnje;
        }

        //pronadji po sifri proizvodnju
        public PodsistemProizvodnje PronadjiPodsistem(string sifra)
        {
            foreach(var p in podsistemiProizvodnje)
            {
                if(p.SifraPodsProiz == sifra)
                {
                    return p;
                }
            }
            return new PodsistemProizvodnje();
        }
    };
}
