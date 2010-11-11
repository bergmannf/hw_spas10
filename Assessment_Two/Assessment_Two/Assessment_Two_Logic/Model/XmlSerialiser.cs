using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assessment_Two_Logic.Interfaces;
using System.IO;
using System.Xml.Serialization;

namespace Assessment_Two_Logic.Model
{
    /// <summary>
    /// An XmlSerialiser.
    /// </summary>
    /// <typeparam name="T">The type that can be serialised via this Serialiser.</typeparam>
    public class XmlSerialiser<T> : ISerialiser<T>
    {
        private String _FilePath;

        public string FilePath
        {
            get
            {
                return this._FilePath;
            }
            set
            {
                this._FilePath = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlSerialiser&lt;T&gt;"/> class.
        /// </summary>
        public XmlSerialiser()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlSerialiser&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        public XmlSerialiser(string filePath)
        {
            this.FilePath = filePath;
        }

        /// <summary>
        /// Writes the specified t to the filepath.
        /// </summary>
        /// <param name="t">The t.</param>
        public void Write(T t)
        {
            if (!String.IsNullOrEmpty(this.FilePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                TextWriter writer = new StreamWriter(this._FilePath);
                serializer.Serialize(writer, t);
                writer.Close();  
            }
            else
            {
                throw new NoFilePathSetException("No file path set to save the elements to.");
            }
        }

        /// <summary>
        /// Reads a specified t from the filepath.
        /// </summary>
        /// <returns>The t read.</returns>
        public T Read()
        {
            if (!String.IsNullOrEmpty(this.FilePath))
            {
                T t;
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                TextReader reader = new StreamReader(this._FilePath);
                t = (T)serializer.Deserialize(reader);
                reader.Close();
                return t;
            }
            else
            {
                throw new NoFilePathSetException("No file path set to read the elements from.");
            }
        }

    }
}
