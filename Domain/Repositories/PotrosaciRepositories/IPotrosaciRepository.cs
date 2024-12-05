using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.PotrosaciRepositories
{
    public interface IPotrosaciRepository
    {
        bool DodajPotrosaca(Potrosac potrosac);

        IEnumerable<Potrosac> SviPotrosaci();
    }
}
