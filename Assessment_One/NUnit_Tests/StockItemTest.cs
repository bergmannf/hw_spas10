using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application_Logic.Model;
using NUnit.Framework;

namespace NUnit_Tests
{
    [TestFixture]
    class StockItemTest
    {
        [Test]
        public void TestIsValidStockCode()
        {
            StockItem si = new StockItem();
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
            StockItem si = new StockItem();
            si.IsValidStockCode(null);
        }
    }
}
