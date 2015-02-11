using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class TestPosition
    {
        [Test]
        public void TestTakingExists()
        {
            var arrangement = new SetOfItems("wa3; bb4;");
            var position = new Position(arrangement, ColourNames.White);
            Assert.AreEqual(true, position.TakingExists());
        }
        [Test]
        public void TestSimpleMoves()
        {
            var arrangement = new SetOfItems("wb2; wc3;");
            var position = new Position(arrangement, ColourNames.White);
            Assert.AreEqual(3, position.SimpleMoves().Count());
        }
        [Test]
        public void TestTakings()
        {
            var arrangement = new SetOfItems("wb2; bc3; wd4");
            var position = new Position(arrangement, ColourNames.White);
            Assert.AreEqual(0, position.Takings().Count());
        }
        [Test]
        public void TestTakings1()
        {
            var arrangement = new SetOfItems("wb2; bc3; wd4");
            var position = new Position(arrangement, ColourNames.Black);
            Assert.AreEqual(2, position.Takings().Count());
        }
        [Test]
        public void TestTakings2()
        {
            var arrangement = new SetOfItems("bc3; wb2; wd2; wf2;");
            var position = new Position(arrangement, ColourNames.Black);
            Assert.AreEqual(2, position.Takings().Count());
        }
        [Test]
        public void TestTakings3()
        {
            var arrangement = new SetOfItems("wa1; wc1; bb2; bb4; bb6;");
            var position = new Position(arrangement, ColourNames.White);
            Assert.AreEqual(2, position.Takings().Count());
            Assert.AreEqual(4, position.Takings().Moves[0].Points.Count);
            Assert.AreEqual(4, position.Takings().Moves[1].Points.Count);
        }
        [Test]
        public void TestMoves()
        {
            var arrangement = new SetOfItems("wa1; wc1; bb2; bb4; bb6;");
            var position = new Position(arrangement, ColourNames.Black);
            Assert.AreEqual(4, position.Moves().Count());
        }
        [Test]
        public void TestMoves1()
        {
            var arrangement = new SetOfItems("wa1; wc1; bb2; bb4; bb6; wc3;");
            var position = new Position(arrangement, ColourNames.Black);
            Assert.AreEqual(2, position.Moves().Count());
        }
    }
}
