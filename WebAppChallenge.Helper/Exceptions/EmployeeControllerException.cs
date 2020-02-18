using System;
using System.Collections.Generic;
using System.Text;

namespace WebAppChallenge.Helper.Exceptions
{
	[Serializable]
	public class EmployeeControllerException: Exception
	{
		//
		// For guidelines regarding the creation of new exception types, see
		//    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
		// and
		//    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
		//

		public EmployeeControllerException()
		{
		}

		public EmployeeControllerException(string message) : base(message)
		{
		}

		public EmployeeControllerException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
