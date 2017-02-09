using System;
using System.Collections.Generic;
namespace ProxyLibrary
{
	public class DR_Request {


		public  DR_Request()
		{
			 RequestExecutionTime = new List<DR_RequestExecutionTime>();
		}


		public Guid Identity;


		public string Name;


		public Enum_DR_RequestType Type;


		public DR_Requester Requester;


		public List<DR_RequestExecutionTime> RequestExecutionTime;


		public DR_SearchViewRequest SearchViewRequest;


		public DR_EditRequest EditRequest;

	}

}
