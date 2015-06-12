<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MyBand.aspx.cs" Inherits="MyBand" %>

<%@ Register src="UIControls/MyBand.ascx" tagname="MyBand" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link charset="utf8" href="http://localhost:1994/web/styles/base_simple_style.css" type="text/css" rel="Stylesheet" />
     <link charset="utf8" href="http://localhost:1994/web/styles/grid_style.css" type="text/css" rel="Stylesheet" />
     <link charset="utf8" href="http://localhost:1994/web/styles/filter_style.css" type="text/css" rel="Stylesheet" />
     <link charset="utf8" href="http://localhost:1994/web/styles/myband_style.css" type="text/css" rel="Stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="centerColumn" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<div style="width: 100%">
    <uc1:MyBand ID="MyBand1" runat="server" />
</div>
</asp:Content>

