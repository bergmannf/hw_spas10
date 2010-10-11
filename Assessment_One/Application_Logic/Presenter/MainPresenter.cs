using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApplicationLogic.Model;

namespace ApplicationLogic.Presenter
{
    /// <summary>
    /// Presenter for the MainWindow: handles events and application logic.
    /// </summary>
    class MainPresenter
    {
        private List<StockItem> _StockItems;
        private List<BankAccount> _BankAccounts;
        private IStockView _View;
    }
}
