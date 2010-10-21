using System;
using System.ComponentModel;
using System.Security.Cryptography;
using ApplicationLogic.Interfaces;
using System.Collections;
using System.Collections.Generic;

namespace ApplicationLogic.Model
{
    /// <summary>
    /// Handles persistence issues and ensure the correct sequence of method calls.
    /// </summary>
    public class AppDataManager : IViewModel
    {
        private BindingList<StockItem> _StockItems;
        /// <summary>
        /// Gets or sets the stock items.
        /// </summary>
        /// <value>The stock items.</value>
        public BindingList<StockItem> StockItems
        {
            get { return _StockItems; }
            set { _StockItems = value; }
        }

        private BindingList<BankAccount> _BankAccounts;
        /// <summary>
        /// Gets or sets the bank accounts.
        /// </summary>
        /// <value>The bank accounts.</value>
        public BindingList<BankAccount> BankAccounts
        {
            get { return _BankAccounts; }
            set { _BankAccounts = value; }
        }

        /// <summary>
        /// Gets or sets the stock item handler.
        /// </summary>
        /// <value>The stock item handler.</value>
        public FileHandler<StockItem> StockItemHandler { get; private set; }
        /// <summary>
        /// Gets or sets the bank account handler.
        /// </summary>
        /// <value>The bank account handler.</value>
        public FileHandler<BankAccount> BankAccountHandler { get; private set; }

        public AppDataManager()
        {
            this.StockItems = new BindingList<StockItem>();
            this.BankAccounts = new BindingList<BankAccount>();
            this.StockItemHandler = new FileHandler<StockItem>();
            this.BankAccountHandler = new FileHandler<BankAccount>();
        }

        /// <summary>
        /// Creates a new StockItem and initializes it with dummy values.
        /// Adds the item to the StockItem collection.
        /// </summary>
        public void CreateNewStockItem()
        {
            StockItem si = new StockItem("0000", "Dummy Item", "None", 0.0, 0, 0);
            this.StockItems.Add(si);
        }

        /// <summary>
        /// Deletes a StockItem from the StockItem collection.
        /// Throws an ArgumentException if the item can not be found.
        /// </summary>
        public void DeleteStockItem(StockItem si)
        {
            if (this.StockItems.Contains(si))
            {
                this.StockItems.Remove(si);
            }
            else
            {
                throw new ArgumentException("Item to delete not present.");
            }
        }

        /// <summary>
        /// Creates a new BankAccount and initializes it with dummy values.
        /// Adds the item to the BankAccount collection.
        /// </summary>
        public void CreateNewBankAccount()
        {
            BankAccount ba = new BankAccount(0, "Dummy Account", 0.0);
            this.BankAccounts.Add(ba);
        }

        /// <summary>
        /// Deletes a BankAccount from the BankAccount collection.
        /// Throws an ArgumentException if the account can not be found.
        /// </summary>
        public void DeleteBankAccount(BankAccount ba)
        {
            if (this.BankAccounts.Contains(ba))
            {

                this.BankAccounts.Remove(ba);
            }
            else
            {
                throw new ArgumentException("Item to delete not present.");
            }
        }

        /// <summary>
        /// Attempts to edit specified StockItem in the StockItem collection.
        /// Throws an ArgumentException if the item can not be found.
        /// </summary>
        /// <param name="si">StockItem to be edited.</param>
        /// <param name="stockCode">New StockCode</param>
        /// <param name="supplier">New SupplierName</param>
        /// <param name="name">New Name</param>
        /// <param name="currentStock">New CurrentStock</param>
        /// <param name="reqStock">New RequiredStock</param>
        /// <param name="price">New Price</param>
        internal void EditStockItem(StockItem si, string stockCode, string supplier, string name, int currentStock, int reqStock, double price)
        {
            if (si != null)
            {
                si.EditStockItem(stockCode, name, supplier, price, reqStock, currentStock);
            }
            else
            {
                throw new ArgumentNullException("Stock item to edit not present.");
            }
        }

        /// <summary>
        /// Attempts to edit specified BankAccount in the BankAccount collection.
        /// Throws an ArgumentException if the account can not be found.
        /// </summary>
        /// <param name="ba">BankAccount to be edited</param>
        /// <param name="surname">New surname</param>
        /// <param name="accountNumber">New accoutnumber</param>
        internal void EditBankAccount(BankAccount ba, string surname, int accountNumber)
        {
            if (ba != null)
            {
                ba.EditBankAccount(surname, accountNumber);
            }
            else
            {
                throw new ArgumentNullException("Bank account to edit not present.");
            }
            
        }

        /// <summary>
        /// Validates the changes that may be made to a stock item.
        /// </summary>
        /// <param name="accountNumber">New account number</param>
        /// <param name="surname">New surname</param>
        /// <returns>True if new values are vald. False otherwise.</returns>
        internal bool ValidateStockItem(string stockCode, string name, string supplier, double price, int reqStock, int currentStock)
        {
            bool areValuesValid = StockItem.Validate(stockCode, name, supplier, price, reqStock, currentStock);
            return areValuesValid;
        }

        /// <summary>
        /// Stores the errors that occured in the last validation of stock item data.
        /// </summary>
        /// <returns>The errors that occured.</returns>
        internal ErrorMessageCollection StockItemErrors()
        {
            return StockItem.ErrorMessages; ;
        }


        /// <summary>
        /// Clears the errors of the last stock item validation.
        /// </summary>
        internal void ClearStockItemErrors()
        {
            StockItem.ErrorMessages.Clear();
        }

