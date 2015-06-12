﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="InboxMessages.ascx.cs" Inherits="UIControls_InboxMessages" %>
<div class="dvHeadChartTable">
    <div>
        <div>
        &nbsp;
        </div>
    </div>
</div>
<div class="dvChartTableDiv">
<table>
    <tr>
        <td>
            <asp:GridView ID="gvInbox" runat="server" onrowcommand="gvInbox_RowCommand" AutoGenerateColumns="false"
             DataKeyNames="Id" onrowdatabound="gvInbox_RowDataBound"
              CssClass="tblGridTable">
                <HeaderStyle CssClass="tblGridTable_Header" />
                <RowStyle CssClass="tblGridTable_Row" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="cbSelected" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:ButtonField ButtonType="Link" HeaderText="Subject" DataTextField="Subj" CommandName="ShowMessage"/>
                    <asp:BoundField HeaderText="From" DataField="FromName" />
                    <asp:BoundField HeaderText="Received" DataField="Created" />
                    <asp:ButtonField ButtonType="Image" ImageUrl="~/img/GoLtr.bmp" CommandName="ShowMessage" />
                </Columns>
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnDelete" runat="server" Text="Delete" 
                onclick="btnDelete_Click"/>
        </td>
    </tr>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <tr id="trMessage" runat="server" visible="false">
        <td>
            <table>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lbLabelSubj" runat="server" Text="Subject: "></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbMsgSubject" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbLabelFrom" runat="server" Text="From: "></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbFrom" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbLabelRec" runat="server" Text="Received: "></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbSent" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                       <div id="dvText" runat="server" style="border: dashed 1px black; padding: 3px 3px 3px 3px;">
                       </div> 
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="gvInbox" />
    </Triggers>
    </asp:UpdatePanel>
</table>
</div>
<div class="dvFootChartTable">
    <div>
        <div>
        &nbsp;
        </div>
    </div>
</div>                        
