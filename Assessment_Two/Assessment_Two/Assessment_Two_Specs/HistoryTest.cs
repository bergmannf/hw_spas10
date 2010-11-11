using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Assessment_Two_Logic.Model;

namespace Assessment_Two_Specs
{
    [TestFixture]
    class HistoryTest
    {
        [Test]
        public void TestHistoryValidValues()
        {
            History hist = new History();
            hist.AddItem("http://www.google.de/");
            Assert.AreEqual(1, hist.VisitList.Count);
            Assert.AreEqual("http://www.google.de/", hist.VisitList.ElementAt(0).Value);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestHistoryInvalidUrl()
        {
            History hist = new History();
            hist.AddItem("http://www.google.d/");
        }
    }
}
