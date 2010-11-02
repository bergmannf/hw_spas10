using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assessment_Two_Logic.Model
{
    /// <summary>
    /// Stores a favourite with a display name.
    /// </summary>
    class Favourite
    {
        private String _Url;

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        public String Url
        {
            get
            {
                return _Url;
            }
            set
            {
                _Url = value;
            }
        }

        private String _Name;
        public String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Favourite"/> class.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="name">The name.</param>
        public Favourite(String url, String name)
        {
            this._Name = name;
            this._Url = url;
        }
    }
}
