using MyDataManagerBusiness;
using MyDataManagerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataManagerService
{
    public class RelationshipManagerService
    {

        BizRelationshipManager bizRelationshipManager { set; get; }
        public RelationshipManagerService()
        {
            bizRelationshipManager = new BizRelationshipManager();
        }

        public bool ReverseRelationshipIsMandatory(int relationshipID)
        {
            return bizRelationshipManager.ReverseRelationshipIsMandatory(relationshipID);
        }

    }
}
