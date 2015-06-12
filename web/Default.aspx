<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageDefaultPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register src="UIControls/UserLogin.ascx" tagname="UserLogin" tagprefix="uc1" %>
<%@ Register src="UIControls/ChartsControl.ascx" tagname="ChartsControl" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link charset="utf8" href="http://localhost:1994/web/styles/defaultpage_style.css" type="text/css" rel="Stylesheet" />
</asp:Content>

<asp:Content ID="ContentLeft" ContentPlaceHolderID="leftColumn" runat="server">
    <uc1:UserLogin ID="UserLogin1" runat="server" />    
    <div id="dvAfishaDefaultPage">
        <h3 class="csLeftH"><asp:Label ID="lbLabelAfisha" runat="server">Афиша</asp:Label></h3>
        
        <div class="csLeftTodayEvent">
            <h5><asp:Label ID="lbLabelToday" runat="server">СЕГОДНЯ</asp:Label></h5>
            <asp:Repeater ID="rpAfishaNow" runat="server" 
                onitemdatabound="rpAfishaNow_ItemDataBound">
                <ItemTemplate>
                    <div>
                        <asp:HyperLink ID="hlNowWho" runat="server"></asp:HyperLink>
                    </div>
                    <div>
                        <asp:Label ID="lbNowEvent" runat="server"></asp:Label>
                    </div>
                </ItemTemplate>
                <SeparatorTemplate>
                    <br />
                </SeparatorTemplate>
            </asp:Repeater>
        </div>
        <asp:Repeater ID="rpAfisha" runat="server" 
            onitemdatabound="rpAfisha_ItemDataBound">
            <ItemTemplate>
                <div class="csLeftDate">
                    <asp:Label ID="lbAfishaDate" runat="server"></asp:Label>
                </div>
                <div class="csLeftContent">
                    <asp:HyperLink ID="hlWho" runat="server"></asp:HyperLink>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>    
</asp:Content>

<asp:Content ID="ContentCenter" ContentPlaceHolderID="centerColumn" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<div class="dvSiteNews">
    <h2 id="hSiteNewsTitle" class="csCenterH" runat="server"><span>Jjlkjldsj skhfskhf<span> reitoiut!</span></span></h2>
    <div id="dvSiteNewsImg" class="csCenterMaskot" runat="server">
   </div>
    <div id="dvSiteNewsText" class="csCenterContent" runat="server">
    </div>
    <div class="csInfoLabel">
        <div>
            <div>
                Добавил <span><asp:HyperLink ID="hlSiteNewsAuthor" runat="server"></asp:HyperLink></span> Комментариев: 
                <asp:HyperLink ID="hlComment" runat="server">0</asp:HyperLink>
            </div>
        </div>
    </div>    
</div>
<div class="csCenterChart">
    <uc2:ChartsControl ID="ChartsControl1" runat="server" />
</div>    
</asp:Content>

<asp:Content ID="ContentRight" ContentPlaceHolderID="rightColumn" Runat="Server">
<div class="csRightNews">
    <h3 class="csRightH"><asp:Label ID="lbLabelNews" runat="server">Новости</asp:Label></h3>
    <asp:Repeater ID="rpNews" runat="server" onitemdatabound="rpNews_ItemDataBound">
        <ItemTemplate>
            <div class="csRightDate">
                <asp:Label ID="lbNewsDate" runat="server"></asp:Label>
            </div>
            <div class="csRightContent">
                <asp:Label ID="lbNewsText" runat="server"></asp:Label>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
</asp:Content>
