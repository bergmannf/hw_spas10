using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.ComponentModel;
using ApplicationLogic.Interfaces;

namespace ApplicationLogic.Model
{
	/// <summary>
	/// Stores all necessary data for a StockItem.
	/// </summary>
	public class StockItem : INotifyPropertyChanged, ICSVSerializable<StockItem>
	{
		private String _StockCode;
		public String StockCode {
			get { return _StockCode; }
			set {
				if (!IsValidStockCode (value)) {
					throw new ArgumentException ("Provided stockcode did not match designated format.");
				} else {
					this._StockCode = value;
					this.NotifyPropertyChanged ("StockCode");
				}
			}
		}

		private String _Name;
		public String Name {
			get { return _Name; }
			set {
				_Name = value;
				this.NotifyPropertyChanged ("Name");
			}
		}

		private String _SupplierName;
		public String SupplierName {
			get { return _SupplierName; }
			set {
				_SupplierName = value;
				this.NotifyPropertyChanged ("SupplierName");
			}
		}

		private double _UnitCost;
		public double UnitCost {
			get { return _UnitCost; }
			private set {
				if (value < 0.0) {
					throw new ArgumentException ("Price can not be lower than 0.");
				} else {
					_UnitCost = value;
					this.NotifyPropertyChanged ("UnitCost");
				}
				
			}
		}

		private int _RequiredStock;
		public int RequiredStock {
			get { return _RequiredStock; }
			set {
				if (value < 0) {
					throw new ArgumentException ("Can not require less than 0 items.");
				} else {
					_RequiredStock = value;
					this.NotifyPropertyChanged ("RequiredStock");
				}
				
			}
		}

		private int _CurrentStock;
		public int CurrentStock {
			get { return _CurrentStock; }
			set {
				if (value < 0) {
					throw new ArgumentException ("Current stock can not be less than 0 items.");
				} else {
					_CurrentStock = value;
					this.NotifyPropertyChanged ("CurrentStock");
				}
				
			}
		}

		public static ErrorMessageCollection ErrorMessages = new ErrorMessageCollection ();

		public StockItem ()
		{
		}

		public StockItem (String stockCode, String name, String supplierName, double unitCost, int required, int currentStock)
		{
			this.StockCode = stockCode;
			this.Name = name;
			this.SupplierName = supplierName;
			this.UnitCost = unitCost;
			this.RequiredStock = required;
			this.CurrentStock = currentStock;
		}

		/// <summary>
		/// Checks if the stock code conforms to a certain format.
		/// Current format is exactly four numbers, with leading 0 allowed.
		/// </summary>
		/// <param name="value">The string that must be checked against the schema.</param>
		/// <returns>True if the string conforms to the schema, false otherwise.</returns>
		public static bool IsValidStockCode (string value)
		{
			if (String.IsNullOrEmpty (value)) {
				throw new ArgumentNullException ("Provided stockcode was null or empty.");
			} else {
				// TODO: Do not use magic numbers in code
				Regex regexp = new Regex ("^[0-9]{4}$");
				return regexp.IsMatch (value);
			}
			
		}

		public void EditStockItem (String stockCode, String name, String supplierName, double unitCost, int required, int currentStock)
		{
			this.StockCode = stockCode;
			this.Name = name;
			this.SupplierName = supplierName;
			this.UnitCost = unitCost;
			this.RequiredStock = required;
			this.CurrentStock = currentStock;
		}

		/// <summary>
		/// Validates a set of possible changes to a StockItem.
		/// </summary>
		/// <param name="stockCode">StockCodew to be verified</param>
		/// <param name="name">Name to be verified</param>
		/// <param name="supplierName">SupplierName to be verified</param>
		/// <param name="unitCost">UnitCost to be verified</param>
		/// <param name="required">RequiredStock to be verified</param>
		/// <param name="currentStock">CurrentStock to be verified</param>
		/// <returns>True if the values would be valid, false otherwise.</returns>
		public static bool Validate (String stockCode, String name, String supplierName, double unitCost, int required, int currentStock)
		{
			if (String.IsNullOrEmpty (stockCode) || !IsValidStockCode (stockCode)) {
				ErrorMessages.Add (new ErrorMessage ("Need a stockcode that adheres to the stockcode format: 4 numbers."));
			}
			if (String.IsNullOrEmpty (name)) {
				ErrorMessages.Add (new ErrorMessage ("Need an item name."));
			}
			if (String.IsNullOrEmpty (supplierName)) {
				ErrorMessages.Add (new ErrorMessage ("Need a supplier name."));
			}
			if (unitCost < 0.0) {
				ErrorMessages.Add (new ErrorMessage ("Unit costs must be greater or equal 0."));
			}
			if (required < 0) {
				ErrorMessages.Add (new ErrorMessage ("Required must be greater or equal 0."));
			}
			if (currentStock < 0) {
				ErrorMessages.Add (new ErrorMessage ("Current must be greater or equal 0."));
			}
			return ErrorMessages.Count == 0;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void NotifyPropertyChanged (String info)
		{
			if (PropertyChanged != null) {
				PropertyChanged (this, new PropertyChangedEventArgs (info));
			}
		}

		/// <summary>
		/// Returns the current StockItem object as a CSV-String.
		/// </summary>
		/// <returns>Representation of the current object as CSV-String.</returns>
		public String CsvRepresentation ()
		{
			return String.Format ("{0},{1},{2},{3},{4},{5}", this.StockCode, this.Name, this.SupplierName, this.UnitCost, this.RequiredStock, this.CurrentStock);
		}

		/// <summary>
		/// Attempts to create a StockItem object from a string.
		/// </summary>
		/// <param name="stringRepresentation">The String to be parsed to StockItem.</param>
		/// <returns>StockItem object.</returns>
		public StockItem ParseFromString (string stringRepresentation)
		{
			string[] split = stringRepresentation.Split (',');
			String stockCode = split[0];
			String name = split[1];
			String supplierName = split[2];
			String unitCost = split[3];
			String requiredStock = split[4];
			String currentStock = split[5];
			double cost = 0;
			int reqStock = 0;
			int currStock = 0;
			if (!String.IsNullOrEmpty (unitCost)) {
				cost = double.Parse (unitCost);
			}
			if (!String.IsNullOrEmpty (requiredStock)) {
				reqStock = int.Parse (requiredStock);
			}
			if (!String.IsNullOrEmpty (currentStock)) {
				currStock = int.Parse (currentStock);
			}
			return new StockItem (stockCode, name, supplierName, cost, reqStock, currStock);
		}
	}
}
