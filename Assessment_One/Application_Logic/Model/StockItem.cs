using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ApplicationLogic.Model
{
    public class StockItem
    {
        private String _StockCode;
        public String StockCode
        {
            get
            {
                return _StockCode;
            }
            set
            {
                if (!IsValidStockCode(value))
                {
                    throw new ArgumentException("Provided stockcode did not match designated format.");
                }
                this._StockCode = value;
            }
        }

        public String Name { get; set; }

        public String SupplierName { get; set; }

        private double _UnitCost;
        public double UnitCost
        {
            get
            {
                return _UnitCost;
            }
            private set
            {
                if (value < 0.0)
                {
                    throw new ArgumentException("Price can not be lower than 0.");
                }
                _UnitCost = value;
            }
        }

        private int _RequiredStock;
        public int RequiredStock
        {
            get
            {
                return _RequiredStock;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Can not require less than 0 items.");
                }
                _RequiredStock = value;
            }
        }

        private int _CurrentStock;
        public int CurrentStock
        {
            get
            {
                return _CurrentStock;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Current stock can not be less than 0 items.");
                }
                _CurrentStock = value;
            }
        }

        public StockItem(String stockCode, String name, String supplierName, double unitCost, int required, int currentStock)
        {
            this.StockCode = stockCode;
            this.Name = name;
            this.SupplierName = supplierName;
            this.UnitCost = unitCost;
            this.RequiredStock = required;
            this.CurrentStock = currentStock;
        }

        public StockItem()
        {
            // TODO: Complete member initialization
        }

        /// <summary>
        /// Checks if the stock code conforms to a certain format.
        /// Current format is exactly four numbers, with leading 0 allowed.
        /// </summary>
        /// <param name="value">The string that must be checked against the schema.</param>
        /// <returns>True if the string conforms to the schema, false otherwise.</returns>
        public bool IsValidStockCode(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Provided stockcode was null or empty.");
            }
            else
            {
                // TODO: Do not use magic numbers in code
                Regex regexp = new Regex("^[0-9]{4}$");
                return regexp.IsMatch(value);
            }
            
        }

        public void EditStockItem(String stockCode, String name, String supplierName, double unitCost, int required, int currentStock)
        {
            this.StockCode = stockCode;
            this.Name = name;
            this.SupplierName = supplierName;
            this.UnitCost = unitCost;
            this.RequiredStock = required;
            this.CurrentStock = currentStock;
        }
    }
}
