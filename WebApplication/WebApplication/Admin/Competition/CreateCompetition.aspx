<%@ Page Title="Varžybų redagavimas" Language="C#" AutoEventWireup="true" Culture="lt-LT" UICulture="lt-LT" MasterPageFile="~/Site.Master" CodeBehind="~/Admin/Competition/CreateCompetition.aspx.cs" Inherits="WebApplication.Admin.Competition.CreateCompetition" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    <asp:Content runat="server" ID="CreateCompetitionContent" ContentPlaceHolderID="MainContent">
        <h2><%: Title %>.</h2>
        <h4>Redaguoti ir pridėti varžybas</h4>
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
                function openCity(evt, tabName) {
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
            function setDate(sender, args) {
            }
        </script>

        <div>
            <asp:ScriptManager EnableScriptGlobalization="true" runat="server"></asp:ScriptManager>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass=" table table-curved table-hover table-striped text-codemess table-dark noBorder" BackColor="Gray" BorderColor="black" ForeColor="white" GridLines="Horizontal" DataKeyNames="Id" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging">
                <PagerStyle BackColor="#4A4A4A" ForeColor="Black" HorizontalAlign="Center" Font-Bold="True"  />
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
            <asp:Button ID="add_btn2" runat="server" CssClass="btn btn-default" Text="Pridėti" OnClick="add_btn_Click"/>
            <asp:LinkButton ID="fake" runat="server"></asp:LinkButton>
            <br />

                        <!-- add popup start -->
            
            <cc1:ModalPopupExtender ID="popupAdd" runat="server"
                TargetControlID="fake"
                PopupControlID="PanelAdd"
                DropShadow="false"
                BackgroundCssClass="modalBackground"
                >
            </cc1:ModalPopupExtender>
             
            <asp:Panel ID="PanelAdd" runat="server" BorderWidth="5px" ScrollBars="Auto" HorizontalAlign="center" BackColor="#484848" BorderColor="#33CCFF" ForeColor="White" CssClass=" alert-secondary" style='position:relative; display: none; min-height:45%; min-width:30%; max-height:65%;  height:auto; width:auto'>
                
            <!-- Tab links -->
            <ul class="nav nav-tabs navTabFormat">
              <li class="nav-item"><a class="nav-link active" id="home-tab1" data-toggle="tab" onclick="openCity(event, 'creation')">Sukurti varžybas</a></li>
              <li class="nav-item"><a class="nav-link active" id="profile-tab1" data-toggle="tab" onclick="openCity(event, 'eventAdd')">Pridėti rungtis</a></li>
              <li class="nav-item"><a class="nav-link active" id="groups-tab1" data-toggle="tab" onclick="openCity(event, 'groupsAdd')">Priskirti amžiaus grupes</a></li>
            </ul>
            
            <!-- Tab content -->
                <div class="tab-content" id="myTabContent1">
                        <div id="creation" class="tabcontent show active" style="border:none">
                        <h3>Pridėti varžybas</h3>
                         <!--varzybu pridejimas-->
                      
                         <div>
                                <asp:Label ID="ErrorMessage" runat="server" CssClass="col-md-2 control-label"></asp:Label>
                            </div>
                            <div>
                                <asp:Label ID="addName_lbl" runat="server" Text="Pavadinimas" CssClass="formatText"></asp:Label>
                                <asp:TextBox ID="addName_txt" runat="server" ValidationGroup="popup" ></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="addName_txt" ErrorMessage="Įrašykite pavadinimą" ValidationGroup="popup" CssClass="errorMsg"></asp:RequiredFieldValidator>
                                <br />
                            </div>
                            <div>
                                <asp:Label ID="addPlace_lbl" runat="server" Text="Vieta" CssClass="formatText"></asp:Label>
                                <asp:TextBox ID="addPlace_txt" runat="server" ValidationGroup="popup" ></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="addPlace_txt" ErrorMessage="Įrašykite vietą" ValidationGroup="popup" CssClass="errorMsg"></asp:RequiredFieldValidator>
                                <br />
                            </div>
                            <div>
                                <asp:Label ID="addAdress_lbl" runat="server" Text="Adresas" CssClass="formatText"></asp:Label>
                                <asp:TextBox ID="addAdress_txt" runat="server" ValidationGroup="popup" ></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="addAdress_txt" ErrorMessage="Įrašykite adresą" ValidationGroup="popup" CssClass="errorMsg"></asp:RequiredFieldValidator>
                                <br />
                                <asp:Label ID="AddDate_lbl" runat="server" Text="Data" CssClass="formatText"></asp:Label>
                                <asp:TextBox ID="AddDate_txt" runat="server" TextMode="DateTime" ReadOnly="true" ValidationGroup="popup"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="TextBox4_CalendarExtender" runat="server" OnClientDateSelectionChanged="setDate"
                                  Enabled="True" FirstDayOfWeek="Monday"  Format="yyyy-MM-dd" 
                                  TargetControlID="AddDate_txt" />
                                <br />
                                <br />
                                <asp:Label ID="addRegStart_lbl" runat="server" Text="Registracijos pradžia" CssClass="formatText"></asp:Label>
                                <asp:TextBox ID="addRegStart_txt" runat="server" TextMode="DateTime" ReadOnly="true" ValidationGroup="popup" ></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" OnClientDateSelectionChanged="setDate"
                                  Enabled="True" FirstDayOfWeek="Monday"  Format="yyyy-MM-dd" 
                                  TargetControlID="addRegStart_txt" />
                                <br />
                                <br />
                                <asp:Label ID="addRegEnd_lbl" runat="server" Text="Registracijos pabaiga" CssClass="formatText"></asp:Label>
                                <asp:TextBox ID="addRegEnd_txt" runat="server" TextMode="DateTime" ReadOnly="true" ValidationGroup="editPopup"  ></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender8" runat="server" OnClientDateSelectionChanged="setDate"
                                  Enabled="True" FirstDayOfWeek="Monday"  Format="yyyy-MM-dd" 
                                  TargetControlID="addRegEnd_txt" />
                                <br />
                                <br />
                                <asp:Label ID="addIsRegOpen_lbl" runat="server" Text="Registracijos atidarymas/uždarymas"></asp:Label>
                                <br />
                                <asp:RadioButtonList ID="addIsRegOpen_ckbox" runat="server" ValidationGroup="editPopup" RepeatDirection="Horizontal" CssClass="gender rbl centerElement" ForeColor="White">
                                    <asp:ListItem Value="Open"> Atidaryta </asp:ListItem>
                                    <asp:ListItem Selected="True" Value="Closed"> Uždaryta </asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Pasirinkite registracijos būseną" ValidationGroup="editPopup" ControlToValidate="addIsRegOpen_ckbox" CssClass="errorMsg"></asp:RequiredFieldValidator>
                                <br />
                             </div>
                            <asp:Button ID="submit_btn" runat="server" Text="Pridėti" CausesValidation="true" ValidationGroup="popup" OnClick="submit_btn_Click" CssClass="btn"/>
                            <asp:Button ID="cancel_btn" runat="server" Text="Atšaukti" CssClass="btn"/>
                     </div>
                     <div id="eventAdd" class="tabcontent" style="border:none">
                      <h3>Pridėti rungtis</h3>
                         <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                             <ContentTemplate>
                                    <asp:GridView ID="GridView3" runat="server" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="GridView3_PageIndexChanging" DataKeyNames="Id" CssClass="table table-curved table-hover table-striped text-codemess table-dark " BackColor="Gray" BorderColor="black" ForeColor="white">
                                    <PagerStyle BackColor="#4A4A4A" ForeColor="Black" HorizontalAlign="Center" Font-Bold="True"  />
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="checkBox" runat="server" AutoPostBack="false"/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        <asp:BoundField DataField="Title" HeaderText="Pavadinimas" />
                                        <asp:BoundField DataField="Type" HeaderText="Tipas" />
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                     </div>
                     <div id="groupsAdd" class="tabcontent" style="border:none">
                         <h3>Pridėti rungtis</h3>
                         <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="GroupAddUpdatePanel">
                             <ContentTemplate>
                                    <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" CssClass="table table-curved table-hover table-striped text-codemess table-dark " BackColor="Gray" BorderColor="black" ForeColor="white">
                                    <PagerStyle BackColor="#4A4A4A" ForeColor="Black" HorizontalAlign="Center" Font-Bold="True"  />
                                        <Columns>
                                            <asp:BoundField DataField="Type" HeaderText="Pavadinimas" />
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <div>
                                                        <asp:TextBox ID="AddStartYear_tb" runat="server" TextMode="Number">
                                                        </asp:TextBox>
                                                        <asp:TextBox ID="AddEndYear_tb" runat="server" TextMode="Number">
                                                        </asp:TextBox>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                     </div>
                    </div>
            </asp:Panel>
            <!-- add popup end-->


                        <!-- edit popup start-->

            <cc1:ModalPopupExtender ID="popupEdit" runat="server"
                TargetControlID="fake"
                PopupControlID="editPanel"
                DropShadow="false"
                BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
</div>
       

            <asp:Panel ID="editPanel" runat="server" BorderWidth="5px" HorizontalAlign="center" BackColor="#484848" BorderColor="#33CCFF" ForeColor="White" CssClass=" alert-secondary" style='position:relative; display: none; min-height:65%; min-width:30%; height:auto; width:auto'>
                <!-- Tab links -->
                <ul class="nav nav-tabs navTabFormat" id="myTab" role="tablist">
                  <li class="nav-item">
                    <a class="nav-link active" id="home-tab" data-toggle="tab" onclick="openCity(event, 'edit')" role="tab" aria-controls="home" aria-selected="true">Varžybų redagavimas</a>
                  </li>
                  <li class="nav-item">
                    <a class="nav-link active" id="profile-tab" data-toggle="tab" onclick="openCity(event, 'editEventAdd')" role="tab" aria-controls="profile" aria-selected="false">Rungtys</a>
                  </li>
                    <li class="nav-item"><a class="nav-link active" id="groups-tab2" data-toggle="tab" onclick="openCity(event, 'groupsAddEdit')">Priskirti amžiaus grupes</a></li>
                </ul>


                <!-- Tab content -->
                <div class="tab-content" id="myTabContent">
                 <div id="edit" class="tabcontent show active" role="tabpanel" aria-labelledby="home-tab">
                        <h1>Keisti varžybų duomenis</h1>
                        <div>
                            <asp:Label ID="ErrorMessageEdit" runat="server" CssClass="col-md-2 control-label"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="editName_lbl" runat="server" Text="Pavadinimas" CssClass="formatText"></asp:Label>
                            <asp:TextBox ID="editName_tb" runat="server" ValidationGroup="editPopup" ></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="editName_tb" ValidationGroup="editPopup" ErrorMessage="Įrašykite pavadinimą"></asp:RequiredFieldValidator>
                            <br />
                        </div>
                        <div>
                            <asp:Label ID="editLocation_lbl" runat="server" Text="Vieta" CssClass="formatText"></asp:Label>
                            <asp:TextBox ID="editLocation_tb" runat="server" ValidationGroup="editPopup" ></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="editLocation_tb" ValidationGroup="editPopup" ErrorMessage="Įrašykite vietą"></asp:RequiredFieldValidator>
                            <br />
                        </div>
                        <div>
                            <asp:Label ID="editAddress_lbl" runat="server" Text="Adresas" CssClass="formatText"></asp:Label>
                            <asp:TextBox ID="editAddress_tb" runat="server" ValidationGroup="editPopup" ></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="editAddress_tb" ValidationGroup="editPopup" ErrorMessage="Įrašykite adresą"></asp:RequiredFieldValidator>
                            <br />
                            <asp:Label ID="editDate_lbl" runat="server" Text="Data" CssClass="formatText"></asp:Label>
                            <asp:TextBox ID="editDate_tb" runat="server" TextMode="DateTime" ReadOnly="true" ValidationGroup="editPopup" ></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" OnClientDateSelectionChanged="setDate"
                              Enabled="True" FirstDayOfWeek="Monday"  Format="yyyy-MM-dd" 
                              TargetControlID="editDate_tb" />
                            <br />
                            <br />
                            <asp:Label ID="editRegistrationStartDate_lbl" runat="server" Text="Registracijos pradžia" CssClass="formatText"></asp:Label>
                            <asp:TextBox ID="editRegistrationStartDate_tb" runat="server" TextMode="DateTime" ReadOnly="true" ValidationGroup="editPopup" ></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" OnClientDateSelectionChanged="setDate"
                              Enabled="True" FirstDayOfWeek="Monday"  Format="yyyy-MM-dd" 
                              TargetControlID="editRegistrationStartDate_tb" />
                            <br />
                            <br />
                            <asp:Label ID="editRegistrationEndDate_lbl" runat="server" Text="Registracijos pabaiga" CssClass="formatText"></asp:Label>
                            <asp:TextBox ID="editRegistrationEndDate_tb" runat="server" TextMode="DateTime" ReadOnly="true" ValidationGroup="editPopup" ></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" OnClientDateSelectionChanged="setDate"
                              Enabled="True" FirstDayOfWeek="Monday"  Format="yyyy-MM-dd" 
                              TargetControlID="editRegistrationEndDate_tb" />
                            <br />
                            <br />
                            <asp:Label ID="editisRegOpen_lbl" runat="server" Text="Registracijos atidarymas/uždarymas"></asp:Label>
                            <br />

                             <asp:RadioButtonList ID="editisRegOpen_ckbox" runat="server" ValidationGroup="editPopup" RepeatDirection="Horizontal" CssClass="gender rbl centerElement" ForeColor="White">
                                <asp:ListItem Value="Open"> Atidaryta </asp:ListItem>
                                <asp:ListItem Value="Closed"> Uzdaryta </asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="gendervalidator" runat="server" ControlToValidate="editisRegOpen_ckbox" ErrorMessage="Pasirinkite registracijos būseną"  ValidationGroup="editPopup" CssClass="errorMsg"></asp:RequiredFieldValidator>
                             </div>
                            <asp:Button ID="edit_btn" runat="server" Text="Keisti" CausesValidation="true" OnClick="edit_btn_Click" ValidationGroup="editPopup" CssClass="btn"/>
                            <asp:Button ID="canceledit_btn" runat="server" Text="Atšaukti" CssClass="btn"/>
                            <asp:Button ID="remove_btn" runat="server" Text="Ištrinti varžybas" OnClick="remove_btn_Click" CssClass="btn btn-danger"/>
                        </div>
                        <div>
                    </div>
                    <div id="editEventAdd" class="tabcontent" role="tabpanel" aria-labelledby="profile-tab">
                        <h1>Keisti varžybų rungtis</h1>
                        <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                           <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="GridView2_PageIndexChanging" DataKeyNames="Id" CssClass="table table-curved table-hover table-striped text-codemess table-dark " BackColor="Gray" BorderColor="black" ForeColor="white">
                            <PagerStyle BackColor="#4A4A4A" ForeColor="Black" HorizontalAlign="Center" Font-Bold="True"  />
                            <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="checkBox" runat="server" AutoPostBack="false"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                <asp:BoundField DataField="Title" HeaderText="Pavadinimas" />
                                <asp:BoundField DataField="Type" HeaderText="Tipas" />
                            </Columns>
                        </asp:GridView>
                                </ContentTemplate>
                         </asp:UpdatePanel>
                    </div>
                     <div id="groupsAddEdit" class="tabcontent" style="border:none">
                         <h3>Pridėti rungtis</h3>
                         <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1">
                             <ContentTemplate>
                                    <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" CssClass="table table-curved table-hover table-striped text-codemess table-dark " BackColor="Gray" BorderColor="black" ForeColor="white">
                                    <PagerStyle BackColor="#4A4A4A" ForeColor="Black" HorizontalAlign="Center" Font-Bold="True"  />
                                        <Columns>
                                            <asp:BoundField DataField="Type" HeaderText="Pavadinimas" />
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <div>
                                                        <asp:TextBox ID="EditStartYear_tb" runat="server" TextMode="Number" ValidationGroup="EditYear">
                                                        </asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="EditStartYearValid" runat="server" ControlToValidate="EditStartYear_tb" ErrorMessage="VEIKIA"></asp:RequiredFieldValidator>
                                                        <asp:TextBox ID="EditEndYear_tb" runat="server" TextMode="Number" ValidationGroup="EditYear">
                                                        </asp:TextBox>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                     </div>
                    </div>
                </asp:Panel>
            <!-- edit popup end-->

    </asp:Content>