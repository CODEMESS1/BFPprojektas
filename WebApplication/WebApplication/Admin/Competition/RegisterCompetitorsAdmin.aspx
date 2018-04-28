<%@ Page Language="C#" AutoEventWireup="true" Culture="lt-LT" UICulture="lt-LT" MasterPageFile="~/Site.Master" CodeBehind="RegisterCompetitorsAdmin.aspx.cs" Inherits="WebApplication.Admin.Competition.RegisterCompetitorsAdmin" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    <asp:Content runat="server" ID="CreateEventsContent" ContentPlaceHolderID="MainContent">
        
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

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

        <asp:Panel ID="panelSearch" runat="server" style="display: none;">
            <asp:UpdatePanel ID="searchUpdatePanel" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div>
                        <label>Paieška </label>
                        <asp:TextBox ID="search_tb" runat="server">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="search_tb_validator" runat="server" ControlToValidate="search_tb" ErrorMessage="Įveskite ID, vardą arba pavardę"></asp:RequiredFieldValidator>
                    </div>
                    <div>
                        <asp:Button ID="search_btn" runat="server" OnClick="search_btn_Click" Text="Ieškoti" />
                    </div>
                    <div>
                        <asp:GridView ID="competitorsGridView" runat="server" OnSelectedIndexChanged="competitorsGridView_SelectedIndexChanged" >
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
                    <div>
                        <asp:Button ID="cancel_btn" runat="server" OnClick="cancel_btn_Click" Text="Atšaukti" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
        </div>
        <div>
        <cc1:ModalPopupExtender ID="addCompetitorPopup" runat="server"
                TargetControlID="fake"
                PopupControlID="panelAddTo"
                DropShadow="false"
                BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>

        <asp:Panel ID="panelAddTo" runat="server" BackColor="White">
            <div>
                    <div>
                        <label>Pridėti/šalinti iš varžybų</label>
                    </div>
                    <div>
                        <asp:TextBox ID="Info_tb" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Button ID="AddToCompeition" runat="server" Text="Pridėti" OnClick="AddToCompeition_Click"/>
                        <asp:Button ID="RemoveFromCompetition" runat="server" Text="Šalinti" OnClick="RemoveFromCompetition_Click" />
                        <asp:Button ID="cancelAdding" runat="server" Text="Atšaukti" OnClick="cancelAdding_Click" />
                     </div>
            </div>
        </asp:Panel>
        </div>
    </asp:Content>
