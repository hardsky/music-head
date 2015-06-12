<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Finder.ascx.cs" Inherits="UIControls_Finder" %>
<div class="dvFilter">
<table>
    <tr>
        <td>
            <asp:Label ID="lbLabelTitle" runat="server" Text="Title: "></asp:Label>
        </td>
        <td>
            <div class="csFilterInput">
                <div>
                    <div>
                        <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
        </td>
        <td style="width: 200px; font-size: 11px;">
            <asp:Label ID="lbLabelTitleNote" runat="server" Text="*You can specify 'part' of title. For an example, 'Very*' for search 'Very Cool Title'."></asp:Label>
        </td>
    </tr>
    <tr id="trAuthor" visible="false" runat="server">
        <td>
            <asp:Label ID="lbLabelAuthor" runat="server" Text="Author: "></asp:Label>
        </td>
        <td>
            <div class="csFilterInput">
                <div>
                    <div>
                        <asp:TextBox ID="tbAuthor" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
        </td>
        <td style="width: 200px; font-size: 11px;">
            <asp:Label ID="lbLabelAuthorNote" runat="server" Text="*Can specify 'part' of name."></asp:Label>
        </td>
    </tr>
    <tr id="trBand" visible="false" runat="server">
        <td>
            <asp:Label ID="lbLabelBand" runat="server" Text="Band: "></asp:Label>
        </td>
        <td>
            <div class="csFilterInput">
                <div>
                    <div>
                        <asp:TextBox ID="tbBand" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
        </td>
        <td style="width: 200px; font-size: 11px;">
            <asp:Label ID="lbLabelBandNote" runat="server" Text="*Can specify 'part' of name."></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lbLabelStyle" runat="server" Text="Style: "></asp:Label>
        </td>
        <td>
            <div class="csFilterInput">
                <div>
                    <div>
                        <asp:TextBox ID="tbStyle" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lbLabelLanguage" runat="server" Text="Language: "></asp:Label>
        </td>
        <td>
            <div class="csFilterInput">
                <div>
                    <div>
                        <asp:TextBox ID="tbLang" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td colspan="3">
            <asp:Button ID="btnFind" runat="server" Text="Find!" onclick="btnFind_Click" />
        </td>
    </tr>
</table>
</div>
