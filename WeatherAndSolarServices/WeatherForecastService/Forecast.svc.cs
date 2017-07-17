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

namespace WeatherForecastService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : Forecast
    {
        static string API_KEY = "b9de604610f84878b0290758172503";
        public WeatherForecastObj GetWeatherData(string value)
        {
            //Get the Response from the API for 7 day Weather Forecast 
            HttpWebResponse response = null;
            string buildUrl = string.Format("http://api.apixu.com/v1/forecast.json?key={0}&q={1}&days=7", API_KEY, value);
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(buildUrl);
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException e)
            {
                Console.WriteLine(e);
                WeatherForecastObj weatherForeCastError = new WeatherForecastObj();
                weatherForeCastError.name = "No matching location found for this Zipcode";
                return weatherForeCastError;
            }
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                string output = (reader.ReadToEnd());

                //Error in response. No matching location found in the API
                if (output.Contains("error"))
                {
                    WeatherForecastObj weatherForeCastError = new WeatherForecastObj();
                    weatherForeCastError.name = "No matching location found for this Zipcode";
                    return weatherForeCastError;
                }

                //Using NewtonSoft to deserialize the data into JSON
                RootObject str = JsonConvert.DeserializeObject<RootObject>(output);

                WeatherForecastObj weatherForeCast = new WeatherForecastObj();
                weatherForeCast.name = str.location.name;
                weatherForeCast.region = str.location.region;
                weatherForeCast.country = str.location.country;
                weatherForeCast.current_temp_f = str.current.temp_f;
                weatherForeCast.current_humidity = str.current.humidity;

                List<Date> dateObjs = new List<Date>();
                foreach (Forecastday fd in str.forecast.forecastday)
                {
                    Date dateObj = new Date();
                    dateObj.date = fd.date;
                    dateObj.avgtemp_f = fd.day.avgtemp_f;
                    dateObj.avghumidity = fd.day.avghumidity;
                    dateObjs.Add(dateObj);
                }
                weatherForeCast.dates = dateObjs;
                return weatherForeCast;
            }
            else
            {
                WeatherForecastObj weatherForeCastError = new WeatherForecastObj();
                weatherForeCastError.name = "No matching location found for this Zipcode";
                return weatherForeCastError;
            }

        }
        public class Location
        {
            public string name { get; set; }
            public string region { get; set; }
            public string country { get; set; }
            public double lat { get; set; }
            public double lon { get; set; }
            public string tz_id { get; set; }
            public int localtime_epoch { get; set; }
            public string localtime { get; set; }
        }

        public class Condition
        {
            public string text { get; set; }
            public string icon { get; set; }
            public int code { get; set; }
        }

        public class Current
        {
            public int last_updated_epoch { get; set; }
            public string last_updated { get; set; }
            public double temp_c { get; set; }
            public double temp_f { get; set; }
            public int is_day { get; set; }
            public Condition condition { get; set; }
            public double wind_mph { get; set; }
            public double wind_kph { get; set; }
            public int wind_degree { get; set; }
            public string wind_dir { get; set; }
            public double pressure_mb { get; set; }
            public double pressure_in { get; set; }
            public double precip_mm { get; set; }
            public double precip_in { get; set; }
            public int humidity { get; set; }
            public int cloud { get; set; }
            public double feelslike_c { get; set; }
            public double feelslike_f { get; set; }
            public double vis_km { get; set; }
            public double vis_miles { get; set; }
        }

        public class Condition2
        {
            public string text { get; set; }
            public string icon { get; set; }
            public int code { get; set; }
        }

        public class Day
        {
            public double maxtemp_c { get; set; }
            public double maxtemp_f { get; set; }
            public double mintemp_c { get; set; }
            public double mintemp_f { get; set; }
            public double avgtemp_c { get; set; }
            public double avgtemp_f { get; set; }
            public double maxwind_mph { get; set; }
            public double maxwind_kph { get; set; }
            public double totalprecip_mm { get; set; }
            public double totalprecip_in { get; set; }
            public double avgvis_km { get; set; }
            public double avgvis_miles { get; set; }
            public double avghumidity { get; set; }
            public Condition2 condition { get; set; }
        }

        public class Astro
        {
            public string sunrise { get; set; }
            public string sunset { get; set; }
            public string moonrise { get; set; }
            public string moonset { get; set; }
        }

        public class Condition3
        {
            public string text { get; set; }
            public string icon { get; set; }
            public int code { get; set; }
        }

        public class Hour
        {
            public int time_epoch { get; set; }
            public string time { get; set; }
            public double temp_c { get; set; }
            public double temp_f { get; set; }
            public int is_day { get; set; }
            public Condition3 condition { get; set; }
            public double wind_mph { get; set; }
            public double wind_kph { get; set; }
            public int wind_degree { get; set; }
            public string wind_dir { get; set; }
            public double pressure_mb { get; set; }
            public double pressure_in { get; set; }
            public double precip_mm { get; set; }
            public double precip_in { get; set; }
            public int humidity { get; set; }
            public int cloud { get; set; }
            public double feelslike_c { get; set; }
            public double feelslike_f { get; set; }
            public double windchill_c { get; set; }
            public double windchill_f { get; set; }
            public double heatindex_c { get; set; }
            public double heatindex_f { get; set; }
            public double dewpoint_c { get; set; }
            public double dewpoint_f { get; set; }
            public int will_it_rain { get; set; }
            public int will_it_snow { get; set; }
            public double vis_km { get; set; }
            public double vis_miles { get; set; }
        }

        public class Forecastday
        {
            public string date { get; set; }
            public int date_epoch { get; set; }
            public Day day { get; set; }
            public Astro astro { get; set; }
            public List<Hour> hour { get; set; }
        }

        public class Forecast
        {
            public List<Forecastday> forecastday { get; set; }
        }
        [Serializable]
        public class RootObject
        {
            public Location location { get; set; }
            public Current current { get; set; }
            public Forecast forecast { get; set; }
        }

    }


}
