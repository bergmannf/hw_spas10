using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationLogic.Model
{
    class WrongStringToParseException : Exception
    {
        public WrongStringToParseException(String msg)
            : base(msg)
        {
        }
    }
}
