<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TabConteinerControl.ascx.cs" Inherits="UIControls_TabConteinerControl" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true">
    <ContentTemplate>
        <div class="csChartMenu">
            <asp:PlaceHolder ID="phMenu" runat="server"></asp:PlaceHolder>
        </div>
        <asp:PlaceHolder ID="phContent" runat="server"></asp:PlaceHolder>
    </ContentTemplate>
</asp:UpdatePanel>
