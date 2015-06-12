<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageMy.master" AutoEventWireup="true" CodeFile="MyNews.aspx.cs" Inherits="MyNews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MyHead" Runat="Server">
    <link charset="utf8" href="http://localhost:1994/web/styles/base_art_style.css" type="text/css" rel="Stylesheet" />
    <link charset="utf8" href="http://localhost:1994/web/styles/grid_style.css" type="text/css" rel="Stylesheet" />
    <link charset="utf8" href="http://localhost:1994/web/styles/filter_style.css" type="text/css" rel="Stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyRightColumn" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MyCenterColumn" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:GridView ID="gvNews" runat="server" AutoGenerateColumns="false"
        DataKeyNames="Id" CssClass="tblGridTable" onrowdatabound="gvNews_RowDataBound" >
        <HeaderStyle CssClass="tblGridTable_Header" />
        <RowStyle CssClass="tblGridTable_Row" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="chSelected" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Date" DataField="Created" />
            <asp:BoundField HeaderText="News" DataField="Title" />
            <asp:TemplateField HeaderText="Who">
                <ItemTemplate>
                    <asp:Label ID="lbWho" runat="server"></asp:Label>
                    <asp:HyperLink ID="hlWho" runat="server">HyperLink</asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Button ID="btnAdd" runat="server" Text="Add" onclick="btnAdd_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" 
                onclick="btnDelete_Click" />
        <div  class="dvFilter">        
            <table id="tblNews" runat="server" visible="false">
                <tr>
                    <td>
                        <asp:Label ID="lbLabelTitle" runat="server" Text="Title:"></asp:Label>
                    </td>
                    <td>
                        <div class="csFilterInput">
                            <div>
                                <div>
                                    <asp:TextBox ID="tbTitle" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbLabelText" runat="server" Text="Text:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbText" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbLabelWho" runat="server" Text="Who: "></asp:Label>
                    </td>
                    <td>
                        <div class="csFilterInput">
                            <div>
                                <div>
                        <asp:DropDownList ID="ddWho" runat="server" 
                            onselectedindexchanged="ddWho_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                            <table id="tblBand" runat="server" visible="false">
                                <tr>
                                    <td>
                                        <asp:Label ID="lbLabelBand" runat="server" Text="Band:"></asp:Label>
                                    </td>
                                    <td>
                                        <div class="csFilterInput">
                                            <div>
                                                <div>
                                        <asp:DropDownList ID="ddBand" DataTextField="Name" DataValueField="Id" runat="server">
                                        </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="ddWho" />
                            </Triggers>
                        </asp:UpdatePanel>                        
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                            onclick="btnCancel_Click" />
                    </td>
                </tr>
            </table>        
        </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnAdd" />
            <asp:PostBackTrigger ControlID="btnCancel" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

