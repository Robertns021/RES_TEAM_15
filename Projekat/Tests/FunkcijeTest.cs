using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunkcijeProjekat;
using Moq;
using Common;
using DataBase;

namespace Tests
{
    [TestFixture]
    class FunkcijeTest
    {
        Mock<IDataAccess> dapom = new Mock<IDataAccess>();
        Mock<IRacunanje> rapom = new Mock<IRacunanje>();

        IFunkcije testingDummy;
        IDataAccess da;
        IRacunanje ra;

        private const int ID = 1;
        private const int VREDNOST = 1;
        
        [SetUp]
        public void Funkcije()
        {
            ra = rapom.Object;
            testingDummy = new Funkcije();
            dapom.Setup(d => d.DobaviMerenja()).Returns(new List<Merenje>(0));
            dapom.Setup(d => d.DobaviPoslednjeVreme()).Returns(Convert.ToDateTime("6 / 7 / 2021 10:04:26"));
            dapom.Setup(d => d.UpisiURacunanja(ra)).Verifiable();
            da = dapom.Object;
        }

        [Test]
        public void FunkcijaMin()//kad sve radi
        {
            rapom.Reset();
            ra = rapom.Object;
            ra.Id = 1;
            ra.Naziv = "novi sad";
            ra.Vrednost = 100;
            ra.VremeProracuna = Convert.ToDateTime("6 / 7 / 2021 10:04:26");
            ra.PoslednjeVreme = Convert.ToDateTime("6 / 7 / 2021 10:04:26");
            rapom.Setup(pom => pom.Id).Returns(1);
            rapom.Setup(pom => pom.Naziv).Returns("novi sad");
            rapom.Setup(pom => pom.Vrednost).Returns(100);
            rapom.Setup(pom => pom.VremeProracuna).Returns(Convert.ToDateTime("6 / 7 / 2021 10:04:26"));
            rapom.Setup(pom => pom.PoslednjeVreme).Returns(Convert.ToDateTime("6 / 7 / 2021 10:04:26"));

            dapom.Setup(d => d.UpisiURacunanja(ra)).Verifiable();

            IRacunanje rez = testingDummy.FunkcijaMin(da,ra);

            Assert.AreEqual(1, rez.Id);
            Assert.AreEqual("novi sad", rez.Naziv);
            Assert.AreEqual(100, rez.Vrednost);
            Assert.AreEqual("6 / 7 / 2021 10:04:26", rez.VremeProracuna);
            Assert.AreEqual("6 / 7 / 2021 10:04:26", rez.PoslednjeVreme);

            dapom.Verify(d => d.UpisiURacunanja(ra), Times.Once);
        }


        [Test]
        public void FunkcijaMinNeradi()//kad sve radi
        {
            rapom.Reset();
            ra = rapom.Object;
            ra.Id = 1;
            ra.Naziv = "novi sad";
            ra.Vrednost = 100;
            ra.VremeProracuna = Convert.ToDateTime("6 / 7 / 2021 10:04:26");
            ra.PoslednjeVreme = Convert.ToDateTime("6 / 7 / 2021 10:04:26");
            rapom.Setup(pom => pom.Id).Returns(1);
            rapom.Setup(pom => pom.Naziv).Returns("novi sad");
            rapom.Setup(pom => pom.Vrednost).Returns(100);
            rapom.Setup(pom => pom.VremeProracuna).Returns(Convert.ToDateTime("6 / 7 / 2021 10:04:26"));
            rapom.Setup(pom => pom.PoslednjeVreme).Returns(Convert.ToDateTime("6 / 7 / 2021 10:04:26"));

            dapom.Setup(d => d.UpisiURacunanja(ra)).Verifiable();

            IRacunanje rez = testingDummy.FunkcijaMin(da, ra);

            Assert.AreNotEqual(0, rez.Id);
            Assert.AreNotEqual("", rez.Naziv);
            Assert.AreNotEqual(50, rez.Vrednost);
            Assert.AreNotEqual("6 / 7 / 10000 10:04:26", rez.VremeProracuna);
            Assert.AreNotEqual("6 / 7 / 10000 10:04:26", rez.PoslednjeVreme);

            dapom.Verify(d => d.UpisiURacunanja(ra), Times.Once);
        }


        [Test]
        public void FunkcijaMinGranica()//kad sve radi
        {
            rapom.Reset();
            ra = rapom.Object;
            ra.Id = 1;
            ra.Naziv = "novi sad";
            ra.Vrednost = 100;
            ra.VremeProracuna = Convert.ToDateTime("6 / 7 / 2021 10:04:26");
            ra.PoslednjeVreme = Convert.ToDateTime("6 / 7 / 2021 10:04:26");
            rapom.Setup(pom => pom.Id).Returns(1);
            rapom.Setup(pom => pom.Naziv).Returns("novi sad");
            rapom.Setup(pom => pom.Vrednost).Returns(100);
            rapom.Setup(pom => pom.VremeProracuna).Returns(Convert.ToDateTime("6 / 7 / 2021 10:04:26"));
            rapom.Setup(pom => pom.PoslednjeVreme).Returns(Convert.ToDateTime("6 / 7 / 2021 10:04:26"));

            dapom.Setup(d => d.UpisiURacunanja(ra)).Verifiable();

            IRacunanje rez = testingDummy.FunkcijaMin(da, ra);

            Assert.AreEqual(1, rez.Id);
            Assert.AreEqual("novi sad", rez.Naziv);
            Assert.AreEqual(100, rez.Vrednost);
            Assert.AreEqual("6 / 7 / 9999 10:04:26", rez.VremeProracuna);
            Assert.AreEqual("6 / 7 / 9999 10:04:26", rez.PoslednjeVreme);

            dapom.Verify(d => d.UpisiURacunanja(ra), Times.Once);
        }
    }
}
