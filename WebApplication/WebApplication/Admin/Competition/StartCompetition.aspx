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

                .changeComp{
                    position:absolute;
                    right:1px;
                    
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
                        <%--<asp:Button ID="SelectCompetitionBtn" Visible="false" runat="server" Text="Varžybų sąrašas" OnClick="SelectCompetitionBtn_Click" CssClass=" nav-link active" />--%>
                        <li class="nav-item"><a  class="nav-link active" data-toggle="tab" onclick="openLink(event, 'generate')" id="defaultLink">Pogrūpiai</a></li>
                        <li class="nav-item"><a  class="nav-link active" data-toggle="tab" onclick="openLink(event, 'documents')">Protokolai</a></li>
                        <li class="nav-item"><a  class="nav-link active" data-toggle="tab" onclick="openLink(event, 'results')" id="startLink">Rezultatų vedimas</a></li>
                    </ul>

                    <!-- Tab content -->
                    <div class="tab-content" id="myTabContent1" style="height:100%; width: 100%;">
                        <div id="generate" class="tabcontent show active dropdown" style="border:none">
                            <h2>Pogrūpiai</h2>
                            <div class="float-right">
                                <asp:Button ID="Button2" Visible="true" runat="server" Text="Keisti varžybas" OnClick="SelectCompetitionBtn_Click" CssClass="btn btn-danger" />
                            </div>
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
                            <asp:Panel runat="server">
                            <asp:GridView ID="CompetitorsGridView" runat="server" AllowPaging="True" AutoGenerateColumns="False" Width="50%" BackColor="Gray" BorderColor="black" CssClass="table table-curved table- text-codemess table-dark noBorder" ForeColor="white" GridLines="Horizontal" PageSize="1000">
                                <PagerStyle BackColor="#4A4A4A" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#333333" />
                                <Columns>
                                    <asp:BoundField DataField="Subgroup" HeaderText="Pogrupis" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-Font-Size="70"/>
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
                            <div class="float-right">
                                <asp:Button ID="Button3" Visible="true" runat="server" Text="Keisti varžybas" OnClick="SelectCompetitionBtn_Click" CssClass="btn btn-danger" />
                            </div>
                            
                            <hr>
                        </div>
                        <div id="results" class="tabcontent show active" style="border:none">
                            <h2>Rezultatų suvedimas</h2>
                            <div class="float-right">
                                <asp:Button ID="Button4" Visible="true" runat="server" Text="Keisti varžybas" OnClick="SelectCompetitionBtn_Click" CssClass="btn btn-danger" />
                            </div>
                            <div>
                                <label id="start_lbl">Ar pradėti varžybas?</label>
                                <asp:Button ID="startCompetition_btn" runat="server" Text="Pirmyn" CssClass="btn btn-success" OnClick="startCompetition_Click"/>
                            </div>
                            <hr />
                                    <%--<div class="col">
                                        <br />
                                        <label>Skaičiuoti rezultatus</label>
                                        <asp:DropDownList ID="CalculateResultsGroup_list" runat="server" DataValueField="Type" AutoPostBack="true" DataTextField="Type" OnSelectedIndexChanged="CalculateResultsGroup_list_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                                        <asp:Button ID="Calculate_btn" runat="server" Text="Skaičiuoti" OnClick="Calculate_btn_Click" CssClass="btn"/>
                                    </div>--%>
                                    <div class="form-row">
                                        <div class="form-group col-md-2">
                                          <label for="inputGroup">Skaičiuoti rezultatus</label>
                                            <asp:DropDownList ID="CalculateResultsGroup_list" runat="server" DataValueField="Type" AutoPostBack="true" DataTextField="Type" OnSelectedIndexChanged="CalculateResultsGroup_list_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                                            <asp:Button ID="Calculate_btn" runat="server" Text="Skaičiuoti" OnClick="Calculate_btn_Click" CssClass="form-control btn btn-outline-light"/>
                                        </div>
                                     </div>
                            <hr />
                            <div>
                                <asp:GridView ID="Results_GridView" runat="server" Width="35%" AutoGenerateColumns="false" CssClass="table table-curved table-hover table-striped text-codemess table-dark noBorder" BackColor="Gray" BorderColor="black" ForeColor="white" GridLines="Horizontal">
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
                
                    <asp:Button ID="saveCompetition_btn" runat="server" CausesValidation="false" Text="Saugoti varžybas" OnClick="saveCompetition_btn_Click" CssClass="btn" />

                <hr />
                <form>                      
                      <div class="form-row">
                        <div class="form-group col-md-4">
                          <label for="inputGroup">Pasirinkite grupę</label>
                            <asp:DropDownList ID="selectGroup_list" runat="server" DataValueField="Id" DataTextField="Type" CssClass="form-control"></asp:DropDownList>
                            <asp:Button ID="SelectGroup_btn" runat="server" Text="Pasirinkti" OnClick="SelectGroup_btn_Click" CssClass="form-control" />
                        </div>
                        <div class="form-group col-md-4">
                          <label for="inputCompetition">Pasirinkite rungtį</label>
                          <asp:DropDownList ID="selectEvent_list" DataValueField="Id" CssClass="form-control" DataTextField="Title" runat="server" Enabled="false"></asp:DropDownList>
                        </div>
                        <div class="form-group col-md-2">
                          <label for="inputButton">Patvirtinkite</label>
                          <asp:Button ID="WriteResults_btn" runat="server" OnClick="WriteResults_btn_Click" Text="Vesti rezultatus" CssClass="form-control"/>
                        </div>
                      </div>
                    <hr />
                        <div class="form-row">
                          <div class="form-group col-md-2">
                            <label for="inputID">Įveskite ID</label>
                              <asp:TextBox ID="EnterId_tb" runat="server" onkeydown="return onKeyDownFind()" TextMode="Number" CssClass="form-control"></asp:TextBox>
                              <asp:Button ID="FindById_btn" OnClick="FindById_btn_Click" runat="server" Text="Ieškoti" CssClass="form-control" />
                              <asp:RequiredFieldValidator ID="EnterId_Validator" ControlToValidate="EnterId_tb" runat="server" ErrorMessage="" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                          </div>
                          <div class="form-group col-md-6">
                            <label for="inputCompetitor">Dalyvis</label>
                            <asp:TextBox ID="Competitor_tb" runat="server" AutoPostBack="true" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                          </div>
                        </div>
                    </form>
                        <div>
                            <%--<asp:TextBox ID="EnterId_tb" runat="server" TextMode="Number"></asp:TextBox>--%>
                            <%--<asp:RequiredFieldValidator ID="EnterId_Validator" ControlToValidate="EnterId_tb" runat="server" ErrorMessage="" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:Button ID="FindById_btn" OnClick="FindById_btn_Click" runat="server" Text="Ieškoti" />--%>
                            <%--<asp:TextBox ID="Competitor_tb" runat="server" AutoPostBack="true" ReadOnly="true"></asp:TextBox>--%>
                        </div>
                    <div>
                    </div>
                
            </asp:Panel>

             <hr />

             <asp:Panel ID="time" runat="server">
                    <div>
                        <label>Įveskite rezultatą</label>
                        <asp:TextBox ID="ResultsTimeMinute_TextBox" runat="server" TextMode="Number" min="0" max="60"></asp:TextBox>
                        <label> mm</label>
                        <asp:TextBox ID="ResultsTimeSeconds_TextBox" runat="server" TextMode="Number" min="0" max="60"></asp:TextBox>
                        <label> ss</label>
                        <asp:TextBox ID="ResultsTimeMili_TextBox" runat="server" TextMode="Number" min="0" max="999"></asp:TextBox>
                        <label> ms</label>
                        <asp:Button ID="ResultsTime_btn" runat="server" Text="Saugoti" OnClick="ResultsTime_btn_Click"/>
                    </div>
                 
                    
             </asp:Panel>

             <asp:Panel ID="count" runat="server">
                    
                    <div class="form-row">
                        <div class="form-group col-md-4">
                          <label for="inputGroup">Įveskite rezultatą</label>
                            <asp:TextBox ID="TextBox3" runat="server" TextMode="Number" min="0" CssClass="form-control"></asp:TextBox>
                            <asp:Button ID="ResultsCount_btn" runat="server" Text="Saugoti" OnClick="ResultsCount_btn_Click" CssClass="form-control" />
                        </div>
                      </div>
             </asp:Panel>
        </div>
        <div>
            <asp:Panel ID="last_entries_panel" runat="server">
                 <asp:GridView ID="LastEntries_Gridview" runat="server" AutoGenerateColumns="false" AllowPaging="false" PageSize="5" CssClass="table table-curved table-striped text-codemess table-dark noBorder" BackColor="Gray" BorderColor="black" ForeColor="white" GridLines="Horizontal">
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
            function onKeyDownFind() {
                if (event.keyCode == 13) {
                    event.preventDefault();
                    document.getElementById("<%=FindById_btn.ClientID%>").click();
                }
            }
        </script>


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

