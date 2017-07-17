<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    </asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        cse 445 - AssignMent 3 - Abhishek Rao (1210425135)</h2>
    <div id="rs1" style="border: 1px dashed grey; padding-left: 20px; padding-bottom: 20px; margin-top: 10px;">
        <p><strong>Elective Service </strong>: <strong>ZipCode to Latitude and Longitude Converter</strong></p>
        <p>URL : http://localhost:55381/ZipCodeLatLngConverter.svc</p>
        <p>Method Signature : string zipcodeToLatLng(string zipcode);</p> 
        <p><span style="font-size:11.0pt;line-height:115%;
font-family:&quot;Calibri&quot;,sans-serif;mso-ascii-theme-font:minor-latin;mso-fareast-font-family:
SimSun;mso-fareast-theme-font:minor-fareast;mso-hansi-theme-font:minor-latin;
mso-bidi-font-family:&quot;Times New Roman&quot;;mso-bidi-theme-font:minor-bidi;
mso-ansi-language:EN-US;mso-fareast-language:ZH-CN;mso-bidi-language:AR-SA">Description : Fetch Latitude and Longitude values from Zipcode (Based on API from https://www.zipcodeapi.com/)</span></p>
        <p>
            <label>Enter Zipcode &nbsp</label>
            <asp:TextBox ID="rs1str" Width="134px" runat="server" />
            <asp:Button ID="Button1" Text="submit" OnClick="TestRequiredService1" runat="server" Width="77px" />
        </p>

            <asp:Label ID="Label37" runat="server" Font-Bold="True" Font-Size="Large" Visible="False"></asp:Label>

        &nbsp;<asp:Label ID="Label34" runat="server" Font-Bold="True" Font-Size="Large" Visible="False"></asp:Label>
&nbsp;<asp:Label ID="Label35" runat="server" Font-Bold="True" Font-Size="Large" Visible="False"></asp:Label>

        <br />
        
    </div>

    
</asp:Content>
