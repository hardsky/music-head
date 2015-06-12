<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ImageCover.ascx.cs" Inherits="UIControls_ImageCover" %>
<tr>
    <td valign="top">
        <asp:Label ID="lbLabelCover" runat="server" Text="Image Cover:"></asp:Label>
    </td>
    <td>
        <asp:Image ID="imgCover" runat="server" ImageUrl="~/img/music_cover.gif" />
    </td>
</tr>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<tr>
    <td></td>
    <td><asp:FileUpload ID="uplImg" runat="server" /><asp:Label ID="lbImgCoverFile" runat="server"></asp:Label>
        </td>
</tr>
    </ContentTemplate>
    <Triggers>
<asp:PostBackTrigger ControlID="btnChangeCover" />        
    </Triggers>
</asp:UpdatePanel>
<tr id="trCoverBtn" runat="server">
    <td colspan="2">
    <asp:Button ID="btnChangeCover" runat="server" Text="Change" onclick="btnChangeCover_Click" 
            />
            <asp:Button
            ID="btnDelete" runat="server" Text="Delete" onclick="btnDelete_Click" />
    </td>
</tr>
