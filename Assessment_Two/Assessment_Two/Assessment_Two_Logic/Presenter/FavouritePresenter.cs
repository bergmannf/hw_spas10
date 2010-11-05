using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assessment_Two_Logic.Interfaces;

namespace Assessment_Two_Logic.Presenter
{
    public class FavouritePresenter
    {
        private IFavouriteView _FavouriteView;

        public FavouritePresenter(IFavouriteView view)
        {
            this._FavouriteView = view;
        }

        public void AddFavourite()
        {
            String favName = this._FavouriteView.FavName;
            String favUrl = this._FavouriteView.Url;
        }
    }
}
