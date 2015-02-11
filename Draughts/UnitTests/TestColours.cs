using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class TestColours
    {
        [Test]
        public void TestCreateColourByChar()
        {
            var first = new Appearance('w');
            Assert.AreEqual(ColourNames.White, first.Colour);
        }
        [Test]
        public void TestCreateColourByChar1()
        {
            var first = new Appearance('b');
            Assert.AreEqual(ColourNames.Black, first.Colour);
        }
        [Test]
        public void TestInverse()
        {
            var first = new Appearance('w');
            var second = new Appearance('b');
            Assert.AreEqual(true, first.InverseColour().AreEqual(second));
        }
        [Test]
        public void TestInverse2()
        {
            var first = new Appearance('b');
            var second = new Appearance('w');
            first.InverseColour();
            Assert.AreEqual(true, first.InverseColour().AreEqual(second));
        }
    }
}
