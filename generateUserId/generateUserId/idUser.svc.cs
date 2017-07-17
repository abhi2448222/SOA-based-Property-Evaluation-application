using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace generateUserId
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : UserID
    {
        //This Service generates UserId using Random number generator . This service is used by Account cretaion serivice to create a new UserID
        public string getUserId(string fullName, string emailId)
        {
            string userId = "";
            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(emailId))
                return userId;
            Random r = new Random();
            int lenOffullName = fullName.Length;
            int lenOfemailId = emailId.Length;

            if (lenOffullName > 1 && lenOfemailId > 1)
            {
                userId += fullName.Substring(0, 2) + emailId.Substring(0, 2); ;
                int num = r.Next(10, 99);
                userId += num;
            }
            else
            {
                userId += fullName.Substring(0, 1) + emailId.Substring(0, 1);
                int num = r.Next(101, 999);
                userId += num;
            }
            return userId;
        }
    }
}
