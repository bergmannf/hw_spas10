using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Assessment_Two_Logic.Model;
using Assessment_Two_Logic.Interfaces;

namespace Assessment_Two_Logic.Presenter
{
    /// <summary>
    /// Presenter to show the history.
    /// </summary>
    public class HistoryPresenter
    {
        /// <summary>
        /// Reference to the history handler.
        /// </summary>
        public HistoryHandler _HistoryHandler;

        /// <summary>
        /// Reference to the accompanying view.
        /// </summary>
        public IHistoryView _HistoryView;

        /// <summary>
        /// Initializes a new instance of the <see cref="HistoryPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public HistoryPresenter(IHistoryView view)
        {
            this._HistoryView = view;
            this._HistoryHandler = HistoryHandler.Instance;
            this._HistoryHandler.ChangeEvent += new HistoryHandler.ChangeHandler(this.Update);

            SetUpHandler();
        }

        private void SetUpHandler()
        {
            String appFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            String history = "History.xml";
            this._HistoryHandler.SetFilePath(Path.Combine(appFolder, history));
            this._HistoryHandler.LoadHistory();
        }

        /// <summary>
        /// Updates the specified subject.
        /// Realizes the observer pattern.
        /// </summary>
        /// <param name="subject">The subject.</param>
        public void Update(object subject)
        {
            if (subject is HistoryHandler)
            {
                HistoryHandler histhandler = subject as HistoryHandler;
                this._HistoryView.DisplayHistory(histhandler.History);
            }
        }

        /// <summary>
        /// Saves the history.
        /// </summary>
        public void SaveHistory()
        {
            try
            {
                this._HistoryHandler.SaveHistory();
            }
            catch (NoFilePathSetException e)
            {
                this.DisplayError(e.Message);
            }
        }

        /// <summary>
        /// Clears the history.
        /// </summary>
        public void ClearHistory()
        {
            this._HistoryHandler.ClearHistory();
        }

        /// <summary>
        /// Displays the error.
        /// </summary>
        /// <param name="p">The String to create an error from.</param>
        private void DisplayError(string p)
        {
            ErrorMessage em = new ErrorMessage(p);
            ErrorMessageCollection emc = new ErrorMessageCollection();
            emc.Add(em);
            this._HistoryView.DisplayErrors(emc);
        }
    }
}
