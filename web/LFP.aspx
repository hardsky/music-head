<%@ Page Title="Looking For People" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LFP.aspx.cs" Inherits="LFP" %>

<%@ Register src="UIControls/LookingForControl.ascx" tagname="LookingForControl" tagprefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="centerColumn" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <uc1:LookingForControl ID="LookingForControl1" runat="server" />
    
</asp:Content>

