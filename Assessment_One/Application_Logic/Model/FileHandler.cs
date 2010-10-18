using System;
using System.Collections;
using System.Collections.Generic;
using ApplicationLogic.Interfaces;
using System.IO;
using ApplicationLogic.Model;

namespace ApplicationLogic
{
    /// <summary>
    /// Handles reading and writing from files.
    /// </summary>
    public class FileHandler<T> where T : ICSVSerializable<T>
    {

        public String ReadFilePath;
        public String WriteFilePath;

        public FileHandler()
        {
        }

        public FileHandler(String readFilePath, String writeFilePath)
        {
            this.ReadFilePath = readFilePath;
            this.WriteFilePath = writeFilePath;
        }

        /// <summary>
        /// Attempts to write the specified collection to the file specified in the Handler.
        /// Throws NoFilePathSetException if no file has yet been set.
        /// </summary>
        /// <param name="elements">Collection to be saved to file.</param>
        public void SaveToFile(IList<T> elements)
        {
            if (!String.IsNullOrEmpty(this.WriteFilePath))
            {
                FileStream writeFile = File.Open(WriteFilePath, FileMode.Create);
                using (StreamWriter sw = new StreamWriter(writeFile))
                {
                    foreach (T item in elements)
                    {
                        sw.Write(item.CsvRepresentation());
                        sw.Write("\n");
                    }
                }
            }
            else
            {
                throw new NoFilePathSetException("No file path to write to set.");
            }

        }

        /// <summary>
        /// Attempts to read a collection of items from the specified file.
        /// Throws NoFilePathSetException if no file has yet been set.
        /// </summary>
        /// <param name="item">Parameter needed to construct the objects.</param>
        /// <returns>Collection of items.</returns>
        public IList<T> LoadFromFile(T item)
        {
            if (!String.IsNullOrEmpty(this.ReadFilePath))
            {
                FileStream readFile = File.Open(ReadFilePath, FileMode.Open);
                List<T> returnList = new List<T>();
                using (StreamReader sr = new StreamReader(readFile))
                {
                    String readString = "";
                    while ((readString = sr.ReadLine()) != null)
                    {
						try {
							T t = item.ParseFromString(readString);
                        	returnList.Add(t);	
						} catch (FormatException ex) {
							Console.WriteLine(ex.StackTrace);
						}
                    }
                }
                return returnList;
            }
            else
            {
                throw new NoFilePathSetException("No file path to write to set.");
            }
        }
    }
}

