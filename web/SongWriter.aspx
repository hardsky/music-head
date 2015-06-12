<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SongWriter.aspx.cs" Inherits="SongWriter" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link charset="utf8" href="http://localhost:1994/web/styles/base_simple_style.css" type="text/css" rel="Stylesheet" />
    <link charset="utf8" href="http://localhost:1994/web/styles/filter_style.css" type="text/css" rel="Stylesheet" />
    <link charset="utf8" href="http://localhost:1994/web/styles/texteditor_style.css" type="text/css" rel="Stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="centerColumn" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true" />
        
    <div class="dvFilter">
        <table>
            <tr>
                <td>
        <asp:Label ID="lbLabelTitle" runat="server" Text="Title: "></asp:Label>
                </td>
                <td>
                    <div class="csFilterInput">
                        <div>
                            <div>
                               <asp:TextBox ID="tbTitle" runat="server" MaxLength="100"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td><asp:Label ID="lbLabelStyle" runat="server" Text="Style: "></asp:Label></td>
                <td>            
                    <div class="csFilterInput">
                        <div>
                            <div>
                                <asp:TextBox ID="tbStyle" runat="server" MaxLength="80"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
            <tr id="trDDGroup" runat="server">
                <td><asp:Label ID="lbLabelBand" runat="server" Text="Band: "></asp:Label></td>
                <td>
                    <div class="csFilterInput">
                        <div>
                            <div>
                                <asp:DropDownList ID="ddGroup" runat="server" DataValueField="BandId" DataTextField="Name">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td><asp:Label ID="lbLabelVisib" runat="server" Text="Visibility: "></asp:Label></td>
                <td>
                    <div class="csFilterInput">
                        <div>
                            <div>
                                <asp:DropDownList ID="ddVisib" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td><asp:Label ID="lbLabelLang" runat="server" Text="Language: "></asp:Label></td>
                <td>
                    <div class="csFilterInput">
                        <div>
                            <div>
                                <asp:TextBox ID="tbLang" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
        </table>                    
    </div>
    <div id="EditorPanel">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" >
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ClearButton" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="SaveButton" EventName="Click" />
            </Triggers>
            <ContentTemplate>
                <cc1:Editor ID="ctrEditor" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <div id="DemoControls">                                                        
            <asp:Button ID="SaveButton" runat="server" Text="Save" OnClick="SaveButton_Click"/> 
            <asp:Button ID="ClearButton" runat="server" Text="Clear" OnClick="ClearButton_Click"/> 
            <asp:Button ID="CancelButton" runat="server" Text="Cancel" onclick="CancelButton_Click" />
        </div>
        
        <div id="Preview">
        
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
                <asp:Button ID="PreviewButton" runat="server" Text="Preview" OnClick="PreviewButton_Click"/>
            </div>                
        </div>
    </div>

</asp:Content>

