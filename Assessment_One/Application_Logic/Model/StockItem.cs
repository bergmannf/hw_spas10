using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Application_Logic.Model
{
    public class StockItem
    {
        private String stockCode;

        public String StockCode
        {
            get
            {
                return stockCode;
            }
            set
            {
                if (IsValidStockCode(value))
                {
                    this.stockCode = value;
                }
            }
        }
        public String Name { get; set; }
        public String SupplierName { get; set; }
        public double UnitCost { get; set; }
        public int Required { get; set; }
        public int CurrentStock { get; set; }

        /// <summary>
        /// Checks if the stock code conforms to a certain format.
        /// </summary>
        /// <param name="value">The string that must be checked against the schema.</param>
        /// <returns>True if the string conforms to the schema, false otherwise.</returns>
        public bool IsValidStockCode(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Provided stockcode was null.");
            }
            else
            {
                // TODO: Do not use magic numbers in code
                Regex regexp = new Regex("^[0-9]{4}$");
                return regexp.IsMatch(value);
            }
            
        }

    }
}
