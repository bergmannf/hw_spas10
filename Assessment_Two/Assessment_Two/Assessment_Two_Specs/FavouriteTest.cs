using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assessment_Two_Logic.Model;
using NUnit.Framework;

namespace Assessment_Two_Specs
{
    [TestFixture]
    public class FavouriteTest
    {
        [Test]
        public void TestFavouriteValidUrl()
        {
            Favourite fav = new Favourite("http://www.google.de/", "Test");
            Assert.AreEqual("Test", fav.Name);
            Assert.AreEqual("http://www.google.de/", fav.Url);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestFavouriteInvalidUrl()
        {
            Favourite fav = new Favourite("http://www.google.d/", "Test");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestFavouriteNoName()
        {
            Favourite fav = new Favourite("http://www.google.de/", null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestFavouriteEmtpyName()
        {
            Favourite fav = new Favourite("http://www.google.de/", "");
        }
    }
}
