﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApplicationLogic.Model;
using NUnit.Framework;

namespace NUnit_Tests.ApplicationLogic
{
    [TestFixture]
    class BankAccountTest
    {
        private BankAccount ba;

        [SetUp]
        public void SetUp()
        {
            ba = new BankAccount(123, "Test", 0.0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestBalanceUnder0()
        {
            ba = new BankAccount(123, "Test", -1.0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestWithdrawalWithTooHighValues()
        {
            double amountToWithdrawTooHigh = 50.0;
            ba.Withdraw(amountToWithdrawTooHigh);
            TestWithdrawalWithTooSmallValues();
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestWithdrawalWithTooSmallValues()
        {
            double amountToWithdrawTooSmall = -10.0;
            ba.Withdraw(amountToWithdrawTooSmall);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDepositWithTooSmallValue()
        {
            double amountToDepositTooSmall = -10;
            ba.Deposit(amountToDepositTooSmall);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestTransferWithTooSmallValue()
        {
            double amountToTransferTooSmall = -10;
            ba.Transfer(amountToTransferTooSmall, 123);
        }

        [Test]
        public void TestOrdinaryFunctions()
        {
            double currentValue = ba.Balance;
            double deposit = 50.0;
            currentValue += deposit;
            ba.Deposit(deposit);
            Assert.AreEqual(currentValue, ba.Balance);

            double withdraw = 25.0;
            currentValue -= withdraw;
            ba.Withdraw(withdraw);
            Assert.AreEqual(currentValue, ba.Balance);

            double transfer = 10.50;
            currentValue -= transfer;
            ba.Transfer(transfer, 123);
            Assert.AreEqual(currentValue, ba.Balance);
        }
    }
}