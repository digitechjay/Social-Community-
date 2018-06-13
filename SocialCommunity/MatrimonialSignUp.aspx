<%@ Page Language="C#" MasterPageFile="~/mstClientPage.master" AutoEventWireup="true"
    CodeFile="MatrimonialSignUp.aspx.cs" Inherits="MatrimonialSignUp" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contentplaceholder1" runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div class="middle-cnt-full">
        <div class="abt_section-full">
            <h1>
                Matrimonial Registration</h1>
            <table class="ErrorDesc RadioBtnList" id="ErrorPart" runat="server">
                <tr>
                    <td style="width: 20px;" id="ErrorImage" runat="server">
                        <img src="../Images/error.png" alt="Error" />
                    </td>
                    <td id="tdError" runat="server" style="width: 100%;">
                    </td>
                </tr>
            </table>
            <div class="call-full">
                <h3>
                    New User? Register Now.
                </h3>
                <p>
                    Email ID<br />
                    <asp:TextBox ID="txtEmailID" CssClass="TextBox" runat="server"></asp:TextBox>
                </p>
                <p>
                    Password<br />
                    <asp:TextBox ID="txtPassword" CssClass="TextBox" runat="server" TextMode="Password"></asp:TextBox>
                </p>
                <p>
                    Member Name<br />
                    <asp:TextBox ID="txtMemberName" CssClass="TextBox" runat="server"></asp:TextBox>
                </p>
                <p>
                    Date of Birth<br />
                    <asp:TextBox ID="txtDOB" CssClass="TextBox" runat="server"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtDOB">
                    </asp:CalendarExtender>
                </p>
                <p>
                    Gender<br />
                    <asp:RadioButtonList ID="rdbtnGender" CssClass="RadioBtnList" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="Male" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Female" Value="1"></asp:ListItem>
                    </asp:RadioButtonList>
                </p>
                <p>
                    Contact No<br />
                    <asp:TextBox ID="txtContactNo" CssClass="TextBox" runat="server"></asp:TextBox>
                </p>
                <p>
                    Gotra<br />
                    <asp:DropDownList ID="ddlGotra" CssClass="TextBox" runat="server">
                        <asp:ListItem Text="--- Select Any ---" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Chandali" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Patoliya" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Asola" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Aasotiya" Value="4"></asp:ListItem>
                        <asp:ListItem Text="Kumbhariya" Value="5"></asp:ListItem>
                        <asp:ListItem Text="Lahora" Value="6"></asp:ListItem>
                        <asp:ListItem Text="Vaghela" Value="7"></asp:ListItem>
                        <asp:ListItem Text="Gawariya" Value="8"></asp:ListItem>
                        <asp:ListItem Text="Tarsangiya" Value="9"></asp:ListItem>
                    </asp:DropDownList>
                </p>
                <p>
                    Living In<br />
                    <asp:DropDownList ID="ddlLivingIn" CssClass="TextBox" runat="server">
                    </asp:DropDownList>
                </p>
                <p>
                    Photo<br />
                    <asp:FileUpload CssClass="TextBox" ID="flFilePath" runat="server" />
                </p>
                <p>
                    <asp:CheckBox ID="chkAgreement" runat="server" Text="" />I agree to the <a href="">Privacy
                        Policy</a> and <a href="">T&amp;C</a>.
                </p>
                <div class="dashed-full">
                </div>
                <div>
                    <asp:Button ID="btnSignup" runat="server" Text="Sign up" OnClick="btnSignup_Click" />
                </div>
            </div>
            <div class="sporter">
                <img src="images/suppor.png" alt="">
            </div>
            <div class="call-full">
                <h3>
                    Already Member? Login now</h3>
                <p>
                    Email ID<br />
                    <asp:TextBox ID="txtLoginEmailID" CssClass="TextBox" runat="server"></asp:TextBox>
                    <br />
                    Password<br />
                    <asp:TextBox ID="txtLoginPassword" CssClass="TextBox" runat="server" TextMode="Password"></asp:TextBox>
                </p>
                <p>
                    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                </p>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BottomContent" runat="Server">
</asp:Content>
