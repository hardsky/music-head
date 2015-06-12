<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Events.aspx.cs" Inherits="Events" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link charset="utf8" href="http://localhost:1994/web/styles/base_simple_style.css" type="text/css" rel="Stylesheet" />
    <link charset="utf8" href="http://localhost:1994/web/styles/grid_style.css" type="text/css" rel="Stylesheet" />
    <link charset="utf8" href="http://localhost:1994/web/styles/filter_style.css" type="text/css" rel="Stylesheet" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="centerColumn" Runat="Server">
    <div class="dvFilter">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbLabelCountry" runat="server" Text="Country: "></asp:Label>
                </td>
                <td>
                    <div class="csFilterInput">
                        <div>
                            <div>
                                <asp:TextBox ID="tbCountry" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbLabelCity" runat="server" Text="City: "></asp:Label>
                </td>
                <td>
                    <div class="csFilterInput">
                        <div>
                            <div>
                                <asp:TextBox ID="tbCity" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </td>                    
            </tr>            
            <tr>
                <td>
                    <asp:Label ID="lbLabelLang" runat="server" Text="Language: "></asp:Label>
                </td>
                <td>
                    <div class="csFilterInput">
                        <div>
                            <div>
                                <asp:TextBox ID="tbLanguage" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnFind" runat="server" Text="Find!" onclick="btnFind_Click" />
                </td>
            </tr>
        </table>
    </div>
    <asp:GridView ID="gvEvents" runat="server" AutoGenerateColumns="false" CssClass="tblGridTable">
        <HeaderStyle CssClass="tblGridTable_Header" />
        <RowStyle CssClass="tblGridTable_Row" />
        <Columns>
            <asp:BoundField HeaderText="Date" DataFormatString="{0:dd.MM.yyyy HH:mm}" HtmlEncode="false" DataField="Event_datetime" />
            <asp:BoundField HeaderText="Event" DataField="Description" />
            <asp:BoundField HeaderText="Country" DataField="Country" />
            <asp:BoundField HeaderText="City" DataField="City"/>
            <asp:BoundField HeaderText="Language" DataField="Language" />
        </Columns>
    </asp:GridView>
</asp:Content>

