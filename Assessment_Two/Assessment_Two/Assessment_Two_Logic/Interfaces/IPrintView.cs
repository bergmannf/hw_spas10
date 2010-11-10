using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Printing;
using System.Drawing;

namespace Assessment_Two_Logic.Interfaces
{
    /// <summary>
    /// Interface to allow a print-presenter to communicate with the view.
    /// </summary>
    public interface IPrintView
    {
        /// <summary>
        /// Gets the current font.
        /// </summary>
        /// <value>The current font.</value>
        Font CurrentFont { get; }

        /// <summary>
        /// Gets the String to be printed.
        /// </summary>
        /// <value>The string.</value>
        String Print { get; }
    }
}
