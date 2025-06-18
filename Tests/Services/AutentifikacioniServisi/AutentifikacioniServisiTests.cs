using Domain.Enums;
using Domain.Models;
using Domain.Services;
using Moq;
using NUnit.Framework;

namespace Tests.Services.AutentifikacioniServisi
{
    [TestFixture]
    public class AutentifikacioniServisiTests
    {
        private Mock<IAutentifikacijaServis> autentifikacijaServis;
        public AutentifikacioniServisiTests() => autentifikacijaServis = new Mock<IAutentifikacijaServis>();

        [SetUp]
        public void Setup()
        {
            autentifikacijaServis = new Mock<IAutentifikacijaServis>();
        }
        [Test]
        [TestCase("Mira Miric", "EPS0000M")]
        public void Prijava_SaIspravnimPodacima_VracaTrue(string korisnickoIme, string lozinka) {
            var potrosac = new Potrosac(korisnickoIme, lozinka, TipSnabdevanja.KOMERCIJALNO, 0, 0);

            autentifikacijaServis.Setup(x => x.Prijava(korisnickoIme, lozinka)).Returns((true, potrosac));

            (bool uspesno, Potrosac prijavljeni) = autentifikacijaServis.Object.Prijava(korisnickoIme, lozinka);

            Assert.That(uspesno, Is.True);
            Assert.That(prijavljeni, Is.Not.Null);
            Assert.That(prijavljeni.ImeIPrezime, Is.EqualTo(korisnickoIme));
            Assert.That(prijavljeni.BrPotrosackogUgovora, Is.EqualTo((true, potrosac)));
        }

        [Test]
        [TestCase("Petar Petrovic", "EPS1111P")]
        public void Prijava_SANeispravnimPodacima_VracaFalse(string korisnickoIme, string lozinka)
        {
            Potrosac potrosac;
            autentifikacijaServis.Setup(x => x.Prijava(korisnickoIme, lozinka));

            (bool uspesno, potrosac) = autentifikacijaServis.Object.Prijava(korisnickoIme, lozinka);

            Assert.That(uspesno, Is.True);
            Assert.That(potrosac, Is.Not.Null);
            Assert.That(potrosac.ImeIPrezime, Is.EqualTo(korisnickoIme));
            Assert.That(potrosac.BrPotrosackogUgovora, Is.EqualTo((true, potrosac)));
            Assert.That(potrosac.UkupnaPotrosnjaEnergije, Is.EqualTo(0));
            Assert.That(potrosac.TrenutnoZaduzenje, Is.EqualTo(0));
        }
    }
}
