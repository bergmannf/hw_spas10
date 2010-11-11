using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Assessment_Two_Logic.Interfaces;
using Assessment_Two_Logic.Model;

namespace Assessment_Two_Logic.Presenter
{
    /// <summary>
    /// Presenter to show and delete a list of favourites.
    /// </summary>
    public class FavouritesPresenter
    {
        private FavouriteHandler _FavouriteHandler;

        private IFavouritesView _FavouritesView;

        /// <summary>
        /// Initializes a new instance of the <see cref="FavouritesPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public FavouritesPresenter(IFavouritesView view)
        {
            this._FavouritesView = view;
            this._FavouriteHandler = FavouriteHandler.Instance;
            this._FavouriteHandler.ChangeEvent += new FavouriteHandler.ChangeHandler(this.Update);
            SetUpHandler();
        }

        private void SetUpHandler()
        {
            String appFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            String history = "Favourites.xml";
            this._FavouriteHandler.SetFilePath(Path.Combine(appFolder, history));
            this._FavouriteHandler.LoadFavourite();
        }

        /// <summary>
        /// Updates the specified subject.
        /// Realizes the observer pattern.
        /// </summary>
        /// <param name="subject">The subject.</param>
        public void Update(object subject)
        {
            if (subject is FavouriteHandler)
            {
                FavouriteHandler favHandler = subject as FavouriteHandler;
                this._FavouritesView.DisplayFavourites(favHandler.Favourites);
            }
        }

        /// <summary>
        /// Deletes the favourite.
        /// </summary>
        public void DeleteFavourite()
        {
            try
            {
                Favourite fav = this._FavouritesView.Favourite;
                this._FavouriteHandler.DeleteFavourite(fav);
            }
            catch (ArgumentException e)
            {
                this.DisplayError(e.Message);
            }
        }

        /// <summary>
        /// Sets the favourites path.
        /// </summary>
        /// <param name="path">The path.</param>
        public void SetFavouritesPath(String path)
        {
            this._FavouriteHandler.SetFilePath(path);
        }

        /// <summary>
        /// Saves the favourites.
        /// </summary>
        public void SaveFavourites()
        {
            try
            {
                this._FavouriteHandler.SaveFavourite();
            }
            catch (NoFilePathSetException e)
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
            this._FavouritesView.DisplayErrors(emc);
        }
    }
}
