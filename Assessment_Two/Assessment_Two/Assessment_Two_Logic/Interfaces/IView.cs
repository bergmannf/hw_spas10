using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assessment_Two_Logic.Model;

namespace Assessment_Two_Logic.Interfaces
{
    /// <summary>
    /// Generic interface to enforce certain methods in all views.
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// Displays the errors.
        /// </summary>
        /// <param name="errors">The errors.</param>
        void DisplayErrors(ErrorMessageCollection errors);
    }
}
