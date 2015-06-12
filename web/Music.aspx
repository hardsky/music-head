<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Music.aspx.cs" Inherits="Music" %>

<%@ Register src="UIControls/Finder.ascx" tagname="Finder" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link charset="utf8" href="http://localhost:1994/web/styles/base_simple_style.css" type="text/css" rel="Stylesheet" />
     <link charset="utf8" href="http://localhost:1994/web/styles/grid_style.css" type="text/css" rel="Stylesheet" />
     <link charset="utf8" href="http://localhost:1994/web/styles/filter_style.css" type="text/css" rel="Stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="centerColumn" Runat="Server">
    <uc1:Finder ID="ctrFinder" AddAuthor="true" AddBand="true" runat="server" />
    <asp:GridView ID="gvMusic" runat="server" AutoGenerateColumns="false" onrowdatabound="gvMusic_RowDataBound"
     DataKeyNames="Id" AllowSorting="true" 
        onselectedindexchanging="gvMusic_SelectedIndexChanging" 
        onsorting="gvMusic_Sorting" CssClass="tblGridTable">
        <HeaderStyle CssClass="tblGridTable_Header" />
        <RowStyle CssClass="tblGridTable_Row" />
        <Columns>
            <asp:TemplateField HeaderText="Title">
                <ItemTemplate>
                    <a href = '<%# Jam.JamRouteUrl.PickUp("song", this.LangEnum, new System.Collections.Generic.Dictionary<string, string>() { { "song_id", Eval("Id").ToString() } })%>'><%# Eval ( "Title" )%></a>                            
                </ItemTemplate>
            </asp:TemplateField>                        
            <asp:TemplateField HeaderText="Author">
                <ItemTemplate>
                    <a href = '<%# Jam.JamRouteUrl.PickUp("folk", this.LangEnum, new System.Collections.Generic.Dictionary<string, string>() { { "name", Eval("AuthorName").ToString() } })%>'><%# Eval ( "AuthorName" )%></a>                            
                </ItemTemplate>
            </asp:TemplateField>            
            <asp:TemplateField HeaderText="Band">
                <ItemTemplate>
                    <a href = '<%# Jam.JamRouteUrl.PickUp("band", this.LangEnum, new System.Collections.Generic.Dictionary<string, string>() { { "name", Eval("BandName").ToString() } })%>'><%# Eval ( "BandName" )%></a>                            
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Style" DataField="Style" SortExpression="Style"/>
            <asp:BoundField HeaderText="Language" DataField="Language" SortExpression="Language"/>
            <asp:BoundField HeaderText="Created" DataField="Created" DataFormatString="{0:dd.MM.yyyy}" SortExpression="Created"/>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:PlaceHolder ID="phButtonPlayer" runat="server"></asp:PlaceHolder>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

