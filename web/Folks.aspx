<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Folks.aspx.cs" Inherits="Folks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link charset="utf8" href="http://localhost:1994/web/styles/base_simple_style.css" type="text/css" rel="Stylesheet" />
     <link charset="utf8" href="http://localhost:1994/web/styles/grid_style.css" type="text/css" rel="Stylesheet" />
     <link charset="utf8" href="http://localhost:1994/web/styles/filter_style.css" type="text/css" rel="Stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="centerColumn" Runat="Server">
	<asp:HyperLink ID="rss_link" ImageUrl="~/img/rss.png" runat="server" CssClass="folks_feed" />
    <div class="dvFilter">
        <table>
            <tr>
                <td style="width: 40px;">
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
                <td style="width: 40px;">
                    <asp:Label ID="lbLabelInstr" runat="server" Text="Musical Instrument:"></asp:Label>
                </td>
                <td>
                    <div class="csFilterInput">
                        <div>
                            <div>
                                <asp:TextBox ID="tbInstrument" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </td>                    
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbLabelStyle" runat="server" Text="Music Style: "></asp:Label>
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
                    <asp:Label ID="lbLabelBand" runat="server" Text="Band: "></asp:Label>
                </td>
                <td>
                    <div class="csFilterInput">
                        <div>
                            <div>
                                <asp:TextBox ID="tbBand" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </td>
                <td colspan="2">
                    <asp:CheckBox ID="cbNotInBand" Text="Not in Band" runat="server" />
                </td>
            </tr>
            <tr>
                <td>                        
                    <asp:Label ID="lbLabelWays" runat="server" Text="Way in Art: "></asp:Label>
                </td>
                <td>
                    <div class="csFilterInput">
                        <div>
                            <div>
                                <asp:DropDownList ID="ddWay" runat="server" DataTextField="WayText" DataValueField="WayId">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                 </td>
                 <td colspan="2">
                    <asp:CheckBox ID="cbWorksExist" Text="Done something" runat="server" />
                 </td>
            </tr>                
            <tr>
                <td colspan="4">
                    <asp:Button ID="btnFind" runat="server" Text="Find!" onclick="btnFind_Click" />
                </td>
            </tr>
        </table>
    </div>
    <asp:GridView ID="gvArtists" runat="server" 
        onrowdatabound="gvArtists_RowDataBound"
        DataKeyNames="Id" AutoGenerateColumns="false" 
        onpageindexchanging="gvArtists_PageIndexChanging" 
        onsorting="gvArtists_Sorting" AllowSorting="true" CssClass="tblGridTable">
        <HeaderStyle CssClass="tblGridTable_Header" />
        <RowStyle CssClass="tblGridTable_Row" />
        <Columns>
            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    <a href = '<%# Jam.JamRouteUrl.PickUp("folk", this.LangEnum, new System.Collections.Generic.Dictionary<string, string>() { { "name", Eval("Name").ToString() } })%>'><%# Eval("Name")%></a>                            
                </ItemTemplate>
            </asp:TemplateField>            
            <asp:TemplateField HeaderText="Way">
                <ItemTemplate>
                    <asp:Repeater ID="rpWay" runat="server">
                        <ItemTemplate>
                            <%# Eval("WayName")%><br />
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Style">
                <ItemTemplate>
                    <asp:Repeater ID="rpStyle" runat="server">
                        <ItemTemplate>
                            <%# Eval("StyleName")%><br />
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Instruments">
                <ItemTemplate>
                    <asp:Repeater ID="rpInstr" runat="server">
                        <ItemTemplate>
                            <%# Eval("Instrument")%><br />
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Languages">
                <ItemTemplate>
                    <asp:Repeater ID="rpLang" runat="server">
                        <ItemTemplate>
                            <%# Eval("Language")%><br />
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
            </asp:TemplateField>                    
        </Columns>
    </asp:GridView>         
</asp:Content>

