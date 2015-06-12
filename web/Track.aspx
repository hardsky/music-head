<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Track.aspx.cs" Inherits="Track" %>

<%@ Register src="UIControls/UserComments.ascx" tagname="UserComments" tagprefix="uc1" %>

<%@ Register src="UIControls/Rating.ascx" tagname="Rating" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link charset="utf8" href="http://localhost:1994/web/styles/base_simple_style.css" type="text/css" rel="Stylesheet" />
     <link charset="utf8" href="http://localhost:1994/web/styles/comment_style.css" type="text/css" rel="Stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="centerColumn" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="dvTrack">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="true">
            <ContentTemplate>
                <uc2:Rating ID="ctrRating" runat="server" />
            </ContentTemplate>            
        </asp:UpdatePanel>
        
        <table border="0" class="tblOrangeLinks">
            <tr>
                <td><asp:Label ID="lbLabelTitle" runat="server" Text="Title: "></asp:Label></td>
                <td><asp:Label ID="lbTitle" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2" style="padding-bottom: 20px;">
                    <asp:PlaceHolder ID="phPlayer" runat="server"></asp:PlaceHolder>
                </td>
            </tr>
            <tr>
                <td><asp:Label ID="lbLabelStyle" runat="server" Text="Style: "></asp:Label></td>
                <td>
                    <asp:Label ID="lbStyle" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td><asp:Label ID="lbLabelAuthor" runat="server" Text="Author: "></asp:Label></td>
                <td>
                    <asp:HyperLink ID="hlAuthor" runat="server"></asp:HyperLink>
                </td>
            </tr>    
            <tr id="trBand" runat="server">
                <td><asp:Label ID="lbLabelBand" runat="server" Text="Band: "></asp:Label></td>
                <td>
                    <asp:HyperLink ID="hlBand" runat="server"></asp:HyperLink>
                </td>
            </tr>
            <tr id="trLang" runat="server">
                <td><asp:Label ID="lbLabelLang" runat="server" Text="Language: "></asp:Label></td>
                <td>
                    <asp:Label ID="lbLang" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2"><asp:Label ID="lbLabelDescr" runat="server" Text="Description: "></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lbDescr" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true">
            <ContentTemplate>
                <uc1:UserComments ID="ctrUserComment" runat="server" />
            </ContentTemplate>       
        </asp:UpdatePanel>
    </div>
</asp:Content>

