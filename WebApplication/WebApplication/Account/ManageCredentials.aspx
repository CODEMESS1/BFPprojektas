<%@ Page Title="Manage Credentials" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageCredentials.aspx.cs" Inherits="WebApplication.Account.ManageCredentials" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Title %>.</h2>
         <asp:PlaceHolder runat="server" ID="NameSurname" Visible="true">
<div class="form-horizontal">
        <div class="form-group">
            <asp:Label runat="server" ID="nameLabel" AssociatedControlID="name" CssClass="col-md-2 control-label">Vardas</asp:Label>
                <asp:TextBox runat="server" ID="name" CssClass="form-control" />
        </div>
    </div>
            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button runat="server" Text="Set Name" CssClass="btn btn-default" Height="31px" OnClick="Name_Click" />
                </div>
            </div>
                    <hr />
                    <div class="form-group">
                        <asp:Label runat="server" ID="SurnameLabel" CssClass="col-md-2 control-label">Pavarde</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="SurnameText" CssClass="form-control" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" Text="Set Surname" ValidationGroup="SetSurName" OnClick="Surname_Click" CssClass="btn btn-default" OnCommand="Surname_Click" />
                        </div>
                    </div>
         </asp:PlaceHolder>
         <asp:PlaceHolder runat="server" ID="YearnPhone" Visible="true">
                <div class="form-horizontal">
                    <hr />
                    <div class="form-group">
                        <asp:Label runat="server" ID="YearOfBirth" CssClass="col-md-2 control-label" style="left: 0px; top: 0px" >Gimimo Diena</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox ID="BirthYear" TextMode="Date" runat="server"></asp:TextBox>
                        </div>
                        <asp:Button runat="server" Text="Pakeisti" ValidationGroup="SetDate" OnClick="SetDate_Click" CssClass="btn btn-default" />
                    </div>
                         <div class="form-group">
                        <asp:Label runat="server" ID="PhoneNumberLabel" CssClass="col-md-2 control-label">Telefono Numeris</asp:Label>
                        <div class="col-md-10">
                    <asp:TextBox runat="server" ID="PhoneNumberTextBox" type="number" />
                     <div class="col-md-10">
                    <asp:Button runat="server" Text="Pakeisti" OnClick="SetPhoneNumber_Click" CssClass="btn btn-default" />
                     </div>
                </div>
                </div>
                    </asp:PlaceHolder>
</asp:Content>
