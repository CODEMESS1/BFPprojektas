<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ResetPassword_ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="icon" 
     type="image/png" 
     href="../Images/pagelogo.png"/>
    <title></title>
    <style type="text/css">

        #form2 {
            width: 100%;
            height: 100%;
            background-image: url(../Images/logo.png), url("../Images/darken-40.png"), url("../Images/pattern.jpg");
            background-position: right 88%, left top, left top;
            background-repeat: no-repeat, repeat, repeat;
            
        }

        .textbox1 {
            text-align: center;
            width: 187px;
            height: 47px;
        }
        .table-1 {
            align-self:center;
            font-family: Calibri, Candara, Segoe, "Segoe UI", Optima, Arial, sans-serif;
            color: white;
            height: 200px;
            width: 364px;
            margin-top:50%;
            background-image: url("../Images/darken70.png");
        }
        .textbox2 {
            text-align: center;
            width: 187px;
            height: 45px;
        }
        .align1 {
            margin-top:0px auto;
            margin:0px auto;
        }

        .align2 {
            width: 364px;
        }
        

        .button {
            background-color: #56c7e9;
            font-family: Calibri, Candara, Segoe, "Segoe UI", Optima, Arial, sans-serif;
            border: none;
            color: white;
            padding: 3px 12px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 16px;
            margin: 4px 2px;
            cursor: pointer;
        }

        .footer {
            position: fixed;
            font-family: Calibri, Candara, Segoe, "Segoe UI", Optima, Arial, sans-serif;
            left: 0;
            bottom: 0;
            height: 6%;
            width: 100%;
            background-image: url("../Images/darken-40.png");
            color: white;
            text-align: center;
        }
        
        </style>
</head>
<body style="position: absolute; overflow: hidden; height:101%; width:100%; top: -11px; left: -8px;">
    <form id="form2" runat="server">
        <div style="font-family:Arial">
    <table style="border:0"; class="align1"; draggable="false">

        <tr>
        <td class="align2">
            <table class="table-1" border="0">
        <tr>
            <td class="textbox1" colspan="2">
                Atstatykite slaptažodį</td>
        </tr>
        <tr>
            <td class="textbox2">
                Vartotojo vardas:</td>    
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
                Width="150px" Text="Atstatyti" onclick="btnResetPassword_Click" CssClass="button" />
            </td>    
        </tr>
        <tr>
            <td colspan="2" class="textbox1">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td>    
        </tr>
                </table>
            </td>
            </tr>
    </table>
</div>
    </form>
    <div class="footer">
  <p>2018 - CodeMess</p>
</div>
</body>
</html>
