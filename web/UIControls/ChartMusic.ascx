<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ChartMusic.ascx.cs" Inherits="UIControls_ChartMusic" %>
<asp:Repeater ID="rpChartMusic" runat="server" 
    onitemdatabound="rpChartMusic_ItemDataBound">
<HeaderTemplate>
    <div class="dvHeadChartTable">
        <div>
            <div>
            &nbsp;
            </div>
        </div>
    </div>
    <div class="dvChartTableDiv">
        <table class="tblChartTable" cellpadding="0" cellspacing="0">
</HeaderTemplate>
<ItemTemplate>
             <tr class="tblChartTable_Row">
                <td>
                    <span>1.</span>
                </td>
                <td>
                    <asp:HyperLink CssClass="csChartTitle" ID="hlRptTitle" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Title")%>' 
                    NavigateUrl='<%#Jam.JamRouteUrl.PickUp("song", this.LangEnum, new System.Collections.Generic.Dictionary<string, string>() { { "song_id", Eval("Id").ToString() } })%>'></asp:HyperLink>
                </td>
                <td>
                    <asp:Label ID="lbLabelRating" runat="server" CssClass="csChartRating">Рейтинг: </asp:Label>
                    <span class="csChartRating">
                    <%#String.Format("{0}",DataBinder.Eval(Container.DataItem, "Rating") != DBNull.Value ? DataBinder.Eval(Container.DataItem, "Rating") : "0")%>
                    </span>                                
                </td>                                    
                <td>
                    <asp:HyperLink ID="hlToPage" NavigateUrl='<%#Jam.JamRouteUrl.PickUp("song", this.LangEnum, new System.Collections.Generic.Dictionary<string, string>() { { "song_id", Eval("Id").ToString() } })%>' 
                    runat="server" CssClass="csChartVote">На страницу</asp:HyperLink>
                </td>                                    
             </tr>
             <tr class="tblChartTable_AltRow">
                <td></td>
                <td colspan="2"> 
                    <asp:HyperLink CssClass="csChartAuth" ID="hlRptBand" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "BandName")%>' 
                    NavigateUrl='<%#Jam.JamRouteUrl.PickUp("band", this.LangEnum, new System.Collections.Generic.Dictionary<string, string>() { { "name", Eval("BandName").ToString() } })%>'></asp:HyperLink> 
                    &nbsp;
                    <asp:HyperLink CssClass="csChartAuth" ID="HyperLink3" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ArtName")%>' 
                    NavigateUrl='<%#Jam.JamRouteUrl.PickUp("folk", this.LangEnum, new System.Collections.Generic.Dictionary<string, string>() { { "name", Eval("ArtName").ToString() } })%>'></asp:HyperLink> 
                </td>
                <td>
                    <asp:HyperLink ID="hlComments" CssClass="csChartSub"
                     NavigateUrl='<%#Jam.JamRouteUrl.PickUp("song", this.LangEnum, new System.Collections.Generic.Dictionary<string, string>() { { "song_id", Eval("Id").ToString() } })%>' runat="server">комментарии</asp:HyperLink>                    
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
    </div>
    <div class="dvFootChartTable">
        <div>
            <div>
            &nbsp;
            </div>
        </div>
    </div>                        
</FooterTemplate>
</asp:Repeater>
