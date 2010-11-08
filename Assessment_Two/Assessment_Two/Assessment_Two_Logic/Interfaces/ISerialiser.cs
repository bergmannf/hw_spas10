using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Assessment_Two_Logic.Interfaces
{
    /// <summary>
    /// Interface to allow different types of serializers to be used if necessary.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISerialiser<T>
    {
        /// <summary>
        /// Gets or sets the file path.
        /// </summary>
        /// <value>The file path.</value>
        String FilePath { get; set; }

        /// <summary>
        /// Writes the specified t.
        /// </summary>
        /// <param name="t">The t.</param>
        void Write(T t);

        /// <summary>
        /// Reads this instance.
        /// </summary>
        /// <returns></returns>
        T Read();
    }
}
