<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ResetPassword_ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="font-family:Arial">
    <table style="border: 1px solid black; width:300px">
        <tr>
            <td colspan="2">
                Atstatykite slaptažodį</td>
        </tr>
        <tr>
            <td>
                Vartotojo vardas</td>    
            <td>
                <asp:TextBox ID="txtUserName" Width="150px" runat="server">
                </asp:TextBox>
            </td>    
        </tr>
        <tr>
            <td>
                    
            </td>    
            <td>
                <asp:Button ID="btnResetPassword" runat="server" 
                Width="150px" Text="Atstatyti" onclick="btnResetPassword_Click" />
            </td>    
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td>    
        </tr>
    </table>
</div>
    </form>
</body>
</html>
