<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ForumSubj.aspx.cs" Inherits="ForumSubj" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link charset="utf8" href="http://localhost:1994/web/styles/forum_style.css" type="text/css" rel="Stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="centerColumn" Runat="Server">
    <div class="csForumNav">
        <asp:HyperLink ID="hlForums" runat="server">Forums</asp:HyperLink>/
        <asp:HyperLink ID="hlForum" runat="server"></asp:HyperLink>/
        <asp:Label ID="lbSubject" runat="server" Text=""></asp:Label>
    </div>
    <asp:GridView ID="gvSubj" runat="server" AutoGenerateColumns="false" 
        onrowdatabound="gvSubj_RowDataBound" AllowPaging="true" 
        onpageindexchanging="gvSubj_PageIndexChanging" CssClass="tblGridTable">
                <HeaderStyle CssClass="tblGridTable_Header" />
                <RowStyle CssClass="tblGridTable_Row" />
        <Columns>
            <asp:TemplateField HeaderText="Author">
                <ItemTemplate>
                    <asp:Image ID="imgUserPic" CssClass="imgCommentUserPic" runat="server" />
                    <asp:HyperLink ID="hlUser" runat="server"></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Message">
                <ItemTemplate>
                <div style="margin: 3px 3px 3px 3px;">
                    <asp:Label ID="lbMsgHead" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lbMsg" runat="server"></asp:Label>
                    <hr />
                </div>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>    
    </asp:GridView>
    <asp:Button ID="btnAnswer" runat="server" Text="Answer" 
        onclick="btnAnswer_Click" />
</asp:Content>

