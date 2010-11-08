using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assessment_Two_Logic.Model
{

    /// <summary>
    /// Stores the history of visited webpages with their associated date.
    /// </summary>
    public class History
    {
        private SerializableDictionary<DateTime, String> _VisitList;

        /// <summary>
        /// Gets the visit list.
        /// </summary>
        /// <value>The visit list.</value>
        public SerializableDictionary<DateTime, String> VisitList
        {
            get
            {
                return _VisitList;
            }
            set
            {
                this._VisitList = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="History"/> class.
        /// </summary>
        public History()
        {
            this._VisitList = new SerializableDictionary<DateTime, string>();
        }

        /// <summary>
        /// Adds the item.
        /// The associated time will be the current time on the executing machine.
        /// </summary>
        /// <param name="url">The URL.</param>
        public void AddItem(String url)
        {
            DateTime time = DateTime.UtcNow;
            this.AddItem(time, url);
        }

        /// <summary>
        /// Adds the item to the history.
        /// </summary>
        /// <param name="time">The time of the visit.</param>
        /// <param name="url">The URL.</param>
        public void AddItem(DateTime time, String url)
        {
            this._VisitList.Add(time, url);
        }

        /// <summary>
        /// Clears the history.
        /// </summary>
        public void ClearHistory()
        {
            this._VisitList.Clear();
        }

        /// <summary>
        /// Determines whether this instance is empty.
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if this instance is empty; otherwise, <c>false</c>.
        /// </returns>
        internal bool IsEmpty()
        {
            return this._VisitList.Count == 0;
        }

        /// <summary>
        /// Adds the item.
        /// </summary>
        /// <param name="item">The item.</param>
        internal void AddItem(KeyValuePair<DateTime, string> item)
        {
            this.VisitList.Add(item.Key, item.Value);
        }
    }
}
