<%@ Page Title="Keisti elektroninį paštą" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageEmail.aspx.cs" Inherits="WebApplication.Account.ManageEmail" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <div class="form-horizontal">
        <section id="passwordForm">

            <asp:PlaceHolder runat="server" ID="changeEmailholder" Visible="false">
                <div class="form-horizontal">
                    <h4>Elektroninio pašto pakeitimo forma</h4>
                    <hr />
                    <asp:ValidationSummary runat="server" ShowModelStateErrors="true" CssClass="text-danger" />
                    <div class="form-group">
                        <asp:Label runat="server" ID="CurrentEmailLabel" AssociatedControlID="CurrentEmail" CssClass="col-md-2 control-label">Dabartinis elektroninis paštas</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="CurrentEmail" TextMode="Email" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="CurrentEmail"
                                CssClass="text-danger" ErrorMessage="Užpildykite dabartinio elektroninio pašto lauką."
                                ValidationGroup="ChangeEmail" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" ID="NewEmailLabel" AssociatedControlID="NewEmail" CssClass="col-md-2 control-label">Naujas elektroninis paštas</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="NewEmail" TextMode="Email" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="NewEmail"
                                CssClass="text-danger" ErrorMessage="Užpildykite naujo elektroninio pašto lauką."
                                ValidationGroup="ChangeEmail" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" ID="PasswordLabel" AssociatedControlID="Password" CssClass="col-md-2 control-label">Dabartinis slaptažodis</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="password" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                                CssClass="text-danger" Display="Dynamic" ErrorMessage="Įveskite dabartinį slaptažodį."
                                ValidationGroup="ChangeEmail" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" Text="Keisti elektroninį paštą" ValidationGroup="ChangeEmail" OnClick="ChangeEmail_Click" CssClass="btn btn-default" />
                        </div>
                    </div>
                </div>
            </asp:PlaceHolder>
        </section>
    </div>
</asp:Content>
