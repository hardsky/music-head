<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageMy.master" AutoEventWireup="true" CodeFile="MyArt.aspx.cs" Inherits="MyArt" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MyHead" Runat="Server">
    <link charset="utf8" href="http://localhost:1994/web/styles/base_art_style.css" type="text/css" rel="Stylesheet" />
    <link charset="utf8" href="http://localhost:1994/web/styles/filter_style.css" type="text/css" rel="Stylesheet" />
    <link charset="utf8" href="http://localhost:1994/web/styles/myart_style.css" type="text/css" rel="Stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MyCenterColumn" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="dvAvatLabel">
        <asp:Label ID="lbLabelAvatar" runat="server" Text="Avatar:"></asp:Label>
    </div>
    <asp:Image ID="imgAvatar" CssClass="csAvatar" runat="server" />
    <div class="dvUpl">
        <asp:FileUpload ID="uplAvatar" runat="server" />
    </div>
	<div class="dvArt">
	    <table border="0" class="tblArt">
	        <tr>
	            <td>
                    <asp:Label ID="lbLabelName" runat="server" Text="Name: "></asp:Label>
	            </td>
	            <td>
<asp:Label ID="lbName" runat="server"></asp:Label>	            
	            </td>
	        </tr>
	        <tr>
	            <td>
                    <asp:Label ID="lbLabelWays" runat="server" Text="Ways in Art: "></asp:Label>
	            </td>
	            <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                        <table>
                            <tr>
                                <td>
                    <asp:GridView ID="gvArtWays" runat="server" 
                        onrowdatabound="gvArtWays_RowDataBound" AutoGenerateColumns="false"
                         DataKeyNames="WayId, WayName" CssClass="tblGridTable">
                <HeaderStyle CssClass="tblGridTable_Header" />
                <RowStyle CssClass="tblGridTable_Row" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbSelect" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="WayName" HeaderText="ѕуть" /> 
                        </Columns>
                    </asp:GridView>
                                </td>
                            </tr>
                            <tr id="trWayDel" runat="server">
                                <td>
                                    <asp:Button ID="btnWayDel" runat="server" Text="Delete" 
                                        onclick="btnWayDel_Click" />
                                </td>
                            </tr>
                            <tr id="trDDWay" runat="server">
                                <td>
                    <div class="csFilterInput">
                        <div>
                            <div>
                    <asp:DropDownList ID="ddWay" runat="server" DataTextField="WayText" DataValueField="WayId">
                    </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                                </td>
                            </tr>
                        </table>
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnAddWay" />
                            <asp:PostBackTrigger ControlID="btnWayDel" />
                        </Triggers>
                    </asp:UpdatePanel>
	            </td>
	        </tr>
	        <tr>
	            <td></td>
	            <td>
                    <asp:Button ID="btnAddWay" runat="server" Text="Add" 
                        onclick="btnAddWay_Click" />
	            </td>	            
	        </tr>
	        <tr>
	            <td>
                    <asp:Label ID="lbLabelInfo" runat="server" Text="My Info: "></asp:Label>
	            </td>
	            <td>
	            </td>
	        </tr>
	    </table>
	    <cc1:Editor ID="ctrEditor" runat="server" />
	    <br />
	<table class="tblArt" border="0">
	    <tr>
	        <td>                
