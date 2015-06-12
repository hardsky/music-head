<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageMy.master" AutoEventWireup="true" CodeFile="MySiteLinks.aspx.cs" Inherits="MySiteLinks" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MyCenterColumn" Runat="Server">
	<asp:ScriptManager ID="ScriptManager1" runat="server">
	</asp:ScriptManager>
<asp:GridView ID="gwLinks" runat="server" DataKeyNames="Id" 
        onrowdeleting="gwLinks_RowDeleting" AutoGenerateColumns="false" 
        onrowdatabound="gwLinks_RowDataBound" >
	<Columns>
		<asp:BoundField HeaderText="Url" DataField="url" />
		<asp:BoundField HeaderText="Description" DataField="descr" />
		<asp:BoundField HeaderText="Created" DataField="created" DataFormatString="{0:dd.MM.yyyy}" />
		<asp:CheckBoxField HeaderText="It link on me too" DataField="is_link_on_me" />
		<asp:CheckBoxField HeaderText="Publish" DataField="IsPublished"/>
		<asp:ButtonField HeaderText="Delete" ButtonType=Button CommandName="Delete" />
	</Columns>
</asp:GridView>
	<asp:Button ID="btnAdd" runat="server" Text="Add" onclick="btnAdd_Click" />
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
		<ContentTemplate>
			<table ID="tblLink" runat="server" visible="false">
				<tr>
					<td><asp:Label ID="lblUrl" runat="server" Text="Url:"></asp:Label></td>
					<td>
						<asp:TextBox ID="tbUrl" runat="server"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td><asp:Label ID="lblDescr" runat="server" Text="Description:"></asp:Label></td>
					<td>
						<asp:TextBox ID="tbDescr" runat="server"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td colspan="2">
						<asp:CheckBox ID="cbIsLink" Text="It links to me" runat="server" />
					</td>
				</tr>
				<tr>
					<td colspan="2">
						<asp:CheckBox ID="cbPublish" Text="Publish it" runat="server" />
					</td>
				</tr>
				<tr>
					<td>
						<asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" />
					</td>
					<td>
						<asp:Button ID="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click" />
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
</asp:Content>

