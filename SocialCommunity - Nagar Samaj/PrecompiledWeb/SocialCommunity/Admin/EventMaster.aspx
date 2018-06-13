<%@ page language="C#" masterpagefile="~/Admin/mstAdminPanel.master" autoeventwireup="true" inherits="Admin_EventMaster, App_Web_lloyrgkv" title="Nagar Bandhara Community | Event Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlEntry" CssClass="ModalPopupDialog" runat="server">
                <table id="PopupHeader" class="PopUPHeader">
                    <tr>
                        <td>
                            Event Master
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
                            Event Name
                        </td>
                        <td class="TextArea">
                            <asp:TextBox CssClass="TextBox" ID="txtEventName" runat="server">
                            </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelBox">
                            Event Start From
                        </td>
                        <td class="TextArea">
                            <asp:TextBox CssClass="TextBox" ID="txtEventStartDate" runat="server">
                            </asp:TextBox>
                            <ajaxtoolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtEventStartDate"
                                runat="server" Format="dd/MM/yyyy">
                            </ajaxtoolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelBox">
                            Event Ends on
                        </td>
                        <td class="TextArea">
                            <asp:TextBox CssClass="TextBox" ID="txtEventEndDate" runat="server">
                            </asp:TextBox>
                            <ajaxtoolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txtEventEndDate"
                                runat="server" Format="dd/MM/yyyy">
                            </ajaxtoolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelBox">
                            Description
                        </td>
                        <td class="TextArea">
                            <asp:TextBox CssClass="TextBox" ID="txtEventDescription" runat="server">
                            </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelBox">
                            Charges
                        </td>
                        <td class="TextArea">
                            <asp:TextBox CssClass="TextBox" ID="txtCharges" runat="server">
                            </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelBox">
                            File Path
                        </td>
                        <td class="TextArea">
                            <asp:FileUpload ID="flFilePath" CssClass="TextBox" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelBox">
                        </td>
                        <td class="TextArea">
                            <asp:CheckBox ID="chkDeleteFilePath" Text="Delete File" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td id="tdUploadedFile" align="center" visible="false" runat="server" colspan="2">
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
            </asp:Panel>
            <table class="ContentHead">
                <tr>
                    <td>
                        Event List
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
                                        <asp:ImageButton ID="imgbtnEdit" ImageUrl="~/Images/Edit.png" CommandArgument='<%# Eval("EventCode") %>'
                                            runat="server" OnClick="imgbtnEdit_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-CssClass="ImageButton">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgbtnDelete" ImageUrl="~/Images/Delete.png" CommandArgument='<%# Eval("EventCode") %>'
                                            CssClass="ImageButton" runat="server" OnClick="imgbtnDelete_Click" />
                                        <ajaxtoolkit:ConfirmButtonExtender ID="ConfirmDelete" TargetControlID="imgbtnDelete"
                                            ConfirmText="Are you Sure to Delete ?" runat="server">
                                        </ajaxtoolkit:ConfirmButtonExtender>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="EventName" HeaderStyle-HorizontalAlign="Left" HeaderText="Event Name"
                                    SortExpression="EventName" />
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
