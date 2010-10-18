using System;
using System.Collections;
using System.Collections.Generic;
using ApplicationLogic;
using ApplicationLogic.Model;
using NUnit.Framework;
namespace NUnit_Tests
{
	[TestFixture()]
	public class FileHandlerTest
	{
		[Test]
		[ExpectedException(typeof(NoFilePathSetException))]
		public void TestWriteToFileWithoutPath ()
		{
			FileHandler<StockItem> fh = new FileHandler<StockItem>();
			fh.SaveToFile(new List<StockItem>());
		}
		
		[Test]
		[ExpectedException(typeof(NoFilePathSetException))]
		public void TestReadFromFileWithoutPath()
		{
			FileHandler<StockItem> fh = new FileHandler<StockItem>();
			fh.LoadFromFile(new StockItem());
		}
	}
}

