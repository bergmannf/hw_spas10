using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Assessment_Two_Logic.Interfaces;
using Assessment_Two_Logic.Model;

namespace Assessment_Two_Logic.Presenter
{
    public class FavouritesPresenter
    {
        private FavouriteHandler _FavouriteHandler;

        private IFavouritesView _FavouritesView;

        public FavouritesPresenter(IFavouritesView view)
        {
            this._FavouritesView = view;
            this._FavouriteHandler = FavouriteHandler.Instance;
            this._FavouriteHandler.ChangeEvent += new FavouriteHandler.ChangeHandler(this.Update);
            String appFolger = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            String history = "Favourites.xml";
            this._FavouriteHandler.SetFilePath(Path.Combine(appFolger, history));
            this._FavouriteHandler.LoadFavourite();
        }

        public void Update(object subject)
        {
            if (subject is FavouriteHandler)
            {
                FavouriteHandler favHandler = subject as FavouriteHandler;
                this._FavouritesView.DisplayFavourites(favHandler.Favourites);
            }
        }

        public void DeleteFavourite()
        {
            Favourite fav = this._FavouritesView.Favourite;
            this._FavouriteHandler.DeleteFavourite(fav);
        }

        public void SetFavouritesPath(String path)
        {
            this._FavouriteHandler.SetFilePath(path);
        }

        public void SaveFavourites()
        {
            this._FavouriteHandler.SaveFavourite();
        }
    }
}
