<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageArt.master" AutoEventWireup="true" CodeFile="Band.aspx.cs" Inherits="Band" %>

<%@ Register src="UIControls/VerticalMenu.ascx" tagname="VerticalMenu" tagprefix="uc2" %>

<%@ Register src="UIControls/VideoFragment.ascx" tagname="VideoFragment" tagprefix="uc3" %>

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

<asp:Content ID="Content3" ContentPlaceHolderID="leftColumn" runat="server">
    <div class="csAvatarBG">
        <div>
            <div>
                <asp:Image ID="imgAvatar" CssClass="csArtAvatar" runat="server" />
            </div>                
        </div>
    </div>
    <uc2:VerticalMenu ID="ctrBandMenu" runat="server" />
    <br />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="centerColumn" Runat="Server">
    <div class="csInfoForm">
        <div>
            <div>
                <a name="info"><asp:Label ID="lbNameTitle" CssClass="csLabel" runat="server" Text="Band Name: "></asp:Label></a>
            </div>
            <div>
                <asp:Label ID="lbName" runat="server"></asp:Label>
            </div>
        </div>
        <div>
            <div>
                <asp:Label ID="lbDescrTitle" CssClass="csLabel" runat="server" Text="Description: "></asp:Label>
            </div>
            <div>
                <asp:Label ID="lbDescr" runat="server"></asp:Label>
            </div>
        </div>
        <div>
            <div>
                <asp:Label ID="lbLabelMembers" CssClass="csLabel" runat="server" Text="Members:"></asp:Label>
            </div>
            <div>
                <asp:GridView ID="gvMembers" runat="server" AutoGenerateColumns="false" CssClass="tblGridTable">
                    <HeaderStyle CssClass="tblGridTable_Header" />
                    <RowStyle CssClass="tblGridTable_Row" />
                    <Columns>
                        <asp:HyperLinkField DataTextField="SiteName" HeaderText="Name" DataNavigateUrlFields="SiteName" DataNavigateUrlFormatString="~/folks/{0}"/>
                        <asp:BoundField DataField="Comment" HeaderText="Comment" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div id="dvMusic" runat="server" visible="false">
            <div>
                <a name="music"><asp:Label ID="lbLabelMusic" CssClass="csLabel" runat="server" Text="Music:"></asp:Label></a>
            </div>
            <div>
                <asp:GridView ID="gvMusic" runat="server" AutoGenerateColumns="false" CssClass="tblGridTable">
                    <HeaderStyle CssClass="tblGridTable_Header" />
                    <RowStyle CssClass="tblGridTable_Row" />
                    <Columns>
                        <asp:HyperLinkField DataTextField="Title" HeaderText="Title" DataNavigateUrlFields="MusicId" DataNavigateUrlFormatString="~/Track.aspx?id={0}"/>
                        <asp:HyperLinkField DataTextField="SiteName" HeaderText="Author" DataNavigateUrlFields="SiteName" DataNavigateUrlFormatString="~/folks/{0}"/>
                        <asp:BoundField DataField="Created" HeaderText="Created" DataFormatString="{0:dd.MM.yyyy}" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div id="dvLyrics" runat="server" visible="false">
            <div>
                <a name="lyrics"><asp:Label ID="lbLabelLyrics" CssClass="csLabel" runat="server" Text="Lyrics:"></asp:Label></a>
            </div>
            <div>
                <asp:GridView ID="gvLyrics" runat="server" AutoGenerateColumns="false" CssClass="tblGridTable">
                    <HeaderStyle CssClass="tblGridTable_Header" />
                    <RowStyle CssClass="tblGridTable_Row" />
                    <Columns>
                        <asp:HyperLinkField DataTextField="Title" HeaderText="Title" DataNavigateUrlFields="id" DataNavigateUrlFormatString="~/Track.aspx?id={0}"/>
                        <asp:HyperLinkField DataTextField="SiteName" HeaderText="Author" DataNavigateUrlFields="SiteName" DataNavigateUrlFormatString="~/folks/{0}"/>
                        <asp:BoundField DataField="Created" HeaderText="Created" DataFormatString="{0:dd.MM.yyyy}" />
                    </Columns>
                </asp:GridView>
            </div>            
        </div>
        <div id="dvVideo" runat="server" visible="false">
            <div>
                <a name="video"><asp:Label ID="lbLabelVideo" CssClass="csLabel" runat="server" Text="Video: "></asp:Label></a>
            </div>
            <div>
                <asp:GridView ID="gvVideo" runat="server" AutoGenerateColumns="false" 
                GridLines="None" ShowHeader="false" 
                    onpageindexchanging="gvVideo_PageIndexChanging" 
                    onrowdatabound="gvVideo_RowDataBound">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                <uc3:VideoFragment ID="ctrVideoFrag" runat="server" />                            
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>                    
            </div>
        </div>        
    </div>
</asp:Content>

