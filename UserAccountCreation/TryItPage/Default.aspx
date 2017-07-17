<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    </asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        cse 445 - AssignMent 3 - Abhishek Rao (1210425135)</h2>
    <div id="rs1" style="border: 1px dashed grey; padding-left: 20px; padding-bottom: 20px; margin-top: 10px;">
        <p><strong>Elective Service </strong>: <strong>Creation of User Account in the Database </strong></p>
        <p>URL : http://localhost:33932/UserAccountCreationService.svc</p>
        <p><strong>Method 1 : Create an account in the Database and generate a new UserID</strong></p>
        <p>Method Signature : string createUserAcc(string fullName, string emailId, string password, string securityQues, string securityAns);</p> 
        <p><span style="font-size:11.0pt;line-height:115%;
font-family:&quot;Calibri&quot;,sans-serif;mso-ascii-theme-font:minor-latin;mso-fareast-font-family:
SimSun;mso-fareast-theme-font:minor-fareast;mso-hansi-theme-font:minor-latin;
mso-bidi-font-family:&quot;Times New Roman&quot;;mso-bidi-theme-font:minor-bidi;
mso-ansi-language:EN-US;mso-fareast-language:ZH-CN;mso-bidi-language:AR-SA">Description : This service creates a new User Account in the Database and use GenerateUserId service to generate a new UserID. The Account details are stored in a XML file. If the account already exists , Error message &quot;User account already exists &quot; is displayed to the User.</span></p>
        <p>
            <label>Enter Fullname &nbsp</label>
            <asp:TextBox ID="rs1str" Width="180px" runat="server" style="margin-left: 33px" />
            &nbsp;</p>
        <p>
            Enter Email Address
            <asp:TextBox ID="rs1str0" Width="175px" runat="server" style="margin-left: 8px" />
        </p>
        <p>
            Enter Password&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="rs1str1" Width="175px" runat="server" style="margin-left: 8px" />
        </p>
        <p>
            Select a Security Question<asp:DropDownList ID="DropDownList1" runat="server" Height="16px" style="margin-left: 24px" Width="288px">
                <asp:ListItem Selected="True">What is your Mother&#39;s maiden name?</asp:ListItem>
                <asp:ListItem>What is the name of your pet?</asp:ListItem>
                <asp:ListItem>Who was your favourite teacher at school?</asp:ListItem>
                <asp:ListItem>Which was your birthplace?</asp:ListItem>
            </asp:DropDownList>
        </p>
        <p>
            Answer to the Security Question
            <asp:TextBox ID="rs1str2" Width="175px" runat="server" style="margin-left: 8px" />
        </p>
        <p>
            <asp:Button ID="Button1" Text="submit" OnClick="TestRequiredService1" runat="server" Width="138px" style="margin-left: 181px" />
        </p>
        <p>

            <asp:Label ID="Label37" runat="server" Font-Bold="True" Font-Size="Large" Visible="False"></asp:Label>

        </p>

        &nbsp;&nbsp;<br />
        <br />
        <hr />
        <br />
        <br />
        <strong>Method 2 : Forgot UserId? Enter your Full Name and Email Address to fetch UserID from the Database<br />
        <br />
        </strong>Method Signature : string retrieveUserName(string fullName, string emailId);<br />
        <br />
        <span style="font-size:11.0pt;line-height:115%;
font-family:&quot;Calibri&quot;,sans-serif;mso-ascii-theme-font:minor-latin;mso-fareast-font-family:
SimSun;mso-fareast-theme-font:minor-fareast;mso-hansi-theme-font:minor-latin;
mso-bidi-font-family:&quot;Times New Roman&quot;;mso-bidi-theme-font:minor-bidi;
mso-ansi-language:EN-US;mso-fareast-language:ZH-CN;mso-bidi-language:AR-SA">Description : This service searches the database for existing name and Email address and retrieves the Username if found, or else displays error message &quot;User not registered in the Database&quot;.<br />
        <br />
            <label>Enter Fullname&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="rs1str3" Width="199px" runat="server" style="margin-left: 33px" />
            <br />
        <br />
            Enter Email Address&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="rs1str4" Width="175px" runat="server" style="margin-left: 8px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" Text="submit" OnClick="TestRequiredService2" runat="server" Width="138px" style="margin-left: 181px" />
        <br />
        <br />

            <asp:Label ID="Label38" runat="server" Font-Bold="True" Font-Size="Large" Visible="False"></asp:Label>

        </label>
            </span>
        
    </div>

    
</asp:Content>
