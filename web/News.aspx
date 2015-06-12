<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="News.aspx.cs" Inherits="News" %>

<%@ Register src="UIControls/NewsBlock.ascx" tagname="NewsBlock" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link charset="utf8" href="http://localhost:1994/web/styles/sitenews_style.css" type="text/css" rel="Stylesheet" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="centerColumn" Runat="Server">
    <div class="ClearFix"></div>
    <h4 id="hLabelSiteNews" class="sitenews_header" runat="server">Новости сайта</h4>
    <asp:GridView ID="gvNews" runat="server" AutoGenerateColumns="false" 
        AllowPaging="true" onpageindexchanging="gvNews_PageIndexChanging" CssClass="tblGridTable" ShowHeader="false" >
                <RowStyle CssClass="tblGridTable_Row" />
        <Columns>        
            <asp:TemplateField>
                <ItemTemplate>
                    <uc1:NewsBlock Title='<%#DataBinder.Eval(Container, "DataItem.Title")%>'
                       Date='<%#DataBinder.Eval(Container, "DataItem.Created")%>' 
                       NewsId='<%#DataBinder.Eval(Container, "DataItem.Id").ToString()%>' 
                     ID="ctrNewsBlock" runat="server" />                    
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

