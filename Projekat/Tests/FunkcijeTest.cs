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
        Mock<DataAccess> da = new Mock<DataAccess>();

        IFunkcije testingDummy;
        [SetUp]
        public void Funkcije()
        {
            testingDummy = new Funkcije();
        }

        public void FunkcijaMin()//kad sve radi
        {

        }
    }
}
