using Domain.Enums;
using Domain.Models;
using NUnit.Framework;

namespace Tests.Domain
{
    [TestFixture]
    public class PodsistemPotrosnjeTests
    {
        [Test]
        [TestCase("Visegrad", "PSP123-VG1")]
        [TestCase("Novi Sad", "PSP456-NS1")]

        public void PodsistemPotrosnjeKonstruktor_SaIspravnimPodacima_Ok(string naziv, string sifra)
        {
            PodsistemPotrosnje potr = new(naziv, sifra);

            Assert.That(potr.NazivPodsistema, Is.EqualTo(naziv));
            Assert.That(potr.SifraPodsPotr, Is.EqualTo(sifra));
            Assert.That(potr, Is.Not.Null);
        }

        [Test]
        [TestCase("Visegrad", "PSP123-VG1")]
        [TestCase("Novi Sad", "PSP456-NS1")]

        public void PodsistemPotrosnjeKonstruktorProveraProperty_SaIspravnimPodacima_Ok(string naziv, string sifra)
        {
            PodsistemPotrosnje potr = new(naziv, sifra);

            string naziv2 = "Sombor";
            string sifra2 = "PSP789-SO1";

            potr.NazivPodsistema = naziv2;
            potr.SifraPodsPotr = sifra2;

            Assert.That(potr.NazivPodsistema, Is.EqualTo(naziv2));
            Assert.That(potr.SifraPodsPotr, Is.EqualTo(sifra2));
            Assert.That(potr, Is.Not.Null);
        }

        [Test]
        [TestCase(null, "PSP789-SO1")]
        [TestCase("Sombor", null)]
        public void PodsistemPotrosnjeKonstruktorProveraProperty_ParametriNull_Izuzetak(string naziv, string sifra)
        {
            Assert.Throws<ArgumentNullException>(() => new PodsistemPotrosnje(naziv, sifra))
        }

    }
}
