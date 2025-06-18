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
    public class PotrosnjaServisiTests
    {
        private IPotrosnjaServis potrosnjaServis;
        private Mock<IProizvodnjaServis> garantovanaProizvodnjaServis;
        private Mock<IProizvodnjaServis> komercijalnaProizvodnjaServis;
        private Mock<IEvidencijaServis> garantovanaEvidencijaServis;
        private Mock<IEvidencijaServis> komercijalnaEvidencijaServis;
        private Mock<IPotrosaciRepository> potrosaciRepository;

        public PotrosnjaServisiTests()
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

            garantovanaProizvodnjaServis.Setup(p => p.ObradiZahtev(It.IsAny<int>())).Returns(true);
            komercijalnaProizvodnjaServis.Setup(p => p.ObradiZahtev(It.IsAny<int>())).Returns(true);
            //garantovanaEvidencijaServis.Setup(e => e.EvidentirajIsporuku(It.Is<Evidencija>());
        }

        [Test]
        [TestCase(100, true)]
        [TestCase(100, false)]
        public void EvidentriajPotrosnju_TrueIFalse(int kolicinaEnergije, bool uspesno)
        {
            
        }
    }
}
