using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BusinessLogic;

namespace UnitTests
{
    [TestFixture]
    public class TestSetOfDraughts
    {
        [Test]
        public void TestContain()
        {
            var position = new SetOfItems();
            var first = new Square(3, 1);
            Assert.AreEqual(false, position.Contain(first));
        }
        [Test]
        public void TestAdd()
        {
            var position = new SetOfItems();
            var first = new Item(3, 1, ColourNames.White);
            position.AddItem(first);
            Assert.AreEqual(1, position.Arrangement.Count);
        }
        [Test]
        public void TestAdd2()
        {
            var position = new SetOfItems();
            var first = new Item(3, 1, ColourNames.White);
            position.AddItem(first);
            Assert.AreEqual(3, position.Arrangement[0].Coordinates.FirstCoordinate);
            Assert.AreEqual(1, position.Arrangement[0].Coordinates.SecondCoordinate);
        }
        [Test]
        public void TestAdd3()
        {
            var position = new SetOfItems();
            position.AddItem(new Item("wc1"));
            position.AddItem(new Item("wb4"));
            Assert.AreEqual(2, position.Arrangement.Count);
            Assert.AreEqual(2, position.Arrangement[1].Coordinates.FirstCoordinate);
            Assert.AreEqual(4, position.Arrangement[1].Coordinates.SecondCoordinate);
        }
        [Test]
        public void TestSetFromLine()
        {
            var input = "wc3;";
            var first = new Item(3, 3, ColourNames.White);
            var position = new SetOfItems(input);
            Assert.AreEqual(1, position.Arrangement.Count);
            Assert.AreEqual(true, position.Arrangement[0].AreEqual(first));
        }
        [Test]
        public void TestSetFromLine2()
        {
            var input = "wc3; wd2; wb2; bd4; bb4; bc5;";
            var second = new Item(4, 2, ColourNames.White);
            var sixth = new Item(3, 5, ColourNames.Black);
            var position = new SetOfItems(input);
            Assert.AreEqual(6, position.Arrangement.Count);
            Assert.AreEqual(true, position.Arrangement[1].AreEqual(second));
            Assert.AreEqual(true, position.Arrangement[5].AreEqual(sixth));
        }
    }
}
