using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BusinessLogic;

namespace UnitTests
{
    [TestFixture]
    class TestSimpleMoves
    {
        [Test]
        public void TestSimpleMoveForWhite()
        {
            var first = new Draught(3, 1, Peculiarity.Colours.White);
            var set = new SetOfDraughts();
            set.AddDraught(first);
            var temp = new DraughtInPlay(first, set);
            var moves = temp.SimpleMovesForWhite();
            Assert.AreEqual(2, moves.Count());
            Assert.AreEqual(2, moves.Moves[0].Points.Count);
            Assert.AreEqual(2, moves.Moves[1].Points.Count);
        }
        [Test]
        public void TestSimpleMoveForWhite1()
        {
            var first = new Draught(1, 3, Peculiarity.Colours.White);
            var set = new SetOfDraughts();
            set.AddDraught(first);
            var temp = new DraughtInPlay(first, set);
            var moves = temp.SimpleMovesForWhite();
            Assert.AreEqual(1, moves.Count());
            Assert.AreEqual(2, moves.Moves[0].Points.Count);
        }
        [Test]
        public void TestSimpleMoveForBlack()
        {
            var first = new Draught(3, 1, Peculiarity.Colours.Black);
            var set = new SetOfDraughts();
            set.AddDraught(first);
            var temp = new DraughtInPlay(first, set);
            var moves = temp.SimpleMovesForBlack();
            Assert.AreEqual(0, moves.Count());
        }
        [Test]
        public void TestSimpleMoveForBlack1()
        {
            var first = new Draught(1, 3, Peculiarity.Colours.Black);
            var set = new SetOfDraughts();
            set.AddDraught(first);
            var temp = new DraughtInPlay(first, set);
            var moves = temp.SimpleMovesForBlack();
            Assert.AreEqual(1, moves.Count());
        }
        [Test]
        public void TestSimpleMovesForBlack2()
        {
            var first = new Draught(4, 8, Peculiarity.Colours.Black);
            var second = new Draught(2, 2, Peculiarity.Colours.White);
            var third = new Draught(3, 7, Peculiarity.Colours.White);
            var set = new SetOfDraughts();
            set.AddDraught(first);
            set.AddDraught(second);
            set.AddDraught(third);
            var temp = new DraughtInPlay(first, set);
            var moves = temp.SimpleMovesForBlack();
            Assert.AreEqual(1, moves.Count());
        }
        [Test]
        public void TestSimpleMovesForWhite3()
        {
            var first = new Draught(1, 3, Peculiarity.Colours.White);
            var place1 = new Square(1, 3);
            var place2 = new Square(2, 4);
            var set = new SetOfDraughts();
            set.AddDraught(first);
            var temp = new DraughtInPlay(first, set);
            var moves = temp.SimpleMovesForWhite();
            Assert.AreEqual(true, moves.Moves[0].Points[0].AreEqual(place1));
            Assert.AreEqual(true, moves.Moves[0].Points[1].AreEqual(place2));
        }
        [Test]
        public void TestSimpleMoves1()
        {
            var first = new Draught(1, 3, Peculiarity.Colours.White);
            var place1 = new Square(1, 3);
            var place2 = new Square(2, 4);
            var set = new SetOfDraughts();
            set.AddDraught(first);
            var temp = new DraughtInPlay(first, set);
            var moves = temp.Moves();
            Assert.AreEqual(1, moves.Count());
            Assert.AreEqual(true, moves.Moves[0].Points[0].AreEqual(place1));
            Assert.AreEqual(true, moves.Moves[0].Points[1].AreEqual(place2));
        }
        [Test]
        public void TestSimpleMoves2()
        {
            var first = new Draught(1, 3, Peculiarity.Colours.Black);
            var place1 = new Square(1, 3);
            var place2 = new Square(2, 2);
            var set = new SetOfDraughts();
            set.AddDraught(first);
            var temp = new DraughtInPlay(first, set);
            var moves = temp.Moves();
            Assert.AreEqual(1, moves.Count());
            Assert.AreEqual(true, moves.Moves[0].Points[0].AreEqual(place1));
            Assert.AreEqual(true, moves.Moves[0].Points[1].AreEqual(place2));
        }
        [Test]
        public void TestSimpleMoves3()
        {
            var first = new Draught(1, 3, Peculiarity.Colours.Black);
            var second = new Draught(2, 2, Peculiarity.Colours.Black);
            var set = new SetOfDraughts();
            set.AddDraught(first);
            set.AddDraught(second);
            var temp = new DraughtInPlay(first, set);
            var moves = temp.Moves();
            Assert.AreEqual(0, moves.Count());
        }
        [Test]
        public void TestSimpleMoves4()
        {
            var first = new Draught(4, 8, Peculiarity.Colours.Black);
            var second = new Draught(2, 2, Peculiarity.Colours.White);
            var third = new Draught(3, 7, Peculiarity.Colours.Black);
            var set = new SetOfDraughts();
            set.AddDraught(first);
            set.AddDraught(second);
            set.AddDraught(third);
            var temp = new DraughtInPlay(first, set);
            var moves = temp.SimpleMovesForBlack();
            Assert.AreEqual(1, moves.Count());
            Assert.AreEqual(5, moves.Moves[0].Points[1].FirstCoordinate);
            Assert.AreEqual(7, moves.Moves[0].Points[1].SecondCoordinate);
        }
        [Test]
        public void TestSimpleMoves5()
        {
            var first = new Draught(4, 8, Peculiarity.Colours.Black);
            var second = new Draught(5, 7, Peculiarity.Colours.Black);
            var third = new Draught(3, 7, Peculiarity.Colours.Black);
            var set = new SetOfDraughts();
            set.AddDraught(first);
            set.AddDraught(second);
            set.AddDraught(third);
            var temp = new DraughtInPlay(first, set);
            var moves = temp.SimpleMovesForBlack();
            Assert.AreEqual(0, moves.Count());
        }
        [Test]
        public void TestSimpleMoves6()
        {
            var arrangement = new SetOfDraughts("wc3; wd2; wb2; bd4; bb4; bc5;");
            var draught = new Draught(2, 2, Peculiarity.Colours.White);
            var square = new Square(1, 3);
            var temp = new DraughtInPlay(draught, arrangement);
            var moves = temp.Moves();
            Assert.AreEqual(1, moves.Count());
            Assert.AreEqual(true, moves.Moves[0].Points[1].AreEqual(square));
        }
        [Test]
        public void TestSimpleMoves7()
        {
            var arrangement = new SetOfDraughts("wc3; wd2; wb2; bd4; bb4; bc5; bf4;");
            var draught = new Draught(6, 4, Peculiarity.Colours.Black);
            var square1 = new Square(7, 3);
            var square2 = new Square(5, 3);
            var temp = new DraughtInPlay(draught, arrangement);
            var moves = temp.Moves();
            Assert.AreEqual(2, moves.Count());
            Assert.AreEqual(true, moves.Moves[0].Points[1].AreEqual(square1) ||
                moves.Moves[1].Points[1].AreEqual(square1));
            Assert.AreEqual(true, moves.Moves[0].Points[1].AreEqual(square2) ||
                moves.Moves[1].Points[1].AreEqual(square2));
        }
        [Test]
        public void TestSimpleMoves8()
        {
            var arrangement = new SetOfDraughts("wg1; wh2; bg3;");
            var draught = new Draught("wg1;");
            var square = new Square("f2");
            var temp = new DraughtInPlay(draught, arrangement);
            var moves = temp.Moves();
            Assert.AreEqual(1, moves.Count());
            Assert.AreEqual(true, moves.Moves[0].Points[1].AreEqual(square));
        }
        [Test]
        public void TestSimpleMoves9()
        {
            var arrangement = new SetOfDraughts("wg1; wh2; bg3; bf4");
            var draught = new Draught("wh2;");
            var temp = new DraughtInPlay(draught, arrangement);
            var moves = temp.Moves();
            Assert.AreEqual(0, moves.Count());
        }
        [Test]
        public void TestSimpleMoves10()
        {
            var arrangement = new SetOfDraughts("wg1; wh2; bg3; bf4; bd4;");
            var draught = new Draught("bg3;");
            var square = new Square("f2");
            var temp = new DraughtInPlay(draught, arrangement);
            var moves = temp.Moves();
            Assert.AreEqual(1, moves.Count());
            Assert.AreEqual(true, moves.Moves[0].Points[1].AreEqual(square));
        }
        [Test]
        public void TestSimpleMoves11()
        {
            var arrangement = new SetOfDraughts("wa1");
            var position = new Position(arrangement, Peculiarity.Colours.Black);
            var moves = position.Moves();
            Assert.AreEqual(0, moves.Count());
        }
        [Test]
        public void TestSimpleMoves12()
        {
            var arrangement = new SetOfDraughts("wa1");
            var position = new Position(arrangement, Peculiarity.Colours.White);
            var square1 = new Square("b2");
            var moves = position.Moves();
            Assert.AreEqual(1, moves.Count());
            Assert.AreEqual(true, moves.Moves[0].Points[1].AreEqual(square1));
        }
        [Test]
        public void TestSimpleMoves13()
        {
            var arrangement = new SetOfDraughts("wa3; bb4; bc5");
            var position = new Position(arrangement, Peculiarity.Colours.White);
            var moves = position.Moves();
            Assert.AreEqual(0, moves.Count());
        }
        [Test]
        public void TestSimpleMoves14()
        {
            var arrangement = new SetOfDraughts("wa3; bc5; wg1;");
            var position = new Position(arrangement, Peculiarity.Colours.White);
            var moves = position.Moves();
            Assert.AreEqual(3, moves.Count());
        }
    }
}
