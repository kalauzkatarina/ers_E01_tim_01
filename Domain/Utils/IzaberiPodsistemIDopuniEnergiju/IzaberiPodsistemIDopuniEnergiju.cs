using Domain.Enums;
using Domain.Models;
using Domain.Repositories.ProizvodnjeRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Utils.IzaberiPodsistemIDopuniEnergiju
{
    public class IzaberiPodsistemIDopuniEnergiju
    {
        private IProizvodnjeRepository proizvodnjeRepository = new ProizvodnjeRepository();
        public bool DopuniEnergiju(double procenat)
        {
            var listaPodsistemaProizvodnje = proizvodnjeRepository.SviPodsistemiProizvodnje();
            foreach (var podsistem in listaPodsistemaProizvodnje)
            {
                if (podsistem.PreostalaKolicinaKW < 100)
                {
                    foreach (var p in listaPodsistemaProizvodnje)
                    {
                        p.PreostalaKolicinaKW *= 1 + procenat / 100; //povecanje preostale kolicine za odredjeno procenat
                        //npr prosledi se 22%, onda 1 + 22/100 = 1 + 0.22 = 1.22
                    }
                    return true;
                }
            }
            return false;
        }

        public PodsistemProizvodnje IzaberiNajboljiPodsistem(double kolicinaKW)
        {
            PodsistemProizvodnje najboljiPodsistem = new PodsistemProizvodnje();
            var proizvodniPodsistemi = proizvodnjeRepository.SviPodsistemiProizvodnje();


            foreach (var p in proizvodniPodsistemi)
            {
                if (p.PreostalaKolicinaKW >= kolicinaKW)
                {
                    if (najboljiPodsistem.SifraPodsProiz == "" || p.PreostalaKolicinaKW > najboljiPodsistem.PreostalaKolicinaKW) //znaci da je jos kao prazan taj najboljiPodsistem, onda ce staviti da bude prvi najbolji 
                    {
                        najboljiPodsistem = p;
                    }
                }
            }
            return najboljiPodsistem;
        }
    }
}