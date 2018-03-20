<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MainAdminForm.aspx.cs" Inherits="Administration_MainAdminForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Button ID="logout_btn" runat="server" OnClick="logout_btn_Click" Text="Atsijungti" />
        <br />
        <br />
        <asp:Button ID="editusers_btn" runat="server" OnClick="editusers_btn_Click" Text="Dalyvių kūrimas, redagavimas" />
        <br />
        <br />
        <asp:Button ID="changepass_btn" runat="server" OnClick="changepass_btn_Click" Text="Pakeisti slaptažodį" />
    </form>
</body>
</html>
