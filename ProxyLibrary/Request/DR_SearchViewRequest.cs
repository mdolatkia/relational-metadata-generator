using System;
using System.Collections.Generic;
namespace ProxyLibrary
{
    public class DR_SearchViewRequest
    {

        public DR_SearchViewRequest()
        {
            SearchPackages = new List<DP_DataRepository>();
        }

        public List<DP_DataRepository> SearchPackages;

        public int EntityID;

        //public List<DataMaster.EntityDefinition.ND_Type_Property> SearchProperties;


        public DataAccess.TableDrivedEntity ViewPackage;


        //public List<DataMaster.EntityDefinition.ND_Property> ResultOrder;


        //public int ResultCount;


        //public String ViewCategory;

    }

}
