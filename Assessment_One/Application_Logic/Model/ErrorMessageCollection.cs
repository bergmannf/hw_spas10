using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationLogic.Model
{
    /// <summary>
    /// Used to store meaningful errormessages for further use.
    /// </summary>
    public class ErrorMessageCollection : List<ErrorMessage>
    {
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (ErrorMessage item in this)
            {
                if (sb.Length > 0)
                {
                    sb.Append(Environment.NewLine);
                }

                sb.Append(item.ToString());
            }

            return sb.ToString();
        }
    }
}
