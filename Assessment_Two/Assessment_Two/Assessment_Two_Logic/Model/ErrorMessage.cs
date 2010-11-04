using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assessment_Two_Logic.Model
{
    public class ErrorMessage
    {
        private string _Message;
        private string _Source;

        public ErrorMessage(string message,
            string source)
        {
            _Message = message;
            _Source = source;
        }

        public ErrorMessage(string message)
        {
            _Message = message;
        }

        public ErrorMessage()
        {
        }

        public string Message
        {
            get
            {
                return _Message;
            }

            set
            {
                _Message = value;
            }
        }

        public string Source
        {
            get
            {
                return _Source;
            }

            set
            {
                _Source = value;
            }
        }

        public override string ToString()
        {
            return _Message;
        }
    }
}
