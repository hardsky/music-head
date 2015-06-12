<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageArt.master" AutoEventWireup="true" CodeFile="Art.aspx.cs" Inherits="Jam.Art" %>

<%@ Register src="UIControls/VideoFragment.ascx" tagname="VideoFragment" tagprefix="uc1" %>
<%@ Register src="UIControls/VerticalMenu.ascx" tagname="VerticalMenu" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link charset="utf8" href="http://localhost:1994/web/styles/base_art_style.css" type="text/css" rel="Stylesheet" />
    <link charset="utf8" href="http://localhost:1994/web/styles/videoplayer_style.css" type="text/css" rel="Stylesheet" />
    <link charset="utf8" href="http://localhost:1994/web/styles/video_style.css" type="text/css" rel="Stylesheet" />

    <script language="javascript" type="text/javascript" src="http://localhost:1994/web/Scripts/jquery.pack.js"></script>	
	<script language="javascript" type="text/javascript" src="http://localhost:1994/web/Scripts/flashembed.min.js"></script>	
	<script language="javascript" type="text/javascript" src="http://localhost:1994/web/Scripts/flow.embed.js"></script>		
	<script language="javascript" type="text/javascript">	    // this simple call does the magic
	    $(function() {
	    $("a.flowplayer").flowembed("http://localhost:1994/web/VideoPlayer/FlowPlayerDark.swf", { initialScale: 'scale' });
	    });
	</script>
