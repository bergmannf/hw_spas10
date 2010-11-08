using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assessment_Two_Logic.Model;

namespace Assessment_Two_Logic.Interfaces
{
    /// <summary>
    /// Interface to allow a favourites-presenter to communicate with the view. 
    /// </summary>
    public interface IFavouritesView
    {

        /// <summary>
        /// Gets the favourite.
        /// </summary>
        /// <value>The favourite.</value>
        Favourite Favourite { get; }

        /// <summary>
        /// Displays the favourites.
        /// </summary>
        /// <param name="favourites">The favourites.</param>
        void DisplayFavourites(ICollection<Favourite> favourites); 
    }
}
