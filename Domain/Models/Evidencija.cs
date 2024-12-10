using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Evidencija
    {
        public DateTime DatumIVreme {  get; set; }
        public double KolicinaKW { get; set; }

        public override string? ToString()
        {
            return $"{DatumIVreme:dd.MM.yyyy HH:mm}: Izdato je {KolicinaKW} kW."; ;
        }
    }
}
