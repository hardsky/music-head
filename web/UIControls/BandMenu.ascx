<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BandMenu.ascx.cs" Inherits="UIControls_BandMenu" %>
<div>
    <div class="dvSelectedMenuItem">
        <div>
            <div>
                <asp:HyperLink ID="hlLyrics" runat="server" NavigateUrl="~/MyLyrics.aspx">Информация</asp:HyperLink>    
            </div>
        </div>
    </div>
    <div class="dvMyMenuItem">
        <div>
            <div>
        <asp:HyperLink ID="hlMusic" runat="server" NavigateUrl="~/MyMusic.aspx">Музыка</asp:HyperLink>
            </div>
        </div>
    </div>
    <div class="dvMyMenuItem">
        <div>
            <div>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/MyMusic.aspx">Видео</asp:HyperLink>
            </div>
        </div>
    </div>
    <div class="dvMyMenuItem">
        <div>
            <div>
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/MyMusic.aspx">Контакты</asp:HyperLink>
            </div>
        </div>
    </div>
</div>