using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using ApplicationLogic.Interfaces;
using ApplicationLogic.Model;

namespace ApplicationLogic.Presenter
{
    /// <summary>
    /// Presenter for the MainWindow: handles events and GUI-related part of the application logic.
    /// </summary>
	public class CongregatePresenter
	{
		
		public ICongregateView _View;
		public IStockItemView _StockItemView;
		public IBankAccountView _BankAccountView;
		public AppDataManager _Model;

        /// <summary>
        /// Initializes a new instance of the <see cref="CongregatePresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="stockItemView">The stock item view.</param>
        /// <param name="bankAccountView">The bank account view.</param>
        /// <param name="model">The model.</param>
		public CongregatePresenter (ICongregateView view, IStockItemView stockItemView, IBankAccountView bankAccountView, IViewModel model)
		{
			this._View = view;
			this._StockItemView = stockItemView;
			this._BankAccountView = bankAccountView;
			this._Model = model as AppDataManager;
		}

        /// <summary>
        /// 	<see cref="ApplicationLogic.Model.AppDataManagerClass"/>
        /// </summary>
		public void CreateNewStockItem ()
		{
			this._Model.CreateNewStockItem();
		}

        /// <summary>
        /// Deletes the stock item.
        /// </summary>
		public void DeleteStockItem ()
		{
			if (this._View.ConfirmDelete ()) 
            {
                StockItem si = this._View.StockItem;
				this._Model.DeleteStockItem(si);
			}
		}

        /// <summary>
        /// Creates the new bank account.
        /// </summary>
		public void CreateNewBankAccount ()
		{
			this._Model.CreateNewBankAccount();
		}

        /// <summary>
        /// Deletes the bank account.
        /// </summary>
		public void DeleteBankAccount ()
		{
			if (this._View.ConfirmDelete ()) {
                BankAccount ba = this._View.BankAccount;
				this._Model.DeleteBankAccount(ba);
			}
		}

        /// <summary>
        /// Edits the stock item.
        /// </summary>
		public void EditStockItem()
		{
            try
            {
                StockItem si = this._View.StockItem;
                String stockCode = this._StockItemView.StockCode;
                String supplier = this._StockItemView.SupplierName;
                String name = this._StockItemView.ItemName;
                int currentStock = this._StockItemView.CurrentStock;
                int reqStock = this._StockItemView.RequiredStock;
                double price = this._StockItemView.UnitCost;
                bool areValuesValid = this._Model.ValidateStockItem(stockCode, name, supplier, price, reqStock, currentStock);
                if (areValuesValid)
                {
                    this._Model.EditStockItem(si, stockCode, supplier, name, currentStock, reqStock, price);
                }
                else
                {
                    this._View.DisplayValidationErrors(this._Model.StockItemErrors());
                    this._Model.ClearStockItemErrors();
                }
            }
            catch (FormatException e)
            {
                DisplayError(e);
            }
			
		}

        /// <summary>
        /// Edits the bank account.
        /// </summary>
		public void EditBankAccount()
		{
            try
            {
                BankAccount ba = this._View.BankAccount;
                String surname = this._BankAccountView.Surname;
                int accountNumber = this._BankAccountView.AccountNumber;
                bool areValuesValid = this._Model.ValidateBankAccount(accountNumber, surname);
                if (areValuesValid)
                {
                    this._Model.EditBankAccount(ba, surname, accountNumber);
                }
                else
                {
                    this._View.DisplayValidationErrors(this._Model.BankAccountErrors());
                    this._Model.ClearBankAccountErrors();
                }
            }
            catch (FormatException e)
            {
                DisplayError(e);
            }
			
		}

        /// <summary>
        /// Orders the item.
        /// </summary>
		public void OrderItem()
		{
            try
            {
                BankAccount ba = this._View.BankAccount;
                StockItem si = this._View.StockItem;
                this.EditStockItem();
                int quantity = this._View.Quantity;
                this._Model.OrderItem(si, ba, quantity);
            }
            catch (FormatException e)
            {
                DisplayError(e);
            }
            catch (NotEnoughFundsException e)
            {
                DisplayError(e);
            }
		}

        /// <summary>
        /// Deposits this instance.
        /// </summary>
        public void Deposit()
        {
            try
            {
                BankAccount ba = this._View.BankAccount;
                double amount = this._View.Deposit;
                this._Model.Deposit(ba, amount);
            }
            catch (Exception e)
            {
                DisplayError(e);
            }
        }

        /// <summary>
        /// Withdraws this instance.
        /// </summary>
        public void Withdraw()
        {
            try
            {
                BankAccount ba = this._View.BankAccount;
                double amount = this._View.Withdraw;
                this._Model.Withdraw(ba, amount);
            }
            catch (Exception e)
            {
                DisplayError(e);
            }
        }

        /// <summary>
        /// Displays the error.
        /// </summary>
        /// <param name="e">The e.</param>
        private void DisplayError(Exception e)
        {
            ErrorMessageCollection col = new ErrorMessageCollection();
            col.Add(new ErrorMessage(e.Message));
            this._View.DisplayValidationErrors(col);
        }

        /// <summary>
        /// Closes the application.
        /// </summary>
        public void CloseApplication()
        {
            if (this._View.ConfirmClose())
                Environment.Exit(1);
        }

        /// <summary>
        /// Loads the stock items from file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        public void LoadStockItemsFromFile(String filePath)
        {
            this._Model.LoadStockItemsFromFile(filePath);
        }

        /// <summary>
        /// Loads the bank accounts from file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        public void LoadBankAccountsFromFile(String filePath)
        {
            this._Model.LoadBankAccountsFromFile(filePath);
        }

        /// <summary>
        /// Saves the stock items to file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        public void SaveStockItemsToFile(String filePath)
        {
            this._Model.SaveStockItemsToFile(filePath);
        }

        /// <summary>
        /// Saves the bank accounts to file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        public void SaveBankAccountsToFile(String filePath)
        {
            this._Model.SaveBankAccountsToFile(filePath);
        }

        /// <summary>
        /// Sets up stock item file path.
        /// </summary>
        /// <param name="filePathStockItems">The file path stock items.</param>
        public void SetUpStockItemFilePath(string filePathStockItems)
        {
            // TODO: Check if good.
            this._Model.StockItemHandler.ReadFilePath = filePathStockItems;
            this._Model.StockItemHandler.WriteFilePath = filePathStockItems;
            this._Model.LoadStockItemsFromFile(filePathStockItems);
        }

        /// <summary>
        /// Sets up bank accounts file path.
        /// </summary>
        /// <param name="filePathBankAccounts">The file path bank accounts.</param>
        public void SetUpBankAccountsFilePath(string filePathBankAccounts)
        {
            // TODO: Check if good.
            this._Model.BankAccountHandler.ReadFilePath = filePathBankAccounts;
            this._Model.BankAccountHandler.WriteFilePath = filePathBankAccounts;
            this._Model.LoadBankAccountsFromFile(filePathBankAccounts);
        }

        /// <summary>
        /// Saves the bank accounts to file.
        /// </summary>
        public void SaveBankAccountsToFile()
        {
            try
            {
                this._Model.SaveBankAccountsToFile();
            }
            catch (Exception e)
            {
                DisplayError(e);
            } 
        }

        /// <summary>
        /// Saves the stock items to file.
        /// </summary>
        public void SaveStockItemsToFile()
        {
            try
            {
                this._Model.SaveStockItemsToFile();
            }
            catch (Exception e)
            {
                DisplayError(e);
            }
        }
    }
}
