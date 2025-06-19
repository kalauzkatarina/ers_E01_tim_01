using Domain.Services;
using NUnit.Framework;
using Services.EvidencijaServisi;

namespace Tests.Services.EvidencijaServisi
{
    [TestFixture]
    public class EvidencijaKomercijalnoServisTests
    {
        private IEvidencijaServis evidencijaKomercijalno;

        public EvidencijaKomercijalnoServisTests()
        {
            evidencijaKomercijalno = new EvidencijaKomercijalnoServis();
        }

        [SetUp]
        public void SetUp()
        {
            evidencijaKomercijalno = new EvidencijaKomercijalnoServis();
        }

        [Test]
        [TestCase("{DateTime.Now:dd.MM.yyyy HH:mm}: Izdato je 0 kW.")]
        public void EvidentirajIsporuku_Ispravno_VracaTrue(string ispis)
        {
            bool povratnaVrednost = evidencijaKomercijalno.EvidentirajIsporuku(ispis);

            Assert.That(povratnaVrednost, Is.True);
        }
    }
}
