using Domain.Services;
using NUnit.Framework;
using Services.ProizvodnjaServisi;

namespace Tests.Services.ProizvodnjaServisi
{
    [TestFixture]
    public class KomercijalnaProizvodnjaServisTests
    {
        private IProizvodnjaServis komercijalnoServis;

        public KomercijalnaProizvodnjaServisTests()
        {
            komercijalnoServis = new KomercijalnaProizvodnjaServis();
        }

        [SetUp]
        public void SetUp()
        {
            komercijalnoServis = new KomercijalnaProizvodnjaServis();
        }

        [Test]
        [TestCase(100)]
        [TestCase(500)]
        [TestCase(250)]
        public void ObradiZahtev_DovoljnoEnergije_VracaTrue(double kolicinaEnergije)
        {
            bool povratnaVrednost;
            povratnaVrednost = komercijalnoServis.ObradiZahtev(kolicinaEnergije);

            Assert.That(povratnaVrednost, Is.True);
        }

        [Test]
        [TestCase(-2)]
        public void ObradiZahtev_NijeOdgovarajucaKolicinaEnergije_VracaFalse(double kolicinaEnergije)
        {
            bool povratnaVrednost;
            povratnaVrednost = komercijalnoServis.ObradiZahtev(kolicinaEnergije);

            Assert.That(povratnaVrednost, Is.False);
        }

        [Test]
        [TestCase(0)]
        public void ObradiZahtev_GranicniSlucaj_VracaFalse(double kolicinaEnergije)
        {
            bool povratnaVrednost;
            povratnaVrednost = komercijalnoServis.ObradiZahtev(kolicinaEnergije);

            Assert.That(povratnaVrednost, Is.False);
        }
    }
}
