<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Bands.aspx.cs" Inherits="Bands" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link charset="utf8" href="http://localhost:1994/web/styles/base_simple_style.css" type="text/css" rel="Stylesheet" />
     <link charset="utf8" href="http://localhost:1994/web/styles/grid_style.css" type="text/css" rel="Stylesheet" />
     <link charset="utf8" href="http://localhost:1994/web/styles/filter_style.css" type="text/css" rel="Stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="centerColumn" Runat="Server">
    <div class="dvFilter">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbLabelName" runat="server" Text="Name: "></asp:Label>
                </td>
                <td>
                    <div class="csFilterInput">
                        <div>
                            <div>
                                <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </td>
                <td style="width: 200px; font-size: 11px;">
                    <asp:Label ID="lbLabelNameNotice" runat="server" Text="You can specify 'part' of name. For an example, 'Very*' for search 'Very Cool Band'."></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbLabelStyle" runat="server" Text="Style: "></asp:Label>
                </td>
                <td>
                    <div class="csFilterInput">
                        <div>
                            <div>
                                <asp:TextBox ID="tbStyle" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </td>
                <td>
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
                                <asp:TextBox ID="tbLang" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Button ID="btnFind" runat="server" Text="Find!" onclick="btnFind_Click" />
                </td>
            </tr>
        </table>
    </div>
    <asp:GridView ID="gvBands" runat="server" AutoGenerateColumns = "false" 
        onrowdatabound="gvBands_RowDataBound" DataKeyNames="BandId" 
        onpageindexchanging="gvBands_PageIndexChanging" AllowSorting="true" 
        onsorting="gvBands_Sorting" CssClass="tblGridTable">
        <HeaderStyle CssClass="tblGridTable_Header" />
        <RowStyle CssClass="tblGridTable_Row" />
        <Columns>
            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    <a href = '<%# Jam.JamRouteUrl.PickUp("band", this.LangEnum, new System.Collections.Generic.Dictionary<string, string>() { { "name", Eval("Name").ToString() } })%>'><%# Eval("Name")%></a>                            
                </ItemTemplate>
            </asp:TemplateField>            
            <asp:BoundField HeaderText="Style" DataField="Style" SortExpression="Style"/>
            <asp:TemplateField HeaderText="Languages">
                <ItemTemplate>
                    <asp:Repeater ID="rpLang" runat="server">
                        <ItemTemplate>
                            <asp:Label ID="lbLang" runat="server"><%# Eval("Language")%></asp:Label><br />
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Leader">
                <ItemTemplate>
                    <a href = '<%# Jam.JamRouteUrl.PickUp("folk", this.LangEnum, new System.Collections.Generic.Dictionary<string, string>() { { "name", Eval("LeaderName").ToString() } })%>'><%# Eval("LeaderName")%></a>                            
                </ItemTemplate>
            </asp:TemplateField>            
        </Columns>
    </asp:GridView>        
</asp:Content>

