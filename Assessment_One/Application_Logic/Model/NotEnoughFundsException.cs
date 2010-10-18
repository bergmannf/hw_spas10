using System;

namespace ApplicationLogic.Model
{
	/// <summary>
	/// Description of NotEnoughFundsException.
	/// </summary>
	public class NotEnoughFundsException: Exception
	{
		public NotEnoughFundsException(String message): base(message)
		{
		}
	}
}
