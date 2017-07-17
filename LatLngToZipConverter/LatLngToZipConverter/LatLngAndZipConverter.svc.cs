using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;

namespace LatLngAndZipConverter
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : LatLngAndZipConverter
    {
        static string USER_NAME = "propeval";

        //This service calls geonames Api to fetch Zipcode from Latitude and Longitude
        public string latLngtoZipCode(string lat, string lng)
        {
            string latit = null;
            string longit = null;
            string zipcode = null;
            try
            {
                latit = Double.Parse(lat).ToString();
                longit = Double.Parse(lng).ToString();
                Console.WriteLine("Latitude ={0}", latit);
                Console.WriteLine("Longit ={0}", longit);
            }
            catch (FormatException e)
            {
                // Invalid inputs 
                Console.WriteLine(e);
                zipcode = "Invalid Inputs";
                return zipcode;
            }
            HttpWebResponse response = null;
            string buildUrl = string.Format("http://api.geonames.org/findNearbyPostalCodes?lat={0}&lng={1}&username={2} ", latit, longit, USER_NAME);
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(buildUrl);
                response = (HttpWebResponse)request.GetResponse();

            }
            catch (WebException e)
            {
                Console.WriteLine(e);
                zipcode = "Invalid Latitude Longitude";
                return zipcode;

            }
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            string output = (reader.ReadToEnd());
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(output);
            XmlNodeList statusList = doc.GetElementsByTagName("status");
            if (statusList.Count == 0)
            {
                XmlNodeList elemList = doc.GetElementsByTagName("postalcode");
                //No Zipcode found within 20 miles of the Latitude and Longitude values
                if (elemList.Count == 0)
                {
                    zipcode = "No ZIPCODE found within 20 miles";

                }
                else
                {
                    zipcode = elemList[0].InnerText;
                }

            }
            else
            {

                //zipcode = statusList[0].Attributes["message"].Value;
                zipcode = "Invalid Latitude Longitude";

            }

            return zipcode;
        }

    }
}
