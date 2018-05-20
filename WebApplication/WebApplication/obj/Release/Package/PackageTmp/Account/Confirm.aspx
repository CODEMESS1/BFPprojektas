<%@ Page Title="Vartotojo patvirtinimas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Confirm.aspx.cs" Inherits="WebApplication.Account.Confirm" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>

    <div>
        <asp:PlaceHolder runat="server" ID="successPanel" ViewStateMode="Disabled" Visible="true">
            <p>
                Dėkojame. kad patvirtinote savo paskyra. Spauskite <asp:HyperLink ID="login" runat="server" NavigateUrl="~/Account/Login">čia</asp:HyperLink>  , kad prisijungti.             
            </p>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="errorPanel" ViewStateMode="Disabled" Visible="false">
            <p class="text-danger">
                Klaida.
            </p>
        </asp:PlaceHolder>
    </div>
</asp:Content>
