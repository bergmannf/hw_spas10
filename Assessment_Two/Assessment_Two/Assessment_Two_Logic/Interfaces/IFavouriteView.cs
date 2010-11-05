using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assessment_Two_Logic.Model;

namespace Assessment_Two_Logic.Interfaces
{
    public interface IFavouriteView : IView
    {
        String Url { get; set; }
        String FavName { get; set; }
    }
}
