﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogInFrom.aspx.cs" Inherits="LogInFrom" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            width: 100%;
            height: 2000px;
            background-color: #534A4A;
        }
        .auto-style7 {
            width: 364px;
            height: 21px;
            background-color: #534A4A;
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
            height: 109px;
            width: 364px;
            margin-top:50%;
            background-color: #FFFFFF;
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
        }
        .auto-style19 {
            background-color: #FFFFFF;
            width: 928px;
            height: 494px;
        }
        </style>
</head>
<body style="position: absolute; overflow: hidden; height:100%; width:100%;">
    <form id="form1" runat="server" class="auto-style19">
                <div class="auto-style18">
                <table style="border:0"; class="auto-style14"; draggable="false">
                    <tr>
                        <td class="auto-style7">
                            <table class="auto-style10" border="0">
                                <tr>
                                    <td class="auto-style9">
                                        <asp:Label ID="UserNameLabel" runat="server">Prisijungimo Vardas</asp:Label>
                                    </td>
                                    <td class="auto-style8">
                                        <asp:TextBox ID="username_tb" runat="server" Height="16px" Width="145px" OnTextChanged="username_tb_TextChanged1"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style11">
                                        Slaptažodis</td>
                                    <td class="auto-style12">
                                        <asp:TextBox ID="password_tb" runat="server" TextMode="Password" Width="145px" Height="16px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="auto-style13">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:CheckBox ID="RememberMe" runat="server" Text="Prisiminti mano prisijungimą" OnCheckedChanged="RememberMe_CheckedChanged" />
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
                                    <td colspan="2" class="auto-style15">
                                        <asp:Button ID="login_btn" runat="server" CommandName="Login" OnClick="login_btn_Click" Text="Prisijungti" />
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
