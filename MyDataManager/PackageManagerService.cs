using MyDataManagerBusiness;
using MyDataManagerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataManagerService
{
    public class PackageManagerService 
    {

        BizPackageManager bizPackageManager { set; get; }
        public PackageManagerService()
        {
            bizPackageManager = new BizPackageManager();
        }

        public DP_ResultPackage GetListPackage(DP_RequestEntity request)
        {

            return bizPackageManager.GetListPackage(request);
        }

        public DP_ResultPackageStructure GetPackageTreeStructe(DP_BasePackageRequest request)
        {
            return bizPackageManager.GetPackageTreeStructe(request);
        }

        //public DP_ResultPackage FindPackages(DP_RequestEntity request)
        //{
        //    throw new NotImplementedException();
        //}


        //public DP_ResultRelatedPackage GetRelatedPackage(DP_RequestRelatedPackage request)
        //{
        //    return bizPackageManager.GetRelatedPackage(request);
        //}

        public DP_ResultDatabaseList GetDatabaseList(DP_BasePackageRequest request)
        {
            return bizPackageManager.GetDatabaseList(request);
        }
    }
}
