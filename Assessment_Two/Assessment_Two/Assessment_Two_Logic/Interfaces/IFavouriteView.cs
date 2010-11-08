using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assessment_Two_Logic.Model;

namespace Assessment_Two_Logic.Interfaces
{
    /// <summary>
    /// Interface to allow a favourite-presenter to communicate with the view. 
    /// </summary>
    public interface IFavouriteView : IView
    {
        /// <summary>
        /// Gets or sets the favourite.
        /// </summary>
        /// <value>The favourite.</value>
        Favourite Favourite { get; set; }
        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        String Url { get; set; }
        /// <summary>
        /// Gets or sets the name of the fav.
        /// </summary>
        /// <value>The name of the fav.</value>
        String FavName { get; set; }
    }
}
