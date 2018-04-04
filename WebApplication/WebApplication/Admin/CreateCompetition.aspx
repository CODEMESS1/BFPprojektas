<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="CreateCompetition.aspx.cs" Inherits="WebApplication.Admin.CreateCompetition" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

    <asp:Content runat="server" ID="AddCompetitorsContent" ContentPlaceHolderID="MainContent">
        <div>
            <asp:ScriptManager EnableScriptGlobalization="true" runat="server"></asp:ScriptManager>
            VARŽYBŲ KŪRIMAS<br />
            <br />
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateEditButton="true" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="Name" HeaderText="Pavadinimas" SortExpression="Name" />
                    <asp:BoundField DataField="Location" HeaderText="Vieta" SortExpression="Location" />
                    <asp:BoundField DataField="Address" HeaderText="Adresas" SortExpression="Address" />
                    <asp:BoundField DataField="Date" HeaderText="Data" SortExpression="Date" />
                    <asp:BoundField DataField="RegistrationStartDate" HeaderText="Registracijos pradžia" SortExpression="RegistrationStartDate" />
                    <asp:BoundField DataField="RegistrationEndDate" HeaderText="Registracijos pabaiga" SortExpression="RegistrationEndDate" />
                    <asp:CheckBoxField DataField="Registration" HeaderText="Registracija atidaryta" SortExpression="Registration" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [Competitions]"></asp:SqlDataSource>
            <br />
        </div>
    </asp:Content>
