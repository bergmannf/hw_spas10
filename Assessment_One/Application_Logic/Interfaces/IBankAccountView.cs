using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationLogic.Interfaces
{
    public interface IBankAccountView
    {
        int AccountNumber { get; set; }
        String Surname { get; set; }
        Double Balance { get; set; }

        bool IsChanged();

        bool ConfirmChanges();
    }
}
