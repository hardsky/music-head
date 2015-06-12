<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageMy.master" AutoEventWireup="true" CodeFile="MyBands.aspx.cs" Inherits="MyBands" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MyCenterColumn" Runat="Server">
    <asp:GridView ID="gvBands" runat="server" AutoGenerateColumns="false" 
        DataKeyNames="Id" onpageindexchanging="gvBands_PageIndexChanging" 
        onrowdatabound="gvBands_RowDataBound" CssClass="tblGridTable">
                <HeaderStyle CssClass="tblGridTable_Header" />
                <RowStyle CssClass="tblGridTable_Row" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="cbSelected" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:HyperLinkField HeaderText="Name" DataTextField="Name" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/MyBand.aspx?id={0}" />
            <asp:BoundField HeaderText="Description" DataField="Description" />
            <asp:TemplateField HeaderText="Languages">
                <ItemTemplate>
                    <asp:Repeater ID="rpLang" runat="server">
                        <ItemTemplate>
                            <asp:Label ID="lbLang" runat="server"><%# Eval("Language")%></asp:Label><br />
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:HyperLinkField HeaderText="Leader" DataTextField="LeaderName" DataNavigateUrlFields="LeaderName" DataNavigateUrlFormatString="~/folks/{0}"/>
        </Columns>
    </asp:GridView>
    
    <br />
    <asp:Button ID="btnCreate" runat="server" Text="Create New" 
        onclick="btnCreate_Click" />
        <asp:Button ID="btnLeave" runat="server" Text="Leave" 
        onclick="btnLeave_Click" />
</asp:Content>

