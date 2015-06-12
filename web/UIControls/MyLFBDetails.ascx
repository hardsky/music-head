<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MyLFBDetails.ascx.cs" Inherits="UIControls_MyLFBDetails" %>
<table>
    <tr>
        <td>
            <table cellpadding="5">
                <tr>
                    <td>
                        <asp:Label ID="lbLabelLang" runat="server" Text="Language: "></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lbLang" runat="server" Text="[not defined on user page]"></asp:Label>
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
                        <asp:Label ID="lbLabelLooking" runat="server" Text="Role in Band: "></asp:Label>
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
                    <td>
                        <asp:Label ID="lbLabelStyle" runat="server" Text="Style:"></asp:Label>
                    </td>
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
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lbLabelComment" runat="server" Text="Comment: "></asp:Label><br />                                            
            <asp:TextBox ID="tbComment" TextMode="MultiLine" runat="server"></asp:TextBox>
        </td>                                        
    </tr>
</table>
