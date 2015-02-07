using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BusinessLogic;

namespace UnitTests
{
    [TestFixture]
    public class TestDraughtInPlay
    {
        [Test]
        public void TestCreation()
        {
            var first = new Draught(3, 1, Peculiarity.Colours.White);
            var set = new SetOfDraughts();
            set.AddDraught(first);
            var temp = new DraughtInPlay(first, set);
            Assert.AreEqual(1, temp.State.Arrangement.Count);
        }
        [Test]
        public void TestDraughtInPlay1()
        {
            var first = new Draught("wa3");
            var second = new Draught("bb4");
            var set = new SetOfDraughts("wa3; bb4;");
            var temp = new DraughtInPlay(first, set);
            Assert.AreEqual(true, temp.MainDraught.AreEqual(first));
            Assert.AreEqual(2, temp.State.Arrangement.Count);
            Assert.AreEqual(true, temp.State.Contain(first));
            Assert.AreEqual(true, temp.State.Contain(second));
        }
        [Test]
        public void TestDraughtInPlay2()
        {
            var first = new Draught("wa3");
            var second = new Draught("bb4");
            var set = new SetOfDraughts("wa3; bb4;");
            var temp = new DraughtInPlay(second, set);
            Assert.AreEqual(true, temp.MainDraught.AreEqual(second));
            Assert.AreEqual(2, temp.State.Arrangement.Count);
            Assert.AreEqual(true, temp.State.Contain(first));
            Assert.AreEqual(true, temp.State.Contain(second));
        }
        [Test]
        public void TestTakingExists1()
        {
            var arrangement = new SetOfDraughts("wc3;");
            var draught = new Draught("wc3");
            var temp = new DraughtInPlay(draught, arrangement);
            Assert.AreEqual(false, temp.TakingExists());
        }
        [Test]
        public void TestTakingExists2()
        {
            var arrangement = new SetOfDraughts("ba5;");
            var draught = new Draught("ba5");
            var temp = new DraughtInPlay(draught, arrangement);
            Assert.AreEqual(false, temp.TakingExists());
        }
        [Test]
        public void TestTakingExists3()
        {
            var arrangement = new SetOfDraughts("wc1; wb2;");
            var draught = new Draught("wc1");
            var temp = new DraughtInPlay(draught, arrangement);
            Assert.AreEqual(false, temp.TakingExists());
        }
        [Test]
        public void TestTakingExists4()
        {
            var arrangement = new SetOfDraughts("wc1; bb2;");
            var draught = new Draught("wc1");
            var temp = new DraughtInPlay(draught, arrangement);
            Assert.AreEqual(true, temp.TakingExists());
        }
        [Test]
        public void TestTakingExists5()
        {
            var arrangement = new SetOfDraughts("wc1; bb2;");
            var draught = new Draught("bb21");
            var temp = new DraughtInPlay(draught, arrangement);
            Assert.AreEqual(false, temp.TakingExists());
        }
        [Test]
        public void TestTakingExists6()
        {
            var arrangement = new SetOfDraughts("wa3; bh8;");
            var draught = new Draught("wa3");
            var temp = new DraughtInPlay(draught, arrangement);
            Assert.AreEqual(false, temp.TakingExists());
        }
        [Test]
        public void TestTakingExists7()
        {
            var arrangement = new SetOfDraughts("wd4; be5;");
            var draught = new Draught("be5");
            var temp = new DraughtInPlay(draught, arrangement);
            Assert.AreEqual(true, temp.TakingExists());
        }
        [Test]
        public void TestTakings()
        {
            var arrangement = new SetOfDraughts("wd4; be5;");
            var draught = new Draught("be5");
            var temp = new DraughtInPlay(draught, arrangement);
            Assert.AreEqual(1, temp.Takings().Count());
        }
        [Test]
        public void TestTakings2()
        {
            var arrangement = new SetOfDraughts("wd4; be5;");
            var draught = new Draught("be5");
            var temp = new DraughtInPlay(draught, arrangement);
            Assert.AreEqual(2, temp.Takings().Moves[0].Points.Count);
        }
        [Test]
        public void TestTakings3()
        {
            var arrangement = new SetOfDraughts("wd4; be5;");
            var draught = new Draught("wd4");
            var square = new Square("f6");
            var temp = new DraughtInPlay(draught, arrangement);
            Assert.AreEqual(true, temp.Takings().Moves[0].Points[1].AreEqual(square));
        }
        [Test]
        public void TestTakings4()
        {
            var arrangement = new SetOfDraughts("wd4; be5; be3; bc3; bc5");
            var draught = new Draught("wd4");
            var temp = new DraughtInPlay(draught, arrangement);
            Assert.AreEqual(4, temp.Takings().Count());
        }
        [Test]
        public void TestTakings5()
        {
            var arrangement = new SetOfDraughts("wa1; bb2; bd4; bf6;");
            var draught = new Draught("wa1");
            var square = new Square("g7");
            var temp = new DraughtInPlay(draught, arrangement);
            Assert.AreEqual(1, temp.Takings().Count());
            Assert.AreEqual(4, temp.Takings().Moves[0].Points.Count);
            Assert.AreEqual(true, temp.Takings().Moves[0].Points[3].AreEqual(square));
        }
    }
}
