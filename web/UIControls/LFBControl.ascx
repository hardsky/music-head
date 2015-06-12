<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LFBControl.ascx.cs" Inherits="UIControls_LFBControl" %>
<div class="dvHeadChartTable">
    <div>
        <div>
        &nbsp;
        </div>
    </div>
</div>
<div class="dvChartTableDiv">
    <div class="dvLookingNotice">
        <asp:Label ID="lbPageNotice" runat="server">There are signs from people, that they are looking for band.
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
                <asp:Label ID="lbLabelRole" runat="server" Text="Role in Band:"></asp:Label></td>
            <td>
                <div class="csFilterInput">
                    <div>
                        <div>
                            <asp:TextBox ID="tbRole" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnFind" runat="server" Text="Find!" onclick="btnFind_Click"/>
            </td>
        </tr>
    </table>            
    <asp:GridView ID="gvSearchBand" runat="server" AutoGenerateColumns="false"
     AllowSorting="true" onrowdatabound="gvSearchBand_RowDataBound"
        onsorting="gvSearchBand_Sorting" 
        onpageindexchanging="gvSearchBand_PageIndexChanging" CssClass="tblGridTable">
        <HeaderStyle CssClass="tblGridTable_Header" />
        <RowStyle CssClass="tblGridTable_Row" />
        <Columns>
            <asp:HyperLinkField HeaderText="Artist" DataTextField="ArtName" DataNavigateUrlFields="ArtName" DataNavigateUrlFormatString="~/folks/{0}" />
            <asp:BoundField HeaderText="Role in Band" DataField="LookingFor" SortExpression="LookingFor" />
            <asp:BoundField HeaderText="Style" DataField="Style" SortExpression="Style" />
            <asp:BoundField HeaderText="Comment" DataField="Comment" />
            <asp:BoundField HeaderText="Language" DataField="Language" SortExpression="Language" />
            <asp:BoundField HeaderText="Country" DataField="Country" SortExpression="Country" />
            <asp:BoundField HeaderText="City" DataField="City" SortExpression="City" />
            <asp:BoundField HeaderText="Created" DataField="Created" DataFormatString="{0:dd.MM.yyyy}" />                    
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
