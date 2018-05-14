<%@ Page Language="C#" AutoEventWireup="true" Culture="lt-LT" UICulture="lt-LT" MasterPageFile="~/Site.Master" CodeBehind="RegisterCompetitorsAdmin.aspx.cs" Inherits="WebApplication.Admin.Competition.RegisterCompetitorsAdmin" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    <asp:Content runat="server" ID="CreateEventsContent" ContentPlaceHolderID="MainContent">
        
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
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
                .searchbtn{
                    background-image: url("/Image/users.png" );
                    width: 30px;
                    height: 30px;
                    
                }
                .centered {
                  width: 50%;
                  margin-left: auto;
                  margin-right: auto;
                }
                .modalBackground 
                {
                    height:100%;
                    background-color:#EBEBEB;
                    filter:alpha(opacity=70);
                    opacity:0.7;
                }
                
    </style>
       <script type="text/javascript">
        //Initial load of page
        $(document).ready(sizePage);

        //Dynamically assign height
            function sizePage() {
                var h = screen.height;
                if (h > 1000) {
                    $('#<%= PageSizeHiddenField.ClientID %>').val('13'); //this is page size
                }
                else {
                    $('#<%= PageSizeHiddenField.ClientID %>').val('7'); //this is page size
                }
        
            }
        </script>

        <script type="text/javascript">
            function onKeyDownSearch() {
                if (event.keyCode == 13) {
                    event.preventDefault();
                    document.getElementById("<%=search_btn.ClientID%>").click();
                }
            }
        </script>

        <asp:HiddenField runat="server" ID="PageSizeHiddenField" />

        <div>
               <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="table table-curved table-hover table-striped text-codemess table-dark noBorder" BackColor="Gray" BorderColor="black" ForeColor="white" GridLines="Horizontal" DataKeyNames="Id"  OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging">
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
        </div>
        <div>
            <asp:LinkButton ID="fake" runat="server"></asp:LinkButton>

           <cc1:ModalPopupExtender ID="searchPopup" runat="server"
                TargetControlID="fake"
                PopupControlID="panelSearch"
                DropShadow="false"
                BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>

        <asp:Panel ID="panelSearch" runat="server" style="display: none; position:relative; display: none; min-height:60%; min-width:30%; height:auto; width:auto" BorderWidth="5px" HorizontalAlign="center" BackColor="#484848" BorderColor="#33CCFF" ForeColor="White" CssClass=" alert-secondary">
            <asp:UpdatePanel ID="searchUpdatePanel" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <br />
                            <div class="col-lg-6">
                              <div class="input-group">
                                <asp:TextBox ID="search_tb" runat="server" onkeydown="return onKeyDownSearch()" placeholder="Ieškoti..." CssClass="form-control"></asp:TextBox>
                                <span class="input-group-btn">
                                  <asp:ImageButton ID="search_btn" runat="server" OnClick="search_btn_Click" ImageUrl="/Image/search4.png"  Width="40px" Height="40px" />
                                </span>
                              </div><!-- /input-group -->
                            </div>
                    <div>
                        <%--<asp:TextBox ID="search_tb" runat="server" placeholder="Ieškoti..." CssClass="form-control">
                        </asp:TextBox>
                        <asp:ImageButton ID="search_btn" runat="server" OnClick="search_btn_Click" ImageUrl="/Image/search3.png"  Width="28px" Height="28px" />
                        <%--<asp:Button ID="search_btn" runat="server" OnClick="search_btn_Click" CssClass="btn searchbtn" />--%>
                        <asp:RequiredFieldValidator ID="search_tb_validator" runat="server" ControlToValidate="search_tb" ErrorMessage="Įveskite ID, vardą arba pavardę"></asp:RequiredFieldValidator>
                    </div>
                    <br />
                    <div>
                        <asp:GridView ID="competitorsGridView" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="competitorsGridView_SelectedIndexChanged" CssClass="table table-curved table-hover table-striped text-codemess table-dark noBorder" BackColor="Gray" BorderColor="black" ForeColor="white" GridLines="Horizontal" >
                             <Columns>
                                <asp:CommandField ShowSelectButton="True" SelectText="Pasirinkti" ControlStyle-CssClass="btn btn-success" />
                                <asp:BoundField DataField="Id" HeaderText="ID" />
                                <asp:BoundField DataField="Name" HeaderText="Vardas" />
                                <asp:BoundField DataField="Surname" HeaderText="Pavardė" />
                                <asp:BoundField DataField="Year" HeaderText="Gimimo metai" />
                                <asp:BoundField DataField="Gender" HeaderText="Lytis" />
                                <asp:BoundField DataField="City" HeaderText="Miestas" />
                                <asp:BoundField DataField="Country" HeaderText="Šalis" />
                            </Columns>
                        </asp:GridView>
                    </div>
                    <asp:Panel ID="panelAddTo" Visible="false" runat="server" style="position:relative; min-height:0%; min-width:20%; height:auto; width:auto" BorderWidth="5px" HorizontalAlign="center" BackColor="#484848" BorderColor="#33CCFF" ForeColor="White" CssClass=" alert-secondary" >
                        <div>
                                <div>
                                    <h2>Pridėti/šalinti iš varžybų</h2>
                       
                                </div>
                                <div class=" centered">
                                    <asp:TextBox ID="Info_tb" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                                </div>
                            <br />
                                <div>
                                    <asp:Button ID="AddToCompeition" runat="server" Text="Pridėti" OnClick="AddToCompeition_Click" CssClass="btn"/>
                                    <asp:Button ID="RemoveFromCompetition" runat="server" Text="Šalinti" OnClick="RemoveFromCompetition_Click" CssClass="btn btn-danger" />
                                    <asp:Button ID="cancelAdding" runat="server" Text="Atšaukti" OnClick="cancelAdding_Click" CssClass="btn" />
                                 </div>
                            <br />
                        </div>
                    </asp:Panel>
                    <div>
                        <asp:Button ID="cancel_btn" runat="server" OnClick="cancel_btn_Click" Text="Atšaukti" CssClass="btn" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
        </div>
        <div>
    </asp:Content>
