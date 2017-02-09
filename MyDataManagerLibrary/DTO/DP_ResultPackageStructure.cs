using System;
using System.Collections.Generic;
namespace MyDataManagerLibrary
{
    public class DP_ResultPackageStructure : DP_BasePackageResult
    {


        public DP_ResultPackageStructure()
        {
            Structure = new List<DP_PackageTreeStructure>();
        }


        public List<DP_PackageTreeStructure> Structure;

    }

}
