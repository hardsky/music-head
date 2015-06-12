<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreateMessage.aspx.cs" Inherits="CreateMessage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="centerColumn" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<table>
    <tr>
        <td>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lbLabelTo" runat="server" Text="To: "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbTo" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbLabelSubj" runat="server" Text="Subject: "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbSubj" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:Editor ID="ctrEditor" runat="server" />
</td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnSend" runat="server" Text="Send" onclick="btnSend_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                onclick="btnCancel_Click" />
            <asp:Button ID="btnPreview" runat="server" Text="Preview" 
                onclick="btnPreview_Click" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div id="dvPreview" runat="server" visible="false">
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnPreview" />
                </Triggers>
            </asp:UpdatePanel>
        </td>
    </tr>    
</table>
</asp:Content>

