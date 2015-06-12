<%@ Page Title="My Looking For Band" Language="C#" MasterPageFile="~/MasterPageMy.master" AutoEventWireup="true" CodeFile="MyLFB.aspx.cs" Inherits="MyLFB" %>

<%@ Register src="UIControls/MyLFBDetails.ascx" tagname="MyLFBDetails" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MyHead" Runat="Server">
    <link charset="utf8" href="http://localhost:1994/web/styles/base_art_style.css" type="text/css" rel="Stylesheet" />
    <link charset="utf8" href="http://localhost:1994/web/styles/filter_style.css" type="text/css" rel="Stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MyCenterColumn" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<table border="0" cellspacing="0" cellpadding="0" width="100%">
    <tr>
        <td style="padding-bottom: 10px;">
            <asp:Label ID="lbPageNotice" runat="server">Entries on this page indicate, that you want to join a band(s).
            </asp:Label>
        </td>
    </tr>
    <tr>
        <td style="padding-bottom: 10px;">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:Repeater ID="rpSeachedBands" runat="server">
                        <HeaderTemplate>
                            <table width="100%" id="tblLooking" border="1" class="tblGridTable">
                            <thead>
                                <tr class="tblGridTable_Header">
                                    <th>
                                    </th>
                                    <th>
                                        <asp:Label ID="lbHeaderLooking" runat="server" Text="Role in Band"></asp:Label>
                                    </th>
                                    <th>
                                        <asp:Label ID="lbHeaderComment" runat="server" Text="Comment"></asp:Label>
                                    </th>                            
                                </tr>
                            </thead>
                            <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>                
                                <tr class="tblGridTable_Row">
                                    <td>
                                        <asp:CheckBox ID="cbSelected" runat="server" />
                                        <asp:HiddenField ID="hdId" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "Id")%>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="lbLookingFor" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "LookingFor")%>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbComment" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Comment")%>'></asp:Label>
                                    </td>
                                </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnDelete" />
                </Triggers>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
            <asp:Button ID="btnDelete" runat="server" Text="Delete" Visible="false" 
                onclick="btnDelete_Click" />
            <asp:Button ID="btnAdd" runat="server" Text="Add" 
        onclick="btnAdd_Click" />
            <table id="tblDetails" runat="server" visible="false">
                <tr>
                    <td style="padding-bottom: 10px;">
                   
                        <uc1:MyLFBDetails ID="ctrDetails" runat="server" />
                    
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                            onclick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnAdd" />
        <asp:PostBackTrigger ControlID="btnSave" />
        <asp:PostBackTrigger ControlID="btnCancel" />
    </Triggers>
    </asp:UpdatePanel>
        </td>
    </tr>
</table>
</asp:Content>

