<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageMy.master" AutoEventWireup="true" CodeFile="MyLyrics.aspx.cs" Inherits="MyLyrics" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MyCenterColumn" Runat="Server">
    <asp:GridView ID="gvLirics" runat="server" AutoGenerateColumns="false" 
        DataKeyNames="id" onrowdatabound="gvLirics_RowDataBound" CssClass="tblGridTable">
                <HeaderStyle CssClass="tblGridTable_Header" />
                <RowStyle CssClass="tblGridTable_Row" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="chSelected" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:HyperLinkField HeaderText="Title" DataTextField="Name" DataNavigateUrlFields="id" DataNavigateUrlFormatString="~/SongWriter.aspx?lid={0}" />
            <asp:BoundField HeaderText="Created" DataField="Created" />
            <asp:BoundField HeaderText="Updated" DataField="Updated" />
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnAdd" runat="server" Text="Add" onclick="btnAdd_Click" />
    <asp:Button ID="btnDelete" runat="server" Text="Delete" 
        onclick="btnDelete_Click" />
</asp:Content>

