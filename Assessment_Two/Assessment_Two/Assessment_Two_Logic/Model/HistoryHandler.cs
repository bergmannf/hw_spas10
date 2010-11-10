using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;
using Assessment_Two_Logic.Interfaces;

namespace Assessment_Two_Logic.Model
{
    public class HistoryHandler
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public delegate void ChangeHandler(object subject);
        
        public event ChangeHandler ChangeEvent;

        /// <summary>
        /// Object used to locking to prevent deadlocks.
        /// </summary>
        private static Object lockObject = new Object();

        private static HistoryHandler _Instance;

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static HistoryHandler Instance
        {
            get
            {
                if (_Instance == null)
                {
                    lock (lockObject)
                    {
                        if (_Instance == null)
                        {
                            _Instance = new HistoryHandler();
                        }
                    }
                }
                return _Instance;
            }
        }

        private ISerialiser<History> _Serializer;
        private History _History;

        /// <summary>
        /// Gets the history.
        /// </summary>
        /// <value>The history.</value>
        public History History
        {
            get
            {
                return _History;
            }
        }

        private HistoryHandler()
        {
            this._Serializer = new XmlSerialiser<History>();
            this._History = new History();
        }

        private HistoryHandler(String filePath)
        {
            this._Serializer = new XmlSerialiser<History>(filePath);
            this._History = new History();
        }

        /// <summary>
        /// Adds the entry.
        /// </summary>
        /// <param name="url">The URL.</param>
        public void AddEntry(String url)
        {
            this.History.AddItem(url);
            this.Notify();
        }

        /// <summary>
        /// Adds the entry.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <param name="url">The URL.</param>
        public void AddEntry(DateTime time, String url)
        {
            this.History.AddItem(time, url);
            this.Notify();
        }

        /// <summary>
        /// Sets the file path.
        /// </summary>
        /// <param name="path">The path.</param>
        public void SetFilePath(String path)
        {
            this._Serializer.FilePath = path;
        }

        /// <summary>
        /// Loads the history.
        /// </summary>
        public void LoadHistory()
        {
            try
            {
                History history = this._Serializer.Read();
                this._History.ClearHistory();
                foreach (var item in history.VisitList)
                {
                    this._History.AddItem(item);
                }
                this.Notify();
            }
            catch (Exception e)
            {
                logger.Error(e);
            }
        }

        /// <summary>
        /// Loads the history.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        public void LoadHistory(String filePath)
        {
            String oldPath = this._Serializer.FilePath;
            this._Serializer.FilePath = filePath;
            History history = this._Serializer.Read();
            this._History.ClearHistory();
            foreach (var item in history.VisitList)
            {
                this._History.AddItem(item);
            }
            this._Serializer.FilePath = oldPath;
            this.Notify();
        }

        /// <summary>
        /// Saves the history.
        /// </summary>
        public void SaveHistory()
        {
            this._Serializer.Write(this.History);
        }

        /// <summary>
        /// Saves the history.
        /// </summary>
        /// <param name="path">The path.</param>
        public void SaveHistory(String path)
        {
            String oldPath = this._Serializer.FilePath;
            this._Serializer.FilePath = path;
            this.SaveHistory();
            this._Serializer.FilePath = oldPath;
        }

        /// <summary>
        /// Notifies the observers.
        /// </summary>
        private void Notify()
        {
            if (ChangeEvent != null)
            {
                ChangeEvent(this);
            }
        }
    }
}