</asp:Content>
<asp:Content ID="ContentLeft" ContentPlaceHolderID="leftColumn" runat="server">
    <div class="csAvatarBG">
        <div>
            <div>
                <asp:Image ID="imgAvatar" CssClass="csArtAvatar" runat="server" />
            </div>                
        </div>
    </div>
    <uc2:verticalmenu ID="ctrMyMenu" runat="server" Visible="false" />
    <div id="dvLogoutBtn" class="csLogoutBtn" runat="server" visible="false">
        <asp:LinkButton ID="btnLogout" runat="server" onclick="btnLogout_Click">
          <span>Выйти</span><asp:Image ID="Image2" ImageUrl="~/img/btn_logout.png" runat="server" />
        </asp:LinkButton>    
    </div>    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="centerColumn" Runat="Server">
    <div class="csInfoForm">
        <div>
            <div>
               <asp:Label CssClass="lbArtName" ID="lbName" runat="server"></asp:Label>                            
            </div>
        </div>
        <div id="dvWays" runat="server">
            <div>
               <asp:Label ID="lbLabelWays" CssClass="csLabel" runat="server" Text="Ways in Art: "></asp:Label>
            </div>
            <div>
                <asp:Label ID="lbWays" runat="server"></asp:Label>
            </div>
        </div>
        <div id="dvInfo" runat="server">
            <div>
               <asp:Label ID="lbLabelInfo" CssClass="csLabel" runat="server" Text="Info: "></asp:Label>
            </div>
            <div>
                <asp:PlaceHolder ID="phInfo" runat="server"></asp:PlaceHolder>
            </div>
        </div>
        <div id="dvCountry" runat="server">
            <div>
                <asp:Label ID="lbLabelCountry" CssClass="csLabel" runat="server" Text="Country: "></asp:Label>
            </div>
            <div>
                <asp:Label ID="lbCountry" runat="server"></asp:Label>
            </div>
        </div>
        <div id="dvCity" runat="server">
            <div>
                <asp:Label ID="lbLabelCity" CssClass="csLabel" runat="server" Text="City: "></asp:Label>
            </div>
            <div>
                <asp:Label ID="lbCity" runat="server"></asp:Label>
            </div>
        </div>
        <div id="dvInstrs" runat="server">
            <div>
                <asp:Label ID="lbLabelInstrs" CssClass="csLabel" runat="server" Text="Musical Instruments: "></asp:Label>
            </div>
            <div>
                <asp:Label ID="lbInstruments" runat="server"></asp:Label>
            </div>
        </div>
        <div id="dvStyles" runat="server">
            <div>
                <asp:Label ID="lbLabelStyles" CssClass="csLabel" runat="server" Text="Styles: "></asp:Label>
            </div>
            <div>
                <asp:Label ID="lbStyles" runat="server"></asp:Label>
            </div>
        </div>
        <div id="dvLangs" runat="server">
            <div>
                <asp:Label ID="lbLabelLanguages" CssClass="csLabel" runat="server" Text="Languages: "></asp:Label>
            </div>
            <div>
                <asp:Label ID="lbLanguages" runat="server"></asp:Label>
            </div>
        </div>
        <div id="dvLyrics" runat="server">
            <div>
                <asp:Label ID="lbLabelLyrics" CssClass="csLabel" runat="server" Text="Lyrics: "></asp:Label>
            </div>
            <div>
                <div class="dvHeadInformTable">
                    <div>
                        <div>
                        &nbsp;
                        </div>
                    </div>
                </div>
                <div class="dvInformTableDiv">
                    <asp:Repeater ID="rpLyrics" runat="server" 
                        onitemdatabound="rpLyrics_ItemDataBound">
                        <HeaderTemplate>
                            <table class="tblInformTable" cellpadding="0" cellspacing="0">
                                <tr class="tblInformTable_Header">
                                    <td style="width: 25%;">
                                        <asp:Label ID="lbLabelLyricsTitle" runat="server">Название</asp:Label>
                                    </td>
                                    <td style="width: 25%;">
                                        <asp:Label ID="lbLabelLyricsBand" runat="server">Группа</asp:Label>
                                    </td>
                                    <td style="width: 25%;">
                                        <asp:Label ID="lbLabelLyricsStyle" runat="server">Стиль</asp:Label>
                                    </td>
                                    <td style="width: 25%;">
                                        <asp:Label ID="lbLabelLyricsLang" runat="server">Язык</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <div class="dvHeadSeparatorInformTable">
                                        </div>
                                    </td>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                                 <tr class="tblInformTable_Row">
                                    <td>
                                        <a href = '<%# Jam.JamRouteUrl.PickUp("poem", this.LangEnum, new System.Collections.Generic.Dictionary<string, string>() { { "poem_id", Eval("id").ToString() } })%>'><%# Eval ( "Name" )%></a>
                                    </td>
                                    <td> 
                                        <a href = '<%# Jam.JamRouteUrl.PickUp("band", this.LangEnum, new System.Collections.Generic.Dictionary<string, string>() { { "name", Eval("BandName").ToString() } })%>'><%# Eval("BandName")%></a>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbRptStyle" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.Style")%>'></asp:Label>
                                    </td>
                                    <td> 
                                        <asp:Label ID="lbRptLang" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.Language")%>'></asp:Label>
                                    </td>
                                 </tr>
                                 <tr class="tblInformTable_AltRow">
                                    <td colspan="4">
                                        <asp:Label ID="lbRptLyricsCreated" runat="server"></asp:Label>
                                        &nbsp;
                                        &nbsp;
                                        &nbsp;
                                        &nbsp;
                                        &nbsp;
                                        <asp:Label ID="lbRptLyricsUpdated" runat="server"></asp:Label>
                                    </td>
                                 </tr>                                                                     
                        </ItemTemplate>
                        <SeparatorTemplate>
                            <tr>
                                <td colspan="4">
                                    <hr style="height: 0; border-style: dashed; border-width: 1px 0 0 0; border-color: #b2abab;" />
                                </td>
                            </tr>
                        </SeparatorTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>                                
                </div>
                <div class="dvFootInformTable">
                    <div>
                        <div>
                        &nbsp;
                        </div>
                    </div>
                </div>                        
            </div>
        </div>
        <div id="dvMusic" runat="server">
            <div>
                <asp:Label ID="lbLabelMusic" CssClass="csLabel" runat="server" Text="Music: "></asp:Label>
            </div>
            <div>                        
            <div class="dvHeadInformTable">
                <div>
                    <div>
                    &nbsp;
                    </div>
                </div>
            </div>
            <div class="dvInformTableDiv">
                <asp:Repeater ID="rpMusic" runat="server" 
                    onitemdatabound="rpMusic_ItemDataBound" >
                    <HeaderTemplate>
                        <table class="tblInformTable" cellpadding="0" cellspacing="0">
                            <tr class="tblInformTable_Header">
                                <td style="width: 23%;">
                                    <asp:Label ID="lbLabelMusicTitle" runat="server">Название</asp:Label>
                                </td>
                                <td style="width: 23%;">
                                    <asp:Label ID="lbLabelMusicBand" runat="server">Группа</asp:Label>
                                </td>
                                <td style="width: 23%;">
                                    <asp:Label ID="lbLabelMusicStyle" runat="server">Стиль</asp:Label>
                                </td>
                                <td style="width: 23%;">
                                    <asp:Label ID="lbLabelMusicLang" runat="server">Язык</asp:Label>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5">
                                    <div class="dvHeadSeparatorInformTable">
                                    </div>
                                </td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                             <tr class="tblInformTable_Row">
                                <td>
                                    <a href = '<%# Jam.JamRouteUrl.PickUp("song", this.LangEnum, new System.Collections.Generic.Dictionary<string, string>() { { "song_id", Eval("Id").ToString() } })%>'><%# Eval ( "Title" )%></a>                                
                                </td>
                                <td> 
                                    <a href = '<%# Jam.JamRouteUrl.PickUp("band", this.LangEnum, new System.Collections.Generic.Dictionary<string, string>() { { "name", Eval("BandName").ToString() } })%>'><%# Eval ( "BandName" )%></a>
                                </td>
                                <td>
                                    <asp:Label ID="lbRptStyle" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.Style")%>'></asp:Label>
                                </td>
                                <td> 
                                    <asp:Label ID="lbRptLang" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.Language")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:HiddenField ID="hfId" runat="server" Value='<%#DataBinder.Eval(Container, "DataItem.Id")%>' />
                                    <asp:PlaceHolder ID="phButtonPlayer" runat="server"></asp:PlaceHolder>
                                </td>
                             </tr>
                             <tr class="tblInformTable_AltRow">
                                <td colspan="5">
                                    <asp:Label ID="lbRptCreated" runat="server"></asp:Label>
                                    &nbsp;
                                    &nbsp;
                                    &nbsp;
                                    &nbsp;
                                    &nbsp;
                                    <asp:Label ID="lbRptUpdated" runat="server"></asp:Label>
                                </td>
                             </tr>                                                                     
                    </ItemTemplate>
                    <SeparatorTemplate>
                        <tr>
                            <td colspan="5">
                                <hr style="height: 0; border-style: dashed; border-width: 1px 0 0 0; border-color: #b2abab;" />
                            </td>
                        </tr>
                    </SeparatorTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>                                
                </div>
                <div class="dvFootInformTable">
                    <div>
                        <div>
                        &nbsp;
                        </div>
                    </div>
                </div>                        
                                    
            </div>
        </div>
        <div id="dvVideo" runat="server">
            <div>
                <asp:Label ID="lbLabelVideo" CssClass="csLabel" runat="server" Text="Video: "></asp:Label>
            </div>
            <div>
                <asp:GridView ID="gvVideo" runat="server" AutoGenerateColumns="false" 
                GridLines="None" 
                onrowdatabound="gvVideo_RowDataBound" 
                    onpageindexchanging="gvVideo_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>

                                <uc1:VideoFragment ID="ctrVideoFrag" runat="server" />
                            
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>                    
            </div>
        </div>
        <div id="dvBands" runat="server">
            <div>
                <asp:Label ID="lbLabelBands" CssClass="csLabel" runat="server" Text="Bands: "></asp:Label>
            </div>
            <div>                        
                <div class="dvHeadInformTable">
                    <div>
                        <div>
                        &nbsp;
                        </div>
                    </div>
                </div>
                <div class="dvInformTableDiv">
                    <asp:Repeater ID="rpBands" runat="server" 
                        onitemdatabound="rpBands_ItemDataBound" >
                        <HeaderTemplate>
                            <table class="tblInformTable" cellpadding="0" cellspacing="0" width="100%">
                                <tr class="tblInformTable_Header">
                                    <td style="width: 25%;">
                                        <asp:Label ID="lbLabelBandName" runat="server">Название</asp:Label>
                                    </td>
                                    <td style="width: 25%;">
                                        <asp:Label ID="lbLabelBandStyle" runat="server">Стиль</asp:Label>
                                    </td>
                                    <td style="width: 25%;">
                                        <asp:Label ID="lbLabelBandLang" runat="server">Языки</asp:Label>
                                    </td>
                                    <td style="width: 25%;">
                                        <asp:Label ID="lbLabelBandLeader" runat="server">Лидер</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <div class="dvHeadSeparatorInformTable">
                                        </div>
                                    </td>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                                 <tr class="tblInformTable_Row">
                                    <td>
                                        <a href = '<%# Jam.JamRouteUrl.PickUp("band", this.LangEnum, new System.Collections.Generic.Dictionary<string, string>() { { "name", Eval("Name").ToString() } })%>'><%# Eval("Name")%></a>
                                    </td>
                                    <td> 
                                        <asp:Label ID="lbRptStyle" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.Style")%>'></asp:Label>                                            </td>
                                    <td>
                                        <asp:HiddenField ID="hfBandId" runat="server" Value='<%#DataBinder.Eval(Container, "DataItem.BandId")%>' />
                                        <asp:Label ID="lbRptLangs" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <a href = '<%# Jam.JamRouteUrl.PickUp("folk", this.LangEnum, new System.Collections.Generic.Dictionary<string, string>() { { "name", Eval("LeaderName").ToString() } })%>'><%# Eval("LeaderName")%></a>
                                    </td>
                                 </tr>
                        </ItemTemplate>
                        <SeparatorTemplate>
                            <tr>
                                <td colspan="4">
                                    <hr style="height: 0; border-style: dashed; border-width: 1px 0 0 0; border-color: #b2abab;" />
                                </td>
                            </tr>
                        </SeparatorTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>                                
                </div>
                <div class="dvFootInformTable">
                    <div>
                        <div>
                        &nbsp;
                        </div>
                    </div>
                </div>
            </div>
        </div>            
    </div>
</asp:Content>

