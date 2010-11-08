using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Assessment_Two_Logic.Model;
using Assessment_Two_Logic.Interfaces;

namespace Assessment_Two_Logic.Presenter
{
    public class HistoryPresenter
    {
        public HistoryHandler _HistoryHandler;

        public IHistoryView _HistoryView;

        public HistoryPresenter(IHistoryView view)
        {
            this._HistoryView = view;
            this._HistoryHandler = HistoryHandler.Instance;
            this._HistoryHandler.ChangeEvent += new HistoryHandler.ChangeHandler(this.Update);

            String appFolger = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            String history = "History.xml";
            this._HistoryHandler.SetFilePath(Path.Combine(appFolger, history));
            this._HistoryHandler.LoadHistory();
        }
        
        public void Update(object subject)
        {
            if (subject is HistoryHandler)
            {
                HistoryHandler histhandler = subject as HistoryHandler;
                this._HistoryView.DisplayHistory(histhandler.History);
            }
        }

        public void SetHistoryPath(String path)
        {
            this._HistoryHandler.SetFilePath(path);
        }

        public void SaveHistory()
        {
            this._HistoryHandler.SaveHistory();
        }
    }
}
