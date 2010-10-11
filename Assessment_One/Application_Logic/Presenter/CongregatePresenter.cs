using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using ApplicationLogic.Model;
using ApplicationLogic.Interfaces;

namespace ApplicationLogic.Presenter
{
    /// <summary>
    /// Presenter for the MainWindow: handles events and application logic.
    /// </summary>
    public class CongregatePresenter
    {
        private BindingList<StockItem> _StockItems;
        public BindingList<StockItem> StockItems
        {
            get
            {
                return _StockItems;
            }
            set
            {
                _StockItems = value;
            }
        }

        private BindingList<BankAccount> _BankAccoutns;
        public BindingList<BankAccount> BankAccounts
        {
            get
            {
                return _BankAccoutns;
            }
            set
            {
                _BankAccoutns = value;
            }
        }
        public ICongregateView _View;

        public CongregatePresenter(ICongregateView view)
        {
            this._View = view;
            this.StockItems = new BindingList<StockItem>();
            this.BankAccounts = new BindingList<BankAccount>();
        }

        public void DeleteStockItem(int p)
        {
            if (p < this.StockItems.Count)
            {
                this.StockItems.RemoveAt(p);
            }
            else
            {
                throw new ArgumentException("Index is outside of range.");
            }
        }

        public void CreateNewStockItem()
        {
            StockItem si = new StockItem("0000", "Dummy Item", "None", 0.0, 0, 0);
            this.StockItems.Add(si);
        }

        public void CreateNewBankAccount()
        {
            BankAccount ba = new BankAccount(0, "Dummy Account", 0.0);
            this.BankAccounts.Add(ba);
        }

        public void DeleteBankAccount(int p)
        {
            if (p < this.BankAccounts.Count)
            {
                this.BankAccounts.RemoveAt(p);
            }
            else
            {
                throw new ArgumentException("Index is outside of range.");
            }
        }
    }
}
