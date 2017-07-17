using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace UserAccountCreation
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface UserAccountCreationnew
    {

        [OperationContract]       
         string createUserAcc(string fullName, string emailId, string password, string securityQues, string securityAns);

        [OperationContract]
        string retrieveUserName(string fullName, string emailId);

        // TODO: Add your service operations here
    }
}
