using System;
using System.ComponentModel;
using ApplicationLogic.Model;

namespace ApplicationLogic.Interfaces
{
	public interface IViewModel
	{
		BindingList<StockItem> StockItems { get; }
		BindingList<BankAccount> BankAccounts { get; }
	}
}

