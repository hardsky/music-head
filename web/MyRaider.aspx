<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageMy.master" AutoEventWireup="true" CodeFile="MyRaider.aspx.cs" Inherits="MyRaider" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MyHead" Runat="Server">
    <link charset="utf8" href="http://localhost:1994/web/styles/base_art_style.css" type="text/css" rel="Stylesheet" />
    <link charset="utf8" href="http://localhost:1994/web/styles/grid_style.css" type="text/css" rel="Stylesheet" />
    <link charset="utf8" href="http://localhost:1994/web/styles/filter_style.css" type="text/css" rel="Stylesheet" />
    <script charset="utf8" type="text/javascript">
        function ShowCalendar(e) {
            var evt = window.event || e
            if (evt) {
                if (!evt.target)
                    evt.target = evt.srcElement
                if (evt.target.id == "btnCalend") {
                    var x = evt.clientX;
                    var y = evt.clientY;
                    var oDv = document.getElementById("dvCalend");
                    if (oDv) {
                        oDv.style.visibility = "visible";
                        oDv.style.left = x + 15 + "px";
                        oDv.style.top = y + 10 + "px";
                        if (evt.stopPropagation) //if stopPropagation method supported
                            evt.stopPropagation()
                        else
                            evt.cancelBubble = true
                    }
                }
            }
        }
        function HideCalendar(e) {
            var oDv = document.getElementById("dvCalend");
            if (oDv) {
                oDv.style.visibility = "hidden";
            }
        }
        function StopClick(e) {
            var evt = window.event || e
            if (evt) {
                if (evt.stopPropagation) //if stopPropagation method supported
                    evt.stopPropagation()
                else
                    evt.cancelBubble = true
            }
        }
    </script>     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyRightColumn" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MyCenterColumn" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>    
    <asp:GridView ID="gvAfisha" runat="server" AutoGenerateColumns="false"
        DataKeyNames="Id" CssClass="tblGridTable" 
        onrowdatabound="dvAfisha_RowDataBound">
                <HeaderStyle CssClass="tblGridTable_Header" />
                <RowStyle CssClass="tblGridTable_Row" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="chSelected" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Date" DataField="Event_datetime" />
            <asp:BoundField HeaderText="Title" DataField="Event_name" />
            <asp:BoundField HeaderText="Description" DataField="Description" />
            <asp:TemplateField HeaderText="Who">
                <ItemTemplate>
                    <asp:Label ID="lbWho" runat="server"></asp:Label>
                    <asp:HyperLink ID="hlWho" runat="server">HyperLink</asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:Button ID="btnAdd" runat="server" Text="Add" onclick="btnAdd_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" 
                onclick="btnDelete_Click" />
            <table id="tblEvent" runat="server" visible="false">
                <tr>
                    <td>
                        <asp:Label ID="lbLabelDate" runat="server" Text="Date:"></asp:Label>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lbDate" runat="server" Text="DD.MM.YY"></asp:Label>
                                <img id="btnCalend" alt="Calendar" src="img/Calend.png" />
                                <div id="dvCalend" style="visibility: hidden; position: absolute;">
                                      <asp:Calendar ID="ctrCalendar" runat="server"
                                            onselectionchanged="ctrCalendar_SelectionChanged" >
                                        <DayStyle BackColor="Blue" />
                                        <DayHeaderStyle BackColor="Black" />
                                        <TitleStyle ForeColor="Black" />      
                                      </asp:Calendar>    
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="ctrCalendar" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lbLabelH" runat="server" Text="Hour:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddHour" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lbLabelMin" runat="server" Text="Minute:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddMinute" runat="server">
                                    </asp:DropDownList>                        
                                </td>                                
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbLabelEvent" runat="server" Text="Event:"></asp:Label>
                    </td>
                    <td>
                        <div class="csFilterInput">
                            <div>
                                <div>
                                    <asp:TextBox ID="tbEvent" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbLabelDescr" runat="server" Text="Description:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbDescription" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbCountry" runat="server" Text="Country:"></asp:Label>
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
                        <asp:Label ID="lbCity" runat="server" Text="City:"></asp:Label>
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
                        <asp:Label ID="lbLabelLanguage" runat="server" Text="Language:"></asp:Label>
                    </td>
                    <td>
                        <div class="csFilterInput">
                            <div>
                                <div>
                                    <asp:TextBox ID="tbLanguage" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbLabelWho" runat="server" Text="Who: "></asp:Label>
                    </td>
                    <td>
                        <div class="csFilterInput">
                            <div>
                                <div>
                        <asp:DropDownList ID="ddWho" runat="server" 
                            onselectedindexchanged="ddWho_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                            <table id="tblBand" runat="server" visible="false">
                                <tr>
                                    <td>
                                        <asp:Label ID="lbLabelBand" runat="server" Text="Band:"></asp:Label>
                                    </td>
                                    <td>
                                        <div class="csFilterInput">
                                            <div>
                                                <div>
                                        <asp:DropDownList ID="ddBand" DataTextField="Name" DataValueField="Id" runat="server">
                                        </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="ddWho" />
                            </Triggers>
                        </asp:UpdatePanel>                        
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                            onclick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnAdd" />
            <asp:PostBackTrigger ControlID="btnCancel" />
        </Triggers>
    </asp:UpdatePanel>
    
    <script charset="utf8" type="text/javascript">
        var oBtn = document.getElementById("btnCalend");
        if (oBtn) {
            oBtn.onclick = ShowCalendar;
            var oDvCanc = document.getElementById("dvCalend");
            oDvCanc.onclick = StopClick;
            document.body.onclick = HideCalendar;
        }
    </script>    
</asp:Content>

