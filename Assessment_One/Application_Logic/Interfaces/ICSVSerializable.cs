using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationLogic.Interfaces
{
    /// <summary>
    /// Used to ensure all objects will be able to persited via FileHandler class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICSVSerializable<T>
    {
        String CsvRepresentation();

        T ParseFromString(String stringRepresentation);
    }
}
