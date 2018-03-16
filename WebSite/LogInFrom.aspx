<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogInFrom.aspx.cs" Inherits="LogInFrom" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>PRISIJUNGIMAS</h1>
    </div>
        Prisijungimo vardas&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="username_tb" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="login_username_validator" runat="server" ControlToValidate="username_tb" ErrorMessage="Įveskite prisijungimo vardą" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        Slaptažodis&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="password_tb" runat="server" TextMode="Password"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="login_password_validator" runat="server" ControlToValidate="password_tb" ErrorMessage="Įveskite slaptažodį" ForeColor="#FF3300"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Button ID="login_btn" runat="server" OnClick="login_btn_Click" Text="Prisijungti" />
    </form>
</body>
</html>
