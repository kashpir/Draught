using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BusinessLogic;

namespace UnitTests
{
    [TestFixture]
    public class TestLimits
    {
        [Test]
        public void TestInLimits()
        {
            var square1 = new Square(1, 3);
            var board = new Limits(8,8);
            var square2 = new Square(0, 4);
            Assert.AreEqual(false, board.InLimit(square2));
        }
    }
}
