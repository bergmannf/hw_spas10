using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assessment_Two_Logic.Model;
using Assessment_Two_Logic.Interfaces;

namespace Assessment_Two_Logic.Presenter
{
    class HistoryPresenter
    {
        public History _History;

        public IHistoryView _HistoryView;

        public HistoryPresenter(IHistoryView view)
        {
            this._HistoryView = view;
            this._History = LoadHistory();
        }

        /// <summary>
        /// Loads the history.
        /// </summary>
        /// <returns>Loaded history or empty history if no history was loaded.</returns>
        private History LoadHistory()
        {
            throw new NotImplementedException();
        }
    }
}
