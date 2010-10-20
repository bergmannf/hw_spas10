using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApplicationLogic.Model;
using NUnit.Framework;

namespace NUnit_Tests
{
    [TestFixture]
    public class StockItemTest
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
            bool validSC = StockItem.IsValidStockCode("1234");
            Assert.IsTrue(validSC);
            bool tooLongSC = StockItem.IsValidStockCode("123456");
            Assert.IsFalse(tooLongSC);
            bool stringSC = StockItem.IsValidStockCode("test");
            Assert.IsFalse(stringSC);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIsValidStockCodeRaiseException()
        {
            StockItem.IsValidStockCode(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateStockItemInvalidStockCode()
        {
            String invalidStockCode = "00001";
            StockItem si = new StockItem(invalidStockCode, "", "", 0.0, 0, 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateStockItemInvalidCost()
        {
            double invalidCost = -1.0;
            StockItem si = new StockItem("0001", "", "", invalidCost, 0, 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateStockItemInvalidRequiredStock()
        {
            int invalidStock = -1;
            StockItem si = new StockItem("0001", "", "", 0.0, invalidStock, 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateStockItemInvalidCurrentStock()
        {
            int invalidStock = -1;
            StockItem si = new StockItem("0001", "", "", 0.0,  0, invalidStock);
        }
        
		[Test]
		public void TestStringParsing()
		{
			StockItem parseItem = new StockItem();
			
			String parseOne = "0001,Pencil Holder,John Rambo,5.50,10,15";
			
			StockItem si = parseItem.ParseFromString(parseOne);
			Assert.IsNotNull(si);
			
			String parseTwo = "0001,,John Rambo,5.50,10,15";
			
			StockItem si2 = parseItem.ParseFromString(parseTwo);
			Assert.IsNotNull(si2);
			
			String parseThree = "0001,,,,,";
			
			StockItem si3 = parseItem.ParseFromString(parseThree);
			Assert.IsNotNull(si3);
		}
		
		[Test]
		[ExpectedException(typeof(FormatException))]
		public void TestStringParsingInvalidValues()
		{
			StockItem parseItem = new StockItem();
			
			String parseOne = "0001,Pencil Holder,John Rambo,abc,10,15";
			StockItem si = parseItem.ParseFromString(parseOne);
		}
    }
}
