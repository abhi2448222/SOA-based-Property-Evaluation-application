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
    protected void TestRequiredService1(object sender, EventArgs e)
    {
        Label34.Visible = false;
        Label35.Visible = false;
        Label37.Visible = false;

        string buildUrl = string.Format("http://localhost:55381/ZipCodeLatLngConverter.svc/zipcodeToLatLng?zipcode={0}", rs1str.Text);

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(buildUrl);
        WebResponse response = request.GetResponse();
        Stream responseStream = response.GetResponseStream();

        StreamReader reader = new StreamReader(responseStream);
        string output = (reader.ReadToEnd());
        if(output.Contains("Invalid Zipcode"))
        {
            Label37.Text = output;
            Label37.Visible = true;
            return;

        }
        string[] values = output.Split('|');
        Label37.Text = "Output Latitude and Longitude Values : ";
        Label34.Text = values.GetValue(0).ToString();
        Label35.Text = values.GetValue(1).ToString();
        Label34.Visible = true;
        Label35.Visible = true;
        Label37.Visible = true;
    }

}
