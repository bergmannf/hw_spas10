﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assessment_Two_Logic.Model
{
    /// <summary>
    /// Stores a favourite with a display name.
    /// </summary>
    public class Favourite
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
                if (PageHandler.IsValidUrl(value))
                {
                    _Url = value;
                }
                else
                {
                    throw new ArgumentException("The favourite-url does not match a valid format.");
                }
            }
        }

        private String _Name;
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _Name = value;
                }
                else
                {
                    throw new ArgumentException("The favourite-name is not in a valid format");
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Favourite"/> class.
        /// </summary>
        public Favourite()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Favourite"/> class.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="name">The name.</param>
        public Favourite(String url, String name)
        {
            this.Name = name;
            this.Url = url;
        }

        /// <summary>
        /// Edits the favourite.
        /// </summary>
        /// <param name="newUrl">The new URL.</param>
        /// <param name="newName">The new name.</param>
        public void EditFavourite(String newUrl, String newName)
        {
            this.Name = newName;
            this.Url = newUrl;
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.Name + " - " + this.Url;
        }
    }
}
