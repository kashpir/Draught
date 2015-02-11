using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BusinessLogic;


namespace UnitTests
{
    [TestFixture]
    public class TestSquares
    {
        //[Test]
        //public void TestOnBoard()
        //{
        //    var first = new Square(1, 1);
        //    Assert.AreEqual(true, first.OnBoard());
        //}
        //[Test]
        //public void TestOnBoard2()
        //{
        //    var first = new Square(-1, 1);
        //    Assert.AreEqual(false, first.OnBoard());
        //}
        //[Test]
        //public void TestOnBoard3()
        //{
        //    var first = new Square(3, 9);
        //    Assert.AreEqual(false, first.OnBoard());
        //}
        //[Test]
        //public void TestOnBoard4()
        //{
        //    var first = new Square(5, -4);
        //    Assert.AreEqual(false, first.OnBoard());
        //}
        //[Test]
        //public void TestOnBoard5()
        //{
        //    var first = new Square(3, 3);
        //    Assert.AreEqual(true, first.OnBoard());
        //}
        //[Test]
        //public void TestOnBoard6()
        //{
        //    var first = new Square(4, 2);
        //    Assert.AreEqual(true, first.OnBoard());
        //}
        //[Test]
        //public void TestOnBoard7()
        //{
        //    var first = new Square(3, 2);
        //    Assert.AreEqual(false, first.OnBoard());
        //}
        //[Test]
        //public void TestOnBoard8()
        //{
        //    var first = new Square(1, 6);
        //    Assert.AreEqual(false, first.OnBoard());
        //}
        [Test]
        public void TestEqual()
        {
            var first = new Square(3, 5);
            var second = new Square(3, 5);
            Assert.AreEqual(true, first.AreEqual(second));
        }
        [Test]
        public void TestEqual2()
        {
            var first = new Square(2, 5);
            var second = new Square(3, 5);
            Assert.AreEqual(false, first.AreEqual(second));
        }
        [Test]
        public void TestEqual3()
        {
            var first = new Square(2, 5);
            var second = new Square(2, 6);
            Assert.AreEqual(false, first.AreEqual(second));
        }
    }
}
