using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
 
    protected void TestRequiredService2(object sender, EventArgs e)
    {
        Label33.Visible = false;
        Label36.Visible = false;
        string buildUrl = string.Format("http://localhost:65386/LatLngAndZipConverter.svc/latLngtoZipCode?lat={0}&lng={1}", rs1str5.Text, rs1str6.Text);

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(buildUrl);
        WebResponse response = request.GetResponse();
        Stream responseStream = response.GetResponseStream();

        StreamReader reader = new StreamReader(responseStream);
        string output = (reader.ReadToEnd());
        if(output.Contains("Invalid") || output.Contains("No ZIPCODE found within 20 miles"))
        {
            Label33.Text = output;
            Label33.Visible = true;
            return;
        }
        Label33.Text = "Output Zipcode : ";
        Label36.Text = output;
        Label33.Visible = true;
        Label36.Visible = true;

    }
}
