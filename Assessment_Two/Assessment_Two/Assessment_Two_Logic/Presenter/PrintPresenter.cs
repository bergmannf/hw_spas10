using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assessment_Two_Logic.Interfaces;
using System.Drawing.Printing;
using System.Drawing;


namespace Assessment_Two_Logic.Presenter
{
    /// <summary>
    /// 
    /// </summary>
    public class PrintPresenter
    {
        private IPrintView _PrintView;

        /// <summary>
        /// Gets or sets the string to be printed.
        /// </summary>
        /// <value>The string to be printed.</value>
        private String PrintString { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PrintPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public PrintPresenter(IPrintView view)
        {
            this._PrintView = view;
        }

        /// <summary>
        /// Prints the printstring.
        /// Method from Microsoft.
        /// </summary>
        /// <param name="e">The <see cref="System.Drawing.Printing.PrintPageEventArgs"/> instance containing the event data.</param>
        public void Print(System.Drawing.Printing.PrintPageEventArgs e)
        {
            
            Font font = _PrintView.CurrentFont;
            int charactersOnPage = 0;
            int linesPerPage = 0;

            // Sets the value of charactersOnPage to the number of characters 
            // of PrintString that will fit within the bounds of the page.
            e.Graphics.MeasureString(PrintString, font,
                e.MarginBounds.Size, StringFormat.GenericTypographic,
                out charactersOnPage, out linesPerPage);

            // Draws the string within the bounds of the page
            e.Graphics.DrawString(PrintString, font, Brushes.Black,
                e.MarginBounds, StringFormat.GenericTypographic);

            // Remove the portion of the string that has been printed.
            PrintString = PrintString.Substring(charactersOnPage);

            // Check to see if more pages are to be printed.
            e.HasMorePages = (PrintString.Length > 0);
        }

        public void SetPrintString()
        {
            this.PrintString = this._PrintView.Print;
        }
    }
}
