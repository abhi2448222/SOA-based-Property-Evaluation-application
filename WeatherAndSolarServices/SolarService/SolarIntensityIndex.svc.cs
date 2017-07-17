using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SolarService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : SolarIntensityIndex
    {
        public double getSolarIntensityIndex(string latitude, string longitude)
        {
            string latit = "";
            string longit = "";
            try
            {
                latit = ((int)Math.Ceiling(Double.Parse(latitude))).ToString();
                longit = ((int)Math.Ceiling(Double.Parse(longitude))).ToString();
            }
            catch (FormatException e)
            {
                // send -1 as the output for error Inputs
                Console.WriteLine(e);
                return -1;
            }
            int noOfMonths = 0;
            double solarIntIndex = 0;
            var path = System.IO.Path.GetDirectoryName(
             System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);

            path = path.Substring(6) + "\\Resources\\SolarSunshineIndex.txt";

            //Read all the values from the File and find the matching Latitude and Longitude to calculate the average 
            string[] lines = File.ReadAllLines(path);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] output = lines[i].Split(' ');
                if ((output[0].Equals(latit)) && (output[1].Equals(longit)))
                {
                    for (int j = 2; j < output.Length; j++)
                    {
                        if (!output[j].Equals("na"))
                        {
                            solarIntIndex += Double.Parse(output[j]);
                            noOfMonths++;
                        }
                    }
                }
            }
            //calculate the average and send -1 as the output for error values
            if (solarIntIndex != 0)
                return (solarIntIndex / noOfMonths);
            else
                return -1;

        }
    }
}
