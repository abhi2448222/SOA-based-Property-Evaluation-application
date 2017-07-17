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
        ServiceReference1.UserAccountCreationnewClient client = new ServiceReference1.UserAccountCreationnewClient();
        string output=client.createUserAcc(rs1str.Text, rs1str0.Text, rs1str1.Text, DropDownList1.Text, rs1str2.Text);
        if (output.Equals("Input values Cant be null"))
        {
            Label37.Text = "Input fields cannot be empty or Null";
        }
        else if(output.Equals("Email Address already exists in the Database"))
        {
            Label37.Text = "Email Address already exists in the Database. The User account has already been registered";
        }
        else
        {
            Label37.Text = output;
        }
        Label37.Visible = true;
    }


    protected void TestRequiredService2(object sender, EventArgs e)
    {
        Label38.Visible = false;
        ServiceReference1.UserAccountCreationnewClient client = new ServiceReference1.UserAccountCreationnewClient();
        string output = client.retrieveUserName(rs1str3.Text, rs1str4.Text);
        if(output.Equals("Input values Cant be null"))
        {
            Label38.Text = "Input fields cannot be empty or Null";
        }
        else if(output.Equals("UserName not found in the Database for this Email Address"))
        {
            Label38.Text = "Email Address doesnt exist in the Database. Please make sure that the User account has already been registered";
        }
        else
        {
            Label38.Text = "User Id fetched from the database : " + output;
        }
        Label38.Visible = true;
    }
}
