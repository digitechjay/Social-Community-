<%@ page language="C#" masterpagefile="~/Admin/mstAdminPanel.master" autoeventwireup="true" inherits="Admin_MemberMaster, App_Web_occddnuk" title="Nagar Bandhara Community | Member Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlEntry" CssClass="ModalPopupDialog" runat="server">
                <table id="PopupHeader" class="PopUPHeader">
                    <tr>
                        <td>
                            Member Master
                        </td>
                        <td align="right">
                            <asp:ImageButton ID="imgbtnClose" ImageUrl="~/Images/Exit.png" CssClass="ImageButton"
                                runat="server" />
                        </td>
                    </tr>
                </table>
                <table class="ErrorDesc">
                    <tr>
                        <td style="width: 20px;">
                            <img src="../Images/error.png" alt="Error" />
                        </td>
                        <td id="PopuptdError" runat="server" style="width: 100%;">
                        </td>
                    </tr>
                </table>
                <table class="ContentMain">
                    <tr>
                        <td class="LabelBox">
                            Member Name
                        </td>
                        <td class="TextArea">
                            <asp:TextBox CssClass="TextBox" ID="txtMemberName" runat="server">
                            </asp:TextBox>
                        </td>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelBox">
                            Current Address
                        </td>
                        <td class="TextArea">
                            <asp:TextBox CssClass="TextBox" ID="txtCurrentAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </td>
                        <td class="LabelBox">
                            Permanent Address
                        </td>
                        <td class="TextArea">
                            <asp:TextBox CssClass="TextBox" ID="txtPermanentAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelBox">
                            Country
                        </td>
                        <td class="TextArea">
                            <asp:DropDownList CssClass="ComboBox" ID="ddlCountryCode" runat="server" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlCountryCode_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td class="LabelBox">
                            Native Place
                        </td>
                        <td class="TextArea">
                            <asp:DropDownList CssClass="TextBox" ID="ddlNativePlace" runat="server">
                                <asp:ListItem Text="Talaja" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Gariyadhar" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Palitana" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelBox">
                            State
                        </td>
                        <td class="TextArea">
                            <asp:DropDownList CssClass="ComboBox" ID="ddlStateCode" runat="server" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlStateCode_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td class="LabelBox">
                            Nationality
                        </td>
                        <td class="TextArea">
                            <asp:DropDownList CssClass="TextBox" ID="ddlNationality" runat="server">
                                <asp:ListItem Text="Indian" Value="0"></asp:ListItem>
                                <asp:ListItem Text="American" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Austrailian" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelBox">
                            City
                        </td>
                        <td class="TextArea">
                            <asp:DropDownList CssClass="ComboBox" ID="ddlCityCode" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td class="LabelBox">
                            Photo
                        </td>
                        <td class="TextArea">
                            <asp:FileUpload CssClass="TextBox" ID="flFilePath" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelBox">
                            Contact No
                        </td>
                        <td class="TextArea">
                            <asp:TextBox CssClass="TextBox" ID="txtContactNo" runat="server">
                            </asp:TextBox>
                        </td>
                        <td class="LabelBox">
                        </td>
                        <td class="TextArea">
                            <asp:CheckBox ID="chkDeleteFilePath" Text="Delete File" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelBox">
                            Email Id
                        </td>
                        <td class="TextArea">
                            <asp:TextBox CssClass="TextBox" ID="txtEmailID" runat="server">
                            </asp:TextBox>
                        </td>
                        <td id="tdUploadedFile" visible="false" align="center" runat="server" colspan="2"
                            rowspan="9">
                            <asp:Image ID="imgPhotos" CssClass="ThumbnailImage" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelBox">
                            DOB
                        </td>
                        <td class="TextArea">
                            <asp:TextBox CssClass="TextBox" ID="txtDOB" runat="server">
                            </asp:TextBox>
                            <ajaxtoolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtDOB" runat="server"
                                Format="dd/MM/yyyy">
                            </ajaxtoolkit:CalendarExtender>
                        </td>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelBox">
                            Qualification
                        </td>
                        <td class="TextArea">
                            <asp:DropDownList CssClass="TextBox" ID="ddlQualificationCode" runat="server">
                                <asp:ListItem Text="Doctorate" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Masters" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Graduation" Value="0"></asp:ListItem>
                                <asp:ListItem Text="High School" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Under Highschool" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelBox">
                            Occupation
                        </td>
                        <td class="TextArea">
                            <asp:DropDownList CssClass="TextBox" ID="ddlOccupationCode" runat="server">
                                <asp:ListItem Text="Doctor" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Business" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Professional" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Job" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Housewife" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Other" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelBox">
                            Marital Status
                        </td>
                        <td class="TextArea">
                            <asp:DropDownList CssClass="ComboBox" ID="ddlMaritalStatus" runat="server">
                                <asp:ListItem>Single</asp:ListItem>
                                <asp:ListItem>Married</asp:ListItem>
                                <asp:ListItem>Divorced</asp:ListItem>
                                <asp:ListItem>Widowed</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelBox">
                            Gender
                        </td>
                        <td class="TextArea">
                            <asp:DropDownList CssClass="ComboBox" ID="ddlGender" runat="server">
                                <asp:ListItem>Male</asp:ListItem>
                                <asp:ListItem>Female</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelBox">
                            Physically Challanged
                        </td>
                        <td class="TextArea">
                            <asp:DropDownList CssClass="ComboBox" ID="ddlPhysicallyChallanged" runat="server">
                                <asp:ListItem>None</asp:ListItem>
                                <asp:ListItem>Eyes</asp:ListItem>
                                <asp:ListItem>Feet</asp:ListItem>
                                <asp:ListItem>Hand</asp:ListItem>
                                <asp:ListItem>Ear</asp:ListItem>
                                <asp:ListItem>Paralysed</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelBox">
                            Parent
                        </td>
                        <td class="TextArea">
                            <asp:DropDownList CssClass="ComboBox" ID="ddlParentCode" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelBox">
                            Parent Relationship
                        </td>
                        <td class="TextArea">
                            <asp:DropDownList ID="ddlRelationshipCode" CssClass="ComboBox" runat="server">
                                <asp:ListItem Text="Self" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Father" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Husband" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Guardians" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="CommandButton">
                            <asp:ImageButton ID="imgbtnSave" ImageUrl="~/Images/Save.png" runat="server" OnClick="imgbtnSave_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <table class="ContentHead">
                <tr>
                    <td>
                        Member List
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
                    <td style="width: 50%;" align="left">
                        <table>
                            <tr>
                                <td>
                                    <asp:ImageButton ID="imgBtnTemp" ImageUrl="~/Images/add.gif" CssClass="ImageButtonHide"
                                        runat="server" />
                                    <asp:ImageButton ID="imgbtnAddNew" ImageUrl="~/Images/add.gif" CssClass="ImageButton"
                                        runat="server" OnClick="imgbtnAddNew_Click" />
                                    <ajaxtoolkit:ModalPopupExtender ID="mdlPopupNewEntry" PopupControlID="pnlEntry" TargetControlID="imgBtnTemp"
                                        BackgroundCssClass="ModalPopupBG" PopupDragHandleControlID="PopupHeader" CancelControlID="imgbtnClose"
                                        runat="server">
                                    </ajaxtoolkit:ModalPopupExtender>
                                </td>
                                <td>
                                    <asp:ImageButton ID="imgbtnPrint" ImageUrl="~/Images/print.png" CssClass="ImageButton"
                                        runat="server" OnClick="imgbtnPrint_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 50%;" align="right">
                        <table>
                            <tr>
                                <td>
                                    <asp:ImageButton ID="imgbtnPrev" ImageUrl="~/Images/prev.png" CssClass="ImageButton"
                                        runat="server" OnClick="imgbtnPrev_Click" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCurPage" Width="50px" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    /
                                </td>
                                <td>
                                    <asp:Label ID="lblTotalPage" runat="server" Text="Label"></asp:Label>
                                </td>
                                <td>
                                    <asp:ImageButton ID="imgbtnNext" ImageUrl="~/Images/next.png" CssClass="ImageButton"
                                        runat="server" OnClick="imgbtnNext_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="grdData" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                            Width="100%" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField ItemStyle-CssClass="ImageButton">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgbtnEdit" ImageUrl="~/Images/Edit.png" CommandArgument='<%# Eval("MemberCode") %>'
                                            runat="server" OnClick="imgbtnEdit_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-CssClass="ImageButton">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgbtnDelete" ImageUrl="~/Images/Delete.png" CommandArgument='<%# Eval("MemberCode") %>'
                                            CssClass="ImageButton" runat="server" OnClick="imgbtnDelete_Click" />
                                        <ajaxtoolkit:ConfirmButtonExtender ID="ConfirmDelete" TargetControlID="imgbtnDelete"
                                            ConfirmText="Are you Sure to Delete ?" runat="server">
                                        </ajaxtoolkit:ConfirmButtonExtender>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="MemberName" HeaderStyle-HorizontalAlign="Left" HeaderText="Member Name"
                                    SortExpression="MemberName" />
                                <asp:BoundField DataField="CityName" HeaderStyle-HorizontalAlign="Left" HeaderText="City Name"
                                    SortExpression="CityName" />
                            </Columns>
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="imgbtnSave" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
