using System;
using System.ComponentModel;
using ApplicationLogic.Model;

namespace ApplicationLogic.Interfaces
{
    /// <summary>
    /// Utilized by the View to set up the data binding to the lists in the model
    /// </summary>
	public interface IViewModel
	{
		BindingList<StockItem> StockItems { get; }
		BindingList<BankAccount> BankAccounts { get; }
	}
}