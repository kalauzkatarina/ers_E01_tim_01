using Domain.Enums;
using Domain.Utils.RandomGen;
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
            PreostalaKolicinaKW = new Generator().Generisi(minVrednost, maxVrednost);
        }

        public static implicit operator PodsistemProizvodnje(double v)
        {
            throw new NotImplementedException();
        }
    }
}
