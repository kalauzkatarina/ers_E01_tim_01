using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.EvidencijeRepositories
{
    public interface IEvidencijeRepository
    {
        void DodajEvidenciju(Evidencija evidencija);
        IEnumerable<Evidencija> SviZapisi();
    }
}
