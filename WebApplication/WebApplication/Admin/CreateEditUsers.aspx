<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateEditUsers.aspx.cs" Inherits="WebApplication.Admin.CreateEditUsers" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

    <asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
        <style>

        </style>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [Id], [Email], [Name], [Surname], [PhoneNumber], [UserName], [Role] FROM [AspNetUsers]"></asp:SqlDataSource>
        <br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover text-primary"  DataKeyNames="Id" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Surname" HeaderText="Surname" SortExpression="Surname" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="PhoneNumber" HeaderText="PhoneNumber" SortExpression="PhoneNumber" />
                <asp:BoundField DataField="Role" HeaderText="Role" SortExpression="Role" />
                <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
            </Columns>
        </asp:GridView>
        <br />
        <div>

            <asp:Button ID="add_btn2" runat="server" class="btn btn-default" Text="Pridėti" OnClick="add_btn_Click"/>
            <asp:LinkButton ID="fake" runat="server"></asp:LinkButton>

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
                    <asp:Label ID="editEmail_lbl" runat="server" Text="Elektroninis paštas"></asp:Label>
                    <asp:TextBox ID="editEmail_tb" runat="server" TextMode="Email" ValidationGroup="editPopup" ></asp:TextBox>
                    <br />
                    <br />
                </div>
                <div>
                    <asp:Label ID="editpass_lbl" runat="server" Text="Slaptažodis"></asp:Label>
                    <asp:TextBox ID="editpass_tb" runat="server" TextMode="Password" ValidationGroup="editPopup" ></asp:TextBox>
                    <br />
                    <br />
                </div>
                <div>
                    <asp:Label ID="editpassval_lbl" runat="server" Text="Patvirtinti slaptažodį"></asp:Label>
                    <asp:TextBox ID="editpassval_tb" runat="server" TextMode="Password" ValidationGroup="editPopup" ></asp:TextBox>
                    <br />
                    <br />
                    Vardas
                    <asp:TextBox ID="name_tb" runat="server" ValidationGroup="editPopup" ></asp:TextBox>
                    <br />
                    <br />
                    Pavardė
                    <asp:TextBox ID="surname_tb" runat="server" ValidationGroup="editPopup" ></asp:TextBox>
                    <br />
                    <br />
                </div>
                <div>
                    <asp:DropDownList ID="roleDropListEdit" runat="server">

                          <asp:ListItem Selected="true" Value="User"> 3 - Vartotojas </asp:ListItem>
                          <asp:ListItem Value="Coach"> 2 - Treneris </asp:ListItem>
                          <asp:ListItem Value="Official"> 1 - Teisėjas </asp:ListItem>
                          <asp:ListItem Value="Admin"> 0 - Admin </asp:ListItem>

                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Nepasirinktas vartotojo tipas" ControlToValidate="roleDropListEdit" ValidationGroup="popup"></asp:RequiredFieldValidator>
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