<asp:Label ID="lbLabelCountry" runat="server" Text="Country: "></asp:Label>	        
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
                <asp:Label ID="lbLabelInstrs" runat="server" Text="Musical Instruments: "></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                <asp:GridView ID="gvInst" runat="server" 
                     AutoGenerateColumns="false" DataKeyNames="Id" CssClass="tblGridTable">
                <HeaderStyle CssClass="tblGridTable_Header" />
                <RowStyle CssClass="tblGridTable_Row" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="cbSelect" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Instrument" HeaderText="»нструмент" />
                    </Columns>
                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                <asp:Button ID="btnInstrDel" runat="server" Text="Delete" onclick="btnInstrDel_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                    <div class="csFilterInput">
                        <div>
                            <div>
                                <asp:TextBox ID="tbInstr" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                            </td>
                        </tr>
                    </table>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnAddInstr" />
                        <asp:PostBackTrigger ControlID="btnInstrDel" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnAddInstr" runat="server" Text="Add" 
                    onclick="btnAddInstr_Click" />
            </td>	            
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbLabelStyles" runat="server" Text="Styles: "></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                <asp:GridView ID="gvStyles" runat="server" 
                     AutoGenerateColumns="false" DataKeyNames="Id" CssClass="tblGridTable">
                <HeaderStyle CssClass="tblGridTable_Header" />
                <RowStyle CssClass="tblGridTable_Row" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="cbSelect" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="StyleName" HeaderText="—тиль" />
                    </Columns>
                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            <asp:Button ID="btnStyleDel" runat="server" Text="Delete" 
                                    onclick="btnStyleDel_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                    <div class="csFilterInput">
                        <div>
                            <div>
                                <asp:TextBox ID="tbStyle" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                            </td>
                        </tr>
                    </table>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnAddStyle" />
                        <asp:PostBackTrigger ControlID="btnStyleDel" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnAddStyle" runat="server" Text="Add" 
                    onclick="btnAddStyle_Click" />
            </td>	            
        </tr>        
        <tr>
            <td>
                <asp:Label ID="lbLabelLanguages" runat="server" Text="Languages: "></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                <asp:GridView ID="gvLang" runat="server" 
                     AutoGenerateColumns="false" DataKeyNames="Id" CssClass="tblGridTable">
                <HeaderStyle CssClass="tblGridTable_Header" />
                <RowStyle CssClass="tblGridTable_Row" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="cbSelect" runat="server" />                            
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Language" HeaderText="язык" />
                    </Columns>
                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnLangDel" runat="server" Text="Delete" 
                                    onclick="btnLangDel_Click" />
                            </td>
                        </tr>
                        <tr>
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
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnAddLang" />
                        <asp:PostBackTrigger ControlID="btnLangDel" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnAddLang" runat="server" Text="Add" 
                    onclick="btnAddLang_Click" />
            </td>	            
        </tr>                	    
	    <tr>
	        <td>
                <asp:Label ID="lbLabelTZ" runat="server" Text="Time Zone:"></asp:Label>
	        </td>
	        <td>
                <asp:DropDownList ID="ddTimeZone" runat="server">
                    <asp:ListItem Text="UTC-12" Value="-720" />
                    <asp:ListItem Text="UTC-11" Value="-660" />
                    <asp:ListItem Text="UTC-10" Value="-600" />
                    <asp:ListItem Text="UTC-9" Value="-540" />
                    <asp:ListItem Text="UTC-8" Value="-480" />
                    <asp:ListItem Text="UTC-7" Value="-420" />
                    <asp:ListItem Text="UTC-6" Value="-360" />
                    <asp:ListItem Text="UTC-5" Value="-300" />
                    <asp:ListItem Text="UTC-4:30" Value="-270" />
                    <asp:ListItem Text="UTC-4" Value="-240" />
                    <asp:ListItem Text="UTC-3:30" Value="-210" />
                    <asp:ListItem Text="UTC-3" Value="-180" />
                    <asp:ListItem Text="UTC-2" Value="-120" />
                    <asp:ListItem Text="UTC-1" Value="-60" />
                    <asp:ListItem Text="UTC" Value="0" />
                    <asp:ListItem Text="UTC+1" Value="60" />
                    <asp:ListItem Text="UTC+2" Value="120" />
                    <asp:ListItem Text="UTC+3" Value="180" />
                    <asp:ListItem Text="UTC+3:30" Value="210" />
                    <asp:ListItem Text="UTC+4" Value="240" />
                    <asp:ListItem Text="UTC+4:30" Value="270" />
                    <asp:ListItem Text="UTC+5" Value="300" />
                    <asp:ListItem Text="UTC+5:30" Value="330" />
                    <asp:ListItem Text="UTC+5:45" Value="345" />
                    <asp:ListItem Text="UTC+6" Value="360" />
                    <asp:ListItem Text="UTC+6:30" Value="390" />
                    <asp:ListItem Text="UTC+7" Value="420" />
                    <asp:ListItem Text="UTC+8" Value="480" />
                    <asp:ListItem Text="UTC+9" Value="540" />
                    <asp:ListItem Text="UTC+9:30" Value="570" />
                    <asp:ListItem Text="UTC+10" Value="600" />
                    <asp:ListItem Text="UTC+11" Value="660" />
                </asp:DropDownList>
	        </td>
	    </tr>
	    <tr>
	        <td>
	        </td>
	        <td>
	        </td>
	    </tr>
	</table>    
        <asp:Button ID="btnSave" runat="server" Text="Save" 
        onclick="btnSave_Click" />	
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
        onclick="btnCancel_Click" />	
	</div>
</asp:Content>

