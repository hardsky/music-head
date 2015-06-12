<%@ Page Title="My Looking For People" Language="C#" MasterPageFile="~/MasterPageMy.master" AutoEventWireup="true" CodeFile="MyLFP.aspx.cs" Inherits="MyLFP" %>

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
            <asp:Label ID="lbPageNotice" runat="server">
            You have a band(s) and you are looking for people, which want to join.
            </asp:Label>
        </td>
    </tr>
    <tr>
        <td style="padding-bottom: 10px;">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:Repeater ID="rpSeachedMembers" runat="server">
                        <HeaderTemplate>
                            <table width="100%" id="tblLooking" border="1" class="tblGridTable">
                            <thead>
                                <tr class="tblGridTable_Header">
                                    <th scope="col">
                                    </th>
                                    <th scope="col">
                                        <asp:Label ID="lbHeaderBand" runat="server" Text="Band"></asp:Label>
                                    </th>
                                    <th scope="col">
                                        <asp:Label ID="lbHeaderLooking" runat="server" Text="Looking for.."></asp:Label>
                                    </th>
                                    <th scope="col">
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
                                        <asp:HyperLink ID="hlBand" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "BandName")%>' 
                                         NavigateUrl='~/bands/<%#DataBinder.Eval(Container.DataItem, "BandName")%>'></asp:HyperLink>
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
                    <br />
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" Visible="false" 
                        onclick="btnDelete_Click" />
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnDelete" />
                </Triggers>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr id="trBand" runat="server">
        <td>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lbLabelBand" runat="server" Text="Band:"></asp:Label>
                    </td>
                    <td>
                        <div class="csFilterInput">
                            <div>
                                <div>
                <asp:DropDownList ID="ddBand" runat="server" DataTextField="Name" DataValueField="Id"
                    onselectedindexchanged="ddBand_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </td>
                    <td>
                        <asp:Label ID="lbLabelSelectComment" runat="server" Text="*Select a band."></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table id="tblDetails" runat="server" visible="false">
                        <tr>
                            <td>
                                <asp:Label ID="lbLabelLang" runat="server" Text="Language: "></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbLang" runat="server" Text="[not defined for the band]"></asp:Label>
                                <div class="csFilterInput">
                                    <div>
                                        <div>
                                            <asp:DropDownList ID="ddLangs" runat="server" Visible="false" DataTextField="Language"
                                             DataValueField="Language">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lbLabelCoutry" runat="server" Text="Country: "></asp:Label>
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
                                <asp:Label ID="lbLabelCity" runat="server" Text="City: "></asp:Label>
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
                                <asp:Label ID="lbLabelLooking" runat="server" Text="Looking for: "></asp:Label>
                            </td>
                            <td>
                                <div class="csFilterInput">
                                    <div>
                                        <div>
                                            <asp:TextBox ID="tbLooking" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </td>                                
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lbLabelComment" runat="server" Text="Comment: "></asp:Label><br />                                            
                                <asp:TextBox ID="tbComment" TextMode="MultiLine" runat="server"></asp:TextBox>
                            </td>                                        
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="btnAdd" runat="server" Text="Add" onclick="btnAdd_Click" />
                                &nbsp;
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                                    onclick="btnCancel_Click" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="ddBand" />
                    <asp:PostBackTrigger ControlID="btnCancel" />
                </Triggers>
            </asp:UpdatePanel>
        </td>
    </tr>
</table>
</asp:Content>

