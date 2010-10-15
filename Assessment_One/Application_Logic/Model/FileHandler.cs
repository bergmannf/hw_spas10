using System;
using System.Collections;
using System.Collections.Generic;
using ApplicationLogic.Interfaces;
using System.IO;

namespace ApplicationLogic
{
    /// <summary>
    /// Handles reading and writing from files.
    /// </summary>
	public class FileHandler<T> where T: ICSVSerializable<T>
	{

        public String ReadFilePath;
        public String WriteFilePath;

		public FileHandler()
        {
        }

		public FileHandler (String readFilePath, String writeFilePath)
		{
            this.ReadFilePath = readFilePath;
            this.WriteFilePath = writeFilePath;
		}

        public void SaveToFile(IList<T> elements)
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

        public IList<T> LoadFromFile(T item)
        {
            FileStream readFile = File.Open(ReadFilePath, FileMode.Open);
            List<T> returnList = new List<T>();
            using (StreamReader sr = new StreamReader(readFile))
            {
                String readString = "";
                while ((readString = sr.ReadLine()) != null)
                {
                    T t = item.ParseFromString(readString);
                    returnList.Add(t);
                }
            }
            return returnList;
        }
	}
}

