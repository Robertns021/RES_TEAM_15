using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Tests
{
    [TestFixture]
    class RacunanjeTest
    {
        [Test]
        public void NazivTest()
        {
            Assert.DoesNotThrow(() => new Racunanje().Naziv = "Novi Sad");
            Assert.AreEqual(new Racunanje().Naziv, new Racunanje().Naziv);
        }
        [Test]
        public void VremeProracunaTest()
        {
            Assert.DoesNotThrow(() => new Racunanje().VremeProracuna = DateTime.Now);
            Assert.AreEqual(new Racunanje().VremeProracuna, new Racunanje().VremeProracuna);
        }
        [Test]
        public void PoslednjeVremeTest()
        {
            Assert.DoesNotThrow(() => new Racunanje().PoslednjeVreme = DateTime.Now);
            Assert.AreEqual(new Racunanje().PoslednjeVreme, new Racunanje().PoslednjeVreme);
        }
        [Test]
        public void IDTest()
        {
            Assert.DoesNotThrow(() => new Racunanje().Id = 32);
            Assert.AreEqual(new Racunanje().Id, new Racunanje().Id);
        }
        [Test]
        public void VrednostTest()
        {
            Assert.DoesNotThrow(() => new Racunanje().Vrednost = 32.3);
            Assert.AreEqual(new Racunanje().Vrednost, new Racunanje().Vrednost);
        }
    }
}
