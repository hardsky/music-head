<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Charts.aspx.cs" Inherits="Charts" %>

<%@ Register src="UIControls/ChartLyrics.ascx" tagname="ChartLyrics" tagprefix="uc1" %>
<%@ Register src="UIControls/ChartMusic.ascx" tagname="ChartMusic" tagprefix="uc2" %>
<%@ Register src="UIControls/ChartVideo.ascx" tagname="ChartVideo" tagprefix="uc3" %>

<asp:Content ID="Content2" ContentPlaceHolderID="centerColumn" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<table cellspacing="0">
    <tr>
        <td>
            <asp:LinkButton ID="lbtnLyrics" runat="server" onclick="lbtnLyrics_Click">Lyrics</asp:LinkButton>&nbsp;
            <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click">Music</asp:LinkButton>&nbsp;
            <asp:LinkButton ID="lbtnVideo" runat="server" onclick="lbtnVideo_Click">Video</asp:LinkButton>&nbsp;
        </td>
    </tr>
    <tr>
        <td>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <uc1:ChartLyrics ID="ctrLyrics" runat="server" />
                    <uc2:ChartMusic ID="ctrMusic" runat="server" Visible="false" />
                    <uc3:ChartVideo ID="ctrVideo" runat="server" Visible="false" />
                </ContentTemplate>            
            </asp:UpdatePanel>
        </td>
    </tr>
</table>
</asp:Content>
