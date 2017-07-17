using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace UserAccountCreation
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : UserAccountCreationnew
    {
        public string createUserAcc(string fullName, string emailId, string password, string securityQues, string securityAns)
        {
            string output = null;
            string userId = "";
            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(emailId) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(securityQues) || string.IsNullOrEmpty(securityAns))
            {
                return "Input values Cant be null";
            }
            var path = System.IO.Path.GetDirectoryName(
            System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            path = path.Substring(6) + "\\Resources\\UserAccounts.xml";
            var document = XElement.Load(path);

            //Check if Email address already exists
            var elements = document.Elements("UserAccount").Select(i => new UserAccount
            {
                emailId = i.Element("emailId").Value,
            }).ToArray();

            foreach (var ele in elements)
            {
                //Decrypt the Email Id from the Database
                string outp = ele.emailId;
                try
                {
                    string decryptEmailId = decryptField(ele.emailId);
                    if (decryptEmailId.Equals(emailId))
                    {
                        output = "Email Address already exists in the Database";
                        return output;
                    }
                }
                catch (Exception e)
                {
                    output = "Encrypt Decrypt service is not running . Please start that service and run this again";
                    return output;
                }
            }

            //Creating a new user account if its a new Email address
            //Call getUserId API to create a new UserId
            userIdGenerate.UserIDClient client = new userIdGenerate.UserIDClient();
            try
            {
                userId = client.getUserId(fullName, emailId);
            }
            catch (Exception e)
            {
                Console.WriteLine("User ID generation Service is not running={0}", e);
            }

            try {
                //Encrypt the Fields before storing in the Database
                string encfullName = encryptField(fullName);
                string encemailId = encryptField(emailId);
                string encpassword = encryptField(password);
                string encsecurityQues = encryptField(securityQues);
                string encsecurityAns = encryptField(securityAns);


                XDocument doc = XDocument.Load(path);
                XElement root = doc.Element("Accounts");
                IEnumerable<XElement> rows = root.Descendants("UserAccount");
                XElement recentEntry = rows.First();
                recentEntry.AddAfterSelf(
                        new XElement("UserAccount",
                        new XElement("fullName", encfullName),
                        new XElement("emailId", encemailId),
                        new XElement("password", encpassword),
                        new XElement("securityQues", encsecurityQues),
                        new XElement("securityAns", encsecurityAns),
                        new XElement("userId", userId)));
                doc.Save(path);
                if (userId.Equals(""))
                    output = "Account Created Successfully. Generate UserId Service is not active";
                else
                    output = string.Format("Account Created Successfully. Generated Username is : {0}", userId);
                return output;
            }
           
         catch (Exception e)
            {
                output = "Encrypt Decrypt service is not running . Please start that service and run this again";
                return output;
            }

        }
        //If an user forgots password this service can be used to retrieve the UserID
        public string retrieveUserName(string fullName, string emailId)
        {
            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(emailId))
            {
                return "Input values Cant be null";
            }
            string output = "";
            var path = System.IO.Path.GetDirectoryName(
            System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            path = path.Substring(6) + "\\Resources\\UserAccounts.xml";
            var document = XElement.Load(path);

            //Check if Email address and Fullname are present in the database
            var elements = document.Elements("UserAccount").Select(j => new UserAccount
            {
                fullName = j.Element("fullName").Value,
                userId = j.Element("userId").Value,
                emailId = j.Element("emailId").Value
            }).ToArray();

            foreach (var ele in elements)
            {
                try { 
                string decrypEmailId = decryptField(ele.emailId);
                string decrypFullName = decryptField(ele.fullName);
                if (decrypEmailId.Equals(emailId) && decrypFullName.Equals(fullName))
                {
                    output = ele.userId;
                    return output;
                }
            }   catch (Exception e)
                {
                    output = "Encrypt Decrypt service is not running . Please start that service and run this again";
                    return output;
                }
            }

            //If not Send UserName not found
            return "UserName not found in the Database for this Email Address";
        }


        // Use Encrypt Decrypt service to encrypt the String before storing in the Database
        public string encryptField(string input)
        {
            encryptDecrypt.EncryptDecryptSrvcClient cli = new encryptDecrypt.EncryptDecryptSrvcClient();
            string output = cli.encrypt(input);
            return output;
        }

        public string decryptField(string input)
        {
            encryptDecrypt.EncryptDecryptSrvcClient cli = new encryptDecrypt.EncryptDecryptSrvcClient();
            string output = cli.decrypt(input);
            return output;
        }
    }
    public class UserAccount
    {
        public string fullName { get; set; }
        public string emailId { get; set; }
        public string password { get; set; }
        public string securityQues { get; set; }
        public string securityAns { get; set; }
        public string userId { get; set; }
    }

    public class Accounts
    {
        public List<UserAccount> UserAccounts { get; set; }
    }

}

