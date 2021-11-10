<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Gallery_Web.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 337px;
            width: 0px;
        }
        .auto-style2 {
            height: 304px;
        }
    </style>
</head>
<body style="height: 349px">
    <form id="form1" runat="server">
        <div class="auto-style1">
            <asp:Panel ID="Panel1" runat="server" Height="366px" Width="981px">
                <center class="auto-style2">
                    <br />
                    <asp:Label ID="Label3" runat="server" BorderStyle="Outset" Font-Bold="True" Font-Italic="False" Font-Size="X-Large" Text="LOG-IN " Width="651px"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="Label7" runat="server"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="Label4" runat="server" Text="USERNAME:"></asp:Label>
                    &nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox1" runat="server" ToolTip="Enter Username as Text"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="UserName Required!!"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="PASSWORD: "></asp:Label>
                    &nbsp;&nbsp;
                    <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" ToolTip="Enter Password associated with username"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="Password required!!" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label5" runat="server" Text="VERIFY PASSWORD:"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox3" runat="server" TextMode="Password" Width="150px"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="TextBox2" ControlToValidate="TextBox3" ErrorMessage="Password dont match original. Try again" ForeColor="Red"></asp:CompareValidator>
                    <br />
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button2" runat="server" Font-Bold="True" OnClick="Button2_Click" style="height: 26px" Text="SIGN-IN" ToolTip="Click to Sign-in" Width="82px" />
                    <asp:Button ID="Button1" runat="server" BorderStyle="Outset" Font-Bold="True" OnClick="Button1_Click" Text="LOG-IN" ToolTip="Click to Log-in" Width="90px" />
                    <br />
                    <asp:Label ID="Label6" runat="server" Text="Not already registered? Click:"></asp:Label>
&nbsp;
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" ToolTip="Click to Register">Register</asp:LinkButton>
                    <br />
                    <br />
                </center>
            </asp:Panel>
        </div>
        
    </form>
</body>
</html>
