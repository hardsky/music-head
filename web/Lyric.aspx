<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Lyric.aspx.cs" Inherits="Lyric" %>

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
            
        <table class="tblOrangeLinks">
            <tr>
                <td>
        <h2><asp:Label ID="lbTitle" runat="server" Text=""></asp:Label></h2>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <h4>
                        <span style="display:block;">
                            <asp:Label ID="lbLabelAuthor" runat="server" Text="Author:"></asp:Label>&nbsp;<asp:HyperLink ID="hlAuthor" runat="server"></asp:HyperLink>
                        </span>
                    </h4>
                </td>
            </tr>
            <tr>
                <td id="tdText" runat="server">
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

