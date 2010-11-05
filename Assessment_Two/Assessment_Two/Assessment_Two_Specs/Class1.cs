using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Assessment_Two_Logic.Model;

namespace Assessment_Two_Specs
{
    [TestFixture]
    public class TestPageHandler
    {
        [Test]
        public void TestValidUrl()
        {
            string validUrl = "http://www.google.de/";
            string validUrlTwo = "http://www.go-gl.de/";
            string validUrlThree = "http://m.G123oogle.com.uk";
            Assert.AreEqual(true, PageHandler.IsValidUrl(validUrl));
            Assert.AreEqual(true, PageHandler.IsValidUrl(validUrlTwo));
            Assert.AreEqual(true, PageHandler.IsValidUrl(validUrlThree));
        }
    }
}
