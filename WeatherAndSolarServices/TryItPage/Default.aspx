<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    </asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        cse 445 - AssignMent 3 - Abhishek Rao (1210425135)</h2>
    <div id="rs1" style="border: 1px dashed grey; padding-left: 20px; padding-bottom: 20px; margin-top: 10px;">
        <p><strong>Required Service 1</strong>: <strong>Weather Service</strong></p>
        <p>URL : <a href="http://localhost:12494/Forecast.svc">http://localhost:12494/Forecast.svc</a></p>
        <p>Method Signature : string[] GetWeatherData (string zipcode)</p> 
        <p><span style="font-size:11.0pt;line-height:115%;
font-family:&quot;Calibri&quot;,sans-serif;mso-ascii-theme-font:minor-latin;mso-fareast-font-family:
SimSun;mso-fareast-theme-font:minor-fareast;mso-hansi-theme-font:minor-latin;
mso-bidi-font-family:&quot;Times New Roman&quot;;mso-bidi-theme-font:minor-bidi;
mso-ansi-language:EN-US;mso-fareast-language:ZH-CN;mso-bidi-language:AR-SA">Description : Get&nbsp; 7-day weather forecast service of zipcode location based on the national weather service (https://www.apixu.com/)</span></p>
        <p>
            <label>Enter Zipcode &nbsp</label>
            <asp:TextBox ID="rs1str" Width="134px" runat="server" />
            <asp:Button ID="Button1" Text="submit" OnClick="TestRequiredService1" runat="server" Width="77px" />
        </p>
        <div RunAt="server" id ="opRes" style="display:none">
        <p>
            Weather Forecast Output :<label>&nbsp</label>
            <asp:Label ID="Label22" runat="server" Font-Bold="True" Font-Size="Large" Visible="False"></asp:Label>
            </p>
        <p>
            <asp:Label ID="Label23" runat="server" Text="City Name :" Visible="False"></asp:Label>
&nbsp; <asp:TextBox ID="rs1str0" Width="134px" runat="server" ReadOnly="True" Visible="False" />
            &nbsp;
            <asp:Label ID="Label24" runat="server" Text="Region : " Visible="False"></asp:Label>
&nbsp;
            <asp:TextBox ID="rs1str1" Width="134px" runat="server" ReadOnly="True" Visible="False" />
            &nbsp;<asp:Label ID="Label25" runat="server" Text="Country : " Visible="False"></asp:Label>
&nbsp;&nbsp;
            <asp:TextBox ID="rs1str2" Width="134px" runat="server" ReadOnly="True" Visible="False" />
        </p>
        <p>
            <asp:Label ID="Label30" runat="server" Text="Current Temperature (°F) : " Visible="False"></asp:Label>
&nbsp;
            <asp:TextBox ID="rs1str3" Width="134px" runat="server" ReadOnly="True" Visible="False" />
            &nbsp;<asp:Label ID="Label31" runat="server" Text="Current Humidity  :" Visible="False"></asp:Label>
&nbsp;<asp:TextBox ID="rs1str4" Width="134px" runat="server" ReadOnly="True" Visible="False" />

        </p>
        <p>
            <asp:Label ID="Label26" runat="server" Text="Upcoming Weather Forecast :" Font-Bold="True" Visible="False"></asp:Label>
        </p>
        <p>
            <asp:Label ID="Label27" runat="server" Text="Upcoming days" Font-Bold="True" Visible="False"></asp:Label>
            &nbsp;&nbsp;&nbsp; 
            <asp:Label ID="Label28" runat="server" Text="Average Temperature (°F)&nbsp;" Font-Bold="True" Visible="False"></asp:Label>
            &nbsp;&nbsp;<strong>
            <asp:Label ID="Label29" runat="server" Text=" Average Humidity" Font-Bold="True" Visible="False"></asp:Label>
            </strong>

        </p>
        <p>
            <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server" Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label3" runat="server" Visible="False"></asp:Label><br />
            <asp:Label ID="Label4" runat="server" Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label5" runat="server" Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label6" runat="server" Visible="False"></asp:Label><br />
            <asp:Label ID="Label7" runat="server" Visible="False"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label8" runat="server" Visible="False"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label9" runat="server" Visible="False"></asp:Label><br />
            <asp:Label ID="Label10" runat="server" Visible="False"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label11" runat="server" Visible="False"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label12" runat="server" Visible="False"></asp:Label><br />
            <asp:Label ID="Label13" runat="server" Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label14" runat="server" Visible="False"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label15" runat="server" Visible="False"></asp:Label><br />
            <asp:Label ID="Label16" runat="server" Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label17" runat="server" Visible="False"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            <asp:Label ID="Label18" runat="server" Visible="False"></asp:Label><br />
            <asp:Label ID="Label19" runat="server" Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label20" runat="server" Visible="False"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label21" runat="server" Visible="False"></asp:Label><br />

        </p>
        <p>
            &nbsp;</p>
        
            </div>
        <br /><hr />
        <p>    <strong>Required Service 2 </strong>: <strong>Solar Energy Service</strong></p>
        <p>
            URL: <a href="http://localhost:12097/SolarIntensityIndex.svc">http://localhost:12097/SolarIntensityIndex.svc</a></p>
        <p>
            Method Signature : double getSolarIntensityIndex(string latitude, string longitude);</p>
        <p>
            <span style="font-size:11.0pt;line-height:115%;
font-family:&quot;Calibri&quot;,sans-serif;mso-ascii-theme-font:minor-latin;mso-fareast-font-family:
SimSun;mso-fareast-theme-font:minor-fareast;mso-hansi-theme-font:minor-latin;
mso-bidi-font-family:&quot;Times New Roman&quot;;mso-bidi-theme-font:minor-bidi;
mso-ansi-language:EN-US;mso-fareast-language:ZH-CN;mso-bidi-language:AR-SA">Description : Get&nbsp;an annual average solar Intensity at a location according to NASA Surface meteorology and Solar Energy: Global Data Sets(https://eosweb.larc.nasa.gov/cgi-bin/sse/global.cgi/)</span></p>
        <p>
            Enter a Valid Latitude :&nbsp;
            <asp:TextBox ID="rs1str5" Width="134px" runat="server" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Enter a Valid Longitude :
            <asp:TextBox ID="rs1str6" Width="134px" runat="server" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" Text="submit" OnClick="TestRequiredService2" runat="server" Width="77px" />

        </p>
        <p>
            <asp:Label ID="Label33" runat="server" Font-Bold="True" Font-Size="Large" Visible="False"></asp:Label>
&nbsp;
            <asp:Label ID="Label32" runat="server" Font-Bold="True" Font-Size="Large" Visible="False"></asp:Label>

        </p>
        
    </div>

    
</asp:Content>
