using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LatLngToZipConverter
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ZipCodeLatLngConverter
    {

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json,UriTemplate = "/zipcodeToLatLng?zipcode={zipcode}")]
        string zipcodeToLatLng(string zipcode);

    
     

        // TODO: Add your service operations here
    }
}
