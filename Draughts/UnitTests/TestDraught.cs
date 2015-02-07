using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BusinessLogic;

namespace UnitTests
{
    [TestFixture]
    class TestDraught
    {
        [Test]
        public void TestConstructor()
        {
            var first = new Draught(1, 5, Peculiarity.Colours.White);
            Assert.AreEqual(1,first.Coordinates.FirstCoordinate);
            Assert.AreEqual(5, first.Coordinates.SecondCoordinate);
            Assert.AreEqual(Peculiarity.Colours.White, first.Colour);
        }
        [Test]
        public void TestEqual()
        {
            var first = new Draught(4, 8, Peculiarity.Colours.Black);
            var second = new Draught(2, 4, Peculiarity.Colours.Black);
            Assert.AreEqual(false, first.AreEqual(second));
        }
        [Test]
        public void TestEqual1()
        {
            var first = new Draught(2, 4, Peculiarity.Colours.White);
            var second = new Draught(2, 4, Peculiarity.Colours.Black);
            Assert.AreEqual(false, first.AreEqual(second));
        }
        [Test]
        public void TestEqual2()
        {
            var first = new Draught(3, 5, Peculiarity.Colours.White);
            var second = new Draught(3, 5, Peculiarity.Colours.White);
            Assert.AreEqual(true, first.AreEqual(second));
        }
        [Test]
        public void TestGetColour()
        {
            var first = new Draught(3, 5, Peculiarity.GetColour('w'));
            var second = new Draught(3, 5, Peculiarity.Colours.White);
            Assert.AreEqual(true, first.AreEqual(second));
        }
        [Test]
        public void TestGetColour2()
        {
            var first = new Draught(1, 7, Peculiarity.GetColour('b'));
            var second = new Draught(1, 7, Peculiarity.Colours.Black);
            Assert.AreEqual(true, first.AreEqual(second));
        }
    }
}
