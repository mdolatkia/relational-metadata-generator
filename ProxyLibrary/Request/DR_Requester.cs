using System;
using System.Collections.Generic;
namespace ProxyLibrary
{
	public class DR_Requester {


		public  DR_Requester()
		{
			 Successors = new List<DR_Requester>();
		}


		public Guid Identity;


		public string Name;


		public Enum_DR_RequesterType Type;


		public List<DR_Requester> Successors;

	}

}
