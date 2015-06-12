<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserComments.ascx.cs" Inherits="UIControls_UserComments" %>
<table border="0">
    <tr id="trCom" runat="server">
        <td>
            <asp:Label ID="lbCommentLabel" runat="server" Text="Comments: "></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="gvComments" runat="server" AutoGenerateColumns="false"
             PageSize="20" GridLines="None" onrowdatabound="gvComments_RowDataBound">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Image ID="imgUserPic" CssClass="imgCommentUserPic" runat="server" />
                            <asp:HyperLink ID="hlUser" CssClass="spCommentUserName" runat="server"></asp:HyperLink>
                            
                            <asp:Label ID="lbUserName" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <table border="0" width="100%">
                                <tr>
                                    <td>
                            <asp:Label ID="lbMsg" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <hr />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                            <asp:Label ID="lbMsgHead" runat="server">Posted on</asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
    </tr>
    <tr>        
        <td>
            <asp:TextBox ID="tbNewCommentTxt" TextMode="MultiLine" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnAddComment" runat="server" Text="Add" 
                onclick="btnAddComment_Click" />
        </td>
    </tr>
</table>