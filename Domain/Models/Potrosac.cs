using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Potrosac
    {
        public Guid Id { get; set; }
        public string Ime {  get; set; }
        public string Prezime { get; set; }
        public string BrPotrosackogUgovora {  get; set; }
        public TipSnabdevanja NacinSnabdevanja { get; set; }
        public double UkupnaPotrosnjaEnergije { get; set; }
        public double TrenutnoZaduzenje {  get; set; }

        public Potrosac(Guid id, string ime, string prezime, string brPotrosackogUgovora, TipSnabdevanja nacinSnabdevanja, double ukupnaPotrosnjaEnergije, double trenutnoZaduzenje)
        {
            Id = id;
            Ime = ime;
            Prezime = prezime;
            BrPotrosackogUgovora = brPotrosackogUgovora;
            NacinSnabdevanja = nacinSnabdevanja;
            UkupnaPotrosnjaEnergije = ukupnaPotrosnjaEnergije;
            TrenutnoZaduzenje = trenutnoZaduzenje;
        }

        public Potrosac() { }
    }
}
