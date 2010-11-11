using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Assessment_Two_Logic.Model;
using Assessment_Two_Logic.Interfaces;

namespace Assessment_Two_Specs
{
    [TestFixture]
    class SerialiserTest
    {
        private ISerialiser<String> serialiser;

        [SetUp]
        public void SetUp()
        {
            this.serialiser = new XmlSerialiser<String>();
        }

        [Test]
        [ExpectedException(typeof(NoFilePathSetException))]
        public void TestWriteWithOutFilePath()
        {
            serialiser.Write("Test");
        }

        [Test]
        [ExpectedException(typeof(NoFilePathSetException))]
        public void TestReadWithOutFilePath()
        {
            serialiser.Read();
        }
    }
}