        /// <summary>
        /// Clears the errors of the last bank account validation.
        /// </summary>
        internal void ClearBankAccountErrors()
        {
            BankAccount.ErrorMessages.Clear();
        }

        /// <summary>
        /// Stores the errors that occured in the last validation of bank account data.
        /// </summary>
        /// <returns>The errors that occured.</returns>
        internal ErrorMessageCollection BankAccountErrors()
        {
            return BankAccount.ErrorMessages;
        }

        /// <summary>
        /// Validates the changes that may be made to a bank account.
        /// </summary>
        /// <param name="accountNumber">New account number</param>
        /// <param name="surname">New surname</param>
        /// <returns>True if new values are vald. False otherwise.</returns>
        internal bool ValidateBankAccount(int accountNumber, string surname)
        {
            bool areValidValues = BankAccount.Validate(accountNumber, surname);
            return areValidValues;
        }

        /// <summary>
        /// Attempts to order an item. If no quantity was provided the required quantity will be ordered.
        /// Otherwise the provided quantity will be ordered.
        /// </summary>
        /// <param name="indexStockItem">Index of the stock item in the stock items list.</param>
        /// <param name="indexBankAccount">Index of the bank account in the bank account list.</param>
        /// <param name="quantity">The quantity to be ordered. 0 orders the required quantity.</param>
        public void OrderItem(StockItem si, BankAccount ba, int quantity)
        {
            if (ba != null && si != null)
            {
                bool buyExcessStock = false;
                if (quantity == 0)
                {
                    quantity = si.RequiredStock;
                }
                else
                {
                    /*
                     * It is possible to order more than the needed quantity.
                     */
                    buyExcessStock = true;
                }
                double priceOfOrder = quantity * si.UnitCost;
                if (priceOfOrder <= ba.Balance)
                {
                    ba.Transfer(1, priceOfOrder);
                    si.CurrentStock += quantity;
                    /*
                     * Allow the user to buy more than needed.
                     */
                    if (buyExcessStock)
                    {
                        if (quantity > si.RequiredStock)
                        {
                            si.RequiredStock = 0;
                        }
                    }
                }
                else
                {
                    throw new NotEnoughFundsException(String.Format("Not enough founds on bank account {0} to place an order for {1} £", ba.AccountNumber, priceOfOrder));
                }
            }
            else
            {
                throw new ArgumentNullException("Stock item or bank account provided do not exist.");
            }
        }

        /// <summary>
        /// Attempts to deposit the requested amount from the specified bank account.
        /// </summary>
        /// <param name="indexBankAccount"></param>
        /// <param name="amount"></param>
        internal void Deposit(BankAccount ba, double amount)
        {
            if (ba != null)
            {
                ba.Deposit(amount);
            }
            else
            {
                throw new ArgumentNullException("Provided bank account does not exist.");
            }
        }

        /// <summary>
        /// Attempts to withdraw the specified amount from the specified bank account.
        /// </summary>
        /// <param name="indexBankAccount"></param>
        /// <param name="amount"></param>
        internal void Withdraw(BankAccount ba, double amount)
        {
            if (ba != null)
            {
                ba.Withdraw(amount);
            }
            else
            {
                throw new ArgumentNullException("Bank account provided does not exist.");
            }
        }

        /// <summary>
        /// Will reload the StockItem collection from the specified file.
        /// Will overwrite the currently existing StockItem collection.
        /// </summary>
        /// <param name="filePath"></param>
        internal void LoadStockItemsFromFile(string filePath)
        {
            this.StockItemHandler.ReadFilePath = filePath;
            IList<StockItem> stockItems = StockItemHandler.LoadFromFile(new StockItem());
            this.StockItems.Clear();
            foreach (StockItem item in stockItems)
            {
                this.StockItems.Add(item);
            }
        }

        /// <summary>
        /// Will reload the BankAccount collection from the specified file.
        /// Will overwrite the currently existing BankAccount collection.
        /// </summary>
        /// <param name="filePath">The path to the file</param>
        internal void LoadBankAccountsFromFile(string filePath)
        {
            this.BankAccountHandler.ReadFilePath = filePath;
            IList<BankAccount> bankAccounts = BankAccountHandler.LoadFromFile(new BankAccount());
            this.BankAccounts.Clear();
            foreach (BankAccount item in bankAccounts)
            {
                this.BankAccounts.Add(item);
            }
        }

        /// <summary>
        /// Will save the current StockItem collection to the specified file.
        /// </summary>
        /// <param name="filePath">The path to the file</param>
        internal void SaveStockItemsToFile(string filePath)
        {
            this.StockItemHandler.WriteFilePath = filePath;
            this.StockItemHandler.SaveToFile(this.StockItems);
        }

        /// <summary>
        /// Will save the current BankAccount collection to the specified file.
        /// </summary>
        /// <param name="filePath">The path to the file</param>
        internal void SaveBankAccountsToFile(string filePath)
        {
            this.BankAccountHandler.WriteFilePath = filePath;
            this.BankAccountHandler.SaveToFile(this.BankAccounts);
        }

        /// <summary>
        /// Will save the current BankAccount collection to the file stored in the FileHandler.
        /// Throws NoFilePathSetException if no path is set.
        /// </summary>
        internal void SaveBankAccountsToFile()
        {
            this.BankAccountHandler.SaveToFile(this.BankAccounts);
        }

        /// <summary>
        /// Will save the current BankAccount collection to the file stored in the FileHandler.
        /// Throws NoFilePathSetException if no path is set.
        /// </summary>
        internal void SaveStockItemsToFile()
        {
            this.StockItemHandler.SaveToFile(this.StockItems);
        }
    }
}

