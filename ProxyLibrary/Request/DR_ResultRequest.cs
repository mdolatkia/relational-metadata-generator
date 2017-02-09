using System;
using System.Collections.Generic;
namespace ProxyLibrary
{
	public class DR_ResultRequest {


		public  DR_ResultRequest()
        {
            EditResult = new DR_ResultEdit();
		}


		public string Identity;


		public string RequestIdentity;


		public string Message;


		public Enum_DR_ResultType Result;


		public int PartNumber;


		public DR_ResultEdit EditResult;


		public DR_ResultSearchView SearchViewResult;

	}

}
