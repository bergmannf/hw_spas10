using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assessment_Two_Logic.Model
{
    /// <summary>
    /// Exception to notify the caller that no filepath was set.
    /// </summary>
    class NoFilePathSetException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoFilePathSetException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public NoFilePathSetException(String message) : base(message)
        { }
    }
}
