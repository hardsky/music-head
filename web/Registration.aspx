<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link charset="utf8" href="http://localhost:1994/web/styles/base_simple_style.css" type="text/css" rel="Stylesheet" />
     <link charset="utf8" href="http://localhost:1994/web/styles/filter_style.css" type="text/css" rel="Stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="centerColumn" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<div style="width: 100%;">
    <table>
        <tr id="trErr" runat="server">
            <td colspan="2">
                <asp:Label ID="lbErr" ForeColor="Red" runat="server"></asp:Label>
            </td>            
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbLabelEmail" runat="server" Text="E-mail: "></asp:Label>
            </td>
            <td>
                <div class="csFilterInput">
                    <div>
                        <div>
                            <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbEmail"
                    ErrorMessage="*" ValidationGroup="gr_reg_page"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbLabelPsw" runat="server" Text="Password: "></asp:Label>
            </td>
            <td>
                <div class="csFilterInput">
                    <div>
                        <div>
                            <asp:TextBox ID="tbPsw" runat="server" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbPsw"
                    ErrorMessage="*" ValidationGroup="gr_reg_page"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbLabelRePsw" runat="server" Text="Retype Password: "></asp:Label>
            </td>
            <td>
                <div class="csFilterInput">
                    <div>
                        <div>
                            <asp:TextBox ID="tbRePsw" runat="server" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbRePsw"
                    ErrorMessage="*" ValidationGroup="gr_reg_page"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbLabelName" runat="server" Text="Site Name: "></asp:Label>
            </td>
            <td>
                <div class="csFilterInput">
                    <div>
                        <div>
                            <asp:TextBox ID="tbSiteName" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbSiteName"
                    ErrorMessage="*" ValidationGroup="gr_reg_page"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true">
                <ContentTemplate>
			    <asp:Image ID="Image1" runat="server" ImageUrl="~/JpegImage.aspx" />
			    <br/>
		        <p>
                    <strong><asp:Label ID="lbLabelCaptcha" runat="server" Text="Enter the code shown above:"></asp:Label></strong><br/>
                    <div class="csFilterInput">
                        <div>
                            <div>
            			        <asp:TextBox id="tbCodeNumberTextBox" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
			        <asp:Button id="btnRefresh" runat="server" Text="Refresh" 
                        onclick="btnRefresh_Click" CausesValidation="false"></asp:Button><br/>
		        </p>
		        <p>
                    <asp:Label ID="lbLabelCaptchaNotice" runat="server">
			        <em>(Note: If you cannot read the numbers in the above<br/>
				        image, click "refresh" button to generate a new one.)</em>
                    </asp:Label>
		        </p>        
                </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnRefresh"/>
                    </Triggers>
                </asp:UpdatePanel>            
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnRegister" runat="server" Text="Register!" 
                    onclick="btnRegister_Click" ValidationGroup="gr_reg_page" />
            </td>
        </tr>
    </table>
</div>
</asp:Content>

