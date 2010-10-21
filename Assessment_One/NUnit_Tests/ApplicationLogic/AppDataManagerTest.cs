using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using ApplicationLogic.Model;

namespace NUnit_Tests.ApplicationLogic
{
    [TestFixture]
    public class AppDataManagerTest
    {
        private AppDataManager _Manager;
        private StockItem _Stock;
        private BankAccount _Account;

        [SetUp]
        public void SetUp()
        {
            this._Manager = new AppDataManager();
            this._Stock = new StockItem();
            this._Account = new BankAccount();
        }

        [Test]
        public void TestAddStockItem()
        {
            this._Manager.CreateNewStockItem();
            Assert.AreEqual(1, this._Manager.StockItems.Count);
        }

        [Test]
        public void TestAddBankAccount()
        {
            this._Manager.CreateNewBankAccount();
            Assert.AreEqual(1, this._Manager.BankAccounts.Count);
        }

        [Test]
        public void TestRemoveStockItem()
        {
            this._Manager.CreateNewStockItem();
            Assert.AreEqual(1, this._Manager.StockItems.Count);
            StockItem remove = this._Manager.StockItems.ElementAt(0);
            this._Manager.DeleteStockItem(remove);
            Assert.AreEqual(0, this._Manager.StockItems.Count);
        }

        [Test]
        public void TestRemoveBankAccount()
        {
            this._Manager.CreateNewBankAccount();
            Assert.AreEqual(1, this._Manager.BankAccounts.Count);
            BankAccount remove = this._Manager.BankAccounts.ElementAt(0);
            this._Manager.DeleteBankAccount(remove);
            Assert.AreEqual(0, this._Manager.BankAccounts.Count);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRemoveStockItemNotPresent()
        {
            StockItem si = new StockItem();
            this._Manager.DeleteStockItem(si);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRemoveBankAccountNotPresent()
        {
            BankAccount ba = new BankAccount();
            this._Manager.DeleteBankAccount(ba);
        }

        [Test]
        public void TestCorrectSequenceOfOrdering()
        {
            var mockBa = new Mock<BankAccount>();
            var mockSi = new Mock<StockItem>();

            mockBa.Setup(ba => ba.Balance).Returns(50.0);

            this._Manager.BankAccounts.Add(mockBa.Object);
            this._Manager.StockItems.Add(mockSi.Object);
            this._Manager.OrderItem(mockSi.Object, mockBa.Object, 0);

            mockBa.VerifyGet(ba => ba.Balance);
            mockBa.Verify(ba => ba.Transfer(0, 10.0), Times.AtMostOnce());
        }

        [Test]
        [ExpectedException(typeof(NotEnoughFundsException))]
        public void TestCorrectSequenceOnInvalidFunds()
        {
            var mockBa = new Mock<BankAccount>();
            var mockSi = new Mock<StockItem>();

            mockBa.Setup(ba => ba.Balance).Returns(0.0);
            mockSi.Setup(si => si.UnitCost).Returns(10.0);

            this._Manager.BankAccounts.Add(mockBa.Object);
            this._Manager.StockItems.Add(mockSi.Object);
            this._Manager.OrderItem(mockSi.Object, mockBa.Object, 1);

            mockBa.VerifyGet(ba => ba.Balance);
            mockBa.Verify(ba => ba.Transfer(0, 10.0), Times.Never());
        }
    }
}
