using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationLogic.Model
{
    public class ErrorMessage
    {
        public String Message { get; set; }
        public String Source { get; set; }

        public ErrorMessage(string p)
        {
            this.Message = p;
        }

        public override string ToString()
        {
            return Message;
        }
    }
}
