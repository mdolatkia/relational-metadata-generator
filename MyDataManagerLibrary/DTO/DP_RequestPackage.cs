using System;
using System.Collections.Generic;
namespace MyDataManagerLibrary
{
	public class DP_RequestEntity : DP_BasePackageRequest 
 {


		public  DP_RequestEntity()
		{
            PackageIDs = new List<int>();
             //////Categories = new List<DataManager.DataPackage.DP_PackageCategory>();
		}


		public List<int> PackageIDs;


        //////public List<DataManager.DataPackage.DP_PackageCategory> Categories;

	}

}
