using System;
using System.Collections.Generic;
namespace ProxyLibrary
{
    public class DR_ResultEdit
    {


        public DR_ResultEdit()
        {
            DR_ResultEditTuples = new List<DR_ResultEditTuple>();
            //EditPackages = new List<DataManager.DataPackage.DP_Package>();
            //AddPackages = new List<DataManager.DataPackage.DP_Package>();
            //DeletePackages = new List<DataManager.DataPackage.DP_Package>();
        }


        //public List<DataManager.DataPackage.DP_Package> EditPackages;
        public List<DR_ResultEditTuple> DR_ResultEditTuples;

        //public List<DataManager.DataPackage.DP_Package> AddPackages;


        //public List<DataManager.DataPackage.DP_Package> DeletePackages;

    }
    public class DR_ResultEditTuple
    {
        public DR_ResultEditTuple(Guid guid, EntityInstanceProperty columnValue)
        {
            GUID = guid;
            ColumnValue = columnValue;
        }
        public Guid GUID { set; get; }
        public EntityInstanceProperty ColumnValue { set; get; }
    }
}
