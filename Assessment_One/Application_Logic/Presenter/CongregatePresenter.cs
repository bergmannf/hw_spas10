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

		public CongregatePresenter (ICongregateView view, IStockItemView stockItemView, IBankAccountView bankAccountView, IViewModel model)
		{
			this._View = view;
			this._StockItemView = stockItemView;
			this._BankAccountView = bankAccountView;
			this._Model = model as AppDataManager;
		}
		
		public void CreateNewStockItem ()
		{
			this._Model.CreateNewStockItem();
		}

		public void DeleteStockItem ()
		{
			if (this._View.ConfirmDelete ()) {
                StockItem si = this._View.StockItem;
				this._Model.DeleteStockItem(si);
			}
		}

		public void CreateNewBankAccount ()
		{
			this._Model.CreateNewBankAccount();
		}

		public void DeleteBankAccount ()
		{
			if (this._View.ConfirmDelete ()) {
                BankAccount ba = this._View.BankAccount;
				this._Model.DeleteBankAccount(ba);
			}
		}

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

        private void DisplayError(Exception e)
        {
            ErrorMessageCollection col = new ErrorMessageCollection();
            col.Add(new ErrorMessage(e.Message));
            this._View.DisplayValidationErrors(col);
        }
    }
}
