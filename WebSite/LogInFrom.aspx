<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogInFrom.aspx.cs" Inherits="LogInFrom" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="icon" 
     type="image/png" 
     href="../Images/pagelogo.png"/>
    <title></title>
    <style type="text/css">
        #form1 {
            width: 100%;
            height: 100%;
            background-image: url(../Images/logo.png), url("../Images/darken-40.png"), url("../Images/pattern.jpg");
            background-position: bottom right, left top, left top;
            background-repeat: no-repeat, repeat, repeat;
            
        }



        .auto-style8 {
            width: 103px;
            height: 47px;
        }
        .auto-style9 {
            text-align: center;
            width: 187px;
            height: 47px;
        }
        .auto-style10 {
            align-self:center;
            font-family: Calibri, Candara, Segoe, "Segoe UI", Optima, Arial, sans-serif;
            color: white;
            height: 200px;
            width: 364px;
            margin-top:50%;
            background-image: url("../Images/darken70.png");
        }
        .auto-style11 {
            text-align: center;
            width: 187px;
            height: 45px;
        }
        .auto-style12 {
            width: 103px;
            height: 45px;
        }
        .auto-style13 {
            height: 27px;
            text-align: left;
            margin-left: 80px;
        }
        .auto-style14 {
            margin-top:0px auto;
            margin:0px auto;
        }
        .auto-style15 {
            text-align: center;     
        }
        .auto-style16 {
            text-align: center;
            height: 25px;
        }
        .auto-style18 {
            text-align: left;
            height: 3px;
            background-color: #000000;
            margin-bottom: 0px;
        }
        .auto-style19 {
            background-color: #FFFFFF;
            width: 928px;
            height: 494px;
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

        </style>
</head>

<body style="position: absolute; overflow: hidden; height:101%; width:100%; top: -11px; left: -8px;">
    <form id="form1" runat="server" class="auto-style19">
        <script src="RememberMe.js" type="text/javascript"></script>
                <div class="auto-style18">
                <table style="border:0"; class="auto-style14"; draggable="false">

                    <tr>
                        <td class="auto-style7">
                            <table class="auto-style10" border="0">
                                <tr>
                                    <td class="auto-style9">
                                        <asp:Label ID="UserNameLabel" runat="server">Prisijungimo vardas:</asp:Label>
                                    </td>
                                    <td class="auto-style8">
                                        <asp:TextBox ID="username_tb" runat="server" Height="16px" Width="145px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style11">
                                        Slaptažodis:</td>
                                    <td class="auto-style12">
                                        <asp:TextBox ID="password_tb" runat="server" TextMode="Password" Width="145px" Height="16px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="auto-style13">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:CheckBox ID="RememberMe" runat="server" Text="Prisiminti mano prisijungimą" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="color: Red;" class="auto-style16">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="password_tb"></asp:RequiredFieldValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="username_tb"></asp:RequiredFieldValidator>
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="SingleParagraph" HeaderText="Neteisingas slaptažodis arba prisijungimo vardas" />
                                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False" Text=""></asp:Literal> 
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" class= "auto-style15">
                                        <asp:Button ID="login_btn" runat="server" CommandName="Login" OnClick="login_btn_Click" Text="Prisijungti" CssClass="button" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
           </div>
    </form>
</body>
</html>
