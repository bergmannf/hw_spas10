using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationLogic.Interfaces
{
    public interface IBankAccountView
    {
        int AccountNumber { get; }
        String Surname { get; }
        double Balance { get; }
    }
}
