using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assessment_Two_Logic.Model;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            PageHandler ph = new PageHandler();
            ph.RequestUrl = "http://www.google.co.uk/";
            ph.RequestPage();
            Console.ReadLine();
        }
    }
}
