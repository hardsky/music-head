<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Video.aspx.cs" Inherits="Video" %>

<%@ Register src="UIControls/Finder.ascx" tagname="Finder" tagprefix="uc1" %>

<%@ Register src="UIControls/VideoFragment.ascx" tagname="VideoFragment" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link charset="utf8" href="http://localhost:1994/web/styles/base_simple_style.css" type="text/css" rel="Stylesheet" />
    <link charset="utf8" href="http://localhost:1994/web/styles/grid_style.css" type="text/css" rel="Stylesheet" />
    <link charset="utf8" href="http://localhost:1994/web/styles/filter_style.css" type="text/css" rel="Stylesheet" />
    <link charset="utf8" href="http://localhost:1994/web/styles/videoplayer_style.css" type="text/css" rel="Stylesheet" />
    <link charset="utf8" href="http://localhost:1994/web/styles/video_style.css" type="text/css" rel="Stylesheet" />

    <script language="javascript" type="text/javascript" src="Scripts/jquery.pack.js"></script>	
	<script language="javascript" type="text/javascript" src="Scripts/flashembed.min.js"></script>	
	<script language="javascript" type="text/javascript" src="Scripts/flow.embed.js"></script>		
	<script language="javascript" type="text/javascript">	    // this simple call does the magic
	    $(function() {
	        $("a.flowplayer").flowembed("./VideoPlayer/FlowPlayerDark.swf", { initialScale: 'scale' }); 
	        });
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="centerColumn" Runat="Server">
    <div style="width: 100%">
        <uc1:Finder ID="ctrFinder" AddAuthor="true" AddBand="true" runat="server" />
        <asp:GridView ID="gvVideo" runat="server" AutoGenerateColumns="false" 
        onrowdatabound="gvVideo_RowDataBound" GridLines="None" 
            onselectedindexchanging="gvVideo_SelectedIndexChanging">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>

                        <uc2:VideoFragment ID="ctrVideoFrag" runat="server" />
                    
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
