<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Forum.aspx.cs" Inherits="Forum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link charset="utf8" href="http://localhost:1994/web/styles/forum_style.css" type="text/css" rel="Stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="centerColumn" Runat="Server">
    <asp:GridView ID="gvForum" runat="server" AutoGenerateColumns="false" 
        Width="100%" onrowdatabound="gvForum_RowDataBound" CssClass="tblGridTable">
                <HeaderStyle CssClass="tblGridTable_Header" />
                <RowStyle CssClass="tblGridTable_Row" />
        <Columns>
            <asp:TemplateField HeaderText="Forums">
                <ItemTemplate>
                    <a href = '<%# Jam.JamRouteUrl.PickUp("forum_sub", this.LangEnum, new System.Collections.Generic.Dictionary<string, string>() { { "subforum_id", Eval("Id").ToString() } })%>'><%# Eval("Subj")%></a>                            
                </ItemTemplate>
            </asp:TemplateField>        
            <asp:BoundField HeaderText="Subjects" DataField="cnt_subj" />
            <asp:BoundField HeaderText="Messages" DataField="cnt_msg" />
            <asp:BoundField HeaderText="Last Message" DataField="last_msg" />
        </Columns>
    </asp:GridView>
</asp:Content>

