/*
 * Created by SharpDevelop.
 * User: Florian Bergmann
 * Date: 15.10.2010
 * Time: 13:47
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
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
