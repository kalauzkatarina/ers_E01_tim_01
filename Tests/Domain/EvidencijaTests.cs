using Domain.Enums;
using Domain.Models;
using NUnit.Framework;

namespace Tests.Domain
{
    [TestFixture]
    internal class EvidencijaTests
    {
        [Test]
        [TestCase(10)]
        [TestCase(20)]
        [TestCase(30)]

        public void EvidencijaKonstruktor_SaIspravnimPodacima_Ok(double kolicina)
        {
            DateTime vreme = DateTime.Now;
            
        }
    }
}
