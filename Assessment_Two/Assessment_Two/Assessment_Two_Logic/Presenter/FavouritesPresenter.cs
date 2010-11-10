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
            String appFolger = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            String history = "Favourites.xml";
            this._FavouriteHandler.SetFilePath(Path.Combine(appFolger, history));
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
            Favourite fav = this._FavouritesView.Favourite;
            this._FavouriteHandler.DeleteFavourite(fav);
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
            this._FavouriteHandler.SaveFavourite();
        }
    }
}
