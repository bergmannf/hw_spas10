using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApplicationLogic.Model;
using NUnit.Framework;

namespace NUnit_Tests
{
    [TestFixture]
    class StockItemTest
    {
        private StockItem si;

        [SetUp]
        public void SetUp()
        {
            si = new StockItem("1234", "Test", "Test", 10.0, 5, 5);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestLessThan0Cost()
        {
            si = new StockItem("1234", "Test", "Test", -1.0, 5, 5);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestLessThan0CurrentStock()
        {
            si = new StockItem("1234", "Test", "Test", 1.0, -1, 5);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestLessThan0RequiredStock()
        {
            si = new StockItem("1234", "Test", "Test", 1.0, 5, -1);
        }

        [Test]
        public void TestIsValidStockCode()
        {
            bool validSC = si.IsValidStockCode("1234");
            Assert.IsTrue(validSC);
            bool tooLongSC = si.IsValidStockCode("123456");
            Assert.IsFalse(tooLongSC);
            bool stringSC = si.IsValidStockCode("test");
            Assert.IsFalse(stringSC);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIsValidStockCodeRaiseException()
        {
            si.IsValidStockCode(null);
        }
    }
}
