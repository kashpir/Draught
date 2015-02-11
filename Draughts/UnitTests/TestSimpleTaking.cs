using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BusinessLogic;

namespace UnitTests
{
    [TestFixture]
    public class TestSimpleTaking
    {
        [Test]
        public void TestTaking()
        {
            var arrangement = new SetOfItems("wa3; bb4;");
            var position = new Position(arrangement, ColourNames.White);
            var moves = position.Moves();
            var square = new Square("c5");
            Assert.AreEqual(1, moves.Count());
            Assert.AreEqual(true, moves.Moves[0].AreEqual(1,square));
        }
        [Test]
        public void TestTaking2()
        {
            var arrangement = new SetOfItems("wa3; bb4; wc3");
            var position = new Position(arrangement, ColourNames.White);
            var moves = position.Moves();
            var square1 = new Square("c5");
            var square2 = new Square("a5");
            Assert.AreEqual(2, moves.Count());
            Assert.AreEqual(true, moves.Moves[0].AreEqual(1,square1)
                || moves.Moves[1].AreEqual(1, square1));
            Assert.AreEqual(true, moves.Moves[0].AreEqual(1,square2)
                || moves.Moves[1].AreEqual(1,square2));
        }
        [Test]
        public void TestTaking3()
        {
            var arrangement = new SetOfItems("wa3; bb2;");
            var position = new Position(arrangement, ColourNames.White);
            var moves = position.Moves();
            var square = new Square("c1");
            Assert.AreEqual(1, moves.Count());
            Assert.AreEqual(true, moves.Moves[0].AreEqual(1,square));
        }
        [Test]
        public void TestTaking4()
        {
            var arrangement = new SetOfItems("wa3; bb4; wc3");
            var position = new Position(arrangement, ColourNames.Black);
            var moves = position.Moves();
            var square = new Square("d2");
            Assert.AreEqual(1, moves.Count());
            Assert.AreEqual(true, moves.Moves[0].AreEqual(1,square));
        }
        [Test]
        public void TestTaking5()
        {
            var arrangement = new SetOfItems("wc3; bd4; we3; wc5; we5;");
            var position = new Position(arrangement, ColourNames.Black);
            var moves = position.Moves();
            Assert.AreEqual(4, moves.Count());
        }
        [Test]
        public void TestTaking6()
        {
            var arrangement = new SetOfItems("wg5; bh4;");
            var position = new Position(arrangement, ColourNames.White);
            Assert.AreEqual(false, position.TakingExists());
            var moves = position.Moves();
            Assert.AreEqual(2, moves.Count());
        }
    }
}
