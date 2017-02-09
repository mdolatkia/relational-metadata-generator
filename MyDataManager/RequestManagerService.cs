using MyDataManagerBusiness;
using ProxyLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataManager
{
    public class RequestRegistrationService 
    {

        public DR_ResultRequest RecieveRequest(DR_Request request)
        {
            var processManager = new RequestProcessManager();
            return processManager.ProcessRequest(request);




            //  return result;
        }


    }
}
