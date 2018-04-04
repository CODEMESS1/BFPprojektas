<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="PrintLists.aspx.cs" Inherits="WebApplication.Admin.PrintLists" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <asp:Label ID="printofficials_lbl" runat="server" Text="Spausdinti teisėjų sąrašą"></asp:Label>
    <br />
    <br />
    <asp:Button ID="printofficial_btn" runat="server" OnClick="printofficial_btn_Click" Text="Spausdinti" />
    <br />
    <br />
    <asp:Label ID="printcoach_lbl" runat="server" Text="Spausdinti trenerių sąrašą"></asp:Label>
    <br />
    <br />
    <asp:Button ID="printcoach_btn" runat="server" OnClick="printcoach_btn_Click" Text="Spausdinti" />
    <br />

</asp:Content>