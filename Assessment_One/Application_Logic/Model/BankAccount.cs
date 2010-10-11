﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationLogic.Model
{
    /// <summary>
    /// Pseudo bank account to allow the placement of an order.
    /// </summary>
    public class BankAccount
    {
        public int AccountNumber { get; set; }
        public String Surname { get; set; }
        private double _Balance;
        public double Balance
        {
            get
            {
                return _Balance;
            }
            private set
            {
                if (value < 0.0)
                {
                    throw new ArgumentException("This class does not allow a balance smaller than 0.");
                }
                _Balance = value;
            }
        }

        public BankAccount(int acc, string name, double balance)
        {
            this.AccountNumber = acc;
            this.Surname = name;
            this.Balance = balance;
        }

        /// <summary>
        /// Allows the withdrawal of money from this account.
        /// Credit is not granted.
        /// </summary>
        /// <param name="amount">Amount to be withdrawn - must be greater than 0.</param>
        public void Withdraw(double amount)
        {
            if (amount > 0.0)
            {
                if (Balance > amount)
                {
                    this.Balance -= amount;
                }
                else
                {
                    throw new ArgumentException("Not enough founds on bank account to withdraw.");
                }
            }
            else
            {
                throw new ArgumentException("There are not enough funds present to fulfill the required action.");
            }
        }

        /// <summary>
        /// Allows the deposit of money to this account.
        /// </summary>
        /// <param name="amount">Amount to be deposited - must be greater than 0.</param>
        public void Deposit(double amount)
        {
            if (amount <= 0.0)
            {
                throw new ArgumentException("To withdraw money please use the appropriate function.");
            }
            else
            {
                this.Balance += amount;
            }
        }

        /// <summary>
        /// Amount to be transfered to another account.
        /// NOTE: This method is a fake to simulate "real" banking. The money will not be transfered to any account.
        /// </summary>
        /// <param name="amount">Amount to be transfered - must be greater than 0.</param>
        /// <param name="accountNumber">Account number to transfer the money to.</param>
        public void Transfer(double amount, int accountNumber)
        {
            if (amount > 0.0)
            {
                if (this.Balance > amount)
                {
                    this.Balance -= amount;
                    // TODO: Fancy logic to transfer money.
                }
                else
                {
                    throw new ArgumentException("There are not enough funds present to fulfill the required action.");
                }
            }
            else
            {
                throw new ArgumentException("It is not possible to transfer funds from another account to yours.");
            }
        }
    }
}