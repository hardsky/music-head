<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MyMenu.ascx.cs" Inherits="UIControls_MyMenu" %>
<div>
    <div class="dvSelectedMenuItem">
        <div>
            <div>
                <asp:HyperLink ID="hlLyrics" runat="server" NavigateUrl="~/MyLyrics.aspx">My Lyrics</asp:HyperLink>    
            </div>
        </div>
    </div>
    <div class="dvMyMenuItem">
        <div>
            <div>
        <asp:HyperLink ID="hlMusic" runat="server" NavigateUrl="~/MyMusic.aspx">My Music</asp:HyperLink>
            </div>
        </div>
    </div>
    <div class="dvMyMenuItem">
        <div>
            <div>
        <asp:HyperLink ID="hlVideo" runat="server" NavigateUrl="~/MyVideo.aspx">My Video</asp:HyperLink>
            </div>
        </div>
    </div>
    <div class="dvMyMenuItem">
        <div>
            <div>
        <asp:HyperLink ID="hlBands" runat="server" NavigateUrl="~/MyBands.aspx">My Bands</asp:HyperLink>
            </div>
        </div>
    </div>
    <div class="dvMyMenuItem">
        <div>
            <div>
        <asp:HyperLink ID="hlInvites" runat="server" NavigateUrl="~/MyInvites.aspx">My Invites</asp:HyperLink>
            </div>
        </div>
    </div>
    <div class="dvMyMenuItem">
        <div>
            <div>
        <asp:HyperLink ID="hlMessages" runat="server" NavigateUrl="~/Messages.aspx">Messages</asp:HyperLink>
            </div>
        </div>
    </div>
    <div class="dvMyMenuItem">
        <div>
            <div>
        <asp:HyperLink ID="hlLFP" runat="server" NavigateUrl="~/MyLFP.aspx">My LFP</asp:HyperLink>
            </div>
        </div>
    </div>
    <div class="dvMyMenuItem">
        <div>
            <div>
        <asp:HyperLink ID="hlLFB" runat="server" NavigateUrl="~/MyLFB.aspx">My LFB</asp:HyperLink>
            </div>
        </div>
    </div>
    <div class="dvMyMenuItem">
        <div>
            <div>
        <asp:HyperLink ID="hlSettings" runat="server" NavigateUrl="~/MyArt.aspx">Settings</asp:HyperLink>
            </div>
        </div>
    </div>
</div>
<div>
    <asp:Button ID="btnLogOut" runat="server" Text="Logout" 
            onclick="btnLogOut_Click" />
</div>
