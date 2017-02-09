using System;
using System.Collections.Generic;
namespace MyDataManagerLibrary
{
	public class DP_PackageTreeStructure {


		public  DP_PackageTreeStructure()
		{
			 SubPackages = new List<DP_PackageTreeStructure>();
		}


		public Guid ID;


        public DataAccess.TableDrivedEntity Package;


		public List<DP_PackageTreeStructure> SubPackages;


		public string Name;

	}

}
