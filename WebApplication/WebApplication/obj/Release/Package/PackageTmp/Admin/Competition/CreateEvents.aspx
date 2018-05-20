<%@ Page Title="Rungčių redagavimas" Language="C#" AutoEventWireup="true" Culture="lt-LT" UICulture="lt-LT" MasterPageFile="~/Site.Master" CodeBehind="~/Admin/Competition/CreateEvents.aspx.cs" Inherits="WebApplication.Admin.Competition.CreateEvents" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    <asp:Content runat="server" ID="CreateEventsContent" ContentPlaceHolderID="MainContent">
        <h2><%: Title %>.</h2>

        <style type="text/css">
        /* Style the tab */
                .tab {
                    overflow: hidden;
                    border: 1px solid #ccc;
                    background-color: #f1f1f1;
                }

                /* Style the buttons that are used to open the tab content */
                .tab button {
                    background-color: inherit;
                    float: left;
                    border: none;
                    outline: none;
                    cursor: pointer;
                    padding: 14px 16px;
                    transition: 0.3s;
                }

                /* Change background color of buttons on hover */
                .tab button:hover {
                    background-color: #ddd;
                }

                /* Create an active/current tablink class */
                .tab button.active {
                    background-color: #ccc;
                }

                /* Style the tab content */
                .tabcontent {
                    display: none;
                    padding: 6px 12px;
                    border: 1px solid #ccc;
                    border-top: none;
                }

                .table-striped > tbody > tr:nth-child(2n+1) > td, .table-striped > tbody > tr:nth-child(2n+1) > th {
                background-color: #4A4A4A;
                }
                .tableFormat{
                    border-color: black;
                }
                .tableRound {
                border-radius: 4px;
                }
                .table-hover tbody tr:hover td, .table-hover tbody tr:hover th {
                  background-image:url(/Image/darken-40.png);
                }
                .table-curved {
                  border-collapse: collapse;
                 /*margin-left: 10px;*/
                }
                .table-curved th {
                  padding: 3px 10px;
                }
                .table-curved td {
                  position: relative;
                  padding: 6px 10px;
                  border-bottom: 2px solid white;
                  border-top: 2px solid white;
                }
                .errorMsg{
                    color: red;
                    font-size: small
                }
                .errorMsg2{
                    margin-left: 30%;
                    margin-right: 1%;
                }
                .selectAllPos{
                  float: left;
                  margin-left: 2px;
                }
                .buttonPos{
                  float: right;
                  margin-right: 2px;
                }
                .rbl input[type="radio"]
                {
                    margin-left: 10px;
                    margin-right: 1px;
                }
                .dateBorder{
                    border-color: black;
                }
                .formatText{
                    display: inline-block;
                    width: 160px;
                    text-align: right;
                }
                    
                .noBorder{
                border-right: none;
                }
                .modalBackground 
                {
                    height:100%;
                    background-color:#EBEBEB;
                    filter:alpha(opacity=70);
                    opacity:0.7;
                }
                .template-checkbox {
                text-align:center;
                }
                .centerElement{
                    margin-left: 30%;
                    margin-right: 30%;
                }
                .navTabFormat{
                    border-radius: 0px;
                    padding: 0px;
                }
        </style>

        <script type="text/javascript">
         function defaultTabOpen() {
            document.getElementById('defaultTab').click();
         }
         </script>            
        
        <script type="text/javascript">
            function selectAllGroups() {
                var grid = document.getElementById("<%=AgeGroupsGridView.ClientID%>");
                for (var i = 1; i < grid.rows.length; i++) {
                    var cell = grid.rows[i].cells[0];
                    for (j = 0; j < cell.childNodes.length; j++) {
                        if (cell.childNodes[j].type == "checkbox") {                                    
                            cell.childNodes[j].checked = true;
                            }
                    }
                }
            }
        </script>

        <script type="text/javascript">

                function openLink(evt, tabName) {
                    // Declare all variables
                    var i, tabcontent, tablinks;

                    // Get all elements with class="tabcontent" and hide them
                    tabcontent = document.getElementsByClassName("tabcontent");
                    for (i = 0; i < tabcontent.length; i++) {
                        tabcontent[i].style.display = "none";
                    }

                    // Get all elements with class="tablinks" and remove the class "active"
                    tablinks = document.getElementsByClassName("tablinks");
                    for (i = 0; i < tablinks.length; i++) {
                        tablinks[i].className = tablinks[i].className.replace(" active", "");
                    }

                    // Show the current tab, and add an "active" class to the button that opened the tab
                    document.getElementById(tabName).style.display = "block";
                    evt.currentTarget.className += " active";
                }
        </script>

        <script type="text/javascript">
                function onKeyDownComp() {
                    if (event.keyCode == 13) {
                        event.preventDefault();
                        document.getElementById("<%=edit_btn.ClientID%>").click();
                    }
                }
        </script>

        <script type="text/javascript">
                function onKeyDownComp() {
                    if (event.keyCode == 13) {
                        event.preventDefault();
                        document.getElementById("<%=submit_btn.ClientID%>").click();
                    }
                }
        </script>

        <h4>Rungčių redagavimas ir kūrimas</h4>
        <div>
               <asp:ScriptManager EnableScriptGlobalization="true" runat="server"></asp:ScriptManager>
               <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="table table-curved table-hover table-striped text-codemess table-dark noBorder" BackColor="Gray" BorderColor="black" ForeColor="white" GridLines="Horizontal" DataKeyNames="Id"  OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging">
                    <PagerStyle BackColor="#4A4A4A" ForeColor="Black" HorizontalAlign="Center" Font-Bold="True"  />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" SelectText="Pasirinkti" ControlStyle-CssClass="btn btn-success" />
                        <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" />
                        <asp:BoundField DataField="Title" HeaderText="Pavadinimas" />
                        <asp:BoundField DataField="Type" HeaderText="Tipas" />
                    </Columns>
                </asp:GridView>
                <div>
                    <asp:Button ID="addEvent_btn" runat="server" OnClick="addEvent_btn_Click" class="btn btn-default" Text="Pridėti" />
                </div>

                <cc1:ModalPopupExtender ID="popupAdd" runat="server"
                        TargetControlID="fake"
                        PopupControlID="PanelAdd"
                        DropShadow="false"
                        >
                 </cc1:ModalPopupExtender>

                <asp:LinkButton ID="fake" runat="server"></asp:LinkButton>
        
                    <asp:Panel ID="PanelAdd" runat="server" style='position:relative; display: none; min-height:60%; min-width:30%; height:auto; width:auto' BorderWidth="5px" HorizontalAlign="center" BackColor="#484848" BorderColor="#33CCFF" ForeColor="White" CssClass=" alert-secondary">
                        <asp:UpdatePanel ID="UpdatePanelAdd" runat="server">
                            <ContentTemplate>
                                <div>
                                    <!-- Tab links -->
                                    <ul class="nav nav-tabs navTabFormat">
                                      <li class="nav-item"><a class="nav-link active" data-toggle="tab" onclick="openLink(event, 'creation')" id="defaultTab">Rungtis</a></li>
                                      <li class="nav-item"><a class="nav-link active" data-toggle="tab" onclick="openLink(event, 'ageGroupsAdd')">Amžiaus grupės</a></li>
                                    </ul>
                                    
                                    <!-- Tab content -->
                                    <div class="tab-content" id="myTabContent1">
                                    <div id="creation" class="tabcontent show active" style="border:none">
                                        <h3>Pridėti rungtį</h3>
                                            <div>
                                                <label id="addName_lbl">Rungties pavadinimas</label>
                                                <asp:TextBox ID="addName_tb" runat="server" onkeydown="return onKeyDownComp()"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="addNameValidator" runat="server" ControlToValidate="addName_tb" ValidationGroup="addPopup" ErrorMessage="Įveskite pavadinimą"></asp:RequiredFieldValidator>
                                            </div>
                                            <div>
                                                <label id="selectType_lbl">Pasirinkite rungties tipą</label>
                                                <asp:DropDownList ID="addType_dropDownList" runat="server" DataValueField="Id" DataTextField="Name">
                                                </asp:DropDownList>

                                            </div>
                                    </div>

                                        

                                    <div id="ageGroupsAdd" class="tabcontent" style="border:none">
                                        <h3>Priskirti amžiaus grupes</h3>
                                           <div>
                                               <a onclick="defaultTabOpen()" class="btn btn-outline-info">Priskirti</a>
                                               <a onclick="selectAllGroups()" class="btn btn-outline-info">Pasirinkti visas</a>
                                            </div>
                                            <div>
                                                <asp:GridView ID="AgeGroupsGridView" runat="server" AutoGenerateColumns="False" CssClass="table table-curved table-hover table-striped text-codemess table-dark " BackColor="Gray" BorderColor="black" ForeColor="white">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="checkBox" runat="server" AutoPostBack="false"/>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="Type" HeaderText="Pavadinimas" />
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div>
                            <br />
                            <asp:Button ID="submit_btn" runat="server" Text="Pridėti" CausesValidation="true" Visible="false" ValidationGroup="addPopup" CssClass="btn" OnClick="submit_btn_Click"/>
                            <asp:Button ID="edit_btn" runat="server" Text="Pakeisti" CausesValidation="true" Visible="false" ValidationGroup="addPopup" CssClass="btn" OnClick="edit_btn_Click"/>
                            <asp:Button ID="cancel_btn" runat="server" Text="Atšaukti" CssClass="btn" OnClick="cancel_btn_Click"/>
                            <br />
                            <br />
                         </div>
                    </asp:Panel>
        </div>
    </asp:Content>
