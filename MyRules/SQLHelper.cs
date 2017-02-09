
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRules
{
    public class SQLHelper
    {
        internal static string GetConnectionString(string catalogName)
        {
            using (var context = new MyProjectEntities())
            {
                return context.DatabaseInformation.First(x => x.Name == catalogName).ConnectionString;
            }

        }
    }
}
