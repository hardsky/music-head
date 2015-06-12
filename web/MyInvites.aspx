<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageMy.master" AutoEventWireup="true" CodeFile="MyInvites.aspx.cs" Inherits="MyInvites" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MyCenterColumn" Runat="Server">
<table>
    <tr>
        <td>
    <asp:GridView ID="gvInvites" runat="server" AutoGenerateColumns="false" 
                DataKeyNames="Id, BandId" onrowdatabound="gvInvites_RowDataBound"
                 CssClass="tblGridTable">
                <HeaderStyle CssClass="tblGridTable_Header" />
                <RowStyle CssClass="tblGridTable_Row" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="cbSelected" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:HyperLinkField DataTextField="BandName" DataNavigateUrlFields="BandName" DataNavigateUrlFormatString="~/bands/{0}" HeaderText="Band" />
            <asp:HyperLinkField DataTextField="InviterName" DataNavigateUrlFields="InviterName" DataNavigateUrlFormatString="~/folks/{0}" HeaderText="Inviter" />
            <asp:BoundField DataField="Msg" HeaderText="Message" />
            <asp:BoundField DataField="Created" HeaderText="Invited" />
        </Columns>
    </asp:GridView>
        </td>
    </tr>
    <tr id="trActions" runat="server">
        <td>
            <asp:Button ID="btnAccept" runat="server" Text="Accept" 
                onclick="btnAccept_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" 
                onclick="btnDelete_Click" />
        </td>
    </tr>
</table>
</asp:Content>

