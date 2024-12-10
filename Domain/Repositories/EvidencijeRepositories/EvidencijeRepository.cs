using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.EvidencijeRepositories
{
    public class EvidencijeRepository : IEvidencijeRepository
    {
        private static List<Evidencija> evidencije = [];

        public void DodajEvidenciju(Evidencija evidencija)
        {
            evidencije.Add(evidencija);
        }

        public IEnumerable<Evidencija> SviZapisi()
        {
            return evidencije;
        }
    }
}
