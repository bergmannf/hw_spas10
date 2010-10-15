using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationLogic.Interfaces
{
    public interface ICSVSerializable<T>
    {
        String CsvRepresentation();

        T ParseFromString(String stringRepresentation);
    }
}
