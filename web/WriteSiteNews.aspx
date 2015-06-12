<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageMy.master" AutoEventWireup="true" CodeFile="WriteSiteNews.aspx.cs" Inherits="WriteSiteNews" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc1" %>

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
    <asp:GridView ID="gvNews" runat="server" DataKeyNames="Id" AutoGenerateColumns="false"
    CssClass="tblGridTable">
    <HeaderStyle CssClass="tblGridTable_Header" />
    <RowStyle CssClass="tblGridTable_Row" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="chSelected" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:ButtonField ButtonType="Link" HeaderText="Date" DataTextField="Created" />
            <asp:BoundField HeaderText="News" DataField="Title" />
            <asp:BoundField HeaderText="Language" DataField="Lang" />            
        </Columns>
    </asp:GridView>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
    <asp:Button ID="btnAdd" runat="server" Text="Add" onclick="btnAdd_Click" />
    <asp:Button ID="btnDelete" runat="server" Text="Delete" />
    <div  class="dvFilter">
            <table id="tblMain" visible="false" runat="server">
                <tr>
                    <td>
                        <table>
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
                                    <asp:Label ID="lbLabelLang" runat="server" Text="Site Language:"></asp:Label>
                                </td>
                                <td>
                                    <div class="csFilterInput">
                                        <div>
                                            <div>
                                                <asp:DropDownList ID="ddLang" runat="server" 
                                                DataTextField="Text" DataValueField="Id">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" >
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ClearButton" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="SaveButton" EventName="Click" />
                            </Triggers>
                            <ContentTemplate>
                                <cc1:Editor ID="ctrEditor" runat="server" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="SaveButton" runat="server" Text="Save" 
                            onclick="SaveButton_Click"/> 
                        <asp:Button ID="ClearButton" runat="server" Text="Clear"/> 
                        <asp:Button ID="CancelButton" runat="server" Text="Cancel" 
                            onclick="CancelButton_Click"/>                
                    </td>
                </tr>
                <tr>
                    <td>
                        <div id="PreviewHeading" runat="server" class="demoHeading">
                            <asp:Label ID="lbLabelPrev" runat="server" Text="Preview"></asp:Label></div>
                        <div id="PreviewText">                
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="PreviewButton" />
                                </Triggers>
                                <ContentTemplate>
                                    <div id="TextPreview" runat="server"></div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        
                        <div id="PreviewControls">
                            <asp:Button ID="PreviewButton" runat="server" Text="Preview"/>
                        </div>                            
                    </td>
                </tr>
            </table> 
    </div>       
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnAdd" />
            <asp:PostBackTrigger ControlID="CancelButton" />
            <asp:PostBackTrigger ControlID="gvNews" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

