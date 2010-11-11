using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assessment_Two_Logic.Model;
using NUnit.Framework;

namespace Assessment_Two_Specs
{
    class FavouriteHandlerTest
    {
        private FavouriteHandler handler;

        [SetUp]
        public void SetUp()
        {
            this.handler = FavouriteHandler.Instance;
        }
        
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestEditFavouriteNull()
        {
            this.handler.EditFavourite(null, "12", "12");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestEditNonPresentFavourite()
        {
            Favourite fav = new Favourite();
            this.handler.EditFavourite(fav, "12", "12");
        }

        [Test]
        public void TestDeleteNonPresentFavourite()
        {
            Favourite fav = new Favourite();
            int length = this.handler.Favourites.Count;
            this.handler.DeleteFavourite(fav);
            int lengthAfterRemoval = this.handler.Favourites.Count;
            Assert.AreEqual(length, lengthAfterRemoval);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestDeleteNull()
        {
            this.handler.DeleteFavourite(null);
        }

        [Test]
        public void TestAddAndRemoveFavourite()
        {
            this.handler.AddEntry("test", "http://www.test.de/");
            Favourite fav = this.handler.Favourites.ElementAt(0);
            this.handler.DeleteFavourite(fav);
            Assert.AreEqual(0, this.handler.Favourites.Count);
        }

        [Test]
        public void TestAddFavourite()
        {
            this.handler.AddEntry("test", "http://www.test.de/");
            Assert.AreEqual(1, this.handler.Favourites.Count);
        }

        [Test]
        public void TestEditFavourite()
        {
            this.handler.AddEntry("test", "http://www.test.de");
            Favourite fav = this.handler.Favourites.ElementAt(0);
            this.handler.EditFavourite(fav, "New", "http://www.test2.de/");
            Assert.AreEqual(fav.Url, "http://www.test2.de/");
            Assert.AreEqual(fav.Name, "New");
        }
    }
}
