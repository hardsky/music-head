<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Language.ascx.cs" Inherits="UIControls_Language" %>
<div id="dvLanguage">
    <asp:HyperLink ID="hlRu" NavigateUrl="~/?lang=ru" runat="server"><img alt="ru" class="csOddLang" src="http://localhost:1994/web/img/flag_ru.png" /></asp:HyperLink>
    <asp:HyperLink ID="hlEn" NavigateUrl="~/?lang=en" runat="server"><img alt="en" class="csEvenLang" src="http://localhost:1994/web/img/flag_en.png" /></asp:HyperLink>
</div>