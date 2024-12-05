using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PodsistemPotrosnje
    {
        // ide u repozitorijum, klasa bi imala 2 odgovornosti
        // da modeluje potrosaca i cuva listu potrosaca
        // rad sa potrosacima ide preko repozitorijuma
        // i servis koji treba da radi sa potrosacima imace te metode
        // ALI CE ZA PRISTUP ISTIM KORISTITI REPOZITORIJUM!!!
        // public List<Potrosac> potrosaci = new List<Potrosac>();
        public string NazivPodsistema { get; set; } = "";
        public string SifraPodsPotr { get; set; } = "";

        public PodsistemPotrosnje(string nazivPodsistema, string sifraPodsPotr)
        {
            NazivPodsistema = nazivPodsistema;
            SifraPodsPotr = sifraPodsPotr;
        }

        public PodsistemPotrosnje() { }
    }
}
