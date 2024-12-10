using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.PotrosaciRepositories
{
    public class PotrosaciRepository : IPotrosaciRepository
    {
        private static List<Potrosac> potrosaci = [];

        static PotrosaciRepository()
        {
            // dodati ako su pottrebni inicijalni podaci
            // npr:
            //potrosaci = [
            //    new Potrosac(Guid.NewGuid(), "ime", "prezime", ....),
            //    ]
        }

        public bool DodajPotrosaca(Potrosac potrosac)
        {
            foreach(Potrosac p in potrosaci)
            {
                // Id i Broj ugovora moraju biti jedinstveni
                if(p.Id == potrosac.Id || p.BrPotrosackogUgovora == potrosac.BrPotrosackogUgovora)
                    return false;
            }

            potrosaci.Add(potrosac);
            return true;
        }

        public Potrosac PronadjiPotrosac(Guid id)
        {
            foreach(var p in potrosaci)
            {
                if (p.Id == id)
                    return p;
            }
            return new Potrosac(); //ovde ne znam da li je validno da vraca prazan potrosac
            //ili treba da vraca null, ali ako se dobro secam to smo komentarisali na vezbama da ne vraca null
            //ili da se u potrosacu dodaje kod praznog konstruktora da kreira
            //da je ukupna potrosnja = 0, trenutnoZaduzenje = 0, a za ime da je prazan string
            //ili nesto slicno, sad su ove nase ideje samo ne znamo koje je najbolje resenje u ovom slucaju
        }

        public IEnumerable<Potrosac> SviPotrosaci()
        {
            return potrosaci;
        }
    }
}
