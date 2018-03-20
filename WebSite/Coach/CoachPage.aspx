<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CoachPage.aspx.cs" Inherits="CoachPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Trenerio puslapis<br />
            <br />
            <asp:Button ID="changepass_btn" runat="server" OnClick="changepass_btn_Click" Text="Pakeisti slaptažodį" />
        </div>
        <p>
            <asp:Button ID="logout_btn" runat="server" OnClick="logout_btn_Click" Text="Atsijungti" />
        </p>
    </form>
</body>
</html>
