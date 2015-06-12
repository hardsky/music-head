<%@ Control Language="C#" AutoEventWireup="true" CodeFile="VideoFragment.ascx.cs" Inherits="UIControls_VideoFragment" %>
<table border="0">
    <tr>
        <td>
            <asp:PlaceHolder ID="phPlayer" runat="server"></asp:PlaceHolder>
        </td>
        <td valign="top">
            <table border="0" class="tblVideo">
                <tr>
                    <td><asp:Label ID="lbLabelTitle" runat="server" Text="Title: "></asp:Label></td>
                    <td><asp:Label ID="lbTitle" runat="server"></asp:Label></td>
                </tr>
                <tr id="trAuthor" runat="server" visible="false">
                    <td><asp:Label ID="lbLabelAuthor" runat="server" Text="Author: "></asp:Label></td>
                    <td>
                        <asp:HyperLink ID="hlAuthor" runat="server"></asp:HyperLink>
                    </td>
                </tr>    
                <tr id="trBand" runat="server" visible="false">
                    <td><asp:Label ID="lbLabelBand" runat="server" Text="Band: "></asp:Label></td>
                    <td>
                        <asp:Label ID="lbBand" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="trStyle" runat="server" visible="false">
                    <td><asp:Label ID="lbLabelStyle" runat="server" Text="Style: "></asp:Label></td>
                    <td>
                        <asp:Label ID="lbStyle" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="trLang" runat="server" visible="false">
                    <td><asp:Label ID="lbLabelLanguage" runat="server" Text="Language: "></asp:Label></td>
                    <td>
                        <asp:Label ID="lbLang" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr id="trMore" runat="server">
        <td colspan="2">
            <asp:HyperLink CssClass="csVideoNavigate" ID="hlMore" runat="server">More...</asp:HyperLink>
        </td>
    </tr>
</table>
