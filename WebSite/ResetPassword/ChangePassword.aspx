<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ResetPassword_ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
           <div style="font-family:Arial">
    <table style="border:0"; class="align1"; draggable="false">

        <tr>
        <td class="align2">
            <table class="table-1" border="0">
        <tr>
            <td class="textbox1" colspan="2">
                Paksikeiskite slaptažodį</td>
        </tr>
        <tr>
            <td class="textbox2">
                Senas slaptažodis:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="oldpass_tb"></asp:RequiredFieldValidator>
            </td>    
            <td>
                <asp:TextBox ID="oldpass_tb" Width="150px" runat="server" TextMode="Password"></asp:TextBox>
            </td>    
        </tr>
        <tr>
            <td>
                Naujas slaptažodis<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="newpass_tb"></asp:RequiredFieldValidator>
            </td>    
            <td>
                <asp:TextBox ID="newpass_tb" runat="server" Width="150px" TextMode="Password"></asp:TextBox>
            </td>  
        </tr>
        <tr>
            <td class="textbox1">
                Pakartokite slaptažodį<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="newver_tb"></asp:RequiredFieldValidator>
            </td>    
            <td class="textbox1">
                <asp:TextBox ID="newver_tb" runat="server" Width="150px" TextMode="Password"></asp:TextBox>
            </td>    
        </tr>
        <tr>
            <td class="textbox1">
                <asp:ValidationSummary ID="ValidationSummary" runat="server" DisplayMode="SingleParagraph" HeaderText="Neteisingai įvesti duomenys" />
            </td>    
            <td class="textbox1">
                <asp:Button ID="changepass_btn" runat="server" OnClick="changepass_btn_Click" Text="Button" />
            </td>    
        </tr>
                </table>
            </td>
            </tr>
    </table>
</div>
           <asp:Label ID="message_lbl" runat="server"></asp:Label>
           <br />
           <asp:Button ID="back_btn" runat="server" OnClick="back_btn_Click" Text="Grįžti atgal" CausesValidation="False" />
    </form>
</body>
</html>
