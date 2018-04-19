<%@ Page Language="C#" AutoEventWireup="true" Culture="lt-LT" UICulture="lt-LT" MasterPageFile="~/Site.Master" CodeBehind="CreateCompetition.aspx.cs" Inherits="WebApplication.Admin.CreateCompetition" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    <asp:Content runat="server" ID="CreateCompetitionContent" ContentPlaceHolderID="MainContent">

        <script type="text/javascript">
            function setDate(sender, args) {
            }
        </script>

        <div>
            <asp:ScriptManager EnableScriptGlobalization="true" runat="server"></asp:ScriptManager>
            VARŽYBŲ KŪRIMAS<br />
            <br />
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True"  AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Id" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateSelectButton="True">
                <Columns>
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
            <asp:Button ID="add_btn2" runat="server" class="btn btn-default" Text="Pridėti" OnClick="add_btn_Click"/>
            <asp:LinkButton ID="fake" runat="server"></asp:LinkButton>
            <br />

                        <!-- add popup start -->
            
            <cc1:ModalPopupExtender ID="popupAdd" runat="server"
                TargetControlID="fake"
                PopupControlID="PanelAdd"
                DropShadow="false">
            </cc1:ModalPopupExtender>
            
            <asp:Panel ID="PanelAdd" runat="server" CssClass="alert-primary" BorderWidth="5px" style='display: none;'>
                <h1>Pridėti Varzybas</h1>
                <div>
                    <asp:Label ID="ErrorMessage" runat="server" CssClass="col-md-2 control-label"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="addName_lbl" runat="server" Text="Pavadinimas"></asp:Label>
                    <asp:TextBox ID="addName_txt" runat="server" ValidationGroup="popup" ></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="addName_txt" ErrorMessage="RequiredFieldValidator" ValidationGroup="popup"></asp:RequiredFieldValidator>
                    <br />
                </div>
                <div>
                    <asp:Label ID="addPlace_lbl" runat="server" Text="Vieta"></asp:Label>
                    <asp:TextBox ID="addPlace_txt" runat="server" ValidationGroup="popup" ></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="addPlace_txt" ErrorMessage="RequiredFieldValidator" ValidationGroup="popup"></asp:RequiredFieldValidator>
                    <br />
                </div>
                <div>
                    <asp:Label ID="addAdress_lbl" runat="server" Text="Adresas"></asp:Label>
                    <asp:TextBox ID="addAdress_txt" runat="server" ValidationGroup="popup" ></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="addAdress_txt" ErrorMessage="RequiredFieldValidator" ValidationGroup="popup"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="AddDate_lbl" runat="server" Text="Data"></asp:Label>
                    <asp:TextBox ID="AddDate_txt" runat="server" TextMode="DateTime" ReadOnly="true" ValidationGroup="popup"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="TextBox4_CalendarExtender" runat="server" OnClientDateSelectionChanged="setDate"
                      Enabled="True" FirstDayOfWeek="Monday"  Format="yyyy-MM-dd" 
                      TargetControlID="AddDate_txt" />
                    <br />
                    <br />
                    <asp:Label ID="addRegStart_lbl" runat="server" Text="Registracijos pradžia"></asp:Label>
                    <asp:TextBox ID="addRegStart_txt" runat="server" TextMode="DateTime" ReadOnly="true" ValidationGroup="popup" ></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" OnClientDateSelectionChanged="setDate"
                      Enabled="True" FirstDayOfWeek="Monday"  Format="yyyy-MM-dd" 
                      TargetControlID="addRegStart_txt" />
                    <br />
                    <br />
                    <asp:Label ID="addRegEnd_lbl" runat="server" Text="Registracijos pabaiga"></asp:Label>
                    <asp:TextBox ID="addRegEnd_txt" runat="server" TextMode="DateTime" ReadOnly="true" ValidationGroup="editPopup"  ></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" OnClientDateSelectionChanged="setDate"
                      Enabled="True" FirstDayOfWeek="Monday"  Format="yyyy-MM-dd" 
                      TargetControlID="addRegEnd_txt" />
                    <br />
                    <br />
                    <asp:Label ID="addIsRegOpen_lbl" runat="server" Text="Registracijos atidarymas/uždarymas"></asp:Label>
                    <br />
                    <asp:RadioButtonList ID="addIsRegOpen_ckbox" runat="server" ValidationGroup="editPopup" RepeatDirection="Horizontal" CssClass="gender rbl" ForeColor="White">
                        <asp:ListItem Value="Open"> Atidaryta </asp:ListItem>
                        <asp:ListItem Selected="True" Value="Closed"> Uždaryta </asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="editPopup" ControlToValidate="addIsRegOpen_ckbox"></asp:RequiredFieldValidator>
                    <br />
                 </div>
                <asp:Button ID="submit_btn" runat="server" Text="Pridėti" CausesValidation="true" ValidationGroup="popup" OnClick="submit_btn_Click"/>
                &nbsp;&nbsp;
                <asp:Button ID="cancel_btn" runat="server" Text="Atšaukti"/>
            </asp:Panel>
            <!-- add popup end-->


                        <!-- edit popup start-->

            <cc1:ModalPopupExtender ID="popupEdit" runat="server"
                TargetControlID="fake"
                PopupControlID="editPanel"
                DropShadow="false">
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
            
            <asp:Panel ID="editPanel" runat="server" CssClass="alert-primary" style='display: none;'>
                <h1>Keisti, ištrinti vartotoją</h1>
                <div>
                    <asp:Label ID="ErrorMessageEdit" runat="server" CssClass="col-md-2 control-label"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="editName_lbl" runat="server" Text="Pavadinimas"></asp:Label>
                    <asp:TextBox ID="editName_tb" runat="server" ValidationGroup="editPopup" ></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="editName_tb" ValidationGroup="editPopup" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                    <br />
                </div>
                <div>
                    <asp:Label ID="editLocation_lbl" runat="server" Text="Vieta"></asp:Label>
                    <asp:TextBox ID="editLocation_tb" runat="server" ValidationGroup="editPopup" ></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="editLocation_tb" ValidationGroup="editPopup" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                    <br />
                </div>
                <div>
                    <asp:Label ID="editAddress_lbl" runat="server" Text="Adresas"></asp:Label>
                    <asp:TextBox ID="editAddress_tb" runat="server" ValidationGroup="editPopup" ></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="editAddress_tb" ValidationGroup="editPopup" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="editDate_lbl" runat="server" Text="Data"></asp:Label>
                    <asp:TextBox ID="editDate_tb" runat="server" TextMode="DateTime" ReadOnly="true" ValidationGroup="editPopup" ></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" OnClientDateSelectionChanged="setDate"
                      Enabled="True" FirstDayOfWeek="Monday"  Format="yyyy-MM-dd" 
                      TargetControlID="editDate_tb" />
                    <br />
                    <br />
                    <asp:Label ID="editRegistrationStartDate_lbl" runat="server" Text="Registracijos pradžia"></asp:Label>
                    <asp:TextBox ID="editRegistrationStartDate_tb" runat="server" TextMode="DateTime" ReadOnly="true" ValidationGroup="editPopup" ></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" OnClientDateSelectionChanged="setDate"
                      Enabled="True" FirstDayOfWeek="Monday"  Format="yyyy-MM-dd" 
                      TargetControlID="editRegistrationStartDate_tb" />
                    <br />
                    <br />
                    <asp:Label ID="editRegistrationEndDate_lbl" runat="server" Text="Registracijos pabaiga"></asp:Label>
                    <asp:TextBox ID="editRegistrationEndDate_tb" runat="server" TextMode="DateTime" ReadOnly="true" ValidationGroup="editPopup" ></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" OnClientDateSelectionChanged="setDate"
                      Enabled="True" FirstDayOfWeek="Monday"  Format="yyyy-MM-dd" 
                      TargetControlID="editRegistrationEndDate_tb" />
                    <br />
                    <br />
                    <asp:Label ID="editisRegOpen_lbl" runat="server" Text="Registracijos atidarymas/uždarymas"></asp:Label>
                    <br />

                     <asp:RadioButtonList ID="editisRegOpen_ckbox" runat="server" ValidationGroup="editPopup" RepeatDirection="Horizontal" CssClass="gender rbl" ForeColor="White">
                        <asp:ListItem Value="Open"> Atidaryta </asp:ListItem>
                        <asp:ListItem Value="Closed"> Uzdaryta </asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="gendervalidator" runat="server" ControlToValidate="editisRegOpen_ckbox" ErrorMessage="Pasirinkite ar aktyvuoti"  ValidationGroup="editPopup" CssClass="errorMsg"></asp:RequiredFieldValidator>
                    <br />
                </div>
                <div>
                   
                    <br />
                    <br />
                </div>
                <asp:Button ID="edit_btn" runat="server" Text="Keisti" CausesValidation="true" OnClick="edit_btn_Click" ValidationGroup="editPopup"/>
                &nbsp;&nbsp;
                <asp:Button ID="canceledit_btn" runat="server" Text="Atšaukti"/>
                &nbsp;<asp:Button ID="remove_btn" runat="server" Text="Ištrinti varžybas" OnClick="remove_btn_Click"/>
            </asp:Panel>

            <!-- edit popup end-->

        </div>
    </asp:Content>
