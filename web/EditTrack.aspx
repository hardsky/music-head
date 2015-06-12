<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditTrack.aspx.cs" Inherits="EditTrack" %>

<%@ Register src="UIControls/ImageCover.ascx" tagname="ImageCover" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link charset="utf8" href="http://localhost:1994/web/styles/base_simple_style.css" type="text/css" rel="Stylesheet" />
     <link charset="utf8" href="http://localhost:1994/web/styles/filter_style.css" type="text/css" rel="Stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="centerColumn" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="dvFilter">    
        <table border="0">
            <tr>
                <td><asp:Label ID="lbLabelTitle" runat="server" Text="Title: "></asp:Label></td>
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
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
            <tr>
                <td><asp:Label ID="lbLabelFile" runat="server" Text="File: "></asp:Label></td>
                <td><asp:FileUpload ID="uplTrack" runat="server" /><asp:Label ID="lbFile" runat="server"></asp:Label></td>
            </tr>
                </ContentTemplate>
                <Triggers>
        <asp:PostBackTrigger ControlID="btnChangeFile" />        
                </Triggers>
            </asp:UpdatePanel>
            <tr id="trCHBtn" runat="server">
                <td colspan="2">
                <asp:Button ID="btnChangeFile" runat="server" Text="Change" 
                        onclick="btnChangeFile_Click" /><asp:Button ID="btnUplCancel" runat="server" 
                        Text="Cancel" Visible="false" onclick="btnChangeFile_Click" />
                </td>
            </tr>
                <uc1:ImageCover ID="ctrImgCover" runat="server" DefaultImgUrl="~/img/music_cover.gif" />    
            <tr>
                <td>
                    <asp:Label ID="lbLabelDescr" runat="server" Text="Description: "></asp:Label></td>
                <td>
                    <asp:TextBox ID="tbDescr" TextMode="MultiLine" runat="server" MaxLength="255"></asp:TextBox>
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
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" />
                    <asp:Button ID="bntCancel" runat="server" Text="Cancel" 
                        onclick="bntCancel_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

