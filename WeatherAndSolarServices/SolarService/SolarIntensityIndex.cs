﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SolarService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface SolarIntensityIndex
    {

        [OperationContract]
        double getSolarIntensityIndex(string latitude, string longitude);

        // TODO: Add your service operations here
    }

}
