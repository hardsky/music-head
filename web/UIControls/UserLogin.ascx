<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserLogin.ascx.cs" Inherits="UIControls_UserLogin" %>
<div class="login_control">
    <asp:Label CssClass="login_auth" ID="lbLabelAuth" runat="server" Text="Authorization"></asp:Label>
    <div style="margin-top: 10px;">
    <asp:Login runat="server" ID="Login1" OnAuthenticate="Login1_Authenticate">
        <LayoutTemplate>
            <div class="csRoundInput">
                <div>
                    <div>
                        <asp:TextBox ontype="if(this.style.backgroundImage!='none'){this.style.backgroundImage='none'}" onclick="this.style.backgroundImage='none'" onblur="if(!this.value || !this.value.length){this.style.backgroundImage='url(./img/email.png)'}" CssClass="login_field" runat="server" ID="UserName"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div style="width: 0px; height: 10px; clear: both;"></div>
            <div class="csRoundInput">
                <div>
                    <div>
                        <asp:TextBox ontype="if(this.style.backgroundImage!='none'){this.style.backgroundImage='none'}" onclick="this.style.backgroundImage='none'" runat="server" CssClass="psw_field" ID="Password" TextMode="Password"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div>
                <asp:CheckBox CssClass="login_reg" ID="RememberMe" Text="Запомнить меня" runat="server" />
            </div>
            <div class="ClearFix"></div>
            <div class="login_btn">                
                <asp:LinkButton ID="lnkLogin" CommandName="Login" runat="server">
                    <asp:Label ID="lbLabelLogin" runat="server">Войти</asp:Label>
                </asp:LinkButton>
                <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Login" ImageUrl="~/img/btn_login.png" />
            </div>
        </LayoutTemplate>
    </asp:Login>
    </div>
    <div class="login_reg">
        <asp:HyperLink ID="hlReg" runat="server" Text="Register!"></asp:HyperLink><br />
        <asp:HyperLink ID="hlForgotPsw" runat="server" Text="Забыли пароль?"></asp:HyperLink>
    </div>
</div>
