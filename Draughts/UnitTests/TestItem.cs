using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BusinessLogic;

namespace UnitTests
{
    [TestFixture]
    class TestItem
    {
        [Test]
        public void TestConstructor()
        {
            var first = new Item(1, 5, ColourNames.White);
            Assert.AreEqual(1,first.Coordinates.FirstCoordinate);
            Assert.AreEqual(5, first.Coordinates.SecondCoordinate);
            Assert.AreEqual(ColourNames.White, first.Colour());
        }
        [Test]
        public void TestEqual()
        {
            var first = new Item(4, 8, ColourNames.Black);
            var second = new Item(2, 4, ColourNames.Black);
            Assert.AreEqual(false, first.AreEqual(second));
        }
        [Test]
        public void TestEqual1()
        {
            var first = new Item(2, 4, ColourNames.White);
            var second = new Item(2, 4, ColourNames.Black);
            Assert.AreEqual(false, first.AreEqual(second));
        }
        [Test]
        public void TestEqual2()
        {
            var first = new Item(3, 5, ColourNames.White);
            var second = new Item(3, 5, ColourNames.White);
            Assert.AreEqual(true, first.AreEqual(second));
        }
        [Test]
        public void TestGetColour()
        {
            var first = new Item(3, 5, ColourNames.White);
            var second = new Item(3, 5, ColourNames.White);
            Assert.AreEqual(true, first.AreEqual(second));
        }
        [Test]
        public void TestGetColour2()
        {
            var first = new Item(1, 7, ColourNames.Black);
            var second = new Item(1, 7, ColourNames.Black);
            Assert.AreEqual(true, first.AreEqual(second));
        }
    }
}
