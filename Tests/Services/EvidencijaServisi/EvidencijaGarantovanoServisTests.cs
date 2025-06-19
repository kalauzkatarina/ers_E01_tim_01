using Domain.Services;
using NUnit.Framework;
using Services.EvidencijaServisi;
using Services.ServisiProizvodnje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Services.EvidencijaServisi
{
    [TestFixture]
    public class EvidencijaGarantovanoServisTests
    {
        private IEvidencijaServis evidencijaGarantovano;

        public EvidencijaGarantovanoServisTests()
        {
            evidencijaGarantovano = new EvidencijaGarantovanoServis(); 
        }

        [SetUp]
        public void SetUp()
        {
            evidencijaGarantovano = new EvidencijaGarantovanoServis();
        }

        [Test]
        [TestCase("evidencija_garantovano.txt")]
        public void EvidentirajIsporuku_Ispravno_VracaTrue(string putanjaFajla)
        {
            bool povratnaVrednost = evidencijaGarantovano.EvidentirajIsporuku(putanjaFajla);

            Assert.That(povratnaVrednost, Is.True);
        }
    }
}
