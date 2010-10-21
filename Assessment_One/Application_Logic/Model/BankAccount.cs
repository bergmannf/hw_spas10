using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using ApplicationLogic.Interfaces;

namespace ApplicationLogic.Model
{
	/// <summary>
	/// Pseudo bank account to allow the placement of an order.
	/// </summary>
	public class BankAccount : INotifyPropertyChanged, ICSVSerializable<BankAccount>
	{
		private int _AccountNumber;
		/// <summary>
		/// Gets or sets the account number.
		/// </summary>
		/// <value>The account number.</value>
		public virtual int AccountNumber {
			get { return _AccountNumber; }
			set {
				_AccountNumber = value;
				this.NotifyPropertyChanged ("AccountNumber");
			}
		}

		private String _Surname;
		/// <summary>
		/// Gets or sets the surname.
		/// </summary>
		/// <value>The surname.</value>
		public virtual String Surname {
			get { return _Surname; }
			set {
				_Surname = value;
				this.NotifyPropertyChanged ("Surname");
			}
		}

		private double _Balance;
		/// <summary>
		/// Gets or sets the balance.
		/// </summary>
		/// <value>The balance.</value>
		public virtual double Balance {
			get { return _Balance; }
			private set {
				if (value < 0.0) {
					throw new ArgumentException ("This class does not allow a balance smaller than 0.");
				} else {
					_Balance = value;
					this.NotifyPropertyChanged ("Balance");
				}
				
			}
		}

		public static ErrorMessageCollection ErrorMessages = new ErrorMessageCollection ();

		/// <summary>
		/// Initializes a new instance of the <see cref="BankAccount"/> class.
		/// </summary>
		public BankAccount ()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="BankAccount"/> class.
		/// </summary>
		/// <param name="acc">The acc.</param>
		/// <param name="name">The name.</param>
		/// <param name="balance">The balance.</param>
		public BankAccount (int acc, string name, double balance)
		{
			this.AccountNumber = acc;
			this.Surname = name;
			this.Balance = balance;
		}

		/// <summary>
		/// Allows the withdrawal of money from this account.
		/// Credit is not granted.
		/// </summary>
		/// <param name="amount">Amount to be withdrawn - must be greater than 0.</param>
		public void Withdraw (double amount)
		{
			if (amount > 0.0) {
				if (Balance >= amount) {
					this.Balance -= amount;
				} else {
					throw new NotEnoughFundsException ("Not enough founds on bank account to withdraw.");
				}
			} else {
                throw new ArgumentException("To deposit money please use the appropriate function.");
			}
		}

		/// <summary>
		/// Allows the deposit of money to this account.
		/// </summary>
		/// <param name="amount">Amount to be deposited - must be greater than 0.</param>
		public void Deposit (double amount)
		{
			if (amount <= 0.0) {
				throw new ArgumentException ("To withdraw money please use the appropriate function.");
			} else {
				this.Balance += amount;
			}
		}

		/// <summary>
		/// Amount to be transfered to another account.
		/// NOTE: This method is a fake to simulate "real" banking. The money will not be transfered to any account.
		/// </summary>
		/// <param name="amount">Amount to be transfered - must be greater than 0.</param>
		/// <param name="accountNumber">Account number to transfer the money to.</param>
		public void Transfer (int accountNumber, double amount)
		{
			if (amount >= 0.0) {
				if (this.Balance >= amount) {
					this.Balance -= amount;
					// TODO: In reality: fancy logic to transfer money.
				} else {
					throw new NotEnoughFundsException ("There are not enough funds present to fulfill the required action.");
				}
			} else {
				throw new ArgumentException ("It is not possible to transfer funds from another account to yours.");
			}
		}

		/// <summary>
		/// Validates a set of possible changes to a BankAccount.
		/// </summary>
		/// <param name="accountNumber">AccountNumber to be verified</param>
		/// <param name="surname">Surename to be verified</param>
		/// <returns>True if the values would be valid, false otherwise.</returns>
		static internal bool Validate (int accountNumber, String surname)
		{
			if (String.IsNullOrEmpty (surname)) {
				ErrorMessages.Add (new ErrorMessage ("Need the name of the account owner."));
			}
			if (accountNumber <= 0) {
				ErrorMessages.Add (new ErrorMessage ("Need a valid account number: greater 0."));
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

		internal void EditBankAccount (string surname, int accountNumber)
		{
			this.Surname = surname;
			this.AccountNumber = accountNumber;
		}

		/// <summary>
		/// Returns the current BankAccount object as a CSV-String.
		/// </summary>
		/// <returns>Representation of the current object as CSV-String.</returns>
		public string CsvRepresentation ()
		{
			return String.Format ("{0},{1},{2}", this.AccountNumber, this.Surname, this.Balance);
		}

		/// <summary>
		/// Attempts to create a BankAccount object from a string.
		/// </summary>
		/// <param name="stringRepresentation">The String to be parsed to bank account.</param>
		/// <returns>BankAccount object.</returns>
		public BankAccount ParseFromString (string stringRepresentation)
		{
			string[] split = stringRepresentation.Split (',');
            if (split.Length == 3)
            {
                String accountNumber = split[0];
                String surname = split[1];
                String balance = split[2];
                int accNumber = 0;
                double bal = 0;
                if (!String.IsNullOrEmpty(accountNumber))
                {
                    accNumber = int.Parse(accountNumber);
                }
                if (!String.IsNullOrEmpty(balance))
                {
                    bal = double.Parse(balance);
                }
                return new BankAccount(accNumber, surname, bal);
            }
            else
            {
                throw new WrongStringToParseException("Can not parse a bank account from the provided string.");
            }
		}
	}
}
