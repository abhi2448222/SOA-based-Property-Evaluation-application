using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WeatherForecastService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface Forecast
    {

        [OperationContract]
        WeatherForecastObj GetWeatherData(string value);

    }
    [DataContract]
    public class WeatherForecastObj
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string region { get; set; }
        [DataMember]
        public string country { get; set; }
        [DataMember]
        public double current_temp_f { get; set; }
        [DataMember]
        public int current_humidity { get; set; }
        [DataMember]
        public List<Date> dates { get; set; }
    }
    public class Date
    {
        public string date { get; set; }
        public double avgtemp_f { get; set; }
        public double avghumidity { get; set; }
    }


}
