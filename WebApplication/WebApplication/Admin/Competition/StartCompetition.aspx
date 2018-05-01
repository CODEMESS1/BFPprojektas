<%@ Page Language="C#" AutoEventWireup="true" Culture="lt-LT" UICulture="lt-LT" MasterPageFile="~/Site.Master" CodeBehind="StartCompetition.aspx.cs" Inherits="WebApplication.Admin.Competition.StartCompetition" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content runat="server" ID="CreateEventsContent" ContentPlaceHolderID="MainContent">
      
        <asp:ScriptManager EnableScriptGlobalization="true" runat="server"></asp:ScriptManager>
    <style>
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
    </style>

        <cc1:ModalPopupExtender ID="SelectPopup" runat="server"
                TargetControlID="fake"
                PopupControlID="SelectPanel"
                DropShadow="false"
                BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>

        <asp:LinkButton ID="fake" runat="server"></asp:LinkButton>

        <asp:Panel ID="SelectPanel" runat="server" style='position:relative; display: none; min-height:60%; min-width:30%; height:auto; width:auto' BorderWidth="5px" HorizontalAlign="center" BackColor="#484848" BorderColor="#33CCFF" ForeColor="White" CssClass=" alert-secondary">
            <asp:UpdatePanel runat="server" UpdateMode="Conditional">
            <ContentTemplate>
            <asp:GridView ID="CompetitionsGridView"  runat="server" AllowPaging="true" OnPageIndexChanging="CompetitionsGridView_PageIndexChanging" OnSelectedIndexChanged="CompetitionsGridView_SelectedIndexChanged" CssClass="table table-curved table-hover table-striped text-codemess table-dark noBorder" BackColor="Gray" BorderColor="black" ForeColor="white" GridLines="Horizontal">
                 <Columns>
                    <asp:CommandField ShowSelectButton="True" SelectText="Pasirinkti" ControlStyle-CssClass="btn btn-success" />
                    <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="Name" HeaderText="Pavadinimas" SortExpression="Name" />
                    <asp:BoundField DataField="Location" HeaderText="Vieta" SortExpression="Location" />
                    <asp:BoundField DataField="Address" HeaderText="Adresas" SortExpression="Address" />
                    <asp:BoundField DataField="Date" HeaderText="Data" SortExpression="Date" />
                    <asp:BoundField DataField="RegistrationStartDate" HeaderText="Registracijos pradžia" SortExpression="RegistrationStartDate" />
                    <asp:BoundField DataField="RegistrationEndDate" HeaderText="Registracijos pabaiga" SortExpression="RegistrationEndDate" />
                    <asp:CheckBoxField DataField="Registration" HeaderText="Registracija atidaryta" SortExpression="Registration" />
                </Columns>
            </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
                <asp:Button ID="cancel_btn" runat="server" Text="Place_Holder" OnClick="cancel_btn_Click" CssClass="btn" />
        </asp:Panel>
        
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

        <asp:Panel ID="CompetitionPanel" runat="server">
            <asp:UpdatePanel ID="CompetitionUpdatePanel" runat="server" UpdateMode="Conditional">
                <ContentTemplate>

                    <!-- Tab links -->
                    <ul class="nav nav-tabs navTabFormat">
                        <li class="nav-item"><a  style="display:none" class="nav-link active" data-toggle="tab" onclick="openLink(event, 'default')"  id="defaultLink">Default</a></li>
                        <li class="nav-item"><a  class="nav-link active" data-toggle="tab" onclick="openLink(event, 'generate')">Generate</a></li>
                        <li class="nav-item"><a  class="nav-link active" data-toggle="tab" onclick="openLink(event, 'documents')">Documents</a></li>
                    </ul>

                    <!-- Tab content -->
                    <div class="tab-content" id="myTabContent1" style="height:100%; width: 100%;">
                        <div id="default" class="tabcontent show active" style="border:none">
                            <h2>Default(What for?)</h2>
                        </div>
                        <div id="generate" class="tabcontent show active dropdown" style="border:none">
                            <h2>Generate</h2>
                            <hr>
                            <asp:DropDownList ID="AgeGroup_DropDownList" DataValueField="Type" runat="server" CssClass="btn dropdown-toggle dropdown">
                            </asp:DropDownList>
                            
                             <asp:Button ID="GetCompetitorsInGroup" runat="server" CssClass="btn" Text="Place_Holder"  OnClick="GetCompetitorsInGroup_Click"/>
                            <br />
                            <br />

                            <asp:DropDownList ID="SubgroupsCount" runat="server" CssClass="btn dropdown-toggle">
                                <asp:ListItem Value="1" Text="1 pogrupis"></asp:ListItem>
                                <asp:ListItem Value="2" Text="2 pogrupis"></asp:ListItem>
                                <asp:ListItem Value="3" Text="3 pogrupis"></asp:ListItem>
                                <asp:ListItem Value="4" Text="4 pogrupis"></asp:ListItem>
                                <asp:ListItem Value="5" Text="5 pogrupis"></asp:ListItem>
                                <asp:ListItem Value="6" Text="6 pogrupis"></asp:ListItem>
                            </asp:DropDownList>

                            <asp:GridView ID="CompetitorsGridView" runat="server" PageSize="7" AllowPaging="True" AutoGenerateColumns="False" CssClass="table table-curved table-hover table-striped text-codemess table-dark noBorder" BackColor="Gray" BorderColor="black" ForeColor="white" GridLines="Horizontal">
                                <PagerStyle BackColor="#4A4A4A" ForeColor="Black" HorizontalAlign="Center" Font-Bold="True"  />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" SelectText="Pasirinkti" ControlStyle-CssClass="btn btn-success" />
                                    <asp:BoundField DataField="Name" HeaderText="Pavadinimas" />
                                    <asp:BoundField DataField="Location" HeaderText="Vieta" />
                                    <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" />
                                    <asp:BoundField DataField="Date" HeaderText="Date" />
                                    <asp:BoundField DataField="Address" HeaderText="Adresas" />
                                    <asp:CheckBoxField DataField="Registration" HeaderText="Registracija" ReadOnly="true" />
                                    <asp:BoundField DataField="RegistrationStartDate" HeaderText="Registracijos pradžią" />
                                    <asp:BoundField DataField="RegistrationEndDate" HeaderText="Registracijos pabaiga" />
                                    
                                </Columns>
                            </asp:GridView>

                            <asp:Button ID="GenerateSubGroups" runat="server" Text="Place_Holder" CssClass="btn"  OnClick="GenerateSubGroups_Click"/>
                        </div>
                        <div id="documents" class="tabcontent show active" style="border:none">
                            <h2>Documents</h2>
                            <hr>
                        </div>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>

        <script type="text/javascript">
            document.getElementById('defaultLink').click();
        </script>

</asp:Content>

