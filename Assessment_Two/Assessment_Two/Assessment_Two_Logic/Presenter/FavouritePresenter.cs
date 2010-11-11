using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assessment_Two_Logic.Interfaces;
using Assessment_Two_Logic.Model;

namespace Assessment_Two_Logic.Presenter
{
    /// <summary>
    /// Presenter to show, add and edit a single favourite object.
    /// </summary>
    public class FavouritePresenter
    {
        /// <summary>
        /// Reference to the view.
        /// </summary>
        private IFavouriteView _FavouriteView;

        /// <summary>
        /// Reference to the favourite handler.
        /// </summary>
        private FavouriteHandler _FavouriteHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="FavouritePresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public FavouritePresenter(IFavouriteView view)
        {
            this._FavouriteView = view;
            this._FavouriteHandler = FavouriteHandler.Instance;
            
        }

        /// <summary>
        /// Adds the favourite.
        /// </summary>
        public void AddFavourite()
        {
            try
            {
                String favName = this._FavouriteView.FavName;
                String favUrl = this._FavouriteView.Url;
                this._FavouriteHandler.AddEntry(favName, favUrl);
            }
            catch (ArgumentException e)
            {
                this.DisplayError(e.Message);   
            }
        }

        /// <summary>
        /// Edits the favourite.
        /// </summary>
        public void EditFavourite()
        {
            try
            {
                Favourite fav = this._FavouriteView.Favourite;
                String favName = this._FavouriteView.FavName;
                String favUrl = this._FavouriteView.Url;
                this._FavouriteHandler.EditFavourite(fav, favName, favUrl);
            }
            catch (ArgumentException e)
            {
                this.DisplayError(e.Message);
            }
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
            this._FavouriteView.DisplayErrors(emc);
        }
    }
}
