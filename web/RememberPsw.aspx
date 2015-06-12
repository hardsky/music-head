<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RememberPsw.aspx.cs" Inherits="RememberPsw" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link charset="utf8" href="http://localhost:1994/web/styles/base_simple_style.css" type="text/css" rel="Stylesheet" />
     <link charset="utf8" href="http://localhost:1994/web/styles/filter_style.css" type="text/css" rel="Stylesheet" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="centerColumn" Runat="Server">
<table>
    <tr>
        <td>
            <asp:Label ID="lbLabelEmail" runat="server" Text="E-mail:"></asp:Label>
        </td>
        <td>
            <div class="csFilterInput">
                <div>
                    <div>
                        <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbEmail" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:Label
                    ID="lblEmailErr" runat="server" Visible="false" ForeColor="Red" Text="* Ошибка в email"></asp:Label>                
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lbLabelPsw" runat="server" Text="Новый пароль:"></asp:Label>
        </td>
        <td>
            <div class="csFilterInput">
                <div>
                    <div>
                        <asp:TextBox ID="tbPsw" TextMode="Password" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbPsw" ErrorMessage="*"></asp:RequiredFieldValidator>
        </td>
    </tr>   
    <tr>
        <td>
            <asp:Label ID="lbLabelPswRepeat" runat="server" Text="Подтвердить пароль:"></asp:Label>
        </td>
        <td>
            <div class="csFilterInput">
                <div>
                    <div>
                        <asp:TextBox ID="tbPswRepeat" TextMode="Password" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <asp:RequiredFieldValidator
                ID="rfvPswRepeat" runat="server" ControlToValidate="tbPswRepeat" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:Label
                    ID="lblErrNotice" runat="server" Visible="false" ForeColor="Red" Text="* Ошибка при повторе пароля"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Button ID="btnSend" runat="server" Text="Отправить!" 
                onclick="btnSend_Click" />
        </td>
    </tr>
</table>
</asp:Content>

