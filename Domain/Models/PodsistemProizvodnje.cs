using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PodsistemProizvodnje
    {
        public string SifraPodsProiz {  get; set; }
        public TipProizvodnje TipProizvodnje { get; set; }
        public string Lokacija { get; set; }
        public double PreostalaKolicinaKW { get; set; }

        public PodsistemProizvodnje(string sifraPodsProiz, TipProizvodnje tipProizvodnje, string lokacija, double minVrednost, double maxVrednost)
        {
            SifraPodsProiz = sifraPodsProiz;
            TipProizvodnje = tipProizvodnje;
            Lokacija = lokacija;
            var generator = new NasumicnaKolicina();
            PreostalaKolicinaKW = generator.Generisi(minVrednost, maxVrednost);
        }
    }
}
