using Domain.Enums;
using Domain.Models;
using Domain.Services;
using Domain.Repositories.PotrosaciRepositories;
using Moq;
using NUnit.Framework;
using Services.ServisiPotrosnje;

namespace Tests.Services.PotrosnjaServisi
{
    [TestFixture]
    public class PotrosnjaServisTests
    {
        private IPotrosnjaServis potrosnjaServis;
        private Potrosac testPotrosac;
        private Mock<IProizvodnjaServis> garantovanaProizvodnjaServis;
        private Mock<IProizvodnjaServis> komercijalnaProizvodnjaServis;
        private Mock<IEvidencijaServis> garantovanaEvidencijaServis;
        private Mock<IEvidencijaServis> komercijalnaEvidencijaServis;
        private Mock<IPotrosaciRepository> potrosaciRepository;

        public PotrosnjaServisTests()
        {
            garantovanaProizvodnjaServis = new Mock<IProizvodnjaServis>();
            komercijalnaProizvodnjaServis = new Mock<IProizvodnjaServis>();
            garantovanaEvidencijaServis = new Mock<IEvidencijaServis>();
            komercijalnaEvidencijaServis = new Mock<IEvidencijaServis>();
            potrosaciRepository = new Mock<IPotrosaciRepository>();
            potrosnjaServis = new PotrosnjaServis(garantovanaProizvodnjaServis.Object, komercijalnaProizvodnjaServis.Object, garantovanaEvidencijaServis.Object, komercijalnaEvidencijaServis.Object);
        }

        [SetUp]
        public void Setup()
        {
            garantovanaProizvodnjaServis = new Mock<IProizvodnjaServis>();
            komercijalnaProizvodnjaServis = new Mock<IProizvodnjaServis>();
            garantovanaEvidencijaServis = new Mock<IEvidencijaServis>();
            komercijalnaEvidencijaServis = new Mock<IEvidencijaServis>();
            potrosaciRepository = new Mock<IPotrosaciRepository>();
            potrosnjaServis = new PotrosnjaServis(garantovanaProizvodnjaServis.Object, komercijalnaProizvodnjaServis.Object, garantovanaEvidencijaServis.Object, komercijalnaEvidencijaServis.Object);

            testPotrosac = new Potrosac("Mirko Mirkovic", "EPS5723F", TipSnabdevanja.GARANTOVANO, 0, 0);

            typeof(PotrosnjaServis)
                .GetField("potrosacRepository", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.SetValue(potrosnjaServis, potrosaciRepository.Object);

            //garantovanaProizvodnjaServis.Setup(p => p.ObradiZahtev(It.IsAny<double>())).Returns(true);
            //komercijalnaProizvodnjaServis.Setup(p => p.ObradiZahtev(It.IsAny<double>())).Returns(true);
            //garantovanaEvidencijaServis.Setup(e => e.EvidentirajIsporuku(It.Is<Evidencija>());
        }

        [Test]
        [TestCase(100)]
        [TestCase(200)]
        [TestCase(50)]
        public void EvidentirajPotrosnju_GarantovanoUspesno_VracaTrue(double kolicina)
        {
            potrosaciRepository.Setup(r => r.PronadjiPotrosac(It.IsAny<Guid>())).Returns(testPotrosac);
            garantovanaProizvodnjaServis.Setup(p => p.ObradiZahtev(It.IsAny<double>())).Returns(true);
            garantovanaEvidencijaServis.Setup(e => e.EvidentirajIsporuku(It.IsAny<string>())).Returns(true);


            bool rezultat = potrosnjaServis.EvidentirajPotrosnju(Guid.NewGuid(), kolicina);

            Assert.That(rezultat, Is.True);
            Assert.That(testPotrosac.TrenutnoZaduzenje, Is.EqualTo(kolicina * 22.72));
        }

        [Test]
        [TestCase(100)]
        [TestCase(200)]
        [TestCase(50)]
        public void EvidentirajPotrosnju_KomercijalnoUspesno_VracaTrue(double kolicina)
        {
            testPotrosac.NacinSnabdevanja = TipSnabdevanja.KOMERCIJALNO;
            potrosaciRepository.Setup(r => r.PronadjiPotrosac(It.IsAny<Guid>())).Returns(testPotrosac);
            komercijalnaProizvodnjaServis.Setup(p => p.ObradiZahtev(It.IsAny<double>())).Returns(true);
            komercijalnaEvidencijaServis.Setup(e => e.EvidentirajIsporuku(It.IsAny<string>())).Returns(true);

            bool rezultat = potrosnjaServis.EvidentirajPotrosnju(Guid.NewGuid(), kolicina);

            Assert.That(rezultat, Is.True);
            Assert.That(testPotrosac.TrenutnoZaduzenje, Is.EqualTo(kolicina * 43.02));
        }

        [Test]
        [TestCase(100)]
        [TestCase(200)]
        [TestCase(50)]
        public void EvidentirajPotrosnju_PotrosacNepostojeci_VracaFalse(double kolicina)
        {
            potrosaciRepository.Setup(r => r.PronadjiPotrosac(It.IsAny<Guid>())).Returns(new Potrosac { ImeIPrezime = "" });

            bool rezultat = potrosnjaServis.EvidentirajPotrosnju(Guid.NewGuid(), kolicina);

            Assert.That(rezultat, Is.False);
        }

        [Test]
        [TestCase(500)]
        [TestCase(200)]
        [TestCase(50)]
        public void EvidentirajPotrosnju_GarantovanoNemaEnergije_VracaFalse(double kolicina)
        {
            potrosaciRepository.Setup(r => r.PronadjiPotrosac(It.IsAny<Guid>())).Returns(testPotrosac);
            garantovanaProizvodnjaServis.Setup(p => p.ObradiZahtev(It.IsAny<double>())).Returns(false);

            bool rezultat = potrosnjaServis.EvidentirajPotrosnju(Guid.NewGuid(), kolicina);

            Assert.That(rezultat, Is.False);
        }

        [Test]
        [TestCase(500)]
        [TestCase(200)]
        [TestCase(50)]
        public void EvidentirajPotrosnju_KomercijalnoNemaEnergije_VracaFalse(double kolicina)
        {
            testPotrosac.NacinSnabdevanja = TipSnabdevanja.KOMERCIJALNO;
            potrosaciRepository.Setup(r => r.PronadjiPotrosac(It.IsAny<Guid>())).Returns(testPotrosac);
            komercijalnaProizvodnjaServis.Setup(p => p.ObradiZahtev(It.IsAny<double>())).Returns(false);

            bool rezultat = potrosnjaServis.EvidentirajPotrosnju(Guid.NewGuid(), kolicina);

            Assert.That(rezultat, Is.False);
        }

        [Test]
        [TestCase(0)] //granicni slucaj
        public void EvidentirajPotrosnju_KolicinaJeNula_VracaFalse(double kolicina)
        {
            potrosaciRepository.Setup(r => r.PronadjiPotrosac(It.IsAny<Guid>())).Returns(testPotrosac);

            bool rezultat = potrosnjaServis.EvidentirajPotrosnju(Guid.NewGuid(), kolicina);

            Assert.That(rezultat, Is.False);
        }
    }
}
