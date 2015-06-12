<%@ Page Title="Looking For Band" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LFB.aspx.cs" Inherits="LFB" %>

<asp:Content ID="Content2" ContentPlaceHolderID="centerColumn" Runat="Server">
<table width="100%">
    <tr>
        <td>
            <asp:HyperLink ID="hlOther" runat="server" NavigateUrl="~/LFP.aspx">Looking For People</asp:HyperLink>
            &nbsp;
            <asp:Label ID="lbCurPage" runat="server">Looking For Band</asp:Label>            
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lbPageNotice" runat="server">There are signs from people, that they are looking for band.
            </asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lbLabelLanguage" runat="server" Text="Language:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbLanguage" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbLabelCountry" runat="server" Text="Country:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbCountry" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbLabelCity" runat="server" Text="City:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbCity" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbLabelRole" runat="server" Text="Role in Band:"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="tbRole" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnFind" runat="server" Text="Find!" onclick="btnFind_Click"/>
                    </td>
                </tr>
            </table>            
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="gvSearchBand" runat="server" AutoGenerateColumns="false"
             AllowSorting="true" onrowdatabound="gvSearchBand_RowDataBound"
                onsorting="gvSearchBand_Sorting" 
                onpageindexchanging="gvSearchBand_PageIndexChanging" CssClass="tblGridTable">
                <HeaderStyle CssClass="tblGridTable_Header" />
                <RowStyle CssClass="tblGridTable_Row" />
                <Columns>
                    <asp:HyperLinkField HeaderText="Artist" DataTextField="ArtName" DataNavigateUrlFields="ArtName" DataNavigateUrlFormatString="~/folks/{0}" />
                    <asp:BoundField HeaderText="Role in Band" DataField="LookingFor" SortExpression="LookingFor" />
                    <asp:BoundField HeaderText="Style" DataField="Style" SortExpression="Style" />
                    <asp:BoundField HeaderText="Comment" DataField="Comment" />
                    <asp:BoundField HeaderText="Language" DataField="Language" SortExpression="Language" />
                    <asp:BoundField HeaderText="Country" DataField="Country" SortExpression="Country" />
                    <asp:BoundField HeaderText="City" DataField="City" SortExpression="City" />
                    <asp:BoundField HeaderText="Created" DataField="Created" />                    
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>
</asp:Content>

