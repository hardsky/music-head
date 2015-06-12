<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Looking.aspx.cs" Inherits="Looking" %>

<%@ Register src="UIControls/LookingForControl.ascx" tagname="LookingForControl" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link charset="utf8" href="http://localhost:1994/web/styles/search_style.css" type="text/css" rel="Stylesheet" />
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="centerColumn" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>
    
    <uc1:LookingForControl ID="LookingForControl1" runat="server" />

</asp:Content>

