<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" Culture="lt-LT" UICulture="lt-LT" CodeBehind="FindUser.aspx.cs" Inherits="WebApplication.Admin.FindUser" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

    <asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
        <style>

        </style>

        <script type="text/javascript">
        function checkDate(sender,args)
        {
         if (sender._selectedDate > new Date())
                    {
                        alert("Negalima data!");
                        sender._selectedDate = new Date(); 
                        // set the date back to the current date
                        sender._textbox.set_Value("");
                    }
        }
     </script>

        <br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover text-primary"  DataKeyNames="Id" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Surname" HeaderText="Surname" SortExpression="Surname" />
                <asp:BoundField DataField="Year" HeaderText="Year" SortExpression="Year" />
                <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
            </Columns>
        </asp:GridView>
        <br />
        <div>

            <asp:Button ID="add_btn" runat="server" class="btn btn-default" Text="Pridėti" OnClick="add_btn_Click" CausesValidation="False"/>
            <asp:LinkButton ID="fake" runat="server"></asp:LinkButton>
            <br />
            <br />
            <asp:Label ID="searcherror_lbl" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <div>
                <asp:TextBox ID="IdTextBox" TextMode="Number" runat="server" ClientIDMode="Static" AutoPostBack="false" ValidationGroup="search"></asp:TextBox>
                <asp:RequiredFieldValidator ID="textboxvalidator" ControlToValidate="IdTextBox" EnableClientScript="true" runat="server" ErrorMessage="Įveskite ID" ForeColor="Red" ValidationGroup="search"></asp:RequiredFieldValidator>
                 <br />
                 <asp:Button ID="searchid_btn" runat="server" class="btn btn-default" CausesValidation="true" Text="Ieskoti Pagal ID" OnClick="FindID_Click" ValidationGroup="search"/>
            </div>

            <div>
                <br />
                <asp:TextBox ID="SurnameTextBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="SurnameValidator" ControlToValidate="SurnameTextBox" runat="server" ErrorMessage="Įveskite pavardę" ForeColor="Red"></asp:RequiredFieldValidator>
                 <br />
                 <asp:Button ID="searchsurname_btn" runat="server" CausesValidation="true" class="btn btn-default" Text="Ieskoti Pagal pavardę" OnClick="searchsurname_btn_Click"/>
            </div>

            <!-- add popup start -->
            
            <cc1:ModalPopupExtender ID="popupAdd" runat="server"
                TargetControlID="fake"
                PopupControlID="PanelAdd"
                DropShadow="false">
            </cc1:ModalPopupExtender>
            
            <asp:Panel ID="panelAdd" runat="server" BorderWidth="5px" Width="30%" HorizontalAlign="center" style='display: none;' BackColor="#484848"  BorderColor="#33CCFF"  ForeColor="White" CssClass=" alert-secondary"  >
            <h1>Pridėti dalyvį</h1>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" Visible="False" ValidationGroup="addcomp" />
            <div>
                <div>
                    <asp:Label ID="gender_lbl" runat="server" Text="Lytis"></asp:Label>
                    <asp:RadioButtonList ID="gender_radbtn" runat="server" ValidationGroup="addcomp" RepeatDirection="Horizontal" CssClass="gender rbl" ForeColor="White">
                        <asp:ListItem>Vyras</asp:ListItem>
                        <asp:ListItem>Moteris</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="gendervalidator" runat="server" ControlToValidate="gender_radbtn" ErrorMessage="Pasirinkie lytį" ValidationGroup="addcomp" CssClass="errorMsg"></asp:RequiredFieldValidator>
                </div>
                <div>
                    <asp:Label ID="name_lbl" runat="server" Text="Vardas:" CssClass="formatText"></asp:Label>
                    <asp:TextBox ID="name_tb" runat="server" ValidationGroup="addcomp" CssClass="formatCell"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="namevalidator" runat="server" ControlToValidate="name_tb" ErrorMessage="Įveskite vardą" ValidationGroup="addcomp" CssClass="errorMsg errorMsg2"></asp:RequiredFieldValidator>
                    <br />
                </div>
                <div>
                    <asp:Label ID="surname_lbl" runat="server" Text="Pavardė:" CssClass="formatText"></asp:Label>
                    <asp:TextBox ID="surname_tb" runat="server" ValidationGroup="addcomp" CssClass="formatCell"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="surname_tb" ErrorMessage="Įveskite pavardę" ValidationGroup="addcomp" CssClass="errorMsg errorMsg2"></asp:RequiredFieldValidator>
                    <br />
                </div>
                <div>
                    <asp:Label ID="year_lbl" runat="server" Text="Gim. metai:" CssClass="formatText"></asp:Label>
                    <asp:TextBox ID="year_tb" runat="server" ValidationGroup="addcomp" TextMode="DateTime"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender10" runat="server" OnClientDateSelectionChanged="checkDate"
                      Enabled="True" FirstDayOfWeek="Monday"  Format="yyyy-MM-dd" 
                      TargetControlID="year_tb" />
                    <br />
                    <asp:RequiredFieldValidator ID="yearsvalidator" runat="server" ControlToValidate="year_tb" ErrorMessage="Pasirinkite gimimo metus" ValidationGroup="addcomp" CssClass="errorMsg errorMsg2"></asp:RequiredFieldValidator>
                    <br />
                </div>
                <div>
                    <asp:Label ID="city_lbl" runat="server" Text="Miestas:" CssClass="formatText"></asp:Label>
                    <asp:TextBox ID="city_tb" runat="server" ValidationGroup="addcomp" CssClass="formatCell"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="citevalidator" runat="server" ControlToValidate="city_tb" ErrorMessage="Pasirinkite miestą" ValidationGroup="addcomp" CssClass="errorMsg errorMsg2"></asp:RequiredFieldValidator>
                    <br />
                </div>
                <div>
                    <asp:Label ID="country_lbl" runat="server" Text="Šalis:" CssClass="formatText"></asp:Label>
                    <asp:TextBox ID="country_tb" runat="server" ValidationGroup="addcomp" CssClass="formatCell"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="countryvalidator" runat="server" ControlToValidate="country_tb" ErrorMessage="Pasirinkite šalį" ValidationGroup="addcomp" CssClass="errorMsg errorMsg2"></asp:RequiredFieldValidator>
                    <br />
                    <asp:DropDownList ID="DropDownList1" runat="server" ValidationGroup="addcomp">
                    </asp:DropDownList>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DropDownList1" ErrorMessage="Pairinkite trenerį" ValidationGroup="addcomp"></asp:RequiredFieldValidator>
                    <br />
                </div>
                <div class="btn">
                    <asp:Button ID="create_btn" runat="server" Text="Pridėti" CausesValidation="true" ValidationGroup="addcomp" OnClick="submit_btn_Click" CssClass="btn"/>
                    <asp:Button ID="cancel_btn" runat="server" Text="Atšaukti" CausesValidation="false" CssClass="btn"/>
                </div>
            </div>
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
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
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
                    <asp:Label ID="editName_lbl" runat="server" Text="Vardas"></asp:Label>
                    <asp:TextBox ID="editName_tb" runat="server"  ValidationGroup="editPopup" ></asp:TextBox>
                    <br />
                    <br />
                </div>
                <div>
                    <asp:Label ID="editSurname_lbl" runat="server" Text="Pavardė"></asp:Label>
                    <asp:TextBox ID="editSurname_tb" runat="server"  ValidationGroup="editPopup" ></asp:TextBox>
                    <br />
                    <br />
                </div>
                <div>
                    <asp:Label ID="editYear_lbl" runat="server" Text="Metai"></asp:Label>
                    <asp:TextBox ID="editYear_tb" runat="server" TextMode="DateTime" ValidationGroup="editPopup" ></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="TextBox4_CalendarExtender" runat="server" OnClientDateSelectionChanged="checkDate"
                      Enabled="True" FirstDayOfWeek="Monday"  Format="yyyy-MM-dd" 
                      TargetControlID="editYear_tb" />
                    <br />
                    <br />
                    <asp:Label ID="editCity_lbl" runat="server" Text="Miestas"></asp:Label>
                    <asp:TextBox ID="editCity_tb" runat="server"  ValidationGroup="editPopup" ></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="editCountry_lbl" runat="server" Text="Šalis"></asp:Label>
                    <asp:TextBox ID="editCountry_tb" runat="server"  ValidationGroup="editPopup" ></asp:TextBox>
                    <br />
                    <br />
                </div>
                <div>
                    <asp:DropDownList ID="GenderDropListEdit" runat="server">

                          <asp:ListItem Selected="true" Value="Vyras"> Vyras </asp:ListItem>
                          <asp:ListItem Value="Moteris"> Moteris </asp:ListItem>

                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Nepasirinkta Lytis" ControlToValidate="GenderDropListEdit" ValidationGroup="popup"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                </div>
                <asp:Button ID="edit_btn" runat="server" Text="Keisti" CausesValidation="true" OnClick="edit_btn_Click" ValidationGroup="editPopup"/>
                &nbsp;&nbsp;
                <asp:Button ID="canceledit_btn" runat="server" Text="Atšaukti"/>
                &nbsp;<asp:Button ID="remove_btn" runat="server" Text="Ištrinti paskyrą" OnClick="remove_btn_Click"/>
            </asp:Panel>

            <!-- edit popup end-->
        

     
    </asp:Content>