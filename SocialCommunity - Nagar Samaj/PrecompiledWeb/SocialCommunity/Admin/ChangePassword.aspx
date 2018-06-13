<%@ page language="C#" masterpagefile="~/Admin/mstAdminPanel.master" autoeventwireup="true" inherits="Admin_ChangePassword, App_Web_lloyrgkv" title="Nagar Bandhara Community | Change Password" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="ContentHead">
        <tr>
            <td>
                Change Password
            </td>
        </tr>
    </table>
    <table class="ErrorDesc" id="ErrorPart" runat="server">
        <tr>
            <td style="width: 20px;" id="ErrorImage" runat="server">
                <img src="../Images/error.png" alt="Error" />
            </td>
            <td id="tdError" runat="server" style="width: 100%;">
            </td>
        </tr>
    </table>
    <table class="ContentMain">
        <tr>
            <td class="LabelBox">
                UserName
            </td>
            <td class="TextArea">
                <asp:TextBox CssClass="TextBox" ID="txtUserName" runat="server">
                </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="LabelBox">
                Password
            </td>
            <td class="TextArea">
                <asp:TextBox CssClass="TextBox" ID="txtPassword" runat="server">
                </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td colspan="2" class="CommandButton">
                <asp:ImageButton ID="imgbtnSave" ImageUrl="~/Images/Save.png" runat="server" OnClick="imgbtnSave_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
