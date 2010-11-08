using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assessment_Two_Logic.Interfaces;
using Assessment_Two_Logic.Model;

namespace Assessment_Two_Logic.Presenter
{
    public class FavouritePresenter
    {
        private IFavouriteView _FavouriteView;

        private FavouriteHandler _FavouriteHandler;

        public FavouritePresenter(IFavouriteView view)
        {
            this._FavouriteView = view;
            this._FavouriteHandler = FavouriteHandler.Instance;
            
        }

        public void AddFavourite()
        {
            String favName = this._FavouriteView.FavName;
            String favUrl = this._FavouriteView.Url;
            this._FavouriteHandler.AddEntry(favName, favUrl);
        }

        public void EditFavourite()
        {
            Favourite fav = this._FavouriteView.Favourite;
            String favName = this._FavouriteView.FavName;
            String favUrl = this._FavouriteView.Url;
            this._FavouriteHandler.EditFavourite(fav, favName, favUrl);
        }
    }
}
