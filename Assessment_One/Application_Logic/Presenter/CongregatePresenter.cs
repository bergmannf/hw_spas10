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
		public AppLogicManager _Model;

		public CongregatePresenter (ICongregateView view, IViewModel model)
		{
			this._View = view;
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
	}
}
