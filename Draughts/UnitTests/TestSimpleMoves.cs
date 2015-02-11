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
            var first = new Item(3, 1, ColourNames.White);
            var set = new SetOfItems();
            set.AddItem(first);
            var temp = new ItemInPlay(first, set);
            var moves = temp.SimpleMovesForWhite();
            Assert.AreEqual(2, moves.Count());
            Assert.AreEqual(2, moves.Moves[0].Points.Count);
            Assert.AreEqual(2, moves.Moves[1].Points.Count);
        }
        [Test]
        public void TestSimpleMoveForWhite1()
        {
            var first = new Item(1, 3, ColourNames.White);
            var set = new SetOfItems();
            set.AddItem(first);
            var temp = new ItemInPlay(first, set);
            var moves = temp.SimpleMovesForWhite();
            Assert.AreEqual(1, moves.Count());
            Assert.AreEqual(2, moves.Moves[0].Points.Count);
        }
        [Test]
        public void TestSimpleMoveForBlack()
        {
            var first = new Item(3, 1, ColourNames.Black);
            var set = new SetOfItems();
            set.AddItem(first);
            var temp = new ItemInPlay(first, set);
            var moves = temp.SimpleMovesForBlack();
            Assert.AreEqual(0, moves.Count());
        }
        [Test]
        public void TestSimpleMoveForBlack1()
        {
            var first = new Item(1, 3, ColourNames.Black);
            var set = new SetOfItems();
            set.AddItem(first);
            var temp = new ItemInPlay(first, set);
            var moves = temp.SimpleMovesForBlack();
            Assert.AreEqual(1, moves.Count());
        }
        [Test]
        public void TestSimpleMovesForBlack2()
        {
            var first = new Item(4, 8, ColourNames.Black);
            var second = new Item(2, 2, ColourNames.White);
            var third = new Item(3, 7, ColourNames.White);
            var set = new SetOfItems();
            set.AddItem(first);
            set.AddItem(second);
            set.AddItem(third);
            var temp = new ItemInPlay(first, set);
            var moves = temp.SimpleMovesForBlack();
            Assert.AreEqual(1, moves.Count());
        }
        [Test]
        public void TestSimpleMovesForWhite3()
        {
            var first = new Item(1, 3, ColourNames.White);
            var place1 = new Square(1, 3);
            var place2 = new Square(2, 4);
            var set = new SetOfItems();
            set.AddItem(first);
            var temp = new ItemInPlay(first, set);
            var moves = temp.SimpleMovesForWhite();
            Assert.AreEqual(true, moves.Moves[0].AreEqual(0,place1));
            Assert.AreEqual(true, moves.Moves[0].AreEqual(1,place2));
        }
        [Test]
        public void TestSimpleMoves1()
        {
            var first = new Item(1, 3, ColourNames.White);
            var place1 = new Square(1, 3);
            var place2 = new Square(2, 4);
            var set = new SetOfItems();
            set.AddItem(first);
            var temp = new ItemInPlay(first, set);
            var moves = temp.Moves();
            Assert.AreEqual(1, moves.Count());
            Assert.AreEqual(true, moves.Moves[0].AreEqual(0,place1));
            Assert.AreEqual(true, moves.Moves[0].AreEqual(1,place2));
        }
        [Test]
        public void TestSimpleMoves2()
        {
            var first = new Item(1, 3, ColourNames.Black);
            var place1 = new Square(1, 3);
            var place2 = new Square(2, 2);
            var set = new SetOfItems();
            set.AddItem(first);
            var temp = new ItemInPlay(first, set);
            var moves = temp.Moves();
            Assert.AreEqual(1, moves.Count());
            Assert.AreEqual(true, moves.Moves[0].AreEqual(0,place1));
            Assert.AreEqual(true, moves.Moves[0].AreEqual(1,place2));
        }
        [Test]
        public void TestSimpleMoves3()
        {
            var first = new Item(1, 3, ColourNames.Black);
            var second = new Item(2, 2, ColourNames.Black);
            var set = new SetOfItems();
            set.AddItem(first);
            set.AddItem(second);
            var temp = new ItemInPlay(first, set);
            var moves = temp.Moves();
            Assert.AreEqual(0, moves.Count());
        }
        [Test]
        public void TestSimpleMoves4()
        {
            var first = new Item(4, 8, ColourNames.Black);
            var second = new Item(2, 2, ColourNames.White);
            var third = new Item(3, 7, ColourNames.Black);
            var set = new SetOfItems();
            set.AddItem(first);
            set.AddItem(second);
            set.AddItem(third);
            var temp = new ItemInPlay(first, set);
            var moves = temp.SimpleMovesForBlack();
            Assert.AreEqual(1, moves.Count());
            Assert.AreEqual(5, moves.Moves[0].Points[1].FirstNumber);
            Assert.AreEqual(7, moves.Moves[0].Points[1].SecondNumber);
        }
        [Test]
        public void TestSimpleMoves5()
        {
            var first = new Item(4, 8, ColourNames.Black);
            var second = new Item(5, 7, ColourNames.Black);
            var third = new Item(3, 7, ColourNames.Black);
            var set = new SetOfItems();
            set.AddItem(first);
            set.AddItem(second);
            set.AddItem(third);
            var temp = new ItemInPlay(first, set);
            var moves = temp.SimpleMovesForBlack();
            Assert.AreEqual(0, moves.Count());
        }
        [Test]
        public void TestSimpleMoves6()
        {
            var arrangement = new SetOfItems("wc3; wd2; wb2; bd4; bb4; bc5;");
            var draught = new Item(2, 2, ColourNames.White);
            var square = new Square(1, 3);
            var temp = new ItemInPlay(draught, arrangement);
            var moves = temp.Moves();
            Assert.AreEqual(1, moves.Count());
            Assert.AreEqual(true, moves.Moves[0].AreEqual(1,square));
        }
        [Test]
        public void TestSimpleMoves7()
        {
            var arrangement = new SetOfItems("wc3; wd2; wb2; bd4; bb4; bc5; bf4;");
            var draught = new Item(6, 4, ColourNames.Black);
            var square1 = new Square(7, 3);
            var square2 = new Square(5, 3);
            var temp = new ItemInPlay(draught, arrangement);
            var moves = temp.Moves();
            Assert.AreEqual(2, moves.Count());
            Assert.AreEqual(true, moves.Moves[0].AreEqual(1,square1) ||
                moves.Moves[1].AreEqual(1,square1));
            Assert.AreEqual(true, moves.Moves[0].AreEqual(1,square2) ||
                moves.Moves[1].AreEqual(1,square2));
        }
        [Test]
        public void TestSimpleMoves8()
        {
            var arrangement = new SetOfItems("wg1; wh2; bg3;");
            var draught = new Item("wg1;");
            var square = new Square("f2");
            var temp = new ItemInPlay(draught, arrangement);
            var moves = temp.Moves();
            Assert.AreEqual(1, moves.Count());
            Assert.AreEqual(true, moves.Moves[0].AreEqual(1,square));
        }
        [Test]
        public void TestSimpleMoves9()
        {
            var arrangement = new SetOfItems("wg1; wh2; bg3; bf4");
            var draught = new Item("wh2;");
            var temp = new ItemInPlay(draught, arrangement);
            var moves = temp.Moves();
            Assert.AreEqual(0, moves.Count());
        }
        [Test]
        public void TestSimpleMoves10()
        {
            var arrangement = new SetOfItems("wg1; wh2; bg3; bf4; bd4;");
            var draught = new Item("bg3;");
            var square = new Square("f2");
            var temp = new ItemInPlay(draught, arrangement);
            var moves = temp.Moves();
            Assert.AreEqual(1, moves.Count());
            Assert.AreEqual(true, moves.Moves[0].AreEqual(1,square));
        }
        [Test]
        public void TestSimpleMoves11()
        {
            var arrangement = new SetOfItems("wa1");
            var position = new Position(arrangement, ColourNames.Black);
            var moves = position.Moves();
            Assert.AreEqual(0, moves.Count());
        }
        [Test]
        public void TestSimpleMoves12()
        {
            var arrangement = new SetOfItems("wa1");
            var position = new Position(arrangement, ColourNames.White);
            var square1 = new Square("b2");
            var moves = position.Moves();
            Assert.AreEqual(1, moves.Count());
            Assert.AreEqual(true, moves.Moves[0].AreEqual(1,square1));
        }
        [Test]
        public void TestSimpleMoves13()
        {
            var arrangement = new SetOfItems("wa3; bb4; bc5");
            var position = new Position(arrangement, ColourNames.White);
            var moves = position.Moves();
            Assert.AreEqual(0, moves.Count());
        }
        [Test]
        public void TestSimpleMoves14()
        {
            var arrangement = new SetOfItems("wa3; bc5; wg1;");
            var position = new Position(arrangement, ColourNames.White);
            var moves = position.Moves();
            Assert.AreEqual(3, moves.Count());
        }
    }
}
