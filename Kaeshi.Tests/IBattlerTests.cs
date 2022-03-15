using Kaeshi.Entity;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kaeshi.Tests
{
    class IBattlerTests
    {
        [Test]
        public void InjureSubtractsLife()
        {
            var sut = new Character(0,0,10);

            var expectedLifeDescription = "Life: 8";
            sut.Injure(2);

            Assert.IsTrue(sut.IsAlive());
            Assert.IsTrue(sut.Observe().Contains(expectedLifeDescription));
        }

        [Test]
        public void InjureCanKill()
        {
            var sut = new Character(0, 0, 10);

            var expectedDescription = "Dead body\r\n";

            sut.Injure(10);
            Assert.IsFalse(sut.IsAlive());
            Assert.AreEqual(expectedDescription, sut.Observe());
        }

        
        
    }
}
