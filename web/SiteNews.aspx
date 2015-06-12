<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SiteNews.aspx.cs" Inherits="SiteNews" %>

<%@ Register src="UIControls/UserComments.ascx" tagname="UserComments" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link charset="utf8" href="http://localhost:1994/web/styles/base_simple_style.css" type="text/css" rel="Stylesheet" />
     <link charset="utf8" href="http://localhost:1994/web/styles/comment_style.css" type="text/css" rel="Stylesheet" />
     <link charset="utf8" href="http://localhost:1994/web/styles/sitenews_style.css" type="text/css" rel="Stylesheet" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="centerColumn" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <h4><asp:Label ID="lbLabelTitle" runat="server" CssClass="sitenews_block_title"></asp:Label></h4>
    <div id="dvAuthor">
        <asp:Label ID="lbLabelAuthor" runat="server"></asp:Label>
    </div>
    <div id="dvText" runat="server">
    </div>
    <div id="dvDate">
        <asp:Label ID="lbLabelDate" runat="server"></asp:Label>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true">
        <ContentTemplate>
            <uc1:UserComments ID="ctrUserComment" runat="server" />    
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

