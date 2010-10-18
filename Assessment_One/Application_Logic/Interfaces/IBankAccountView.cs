using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationLogic.Interfaces
{
    /// <summary>
    /// Utilized by the presenter to get the necessary values from a view.
    /// </summary>
    public interface IBankAccountView
    {
        int AccountNumber { get; }
        String Surname { get; }
        double Balance { get; }
    }
}
