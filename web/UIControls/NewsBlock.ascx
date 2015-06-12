<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewsBlock.ascx.cs" Inherits="UIControls_NewsBlock" %>
<table border="0" class="sitenews_block">
    <tr>
        <td>
            <asp:Label ID="lbBody" runat="server" CssClass="sitenews_block_title"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="lbDate" runat="server" CssClass="sitenews_block_date"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:HyperLink ID="lnkGo" runat="server" CssClass="sitenews_block_more">далее...</asp:HyperLink>
        </td>
    </tr>
</table>