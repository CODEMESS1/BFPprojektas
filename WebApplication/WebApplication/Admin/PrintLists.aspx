<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="PrintLists.aspx.cs" Inherits="WebApplication.Admin.PrintLists" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">


    <div class="alert alert-success text-center" role="alert">
      <h4 class="alert-heading">Spausdinti teisėjų sąrašą</h4>
        <asp:Button ID="printofficial_btn" runat="server" OnClick="printofficial_btn_Click" Text="Spausdinti" CssClass="btn btn-outline-success btn-lg btn-block" />
    </div>
    <br />
    <br />
    <div class="alert alert-success text-center" role="alert">
      <h4 class="alert-heading">Spausdinti trenerių sąrašą</h4>
        <asp:Button ID="printcoach_btn" runat="server" OnClick="printcoach_btn_Click" Text="Spausdinti" CssClass="btn btn-outline-success btn-lg btn-block" />
    </div>

</asp:Content>