using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.ComponentModel;

namespace ApplicationLogic.Model
{
    public class StockItem : INotifyPropertyChanged
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
                else
                {
                    this._StockCode = value;
                    this.NotifyPropertyChanged("StockCode");
                }
            }
        }

        private String _Name;
        public String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
                this.NotifyPropertyChanged("Name");
            }
        }

        private String _SupplierName;
        public String SupplierName
        {
            get
            {
                return _SupplierName;
            }
            set
            {
                _SupplierName = value;
                this.NotifyPropertyChanged("SupplierName");
            }
        }

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
                else
                {
                    _UnitCost = value;
                    this.NotifyPropertyChanged("UnitCost");
                }

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
                else
                {
                    _RequiredStock = value;
                    this.NotifyPropertyChanged("RequiredStock");
                }

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
                else
                {
                    _CurrentStock = value;
                    this.NotifyPropertyChanged("CurrentStock");
                }

            }
        }

        public static ErrorMessageCollection ErrorMessages = new ErrorMessageCollection();

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
        public static bool IsValidStockCode(string value)
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

        public static bool Validate(String stockCode, String name, String supplierName, double unitCost, int required, int currentStock)
        {
            if (String.IsNullOrEmpty(stockCode) || !IsValidStockCode(stockCode))
            {
                ErrorMessages.Add(new ErrorMessage("Need a stockcode that adheres to the stockcode format: 4 numbers."));
            }
            if (String.IsNullOrEmpty(name))
            {
                ErrorMessages.Add(new ErrorMessage("Need an item name."));
            }
            if (String.IsNullOrEmpty("supplierName"))
            {
                ErrorMessages.Add(new ErrorMessage("Need a supplier name."));
            }
            if (unitCost < 0.0)
            {
                ErrorMessages.Add(new ErrorMessage("Unit costs must be greater or equal 0."));
            }
            if (required < 0)
            {
                ErrorMessages.Add(new ErrorMessage("Required must be greater or equal 0."));
            }
            if (currentStock < 0)
            {
                ErrorMessages.Add(new ErrorMessage("Current must be greater or equal 0."));
            }
            return ErrorMessages.Count == 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

    }
}
