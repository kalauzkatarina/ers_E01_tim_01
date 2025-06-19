using Domain.Enums;
using Domain.Models;
using NUnit.Framework;

namespace Tests.Domain
{
    [TestFixture]
    public class PodsistemProizvodnjeTests
    {
        [Test]
        [TestCase("PP123-VG1", TipProizvodnje.CVRSTO_GORIVO, "Visegrad", 381, 700)]
        [TestCase("PP456-NS1", TipProizvodnje.HIDROELEKTRANA, "Novi Sad", 900, 1100)]

        public void PodsistemProizvodnjeKonstruktor_SaValidnimPodacima_Ok(string sifra, TipProizvodnje tipPr, string lokacija, double min, double max)
        {
            PodsistemProizvodnje proizvodnja = new(sifra, tipPr, lokacija, min, max);

            Assert.That(proizvodnja, Is.Not.Null);
            Assert.That(proizvodnja.SifraPodsProiz, Is.EqualTo(sifra));
            Assert.That(proizvodnja.TipProizvodnje, Is.EqualTo(tipPr));
            Assert.That(proizvodnja.Lokacija, Is.EqualTo(lokacija));
            Assert.That(proizvodnja.PreostalaKolicinaKW, Is.GreaterThanOrEqualTo(0));
        }

        [Test]
        [TestCase("PP123-VG1", TipProizvodnje.CVRSTO_GORIVO, "Visegrad", 381, 700)]
        [TestCase("PP456-NS1", TipProizvodnje.HIDROELEKTRANA, "Novi Sad", 900, 1100)]
        
        public void PodsistemProizvodnjeKonstruktorProveraProperty_SaValidnimPodacima_Ok(string sifra, TipProizvodnje tipPr, string lokacija, double min, double max)
        {
            PodsistemProizvodnje proizvodnja = new(sifra, tipPr, lokacija, min, max);

            string sifra2 = "PP789-SO1";
            TipProizvodnje tipPr2 = TipProizvodnje.ECOGREEN;
            string lokacija2 = "Sombor";
            double kolicina2 = 0;

            proizvodnja.SifraPodsProiz = sifra2;
            proizvodnja.TipProizvodnje = tipPr2;
            proizvodnja.Lokacija = lokacija2;
            proizvodnja.PreostalaKolicinaKW = kolicina2;

            Assert.That(proizvodnja, Is.Not.Null);
            Assert.That(proizvodnja.SifraPodsProiz, Is.EqualTo(sifra2));
            Assert.That(proizvodnja.TipProizvodnje, Is.EqualTo(tipPr2));
            Assert.That(proizvodnja.Lokacija, Is.EqualTo(lokacija2));
            Assert.That(proizvodnja.PreostalaKolicinaKW, Is.GreaterThanOrEqualTo(0));
        }

        [Test]
        [TestCase("PP123-VG1", TipProizvodnje.CVRSTO_GORIVO, "Visegrad", 381, 700)]
        public void PodsistemProizvodnjeKonstruktorProveraProperty_PreostalaKolicinaNegativna_Izuzetak(string sifra, TipProizvodnje tipPr, string lokacija, double min, double max)
        {
            double kolicina = -100;
            Assert.Throws<ArgumentException>(() => new PodsistemProizvodnje(sifra, tipPr, lokacija, min, max) { PreostalaKolicinaKW = kolicina });
        }
        [Test]
        [TestCase(null, TipProizvodnje.ECOGREEN, "Sombor", 400, 600)]
        [TestCase("PP789-SO1", TipProizvodnje.ECOGREEN, null, 400, 600)]
        public void PodsistemProizvodnjeKonstruktorProveraProperty_ParametriNull_Izuzetak(string sifra, TipProizvodnje tipPr, string lokacija, double min, double max)
        {
            Assert.Throws<ArgumentNullException>(() => new PodsistemProizvodnje(sifra, tipPr, lokacija, min, max));
        }
    }
}
