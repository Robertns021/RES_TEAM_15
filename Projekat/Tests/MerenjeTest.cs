using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using DataBase;

namespace Tests
{
    [TestFixture]
    class MerenjeTest 
    {
        [Test]
        public void NazivTest()
        {
            Assert.DoesNotThrow(() => new Merenje().Naziv = "Novi Sad");
            Assert.AreEqual(new Merenje().Naziv, new Merenje().Naziv);
        }
        [Test]
        public void VremeTest()
        {
            Assert.DoesNotThrow(() => new Merenje().Vreme = DateTime.Now);
            Assert.AreEqual(new Merenje().Vreme, new Merenje().Vreme);
        }
        [Test]
        public void VrednostTest()
        {
            Assert.DoesNotThrow(() => new Merenje().Vrednost = 32);
            Assert.AreEqual(new Merenje().Vrednost, new Merenje().Vrednost);
        }
    }
}
