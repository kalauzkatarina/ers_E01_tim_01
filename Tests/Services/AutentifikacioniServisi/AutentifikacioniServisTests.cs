using Domain.Enums;
using Domain.Models;
using Domain.Services;
using Moq;
using NUnit.Framework;

namespace Tests.Services.AutentifikacioniServisi
{
    [TestFixture]
    public class AutentifikacioniServisTests
    {
        private Mock<IAutentifikacijaServis> autentifikacijaServis;
        public AutentifikacioniServisTests() => autentifikacijaServis = new Mock<IAutentifikacijaServis>();

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

            Assert.That(uspesno, Is.True); //proverava da li je prijava bila uspesna
            Assert.That(prijavljeni, Is.Not.Null); //proverava da korisnik nije null
            Assert.That(prijavljeni.ImeIPrezime, Is.EqualTo(korisnickoIme)); //proverava jesu li podaci tacni
            Assert.That(prijavljeni.BrPotrosackogUgovora, Is.EqualTo(lozinka));
        }

        [Test]
        [TestCase("Petar Petrovic", "EPS1111P")]
        public void Prijava_SaNeispravnimPodacima_VracaFalse(string korisnickoIme, string lozinka)
        {
            Potrosac potrosac;
            autentifikacijaServis.Setup(x => x.Prijava(korisnickoIme, lozinka)).Returns((false, new Potrosac()));

            (bool uspesno, potrosac) = autentifikacijaServis.Object.Prijava(korisnickoIme, lozinka);

            Assert.That(uspesno, Is.False); //proverava neuspesnu prijavu
            Assert.That(potrosac, Is.Not.Null);
            Assert.That(potrosac.ImeIPrezime, Is.Null.Or.Empty);
            Assert.That(potrosac.BrPotrosackogUgovora, Is.Null.Or.Empty);
            Assert.That(potrosac.UkupnaPotrosnjaEnergije, Is.EqualTo(0));
            Assert.That(potrosac.TrenutnoZaduzenje, Is.EqualTo(0));
        }
    }
}
