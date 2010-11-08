using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assessment_Two_Logic.Model;

namespace Assessment_Two_Logic.Interfaces
{
    /// <summary>
    /// Interface to allow a history-presenter to communicate with the view. 
    /// </summary>
    public interface IHistoryView : IView
    {
        /// <summary>
        /// Displays the history.
        /// </summary>
        /// <param name="history">The history.</param>
        void DisplayHistory(History history);
    }
}
