<%@ Page Title="Vartotojai" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateEditUsers.aspx.cs" Inherits="WebApplication.Admin.CreateEditUsers" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

    <asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
        <h2><%: Title %>.</h2>
        <h4>Redaguoti ir pridėti vartotojus</h4>
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





        </style>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [Id], [Email], [Name], [Surname], [PhoneNumber], [UserName], [Role] FROM [AspNetUsers]"></asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="table table-curved table-hover table-striped text-codemess table-dark noBorder" BackColor="Gray" BorderColor="black" ForeColor="white" GridLines="Horizontal" DataKeyNames="Id" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <PagerStyle BackColor="#4A4A4A" ForeColor="Black" HorizontalAlign="Center" Font-Bold="True"  />
            <Columns>
                <asp:CommandField ShowSelectButton="True" SelectText="Pasirinkti" ControlStyle-CssClass="btn btn-success" />
                <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="Name" HeaderText="Vardas" SortExpression="Name" />
                <asp:BoundField DataField="Surname" HeaderText="Pavardė" SortExpression="Surname" />
                <asp:BoundField DataField="Email" HeaderText="El-paštas" SortExpression="Email" />
                <asp:BoundField DataField="PhoneNumber" HeaderText="Telefono numeris" SortExpression="PhoneNumber" />
                <asp:BoundField DataField="Role" HeaderText="Rolė" SortExpression="Role" />
                <asp:BoundField DataField="UserName" HeaderText="Slapyvardis" SortExpression="UserName" />
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
                DropShadow="false"
                BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>

            
            <asp:Panel ID="PanelAdd" runat="server" BorderWidth="5px" HorizontalAlign="center" BackColor="#484848" BorderColor="#33CCFF" ForeColor="White" CssClass=" alert-secondary" style='display: none;'>
                <h1>Pridėti vartotoją</h1>
                <div>
                    <asp:Label ID="ErrorMessage" runat="server" CssClass="col-md-2 control-label errorMsg"></asp:Label>
         
                </div>
                <div>
                    <asp:Label ID="email_lbl" runat="server" Text="Elektroninis paštas:" CssClass="formatText"></asp:Label>
                    <asp:TextBox ID="email_tb" runat="server" TextMode="Email" ValidationGroup="popup"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="emailvalidator" runat="server" ErrorMessage="Įveskite el. paštą" ControlToValidate="email_tb" ValidationGroup="popup" CssClass="errorMsg"></asp:RequiredFieldValidator>
                </div>
                <div>
                    <asp:Label ID="passw_lbl" runat="server" Text="Slaptažodis:" CssClass="formatText"></asp:Label>
                    <asp:TextBox ID="passw_tb" runat="server" TextMode="Password" ValidationGroup="popup"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="passwordvalidator" runat="server" ErrorMessage="Įveskite slaptažodį" ControlToValidate="passw_tb" ValidationGroup="popup" CssClass="errorMsg"></asp:RequiredFieldValidator>
                </div>
                <div>
                    <asp:Label ID="passwcheck_lbl" runat="server" Text="Patvirtinti slaptažodį:" CssClass="formatText"></asp:Label>
                    <asp:TextBox ID="passwver_tb" runat="server" TextMode="Password" ValidationGroup="popup"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="passconfirmvalidator" runat="server" ErrorMessage="Patvirtinkite slaptažodį" ControlToValidate="passwver_tb" ValidationGroup="popup" CssClass="errorMsg"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="comparepassvalidator" runat="server" ErrorMessage="Slaptažodžiai nesutampa" ControlToValidate="passwver_tb" Display="Dynamic" ValidationGroup="popup" ControlToCompare="passw_tb" CssClass="errorMsg"></asp:CompareValidator>
                </div>
                <div>
                    <asp:DropDownList ID="roleDropListAdd" runat="server" CssClass="btn-sm">

                          <asp:ListItem Selected="true" Value="User"> 3 - Vartotojas </asp:ListItem>
                          <asp:ListItem Value="Coach"> 2 - Treneris </asp:ListItem>
                          <asp:ListItem Value="Official"> 1 - Teisėjas </asp:ListItem>
                          <asp:ListItem Value="Admin"> 0 - Admin </asp:ListItem>

                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="dropdownvalidator" runat="server" ErrorMessage="Nepasirinktas vartotojo tipas" ControlToValidate="roleDropListAdd" ValidationGroup="popup" CssClass="errorMsg"></asp:RequiredFieldValidator>
                </div>
                <br />
                <asp:Button ID="submit_btn" runat="server" Text="Pridėti" CausesValidation="true" ValidationGroup="popup" OnClick="submit_btn_Click" CssClass="btn"/>
                <asp:Button ID="cancel_btn" runat="server" Text="Atšaukti" CssClass="btn"/>
                <br />
                <br />
               
            </asp:Panel>
            <!-- add popup end-->

            <!-- edit popup start-->

            <cc1:ModalPopupExtender ID="popupEdit" runat="server"
                TargetControlID="fake"
                PopupControlID="editPanel"
                DropShadow="false"
                BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>
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
            
            <asp:Panel ID="editPanel" runat="server" BorderWidth="5px" HorizontalAlign="center" BackColor="#484848" BorderColor="#33CCFF" ForeColor="White" CssClass=" alert-secondary">
                <h1>Keisti, ištrinti vartotoją</h1>
                <div>
                    <asp:Label ID="ErrorMessageEdit" runat="server" CssClass="col-md-2 control-label errorMsg"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="editEmail_lbl" runat="server" Text="Elektroninis paštas:" CssClass="formatText"></asp:Label>
                    <asp:TextBox ID="editEmail_tb" runat="server" TextMode="Email" ValidationGroup="editPopup" ></asp:TextBox>
                    <br />
                    <br />
                </div>
                <div>
                    <asp:Label ID="editpass_lbl" runat="server" Text="Slaptažodis:" CssClass="formatText"></asp:Label>
                    <asp:TextBox ID="editpass_tb" runat="server" TextMode="Password" ValidationGroup="editPopup" ></asp:TextBox>
                    <br />
                    <br />
                </div>
                <div>
                    <asp:Label ID="editpassval_lbl" runat="server" Text="Patvirtinti slaptažodį:" CssClass="formatText"></asp:Label>
                    <asp:TextBox ID="editpassval_tb" runat="server" TextMode="Password" ValidationGroup="editPopup" ></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="editname_lbl" runat="server" Text="Vardas:" CssClass="formatText"></asp:Label>
                    <asp:TextBox ID="name_tb" runat="server" ValidationGroup="editPopup"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="editsurname_lbl" runat="server" Text="Pavardė:" CssClass="formatText"></asp:Label>
                    <asp:TextBox ID="surname_tb" runat="server" ValidationGroup="editPopup" ></asp:TextBox>
                    <br />
                    <br />
                </div>
                <div>
                    <asp:DropDownList ID="roleDropListEdit" runat="server" CssClass="btn-sm">

                          <asp:ListItem Selected="true" Value="User"> 3 - Vartotojas </asp:ListItem>
                          <asp:ListItem Value="Coach"> 2 - Treneris </asp:ListItem>
                          <asp:ListItem Value="Official"> 1 - Teisėjas </asp:ListItem>
                          <asp:ListItem Value="Admin"> 0 - Admin </asp:ListItem>

                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Nepasirinktas vartotojo tipas" ControlToValidate="roleDropListEdit" ValidationGroup="popup"></asp:RequiredFieldValidator>
                </div>
                <br />
                <asp:Button ID="edit_btn" runat="server" Text="Keisti" CausesValidation="true" OnClick="edit_btn_Click" ValidationGroup="editPopup" CssClass="btn"/>
                &nbsp;&nbsp;
                <asp:Button ID="canceledit_btn" runat="server" Text="Atšaukti" CssClass="btn"/>
                &nbsp;<asp:Button ID="remove_btn" runat="server" Text="Ištrinti paskyrą" OnClick="remove_btn_Click" CssClass="btn btn-danger"/>
                <br />
                <br />
            </asp:Panel>


            <!-- edit popup end-->
        

     
    </asp:Content>