using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.ProizvodnjeRepositories
{
    public interface IProizvodnjeRepository
    {
        public IEnumerable<PodsistemProizvodnje> SviPodsistemiProizvodnje();
    }
}
