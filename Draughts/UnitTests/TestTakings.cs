using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class TestTakings
    {
        [Test]
        public void TestTaking1()
        {
            var arrangement = new SetOfDraughts("wa3; bb4; bd6");
            var position = new Position(arrangement, Peculiarity.Colours.White);
            var moves = position.Moves();
            var square = new Square("e7");
            Assert.AreEqual(1, moves.Count());
            Assert.AreEqual(3, moves.Moves[0].Points.Count);
            Assert.AreEqual(true, moves.Moves[0].Points[2].AreEqual(square));
        }
        [Test]
        public void TestTaking2()
        {
            var arrangement = new SetOfDraughts("wa3; bb4; bb2");
            var position = new Position(arrangement, Peculiarity.Colours.White);
            var moves = position.Moves();
            Assert.AreEqual(2, moves.Count());
            Assert.AreEqual(2, moves.Moves[0].Points.Count);
            Assert.AreEqual(2, moves.Moves[1].Points.Count);
        }
        [Test]
        public void TestTaking3()
        {
            var arrangement = new SetOfDraughts("wa3; bb4; bd6; bf6; bh4");
            var position = new Position(arrangement, Peculiarity.Colours.White);
            var moves = position.Moves();
            Assert.AreEqual(1, moves.Count());
            Assert.AreEqual(4, moves.Moves[0].Points.Count);
            var square = new Square("c5");
            Assert.AreEqual(true, moves.Moves[0].Points[1].AreEqual(square));
        }
        [Test]
        public void TestTaking4()
        {
            var arrangement = new SetOfDraughts("wc3; bb4; bb6; bd6; bd4");
            var position = new Position(arrangement, Peculiarity.Colours.White);
            var moves = position.Moves();
            Assert.AreEqual(2, moves.Count());
            Assert.AreEqual(5, moves.Moves[0].Points.Count);
            Assert.AreEqual(5, moves.Moves[1].Points.Count);
            var square = new Square("c3");
            Assert.AreEqual(true, moves.Moves[0].Points[4].AreEqual(square));
            Assert.AreEqual(true, moves.Moves[1].Points[4].AreEqual(square));
        }
        [Test]
        public void TestTaking5()
        {
            var arrangement = new SetOfDraughts("wc3; wd4; wc5; we3; bf4; bd6;");
            var position = new Position(arrangement, Peculiarity.Colours.Black);
            var moves = position.Moves();
            Assert.AreEqual(2, moves.Count());
            Assert.AreEqual(3, moves.Moves[0].Points.Count);
            Assert.AreEqual(3, moves.Moves[1].Points.Count);
        }
        [Test]
        public void TestTaking6()
        {
            var arrangement = new SetOfDraughts("wc3; wd4; wc5; we3; wc7; bf4; bd6;");
            var position = new Position(arrangement, Peculiarity.Colours.Black);
            var moves = position.Moves();
            Assert.AreEqual(3, moves.Count());
        }
        [Test]
        public void TestTaking7()
        {
            var arrangement = new SetOfDraughts("wc3; wc5; we3; wc7; bf4; bd6; bb8");
            var position = new Position(arrangement, Peculiarity.Colours.Black);
            var moves = position.Moves();
            Assert.AreEqual(2, moves.Count());
            Assert.AreEqual(3, moves.Moves[0].Points.Count);
            Assert.AreEqual(3, moves.Moves[1].Points.Count);
        }
        [Test]
        public void TestTaking8()
        {
            var arrangement = new SetOfDraughts("wc3; wc5; wc7; we3; we5; we7; bf8");
            var position = new Position(arrangement, Peculiarity.Colours.Black);
            var moves = position.Moves();
            Assert.AreEqual(3, moves.Count());
        }
        [Test]
        public void TestTaking9()
        {
            var arrangement = new SetOfDraughts("wc3; wc5; wg3; we3; we5; we7; bf8");
            var position = new Position(arrangement, Peculiarity.Colours.Black);
            var moves = position.Moves();
            Assert.AreEqual(4, moves.Count());
        }
    }
}
