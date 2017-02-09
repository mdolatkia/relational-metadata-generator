using System;
using System.Collections.Generic;
namespace MyDataManagerLibrary
{
    public class DP_ResultDatabaseList : DP_BasePackageResult
    {


        public DP_ResultDatabaseList()
        {
            Databases = new List<DP_DatabaseListItem>();
        }


        public List<DP_DatabaseListItem> Databases;

    }

}
