<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageMy.master" AutoEventWireup="true" CodeFile="MyMusic.aspx.cs" Inherits="MyMusic" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MyCenterColumn" Runat="Server">
<table>
    <tr>
        <td>
            <asp:GridView ID="gvMusic" runat="server" AutoGenerateColumns="false" onrowdatabound="gvMusic_RowDataBound"
             DataKeyNames="FileName, Id" CssClass="tblGridTable">
                <HeaderStyle CssClass="tblGridTable_Header" />
                <RowStyle CssClass="tblGridTable_Row" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="chSelected" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:HyperLinkField HeaderText="Title" DataTextField="Title" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/EditTrack.aspx?id={0}" />
                    <asp:BoundField HeaderText="Description" DataField="Description" />
                    <asp:BoundField HeaderText="Style" DataField="Style"/>
                    <asp:BoundField HeaderText="Language" DataField="Language"/>                    
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:PlaceHolder ID="phButtonPlayer" runat="server"></asp:PlaceHolder>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnAdd" runat="server" Text="Add" onclick="btnAdd_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" 
                onclick="btnDelete_Click" />
        </td>
    </tr>
</table>
</asp:Content>

