using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BusinessLogic;

namespace UnitTests
{
    [TestFixture]
    public class TestDraughtGeometry
    {
        [Test]
        public void TestValidSquare()
        {
            var geometry = new BoardGeometry();
            var square1 = new Square(1, 3);
            var vector = new Vector(-1, 1);
            var square = geometry.ShiftSquare(square1, vector);
            Assert.AreEqual(false, geometry.ValidSquare(square));
        }
        [Test]
        public void TestValidSquare2()
        {
            var geometry = new BoardGeometry();
            var square1 = new Square(3, 3);
            var vector = new Vector(2, 1);
            var square = geometry.ShiftSquare(square1, vector);
            Assert.AreEqual(false, geometry.ValidSquare(square));
        }
        [Test]
        public void TestValidSquare3()
        {
            var geometry = new BoardGeometry();
            var square1 = new Square(3, 3);
            var vector = new Vector(2, -2);
            var square = geometry.ShiftSquare(square1, vector);
            Assert.AreEqual(true, geometry.ValidSquare(square));
        }
        [Test]
        public void TestShiftedSquare()
        {
            var geometry = new BoardGeometry();
            var square1 = new Square(2, 4);
            var vector = new Vector(3, 3);
            var square2 = geometry.ShiftSquare(square1, vector);
            var square3 = new Square(5, 7);
            Assert.AreEqual(true, square2.AreEqual(square3));
        }
        [Test]
        public void TestShiftedSquare2()
        {
            var geometry = new BoardGeometry();
            var square1 = new Square(2, 4);
            var vector = new Vector(-3, 1);
            var square2 = geometry.ShiftSquare(square1, vector);
            var square3 = new Square(-1, 5);
            Assert.AreEqual(true, square2.AreEqual(square3));
        }
        [Test]
        public void TestShiftedSquare3()
        {
            var geometry = new BoardGeometry();
            var square1 = new Square(2, 4);
            var directoin = new Direction(Towards.RightDown);
            var square2 = geometry.ShiftSquare(square1, directoin);
            var square3 = new Square(3, 3);
            Assert.AreEqual(true, square2.AreEqual(square3));
        }
        [Test]
        public void TestShiftedSquare4()
        {
            var geometry = new BoardGeometry();
            var square1 = new Square(2, 4);
            var directoin = new Direction(Towards.LeftUp);
            var square2 = geometry.ShiftSquare(square1, directoin);
            var square3 = new Square(1, 5);
            Assert.AreEqual(true, square2.AreEqual(square3));
        }

    }
}
