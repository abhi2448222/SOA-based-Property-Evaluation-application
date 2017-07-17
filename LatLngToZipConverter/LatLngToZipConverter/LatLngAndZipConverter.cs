using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LatLngAndZipConverter
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface LatLngAndZipConverter
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "/latLngtoZipCode?lat={lat}&lng={lng}")]
        string latLngtoZipCode(string lat, string lng);

        // TODO: Add your service operations here
    }

}
