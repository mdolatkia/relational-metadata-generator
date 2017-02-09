using System;
using System.Collections.Generic;
namespace ProxyLibrary
{
	public class DR_ResultSearchView {


		public  DR_ResultSearchView()
		{
            DPPackages = new List<DP_DataRepository>();
		}


        public List<DP_DataRepository> DPPackages;


		public int ResultCount;

	}

}
