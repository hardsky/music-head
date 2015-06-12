<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SubForum.aspx.cs" Inherits="SubForum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link charset="utf8" href="http://localhost:1994/web/styles/forum_style.css" type="text/css" rel="Stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="centerColumn" Runat="Server">
    <div class="csForumNav">
        <asp:HyperLink ID="hlForums" runat="server">Forums</asp:HyperLink>/
        <asp:Label ID="lbCurForum" runat="server" Text=""></asp:Label>
    </div>
    <asp:GridView ID="gvForum" runat="server" AutoGenerateColumns="false" 
         onpageindexchanging="gvForum_PageIndexChanging" 
        onrowdatabound="gvForum_RowDataBound" CssClass="tblGridTable">
                <HeaderStyle CssClass="tblGridTable_Header" />
                <RowStyle CssClass="tblGridTable_Row" />
        <Columns>
            <asp:TemplateField HeaderText="Subjects">
                <ItemTemplate>
                    <a href = '<%# Jam.JamRouteUrl.PickUp("forum_sub_subject", this.LangEnum, new System.Collections.Generic.Dictionary<string, string>() { { "subforum_id", Eval("subforum_id").ToString() }, { "subj_id", Eval("subj_id").ToString() } })%>'><%# Eval("Subj")%></a>                            
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Author">
                <ItemTemplate>
                    <a href = '<%# Jam.JamRouteUrl.PickUp("folk", this.LangEnum, new System.Collections.Generic.Dictionary<string, string>() { { "name", Eval("AuthorName").ToString() } })%>'><%# Eval("AuthorName")%></a>
                </ItemTemplate>
            </asp:TemplateField>            
            <asp:BoundField HeaderText="Messages" DataField="cnt_msg" />
            <asp:BoundField HeaderText="Last Message" DataField="Updated" />
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnCreate" runat="server" Text="Create" 
        onclick="btnCreate_Click" />
</asp:Content>

