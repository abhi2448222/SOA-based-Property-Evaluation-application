using Newtonsoft.Json;
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

namespace LatLngToZipConverter
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : ZipCodeLatLngConverter
    {
        static string API_KEY = "L4vYdq5WXgi2R30PD2UbXkPzm7NsewB0B6YOx4Kuk3wb7x1KAVWygL7DTU57rH82";

        //This service calls zipcodeapi Api to fetch Latitude and Longitude from Zipcode  
        public string zipcodeToLatLng(string zipcode)
        {
            string outputLatLng = null;
            HttpWebResponse response = null;
            string buildUrl = string.Format("https://www.zipcodeapi.com/rest/{0}/info.json/{1}/degrees", API_KEY, zipcode);
            try
            { 
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(buildUrl);
            response = (HttpWebResponse)request.GetResponse();

            }
            //Invalid Zipcode
            catch (WebException e)
            {
                Console.WriteLine(e);
                outputLatLng = "Invalid Zipcode";
                return outputLatLng;

            }
            //Successful Response from API
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                string output = (reader.ReadToEnd());
                RootObject str = JsonConvert.DeserializeObject<RootObject>(output);
                string lat = str.lat.ToString();
                string lng = str.lng.ToString();
                // Send Latitude and Longitude in a Pipe separated String
                outputLatLng = lat+"|"+lng;
            }
            else
            {
                outputLatLng = "Invalid Zipcode";
            }

            return outputLatLng;
        }
        public class Timezone
        {
            public string timezone_identifier { get; set; }
            public string timezone_abbr { get; set; }
            public int utc_offset_sec { get; set; }
            public string is_dst { get; set; }
        }

        [Serializable]
        public class RootObject
        {
            public string zip_code { get; set; }
            public double lat { get; set; }
            public double lng { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public Timezone timezone { get; set; }
            public List<object> acceptable_city_names { get; set; }
        }
    }
}
