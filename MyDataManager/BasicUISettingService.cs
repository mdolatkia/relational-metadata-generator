using CommonDefinitions.BasicUISettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataManager
{
    public class BasicUISettingService 
    {

        public PackageAreaUISetting GetPackageAreaSetting()
        {
            PackageAreaUISetting result = new PackageAreaUISetting();
            result.DefaultHeigh = 600;
            result.DefaultWidth = 800;

            result.DefaultColumnCount = 3;
            result.MinimumColumnWidth = 160;
            result.MinimumRowHeight = 35;
            return result;
        }
    }
}
