using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationLogic.Model
{
    public class NoFilePathSetException : Exception
    {

        public NoFilePathSetException(String msg)
            : base(msg)
        {
        }
    }
}
