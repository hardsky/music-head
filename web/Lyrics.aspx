<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Lyrics.aspx.cs" Inherits="Lyrics" %>

<%@ Register src="UIControls/Finder.ascx" tagname="Finder" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link charset="utf8" href="http://localhost:1994/web/styles/base_simple_style.css" type="text/css" rel="Stylesheet" />
     <link charset="utf8" href="http://localhost:1994/web/styles/grid_style.css" type="text/css" rel="Stylesheet" />
     <link charset="utf8" href="http://localhost:1994/web/styles/filter_style.css" type="text/css" rel="Stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="centerColumn" Runat="Server">
    <uc1:Finder ID="ctrFinder" AddAuthor="true" runat="server" />        
    <asp:GridView ID="gvLirics" runat="server" AutoGenerateColumns="false" 
    onpageindexchanging="gvLirics_PageIndexChanging" onsorting="gvLirics_Sorting" 
        AllowSorting="true" onrowdatabound="gvLirics_RowDataBound" CssClass="tblGridTable">
        <HeaderStyle CssClass="tblGridTable_Header" />
        <RowStyle CssClass="tblGridTable_Row" />
        <Columns>
            <asp:TemplateField HeaderText="Title">
                <ItemTemplate>
                    <a href = '<%# Jam.JamRouteUrl.PickUp("poem", this.LangEnum, new System.Collections.Generic.Dictionary<string, string>() { { "poem_id", Eval("id").ToString() } })%>'><%# Eval ( "Name" )%></a>                            
                </ItemTemplate>
            </asp:TemplateField>            
            <asp:TemplateField HeaderText="Author">
                <ItemTemplate>
                    <a href = '<%# Jam.JamRouteUrl.PickUp("folk", this.LangEnum, new System.Collections.Generic.Dictionary<string, string>() { { "name", Eval("AuthorName").ToString() } })%>'><%# Eval ( "AuthorName" )%></a>                            
                </ItemTemplate>
            </asp:TemplateField>            
            <asp:BoundField HeaderText="Style" DataField="Style" SortExpression="Style"/>
            <asp:BoundField HeaderText="Language" DataField="Language" SortExpression="Language"/>
            <asp:BoundField HeaderText="Created" DataField="Created" DataFormatString="{0:dd.MM.yyyy}" SortExpression="Created"/>
            <asp:BoundField HeaderText="Updated" DataField="Updated" DataFormatString = "{0:dd.MM.yyyy}" SortExpression="Updated"/>
        </Columns>
    </asp:GridView>
</asp:Content>

