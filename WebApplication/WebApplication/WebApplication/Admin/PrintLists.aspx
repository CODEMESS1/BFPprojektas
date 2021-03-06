﻿<%@ Page Title="Sąrašai" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="PrintLists.aspx.cs" Inherits="WebApplication.Admin.PrintLists" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <h4>Sąrašų spausdinimas PDF formatu</h4>
    <hr />


    <div class="alert alert-dark text-center" role="alert">
      <h4 class="alert-heading">Spausdinti teisėjų sąrašą</h4>
        <asp:Button ID="printofficial_btn" runat="server" OnClick="printofficial_btn_Click" Text="Spausdinti" CssClass="btn btn-outline-danger btn-lg btn-block" />
    </div>
    <br />
    <br />
    <div class="alert alert-dark text-center" role="alert">
      <h4 class="alert-heading">Spausdinti trenerių sąrašą</h4>
        <asp:Button ID="printcoach_btn" runat="server" OnClick="printcoach_btn_Click" Text="Spausdinti" CssClass="btn btn-outline-danger btn-lg btn-block" />
    </div>

</asp:Content>