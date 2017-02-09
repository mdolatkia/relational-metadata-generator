using System;
using System.Collections.Generic;
namespace ProxyLibrary
{
    public class DP_DataRepository
    {


        public DP_DataRepository()
        {
            //SourceRelatedData = new List<DP_DataRepository>();
            DataInstance = new EntityInstance();
            DataInstance.Properties = new List<EntityInstanceProperty>();
            SourceColumnIDs = new List<int>();
            TargetColumnIDs = new List<int>();
            RemovedItems = new List<DP_DataRepository>();
            //    DataTypes = new List<DP_DataRepository>();

        }

        public int SourceEntityID;
        public int TargetEntityID;
        public int SourceTableID;
        public int TargetTableID;
        public DP_DataRepository SourceRelatedData;
        public int SourceRelationID;
        public List<int> SourceColumnIDs;
        public List<int> TargetColumnIDs;
        public Enum_RelationshipType SourceToTargetRelationshipType;
        public Guid GUID;
        public bool IsNewItem;
        public EntityInstance DataInstance;

        public bool ExcludeFromDataEntry { set; get; }
        public bool ValueChanged { set; get; }
        //public bool RemoveData { set; get; }

        public List<DP_DataRepository> RemovedItems { set; get; }

        public string Info
        {
            get
            {
                string info = "";
                foreach(var item in DataInstance.Properties)
                {
                    info += (info == "" ? "" : Environment.NewLine) + item.Name + " : " + item.Value;
                }
                return info;
            }
        }
    }
    public class EntityInstance
    {


        public EntityInstance()
        {
            Properties = new List<EntityInstanceProperty>();

        }


        public int ID;


        //public string Name;


        //public string Title;


        //public string Description;




        public List<EntityInstanceProperty> Properties;




    }

    public class EntityInstanceProperty
    {
        public EntityInstanceProperty()
        {
        }

        public EntityInstanceProperty(int columnID, string value)
        {
            ColumnID = columnID;
            Value = value;
        }

        public int ColumnID;
        //public Guid ID;


        //public Guid NDTypeID;

        //public string NDTypeName;

        //public ND_Property Property;


        //public bool IsKey;


        //public string Title;


        //public string Description;

        public string Name;
        public string Value;
        public bool IsKey { set; get; }



    }

}
