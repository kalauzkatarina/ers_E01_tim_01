using Domain.Enums;

namespace Domain.Models
{
    public class Potrosac
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string ImeIPrezime { get; set; } = "";
        public string BrPotrosackogUgovora { get; set; } = "";
        public TipSnabdevanja NacinSnabdevanja { get; set; }
        public double UkupnaPotrosnjaEnergije { get; set; }
        public double TrenutnoZaduzenje { get; set; }

        public Potrosac(string imeIPrezime, string brPotrosackogUgovora, TipSnabdevanja nacinSnabdevanja, double ukupnaPotrosnjaEnergije, double trenutnoZaduzenje)
        {
            Id = Guid.NewGuid();
            ImeIPrezime = imeIPrezime;
            BrPotrosackogUgovora = brPotrosackogUgovora;
            NacinSnabdevanja = nacinSnabdevanja;
            UkupnaPotrosnjaEnergije = ukupnaPotrosnjaEnergije;
            TrenutnoZaduzenje = trenutnoZaduzenje;
        }

        public Potrosac() { }

        public override string ToString()
        {
            string s = Id + " " + ImeIPrezime + " " + BrPotrosackogUgovora + " ";

            switch (NacinSnabdevanja)
            {
                case TipSnabdevanja.GARANTOVANO:
                    s += "GARANTOVANO" + " ";
                    break;

                case TipSnabdevanja.KOMERCIJALNO:
                    s += "KOMERCIJALNO" + " ";
                    break;
            }

            s += UkupnaPotrosnjaEnergije + " " + TrenutnoZaduzenje;

            return s;
        }
    }
}
