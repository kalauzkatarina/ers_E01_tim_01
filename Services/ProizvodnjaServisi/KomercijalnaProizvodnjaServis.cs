using Domain.Models;
using Domain.Repositories.ProizvodnjeRepositories;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProizvodnjaServisi
{
    internal class KomercijalnaProizvodnjaServis : IProizvodnjaServis
    {
        private IProizvodnjeRepository proizvodnjeRepository = new ProizvodnjeRepository();

        public bool DopuniEnergiju(string sifra)
        {
            var podsistemi = proizvodnjeRepository.SviPodsistemiProizvodnje();

            if (podsistemi != null)
            {
                return false;
            }
            else
            {
                foreach (var p in podsistemi) //PITANJE: ne znam zasto mi zeleni ovo podsistemi
                {
                    if (p.PreostalaKolicinaKW < 100)
                    {
                        p.PreostalaKolicinaKW *= 1.14; //povecanje preostale kolicine za 14%
                        return true;
                    }
                }
                return false;
            }

        }
        public PodsistemProizvodnje IzaberiNajboljiPodsistem(double kolicinaKW)
        {
            PodsistemProizvodnje najboljiPodsistem = new PodsistemProizvodnje();
            var proizvodniPodsistemi = proizvodnjeRepository.SviPodsistemiProizvodnje();


            foreach (var p in proizvodniPodsistemi)
            {
                if (p.PreostalaKolicinaKW >= kolicinaKW && p.TipProizvodnje.Equals("KOMERCIJALNO")) //PITANJE: jel ovde treba dodati  p.TipProizvodnje.Equals("KOMERCIJALNO") ili ne treba?
                {
                    if (najboljiPodsistem == null)
                    {
                        najboljiPodsistem = p;
                    }
                    else
                    {
                        if (p.PreostalaKolicinaKW > najboljiPodsistem.PreostalaKolicinaKW)
                        {
                            najboljiPodsistem = p;
                        }
                    }
                }
            }
            return najboljiPodsistem;
        }

        public bool ObradiZahtev(double kolicinaEnergije)
        {
            var najboljiPodsistem = IzaberiNajboljiPodsistem(kolicinaEnergije);

            if (najboljiPodsistem == null)
            {
                return false;
            }

            double smanjenaKolicinaEnergije = kolicinaEnergije * 0.99; //smanjujemo za 1% zbog nesavrsenosti provodnika
            najboljiPodsistem.PreostalaKolicinaKW -= smanjenaKolicinaEnergije;

            return true;
        }
    }
}
