<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MyBand.ascx.cs" Inherits="UIControls_MyBand" %>
<table class="tblUpAlign">
    <tr>
        <td>
    <asp:Label ID="lbNameTitle" runat="server" Text="Band Name: "></asp:Label>
        </td>
        <td>
            <div id="dvName" runat="server" class="csFilterInput">
                <div>
                    <div>
                        <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <asp:Label ID="lbName" runat="server" Text="Label" Visible="false"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
    <asp:Label ID="lbDescrTitle" runat="server" Text="Description: "></asp:Label>
        </td>
        <td>
            <div class="csFilterInput">
                <div>
                    <div>
                        <asp:TextBox ID="tbDescr" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
        </td>
    </tr>
    <tr>
        <td colspan="2">
    <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="Save" />
    <asp:Button ID="btnCancel" runat="server" onclick="btnCancel_Click" 
        Text="Cancel" />
        </td>
    </tr>       
</table>
<h4>
<asp:Label ID="lbMembersLabel" runat="server" Text="Members:"></asp:Label></h4>
<table>
    <tr>
        <td>
            <asp:GridView ID="gvMembers" runat="server" AutoGenerateColumns="false"
             CssClass="tblGridTable">
             <HeaderStyle CssClass="tblGridTable_Header" />
             <RowStyle CssClass="tblGridTable_Row" />
                <Columns>
                    <asp:HyperLinkField DataTextField="SiteName" HeaderText="Name"/>
                    <asp:BoundField DataField="Comment" HeaderText="Comment" />
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<table>
    <tr id="trInviteBtns" runat="server">
        <td>
            <asp:Button ID="btnAddMember" runat="server" Text="Add" 
                onclick="btnAddMember_Click" />
       </td>
    </tr>
    <tr>
        <td style="padding-top: 15px;">
            <h4><asp:Label ID="lbInvLabel" runat="server" Text="Invited: "></asp:Label></h4>
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="gvInvited" runat="server" AutoGenerateColumns="false"
             DataKeyNames="InvId" CssClass="tblGridTable">
             <HeaderStyle CssClass="tblGridTable_Header" />
             <RowStyle CssClass="tblGridTable_Row" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="cbSelect" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:HyperLinkField DataTextField="Name" DataNavigateUrlFields="Name" DataNavigateUrlFormatString="~/folks/{0}" HeaderText="Name" />
                <asp:BoundField DataField="Msg" HeaderText="Message" />
            </Columns>
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnRemoveInvite" runat="server" Text="Remove" 
                onclick="btnRemoveInvite_Click" Visible="false" />
        </td>
    </tr>
    <tr id="trMemberRecruit" runat="server" visible="false">
        <td>
            <table>
                <tr>
                    <td><asp:Label ID="lbLabelName" runat="server" Text="Name: "></asp:Label></td>
                    <td>
                        <div class="csFilterInput">
                            <div>
                                <div>                    
                                    <asp:TextBox ID="tbMembName" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
        <td><asp:Label ID="lbLabelMsg" runat="server" Text="Message: "></asp:Label></td>
        <td><asp:TextBox ID="tbMsg" runat="server" MaxLength="256" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnInvite" runat="server" Text="Invite" 
                            onclick="btnInvite_Click" />
                            <asp:Button ID="btnInvCancel" runat="server" Text="Cancel" 
                            onclick="btnInvCancel_Click" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnInvite" />
        <asp:PostBackTrigger ControlID="btnInvCancel" />
        <asp:PostBackTrigger ControlID="btnRemoveInvite" />
    </Triggers>
</asp:UpdatePanel>

<h4><asp:Label ID="lbLabelLanguages" runat="server" Text="Languages:"></asp:Label></h4>
<asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="true">
    <ContentTemplate>
<table id="tblLang" runat="server" style="margin-bottom: 15px;">
    <tr>
        <td>
            <asp:GridView ID="gvLangs" runat="server" AutoGenerateColumns="false"
             DataKeyNames="Id" CssClass="tblGridTable">
             <HeaderStyle CssClass="tblGridTable_Header" />
             <RowStyle CssClass="tblGridTable_Row" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="cbSelect" runat="server" />                    
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Language" DataField="Language" />
                </Columns>
            </asp:GridView>
        </td>
    </tr>
    <tr id="trLangDelete" runat="server" visible="false">
        <td>
            <asp:Button ID="btnDeleteLang" runat="server" Text="Delete" 
                onclick="btnDeleteLang_Click" />            
        </td>
    </tr>
    <tr>
        <td>
            <table class="tblUpAlign">
                <tr>
                    <td>
                    <asp:Label ID="lbLabelNewLang" runat="server" Text="New Language:"></asp:Label>
                    </td>
                    <td>
                        <div class="csFilterInput">
                            <div>
                                <div>                    
                <asp:TextBox ID="tbLang" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnAddLang" runat="server" Text="Add" 
                onclick="btnAddLang_Click" />
        </td>
    </tr>
</table>
    </ContentTemplate>
</asp:UpdatePanel>
