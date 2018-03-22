<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateEditUsers.aspx.cs" Inherits="WebApplication.Admin.CreateEditUsers" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .ModalPopupBG
        {
            background-color: #666699;
            filter: alpha(opacity=50);
            opacity: 0.7;
        }

        .HellowWorldPopup
        {
            min-width:200px;
            min-height:150px;
            background:white;
        }
    </style>
</head>
<body style="height: 574px">
    <form id="form1" runat="server">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [Id], [Email], [Name], [Surname], [PhoneNumber], [UserName], [Role] FROM [AspNetUsers]"></asp:SqlDataSource>
        <br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="Id" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Vertical" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
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
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
        <br />
        <div>
            <asp:Button ID="add_btn" runat="server" Text="Pridėti" OnClick="add_btn_Click"/>
            <asp:LinkButton ID="fake" runat="server"></asp:LinkButton>

            <!-- add popup start -->
            
            <cc1:ModalPopupExtender ID="popupAdd" runat="server"
                TargetControlID="fake"
                PopupControlID="PanelAdd"
                DropShadow="false">
            </cc1:ModalPopupExtender>
            
            <asp:ScriptManager ID="ScriptManager" runat="server">

            </asp:ScriptManager>
            
            <asp:Panel ID="PanelAdd" runat="server">
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
                    <asp:DropDownList ID="roleDropList" runat="server">

                          <asp:ListItem Selected="True" Value="User"> 3 - Vartotojas </asp:ListItem>
                          <asp:ListItem Value="Coach"> 2 - Treneris </asp:ListItem>
                          <asp:ListItem Value="Official"> 1 - Teisėjas </asp:ListItem>
                          <asp:ListItem Value="Admin"> 0 - Admin </asp:ListItem>

                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="dropdownvalidator" runat="server" ErrorMessage="Nepasirinktas vartotojo tipas" ControlToValidate="roleDropList" ValidationGroup="popup"></asp:RequiredFieldValidator>
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
            
            <asp:Panel ID="editPanel" runat="server">
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
                    <asp:DropDownList ID="DropDownList1" runat="server" ValidationGroup="editPopup" Height="16px" >

                          <asp:ListItem Selected="True" Value="User"> 3 - Vartotojas </asp:ListItem>
                          <asp:ListItem Value="Coach"> 2 - Treneris </asp:ListItem>
                          <asp:ListItem Value="Official"> 1 - Teisėjas </asp:ListItem>
                          <asp:ListItem Value="Admin"> 0 - Admin </asp:ListItem>

                    </asp:DropDownList>
                    <br />
                    <br />
                </div>
                <asp:Button ID="edit_btn" runat="server" Text="Keisti" CausesValidation="true" OnClick="edit_btn_Click" ValidationGroup="editPopup"/>
                &nbsp;&nbsp;
                <asp:Button ID="canceledit_btn" runat="server" Text="Atšaukti"/>
                &nbsp;<asp:Button ID="remove_btn" runat="server" Text="Ištrinti paskyrą" OnClick="remove_btn_Click"/>
            </asp:Panel>

            <!-- edit popup end-->

        </div>
    </form>
    </body>
</html>
