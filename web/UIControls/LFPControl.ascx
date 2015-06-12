<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LFPControl.ascx.cs" Inherits="UIControls_LFPControl" %>

<div class="dvHeadChartTable">
    <div>
        <div>
        &nbsp;
        </div>
    </div>
</div>
<div class="dvChartTableDiv">
    <div class="dvLookingNotice">
        <asp:Label ID="lbPageNotice" runat="server">There are signs from bands, that they are looking for people.
        </asp:Label>
    </div>
    <table class="tblLookingFilter">
        <tr>
            <td>
                <asp:Label ID="lbLabelLanguage" runat="server" Text="Language:"></asp:Label>
            </td>
            <td>
                <div class="csFilterInput">
                    <div>
                        <div>
                            <asp:TextBox ID="tbLanguage" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbLabelCountry" runat="server" Text="Country:"></asp:Label>
            </td>
            <td>
                <div class="csFilterInput">
                    <div>
                        <div>
                            <asp:TextBox ID="tbCountry" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbLabelCity" runat="server" Text="City:"></asp:Label>
            </td>
            <td>
                <div class="csFilterInput">
                    <div>
                        <div>
                            <asp:TextBox ID="tbCity" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbLabelLooking" runat="server" Text="Looking For:"></asp:Label>
            </td>
            <td>
                <div class="csFilterInput">
                    <div>
                        <div>
                            <asp:TextBox ID="tbLooking" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnFind" runat="server" Text="Find!" onclick="btnFind_Click" />
            </td>
        </tr>
    </table>
    <asp:GridView ID="gvSearchMembers" runat="server" Width="100%" 
        AutoGenerateColumns="false" 
        onpageindexchanging="gvSearchMembers_PageIndexChanging" 
        onsorting="gvSearchMembers_Sorting" AllowSorting="true" 
        onrowdatabound="gvSearchMembers_RowDataBound" CssClass="tblGridTable">
        <HeaderStyle CssClass="tblGridTable_Header" />
        <RowStyle CssClass="tblGridTable_Row" />
        <Columns>
            <asp:TemplateField HeaderText="Band" SortExpression="bd.Name">
                <ItemTemplate>
                    <a href = '<%# Jam.JamRouteUrl.PickUp("band", this.LangEnum, new System.Collections.Generic.Dictionary<string, string>() { { "name", Eval("BandName").ToString() } })%>'><%# Eval("BandName")%></a>                            
                </ItemTemplate>
            </asp:TemplateField>        
            <asp:BoundField HeaderText="Looking For..." DataField="LookingFor" SortExpression="lp.LookingFor" />
            <asp:BoundField HeaderText="Comment" DataField="Comment" />
            <asp:BoundField HeaderText="Language" DataField="Language" SortExpression="lp.Language" />
            <asp:BoundField HeaderText="Country" DataField="Country" SortExpression="lp.Country" />
            <asp:BoundField HeaderText="City" DataField="City" SortExpression="lp.City" />
            <asp:BoundField HeaderText="Created" DataFormatString="{0:dd.MM.yyyy}" DataField="Created" />
        </Columns>
    </asp:GridView>
</div>
<div class="dvFootChartTable">
    <div>
        <div>
        &nbsp;
        </div>
    </div>
</div>                        
