using Domain.Enums;
using Domain.Models;
using NUnit.Framework;

namespace Tests.Domain
{
    [TestFixture]
    public class PotrosacTests
    {
        [Test]
        [TestCase("Julijana Ristic", "EPS1234R", TipSnabdevanja.KOMERCIJALNO, 100, -13.6)]
        [TestCase("Katarina Kalauz", "EPS5678K", TipSnabdevanja.GARANTOVANO, 120, 120.5)]
        public void PotrosacKonstruktor_SaValidnimPodacima_Ok(string imeIPrezime, string brUgovora, TipSnabdevanja tipSn, double ukPotrosnja, double trDug)
        {
            Potrosac potrosac = new(imeIPrezime, brUgovora, tipSn, ukPotrosnja, trDug);

            Assert.That(potrosac, Is.Not.Null);
            Assert.That(potrosac.ImeIPrezime, Is.EqualTo(imeIPrezime));
            Assert.That(potrosac.BrPotrosackogUgovora, Is.EqualTo(brUgovora));
            Assert.That(potrosac.NacinSnabdevanja, Is.EqualTo(tipSn));
            Assert.That(potrosac.UkupnaPotrosnjaEnergije, Is.EqualTo(ukPotrosnja));
            Assert.That(potrosac.TrenutnoZaduzenje, Is.EqualTo(trDug));

        }

        [Test]
        [TestCase("Julijana Ristic", "EPS1234R", TipSnabdevanja.KOMERCIJALNO, 100, -13.6)]
        [TestCase("Katarina Kalauz", "EPS5678K", TipSnabdevanja.GARANTOVANO, 120, 120.5)]
        public void PotrosacKonstruktorProvereProperty_SaValidnimPodacima_Ok(string imeIPrezime, string brUgovora, TipSnabdevanja tipSn, int ukPotrosnja, double trDug)
        {
            Potrosac potrosac = new(imeIPrezime, brUgovora, tipSn, ukPotrosnja, trDug);

            string imeIPrezime2 = "Mira Miric";
            string brUgovora2 = "EPS0000M";
            TipSnabdevanja tipSn2 = TipSnabdevanja.KOMERCIJALNO;
            double ukPotrosnja2 = 0;
            double trDug2 = 0;

            potrosac.ImeIPrezime = imeIPrezime2;
            potrosac.BrPotrosackogUgovora = brUgovora2;
            potrosac.NacinSnabdevanja = tipSn2;
            potrosac.UkupnaPotrosnjaEnergije = ukPotrosnja2;
            potrosac.TrenutnoZaduzenje = trDug2;

            Assert.That(potrosac, Is.Not.Null);
            Assert.That(potrosac.ImeIPrezime, Is.EqualTo(imeIPrezime2));
            Assert.That(potrosac.BrPotrosackogUgovora, Is.EqualTo(brUgovora2));
            Assert.That(potrosac.NacinSnabdevanja, Is.EqualTo(tipSn2));
            Assert.That(potrosac.UkupnaPotrosnjaEnergije, Is.EqualTo(ukPotrosnja2));
            Assert.That(potrosac.TrenutnoZaduzenje, Is.EqualTo(trDug2));
        }

        [Test]
        [TestCase("Julijana Ristic", "EPS1234R", TipSnabdevanja.KOMERCIJALNO, 0, -13.6)]
        [TestCase("Katarina Kalauz", "EPS5678K", TipSnabdevanja.GARANTOVANO, 0, 120.5)] //testira se za ukupnu potrosnju, jer je to minimalno 0
        public void PotrosacKonstruktor_GranicniParametri_Ok(string imeIPrezime, string brUgovora, TipSnabdevanja tipSn, double ukPotrosnja, double trDug)
        {
            Potrosac potrosac = new(imeIPrezime, brUgovora, tipSn, ukPotrosnja, trDug);

            Assert.That(potrosac, Is.Not.Null);
            Assert.That(potrosac.ImeIPrezime, Is.EqualTo(imeIPrezime));
            Assert.That(potrosac._brPotrosackogUgovora, Is.EqualTo(brUgovora));
            Assert.That(potrosac.NacinSnabdevanja, Is.EqualTo(tipSn));
            Assert.That(potrosac.UkupnaPotrosnjaEnergije, Is.EqualTo(ukPotrosnja));
            Assert.That(potrosac.TrenutnoZaduzenje, Is.EqualTo(trDug));

        }

        [Test]
        [TestCase("Mira Miric", "EPS0000M", TipSnabdevanja.GARANTOVANO, -100, -20.5)] //ukupna potrosnja je negativna
        public void PotrosacKonstruktor_NegativniParametri_Izuzetak(string imeIPrezime, string brUgovora, TipSnabdevanja tipSn, double ukPotrosnja, double trDug)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Potrosac p = new Potrosac(imeIPrezime, brUgovora, tipSn, ukPotrosnja, trDug);
            });
        }

        [Test]
        [TestCase(null, "EPS1234R", TipSnabdevanja.KOMERCIJALNO, 100, -13.6)] //ime i prezime je null
        [TestCase("Katarina Kalauz", null, TipSnabdevanja.GARANTOVANO, 120, 120.5)] //broj ugovora je null
        public void PotrosacKonstruktor_ParametriNull_Izuzetak(string imeIPrezime, string brUgovora, TipSnabdevanja tipSn, double ukPotrosnja, double trDug)
        {
            Assert.Throws<ArgumentNullException>(() => new Potrosac(imeIPrezime, brUgovora, tipSn, ukPotrosnja, trDug));
        }

    }
}
