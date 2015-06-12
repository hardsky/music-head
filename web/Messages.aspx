<%@ Page Language="C#" MasterPageFile="~/MasterPageMy.master" AutoEventWireup="true" CodeFile="Messages.aspx.cs" Inherits="Messages" Title="Untitled Page" %>

<%@ Register src="UIControls/InboxMessages.ascx" tagname="InboxMessages" tagprefix="uc1" %>

<%@ Register src="UIControls/OutboxMessages.ascx" tagname="OutboxMessages" tagprefix="uc2" %>

<%@ Register src="UIControls/MessagesControl.ascx" tagname="MessagesControl" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Myhead" Runat="Server">
    <link charset="utf8" href="http://localhost:1994/web/styles/messages_style.css" type="text/css" rel="Stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MyCenterColumn" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<table>
    <tr>
        <td>
           <uc3:MessagesControl ID="MessagesControl1" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnCreate" runat="server" Text="Create Message" 
                onclick="btnCreate_Click" />            
        </td>
    </tr>
</table>
</asp:Content>
