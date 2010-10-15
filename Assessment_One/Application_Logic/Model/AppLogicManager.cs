using System;
using System.ComponentModel;
using System.Security.Cryptography;
using ApplicationLogic.Interfaces;

namespace ApplicationLogic.Model
{
	public class AppLogicManager : IViewModel
	{
		private BindingList<StockItem> _StockItems;
		public BindingList<StockItem> StockItems {
			get { return _StockItems; }
			set { _StockItems = value; }
		}

		private BindingList<BankAccount> _BankAccounts;
		public BindingList<BankAccount> BankAccounts {
			get { return _BankAccounts; }
			set { _BankAccounts = value; }
		}

		public AppLogicManager ()
		{
			this.StockItems = new BindingList<StockItem> ();
			this.BankAccounts = new BindingList<BankAccount> ();
		}

		public void CreateNewStockItem ()
		{
			StockItem si = new StockItem ("0000", "Dummy Item", "None", 0.0, 0, 0);
			this.StockItems.Add (si);
		}

		public void DeleteStockItem (int p)
		{
			if (p < this.StockItems.Count) {
				this.StockItems.RemoveAt (p);
			} else {
				throw new ArgumentException ("Index is outside of range.");
			}
		}

		public void CreateNewBankAccount ()
		{
			BankAccount ba = new BankAccount (0, "Dummy Account", 0.0);
			this.BankAccounts.Add (ba);
		}

		public void DeleteBankAccount (int p)
		{
			if (p < this.BankAccounts.Count) {
				this.BankAccounts.RemoveAt (p);
			} else {
				throw new ArgumentException ("Index is outside of range.");
			}
		}
		
		public void OrderItemFromAccount()
		{
		}

		internal void EditStockItem(int index, string stockCode, string supplier, string name, int currentStock, int reqStock, double price)
		{
			StockItem si = StockItems[index];
			si.EditStockItem(stockCode, name, supplier, price, reqStock, currentStock);
		}

		internal void EditBankAccount(int index, string surname, int accountNumber)
		{
			BankAccount ba = BankAccounts[index];
			ba.EditBankAccount(surname, accountNumber);
		}

		internal bool ValidateStockItem(string stockCode, string name, string supplier, double price, int reqStock, int currentStock)
		{
			bool areValuesValid = StockItem.Validate(stockCode, name, supplier, price, reqStock, currentStock);
			return areValuesValid;
		}

		internal ErrorMessageCollection StockItemErrors()
		{
			return StockItem.ErrorMessages; ;
		}

		internal void ClearStockItemErrors()
		{
			StockItem.ErrorMessages.Clear();
		}

		internal void ClearBankAccountErrors()
		{
			BankAccount.ErrorMessages.Clear();
		}

		internal ErrorMessageCollection BankAccountErrors()
		{
			return BankAccount.ErrorMessages;
		}

		internal bool ValidateBankAccount(int accountNumber, string surname)
		{
			bool areValidValues = BankAccount.Validate(accountNumber, surname);
			return areValidValues;
		}
		
		public void OrderItem(int indexStockItem, int indexBankAccount, int quantity)
		{
			BankAccount ba = this.BankAccounts[indexBankAccount];
			StockItem si = this.StockItems[indexStockItem];
			if (quantity == 0 || quantity > si.RequiredStock) {
				quantity = si.RequiredStock;
			}
			double priceOfOrder = quantity * si.UnitCost;
			if (priceOfOrder < ba.Balance) {
                ba.Transfer(1, priceOfOrder);
				si.RequiredStock -= quantity;
				si.CurrentStock += quantity;
			}
			else
			{
				throw new NotEnoughFundsException(String.Format("Not enough founds on bank account {0} to place order for {1} £", ba.AccountNumber, priceOfOrder));
			}
		}

        internal void Deposit(int indexBankAccount, double amount)
        {
            BankAccount ba = BankAccounts[indexBankAccount];
            ba.Deposit(amount);
        }

        internal void Withdraw(int indexBankAccount, double amount)
        {
            BankAccount ba = BankAccounts[indexBankAccount];
            ba.Withdraw(amount);
        }
    }
}

