using Domain.Enums;
using Domain.Models;
using Domain.Repositories.ProizvodnjeRepositories;
using Domain.Services;
using Domain.Utils.IzaberiPodsistemIDopuniEnergiju;
using Moq;
using NUnit.Framework;
using Services.ServisiProizvodnje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Services.ProizvodnjaServisi
{
    [TestFixture]
    public class GarantovanaProizvodnjaServisTests
    {

        private IProizvodnjaServis garantovanoServis;
        public GarantovanaProizvodnjaServisTests()
        {
            garantovanoServis = new GarantovanaProizvodnjaServis();
        }

        [SetUp]
        public void SetUp()
        {
            garantovanoServis = new GarantovanaProizvodnjaServis();
        }


        [Test]
        [TestCase(100)]
        [TestCase(500)]
        [TestCase(250)]
        public void ObradiZahtev_DovoljnoEnergije_VracaTrue(double kolicinaEnergije)
        {
            bool povratnaVrednost;
            povratnaVrednost = garantovanoServis.ObradiZahtev(kolicinaEnergije);

            Assert.That(povratnaVrednost, Is.True);
           
        }

        [Test]
        [TestCase(-2)]
        public void ObradiZahtev_NijeOdgovarajucaKolicinaEnergije_VracaFalse(double kolicinaEnergije)
        {
            bool povratnaVrednost;
            povratnaVrednost = garantovanoServis.ObradiZahtev(kolicinaEnergije);

            Assert.That(povratnaVrednost, Is.False);
        }

        [Test]
        [TestCase(0)]
        public void ObradiZahtev_GranicniSlucaj_VracaFalse(double kolicinaEnergije)
        {
            bool povratnaVrednost;
            povratnaVrednost = garantovanoServis.ObradiZahtev(kolicinaEnergije);

            Assert.That(povratnaVrednost, Is.False);
        }

    }
}
