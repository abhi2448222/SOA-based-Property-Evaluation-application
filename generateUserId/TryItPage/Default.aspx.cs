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
        Label37.Visible = false;
        ServiceReference1.UserIDClient client = new ServiceReference1.UserIDClient();
        string output=client.getUserId(rs1str.Text, rs1str0.Text);
        if (output.Equals(""))
        {
            Label37.Text = "Name or Email Id cannot be empty";
        }
        else
        {
            Label37.Text ="UserName Generated : "+ output;
        }
        Label37.Visible = true;
    }

}
