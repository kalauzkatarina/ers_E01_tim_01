using Domain.Enums;

namespace Domain.Models
{
    public class Potrosac
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string _imeIPrezime = "";
        public string ImeIPrezime
        {
            get { return _imeIPrezime; }
            set
            {
                if(value == null)
                {
                    throw new ArgumentNullException("Greska: ime i prezime ne mogu biti null!");
                }
                _imeIPrezime = value;
            }
        }
        public string _brPotrosackogUgovora = "";

        public string BrPotrosackogUgovora
        {
            get { return _brPotrosackogUgovora; }
            set
            {
                if(value == null )
                {
                    throw new ArgumentNullException("Greska: broj potrosackog ugovora ne moze biti null!");
                }
                _brPotrosackogUgovora = value;
            }
        }
        public TipSnabdevanja NacinSnabdevanja { get; set; }
        public double _ukupnaPotrosnjaEnergije;
        public double UkupnaPotrosnjaEnergije
        {
            get { return _ukupnaPotrosnjaEnergije; }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentOutOfRangeException("Greska: ukupna potrosnja ne moze biti negativna vrednost!");
                }
                _ukupnaPotrosnjaEnergije = value;
            }
        }
        public double TrenutnoZaduzenje { get; set; }
       

        public Potrosac(string imeIPrezime, string brPotrosackogUgovora, TipSnabdevanja nacinSnabdevanja, double ukupnaPotrosnjaEnergije, double trenutnoZaduzenje)
        {
            Id = Guid.NewGuid();

            if(imeIPrezime == null)
            {
                throw new ArgumentNullException("Greska: ime i prezime ne mogu biti null!");
            }
            ImeIPrezime = imeIPrezime;

            if (brPotrosackogUgovora == null)
            {
                throw new ArgumentNullException("Greska: broj potrosackog ugovora ne moze biti null!");
            }
            BrPotrosackogUgovora = brPotrosackogUgovora;
            NacinSnabdevanja = nacinSnabdevanja;

            if(ukupnaPotrosnjaEnergije < 0)
            {
                throw new ArgumentException("Greska: ukupna potrosnja energije ne moze biti negativna vrednost!");
            }
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
