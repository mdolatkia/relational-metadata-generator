using System;
using System.Collections.Generic;
namespace MyDataManagerLibrary
{
	public class DP_ResultPackage : DP_BasePackageResult 
 {


		public  DP_ResultPackage()
		{
            Packages = new List<DataAccess.TableDrivedEntity>();
             //////PackageRelations = new List<DataManager.DataPackage.DPPackageRelation>();
		}


        public List<DataAccess.TableDrivedEntity> Packages;


        //////public List<DataManager.DataPackage.DPPackageRelation> PackageRelations;

	}

}
