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
		public AppLogicManager _Model;

		public CongregatePresenter (ICongregateView view, IStockItemView stockItemView, IBankAccountView bankAccountView, IViewModel model)
		{
			this._View = view;
            this._StockItemView = stockItemView;
            this._BankAccountView = bankAccountView;
			this._Model = model as AppLogicManager;
		}
		
		public void CreateNewStockItem ()
		{
			this._Model.CreateNewStockItem();
		}

		public void DeleteStockItem (int p)
		{
			if (this._View.ConfirmDelete ()) {
				this._Model.DeleteStockItem(p);
			}
		}

		public void CreateNewBankAccount ()
		{
			this._Model.CreateNewBankAccount();
		}

		public void DeleteBankAccount (int p)
		{
			if (this._View.ConfirmDelete ()) {
					this._Model.DeleteBankAccount(p);
			}
		}

        public void EditStockItem(int index)
        {
            String stockCode = this._StockItemView.StockCode;
            String supplier = this._StockItemView.SupplierName;
            String name = this._StockItemView.ItemName;
            int currentStock = this._StockItemView.CurrentStock;
            int reqStock = this._StockItemView.RequiredStock;
            double price = this._StockItemView.UnitCost;
            this._Model.EditStockItem(index, stockCode, supplier, name, currentStock, reqStock, price);
        }

        public void EditBankAccount(int index)
        {
            String surname = this._BankAccountView.Surname;
            int accountNumber = this._BankAccountView.AccountNumber;
            this._Model.EditBankAccount(index, surname, accountNumber);
        }
    }
}
