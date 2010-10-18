using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApplicationLogic.Model;

namespace ApplicationLogic.Interfaces
{
    /// <summary>
    /// Utilized by the presenter to get the necessary values from a view.
    /// </summary>
    public interface ICongregateView
    {
        StockItem StockItem { get; }

        BankAccount BankAccount { get; }

        int Quantity { get; }

        double Deposit { get; }

        double Withdraw { get; }

        bool ConfirmDelete();

        bool ConfirmClose();

        void DisplayValidationErrors(ErrorMessageCollection errorCollection);
    }
}
