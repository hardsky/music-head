<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Rating.ascx.cs" Inherits="UIControls_Rating" %>
<table border="0">
    <tr>
        <td>
            <span style="display: block;"><asp:Label ID="lbRating" runat="server" Text="Rating:"></asp:Label>&nbsp;<asp:Label ID="lbRateNum"
                runat="server"></asp:Label></span>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnPlus" runat="server" Text="+" onclick="btnPlus_Click" />
            <asp:Button ID="btnMinus" runat="server" Text="-" onclick="btnMinus_Click" />
        </td>
    </tr>
</table>