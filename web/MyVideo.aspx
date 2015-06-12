<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageMy.master" AutoEventWireup="true" CodeFile="MyVideo.aspx.cs" Inherits="MyVideo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MyHead" runat="server">
    <link charset="utf8" href="http://localhost:1994/web/styles/base_art_style.css" type="text/css" rel="Stylesheet" />
    <link charset="utf8" href="http://localhost:1994/web/styles/grid_style.css" type="text/css" rel="Stylesheet" />
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
    <link charset="utf8" href="styles/styles.css" type="text/css" rel="Stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyCenterColumn" Runat="Server">
    <table>
        <tr>
            <td>
    <asp:GridView ID="gvVideo" runat="server" AutoGenerateColumns="false" 
        onrowdatabound="gvVideo_RowDataBound" DataKeyNames="Id, ImgId, FileName" 
        CssClass="tblGridTable">
        <HeaderStyle CssClass="tblGridTable_Header" />
        <RowStyle CssClass="tblGridTable_Row" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="chSelected" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:PlaceHolder ID="phPlayer" runat="server"></asp:PlaceHolder>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Description" HeaderText="Description" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HyperLink ID="hlGo" runat="server" ImageUrl="~/img/GoLtr.bmp"></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
    <asp:Button ID="btnAdd" runat="server" Text="Add" onclick="btnAdd_Click" />
    <asp:Button ID="btnDelete" runat="server" Text="Delete" onclick="btnDelete_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

