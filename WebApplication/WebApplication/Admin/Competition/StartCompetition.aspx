<%@ Page Language="C#" AutoEventWireup="true" Culture="lt-LT" UICulture="lt-LT" MasterPageFile="~/Site.Master" CodeBehind="StartCompetition.aspx.cs" Inherits="WebApplication.Admin.Competition.StartCompetition" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content runat="server" ID="CreateEventsContent" ContentPlaceHolderID="MainContent">
      
    <asp:ScriptManager ID="ScriptManager" EnableScriptGlobalization="true" runat="server"></asp:ScriptManager>
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

        <asp:Panel ID="SelectPanel" runat="server" style='position:relative; min-height:60%; min-width:30%; height:auto; width:auto' BorderWidth="5px" HorizontalAlign="center" BackColor="#484848" BorderColor="#33CCFF" ForeColor="White" CssClass=" alert-secondary">
               <asp:GridView ID="CompetitionsGridView" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="table table-curved table-hover table-striped text-codemess table-dark noBorder" BackColor="Gray" BorderColor="black" ForeColor="white" GridLines="Horizontal" DataKeyNames="Id"  OnSelectedIndexChanged="CompetitionsGridView_SelectedIndexChanged" OnPageIndexChanging="CompetitionsGridView_PageIndexChanging">
                    <PagerStyle BackColor="#4A4A4A" ForeColor="Black" HorizontalAlign="Center" Font-Bold="True"  />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" SelectText="Pasirinkti" ControlStyle-CssClass="btn btn-success" />
                        <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" />
                        <asp:BoundField DataField="Name" HeaderText="Pavadinimas" />
                        <asp:BoundField DataField="Location" HeaderText="Vieta" />
                        <asp:BoundField DataField="Address" HeaderText="Adresas" />
                        <asp:BoundField DataField="Date" HeaderText="Date" />
                        <asp:BoundField DataField="RegistrationStartDate" HeaderText="Registracijos pradžią" />
                        <asp:BoundField DataField="RegistrationEndDate" HeaderText="Registracijos pabaiga" />
                        <asp:CheckBoxField DataField="Registration" HeaderText="Registracija" ReadOnly="true" />
                    </Columns>
                </asp:GridView>
        </asp:Panel>

        <script type="text/javascript">
            function openLink(evt, tabName) {
                var startBtn = document.getElementById('<%=startCompetition_btn.ClientID%>');
                if (startBtn.style.display != "none") {
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
                }
        </script>

        <asp:Panel ID="CompetitionPanel" runat="server" Visible="false">
                    <!-- Tab links -->
                    <ul class="nav nav-tabs navTabFormat">
                        <asp:Button ID="SelectCompetitionBtn" Visible="false" runat="server" Text="Varžybų sąrašas" OnClick="SelectCompetitionBtn_Click" CssClass="nav-link active" />
                        <li class="nav-item"><a  class="nav-link active" data-toggle="tab" onclick="openLink(event, 'generate')" id="defaultLink">Pogrūpiai</a></li>
                        <li class="nav-item"><a  class="nav-link active" data-toggle="tab" onclick="openLink(event, 'documents')">Protokolai</a></li>
                        <li class="nav-item"><a  class="nav-link active" data-toggle="tab" onclick="openLink(event, 'results')" id="startLink">Rezultatų vedimas</a></li>
                    </ul>

                    <!-- Tab content -->
                    <div class="tab-content" id="myTabContent1" style="height:100%; width: 100%;">
                        <div id="generate" class="tabcontent show active dropdown" style="border:none">
                            <h2>Generate</h2>
                            <hr>
                            <asp:DropDownList ID="AgeGroup_DropDownList" DataValueField="Type" runat="server" CssClass="btn dropdown-toggle dropdown">
                            </asp:DropDownList>
                            
                            <br />
                            <br />

                            <asp:DropDownList ID="SubgroupsCount" runat="server" CssClass="btn dropdown-toggle">
                                <asp:ListItem Value="1" Text="1 pogrupis"></asp:ListItem>
                                <asp:ListItem Value="2" Text="2 pogrupiai"></asp:ListItem>
                                <asp:ListItem Value="3" Text="3 pogrupiai"></asp:ListItem>
                                <asp:ListItem Value="4" Text="4 pogrupiai"></asp:ListItem>
                                <asp:ListItem Value="5" Text="5 pogrupiai"></asp:ListItem>
                                <asp:ListItem Value="6" Text="6 pogrupiai"></asp:ListItem>
                            </asp:DropDownList>

                            <br />
                            <br />
                            <asp:Label ID="InformationLabel" runat="server" Text=""></asp:Label>
                            <asp:Panel runat="server" ScrollBars="Vertical">
                            <asp:GridView ID="CompetitorsGridView" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="Gray" BorderColor="black" CssClass="table table-curved table-hover table-striped text-codemess table-dark noBorder" ForeColor="white" GridLines="Horizontal" PageSize="1000">
                                <PagerStyle BackColor="#4A4A4A" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" />
                                <Columns>
                                    <asp:BoundField DataField="Subgroup" HeaderText="Pogrupis" />
                                    <asp:BoundField DataField="Name" HeaderText="Vardas" />
                                    <asp:BoundField DataField="Surname" HeaderText="Pavardė" />
                                    <asp:BoundField DataField="Year" HeaderText="Gimimo metai" />
                                </Columns>
                            </asp:GridView>
                            </asp:Panel>
                            <asp:Button ID="GetCompetitorsInGroup" runat="server" CssClass="btn" Text="Sugeneruoti pogrupius"  OnClick="GetCompetitorsInGroup_Click"/>
                            <asp:Button ID="GenerateSubGroups" runat="server" Text="Išsaugoti" CssClass="btn" OnClick="GenerateSubGroups_Click"/>
                            <asp:Button ID="Button1" runat="server" Text="Atšaukti" CssClass="btn" OnClick="Button1_Click"/>
                        </div>
                        <div id="documents" class="tabcontent show active" style="border:none">
                            <h2>Documents</h2>
                            <hr>
                        </div>
                        <div id="results" class="tabcontent show active" style="border:none">
                            <h2>Rezultatų suvedimas</h2>
                            <div>
                                <label id="start_lbl">Pradėti varžybas?</label>
                                <asp:Button ID="startCompetition_btn" runat="server" Text="Pradėti varžybas" OnClick="startCompetition_Click"/>
                            </div>
                                    <div>
                                        <label>Skaičiuoti rezultatus</label>
                                        <asp:DropDownList ID="CalculateResultsGroup_list" runat="server" DataValueField="Type" AutoPostBack="true" DataTextField="Type" OnSelectedIndexChanged="CalculateResultsGroup_list_SelectedIndexChanged"></asp:DropDownList>
                                        <asp:Button ID="Calculate_btn" runat="server" Text="Skaičiuoti" OnClick="Calculate_btn_Click"/>
                                    </div>
                            <div>
                                <asp:GridView ID="Results_GridView" runat="server" AutoGenerateColumns="false" BackColor="White">
                                    <Columns>
                                        <asp:BoundField DataField="Score" HeaderText="Vieta" />
                                        <asp:BoundField DataField="Points" HeaderText="Taškai" />
                                        <asp:BoundField DataField="Result" HeaderText="Rezultatas" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
        </asp:Panel>

         <div id="ResultsInputContent">
            <asp:Panel ID="ResultsUpdatePanel" runat="server" > 
                
                    <asp:Button ID="saveCompetition_btn" runat="server" CausesValidation="false" Text="Saugoti varžybas" OnClick="saveCompetition_btn_Click" />
                    <label id="save_lbl">Išsaugoti varžybas</label>
                    <div id="select">
                        <label>Pasirinkite grupę</label>
                        <asp:DropDownList ID="selectGroup_list" runat="server" DataValueField="Id" DataTextField="Type"></asp:DropDownList>
                        <asp:Button ID="SelectGroup_btn" runat="server" Text="Pasirinkti" OnClick="SelectGroup_btn_Click" />
                        <label>Pasirinkite rungtį</label>
                        <asp:DropDownList ID="selectEvent_list" DataValueField="Id" DataTextField="Title" runat="server" Enabled="false"></asp:DropDownList>
                        <asp:Button ID="WriteResults_btn" runat="server" OnClick="WriteResults_btn_Click" Text="Vesti rezultatus" Width="166px"/>
                        <br />
                    </div>
                        <div>
                            <label>Įveskite ID</label>
                            <asp:TextBox ID="EnterId_tb" runat="server" TextMode="Number"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="EnterId_Validator" ControlToValidate="EnterId_tb" runat="server" ErrorMessage="" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            &nbsp;&nbsp;
                            <asp:Button ID="FindById_btn" OnClick="FindById_btn_Click" runat="server" Text="Ieškoti" />
                            &nbsp;&nbsp;
                            <asp:TextBox ID="Competitor_tb" runat="server" AutoPostBack="true" ReadOnly="true"></asp:TextBox>
                        </div>
                    <div>
                    </div>
            </asp:Panel>

             <asp:Panel ID="time" runat="server">
                    <div>
                        <label>Įveskite rezultatą</label>
                        <asp:TextBox ID="ResultsTimeMinute_TextBox" runat="server" TextMode="Number" min="0" max="60"></asp:TextBox>
                        <label> mm</label>
                        <asp:TextBox ID="ResultsTimeSeconds_TextBox" runat="server" TextMode="Number" min="0" max="60"></asp:TextBox>
                        <label> ss</label>
                        <asp:TextBox ID="ResultsTimeMili_TextBox" runat="server" TextMode="Number" min="0" max="99"></asp:TextBox>
                        <label> ms</label>
                        <asp:Button ID="ResultsTime_btn" runat="server" Text="Saugoti" OnClick="ResultsTime_btn_Click"/>
                    </div>
             </asp:Panel>

             <asp:Panel ID="count" runat="server">
                    <div>
                        <label>Įveskite rezultatą</label>
                        <asp:TextBox ID="TextBox3" runat="server" TextMode="Number" min="0"></asp:TextBox>
                        <asp:Button ID="ResultsCount_btn" runat="server" Text="Saugoti" OnClick="ResultsCount_btn_Click" />
                    </div>
             </asp:Panel>
        </div>
        <div>
            <asp:Panel ID="last_entries_panel" runat="server">
                 <asp:GridView ID="LastEntries_Gridview" runat="server" AutoGenerateColumns="false" AllowPaging="false" PageSize="5">
                     <Columns>
                         <asp:BoundField DataField="Id" HeaderText="ID" />
                         <asp:BoundField DataField="Name" HeaderText="Vardas" />
                         <asp:BoundField DataField="Surname" HeaderText="Pavardė" />
                         <asp:BoundField DataField="Event" HeaderText="Rungtis" />
                         <asp:BoundField DataField="Result" HeaderText="Rezultatas" />
                     </Columns>
                 </asp:GridView>
             </asp:Panel>
        </div>


        <script type="text/javascript">

            function click() {
                document.getElementById('defaultLink').click();
            }

            function clickPostBackStart(){
                document.getElementById('startLink').click();
            }

            function clickStart() {
                document.getElementById('ResultsInputContent').style.display = "block";
                document.getElementById('save_lbl').style.display = "block";
                document.getElementById('start_lbl').style.display = "none";
                document.getElementById('startLink').click();
                var startBtn = document.getElementById('<%=startCompetition_btn.ClientID%>');
                startBtn.style.display = "none";
                var saveBtn = document.getElementById('<%=saveCompetition_btn.ClientID%>');
                saveBtn.style.display = "block";
            }

            function clickSave() {
                document.getElementById('ResultsInputContent').style.display = "none";
                document.getElementById('save_lbl').style.display = "none";
                document.getElementById('start_lbl').style.display = "block";
                var startBtn = document.getElementById('<%=startCompetition_btn.ClientID%>');
                startBtn.style.display = "block";
                var saveBtn = document.getElementById('<%=saveCompetition_btn.ClientID%>');
                saveBtn.style.display = "none";
                document.getElementById('startLink').click();
            }
        </script>
</asp:Content>

