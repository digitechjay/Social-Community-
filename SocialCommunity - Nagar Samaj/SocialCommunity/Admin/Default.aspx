<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login | Nagar Bandhara Community, INDIA</title>
    <link href="CSS/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div id="wrapperlogin">
        <div id="headerlogin">
            <div class="logo-boxlogin">
                <img src="images/bg-logo.png" width="205" height="46" /></div>
            <div style="padding: 20px 10px 0 0; font-size: 15px; font-weight: bold; float: right;
                color: white;">
                Nagar Bandhara Community, INDIA</div>
        </div>
        <div id="contentlogin">
            <div class="content-leftlogin">
                <img src="images/admin-image.png" alt="" width="291" height="221" /></div>
            <div class="content-midiumlogin">
                <img src="images/bg-midium.gif" alt="" width="4" height="387" /></div>
            <div class="content-rightlogin">
                <div class="content-right1login">
                    <div class="ErrorDesc" style="margin-bottom: 10px;" id="tdError" runat="server">
                    </div>
                    <div class="content-textlogin">
                        UserName:</div>
                    <div class="content-formlogin">
                        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valUserName" ValidationGroup="Login" runat="server"
                            ControlToValidate="txtUserName" ErrorMessage="Invalid User Name" Display="None"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="valCallUserName" PopupPosition="BottomRight" TargetControlID="valUserName"
                            runat="server">
                        </asp:ValidatorCalloutExtender>
                    </div>
                    <div class="content-textlogin">
                        Password:</div>
                    <div class="content-formlogin">
                        <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valPassword" ValidationGroup="Login" runat="server"
                            ControlToValidate="txtPassword" ErrorMessage="Invalid Password" Display="None"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="valCallPassword" PopupPosition="BottomRight" TargetControlID="valPassword"
                            runat="server">
                        </asp:ValidatorCalloutExtender>
                    </div>
                    <div class="content-formlogin">
                        <asp:ImageButton ID="btnLogin" ValidationGroup="Login" ImageUrl="images/bg-login.gif"
                            Width="174" Height="34" Style="padding: 20px 0 0 61px;" runat="server" OnClick="btnLogin_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
