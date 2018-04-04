<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FindUser.aspx.cs" Inherits="WebApplication.Admin.FindUser" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

    <asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
        <style>

        </style>

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

            <asp:Button ID="add_btn2" runat="server" class="btn btn-default" Text="Pridėti" OnClick="add_btn_Click"/>
            <asp:LinkButton ID="fake" runat="server"></asp:LinkButton>
                    <div>
            <asp:TextBox ID="PersonSurname" runat="server"></asp:TextBox>
            <div>
                 <asp:Button ID="SearchID" runat="server" class="btn btn-default" Text="Ieskoti Pagal ID" OnClick="FindID_Click"/>
            </div>

            <!-- add popup start -->
            
            <cc1:ModalPopupExtender ID="popupAdd" runat="server"
                TargetControlID="fake"
                PopupControlID="PanelAdd"
                DropShadow="false">
            </cc1:ModalPopupExtender>
            
            <asp:Panel ID="PanelAdd" runat="server" CssClass="alert-primary" BorderWidth="5px" style='display: none;'>
                <h1>Pridėti vartotoją</h1>
                <div>
                    <asp:Label ID="ErrorMessage" runat="server" CssClass="col-md-2 control-label"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="email_lbl" runat="server" Text="Elektroninis paštas"></asp:Label>
                    <asp:TextBox ID="email_tb" runat="server" TextMode="Email" ValidationGroup="popup"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="emailvalidator" runat="server" ErrorMessage="Įveskite el. paštą" ControlToValidate="email_tb" ValidationGroup="popup"></asp:RequiredFieldValidator>
                </div>
                <div>
                    <asp:Label ID="passw_lbl" runat="server" Text="Slaptažodis"></asp:Label>
                    <asp:TextBox ID="passw_tb" runat="server" TextMode="Password" ValidationGroup="popup"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="passwordvalidator" runat="server" ErrorMessage="Įveskite slaptažodį" ControlToValidate="passw_tb" ValidationGroup="popup"></asp:RequiredFieldValidator>
                </div>
                <div>
                    <asp:Label ID="Label1" runat="server" Text="Patvirtinti"></asp:Label>
                    &nbsp;<asp:TextBox ID="passwver_tb" runat="server" TextMode="Password" ValidationGroup="popup"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="passconfirmvalidator" runat="server" ErrorMessage="Patvirtinkite slaptažodį" ControlToValidate="passwver_tb" ValidationGroup="popup"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="comparepassvalidator" runat="server" ErrorMessage="Slaptažodžiai nesutampa" ControlToValidate="passwver_tb" Display="Dynamic" ValidationGroup="popup" ControlToCompare="passw_tb"></asp:CompareValidator>
                </div>
                <div>
                    <asp:DropDownList ID="roleDropListAdd" runat="server">

                          <asp:ListItem Selected="true" Value="User"> 3 - Vartotojas </asp:ListItem>
                          <asp:ListItem Value="Coach"> 2 - Treneris </asp:ListItem>
                          <asp:ListItem Value="Official"> 1 - Teisėjas </asp:ListItem>
                          <asp:ListItem Value="Admin"> 0 - Admin </asp:ListItem>

                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="dropdownvalidator" runat="server" ErrorMessage="Nepasirinktas vartotojo tipas" ControlToValidate="roleDropListAdd" ValidationGroup="popup"></asp:RequiredFieldValidator>
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
                    <asp:TextBox ID="editYear_tb" runat="server" TextMode="Date" ValidationGroup="editPopup" ></asp:TextBox>
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