<%@ Page Title="Manage EMail" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageEmail.aspx.cs" Inherits="WebApplication.Account.ManageEmail" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <div class="form-horizontal">
        <section id="passwordForm">

            <asp:PlaceHolder runat="server" ID="changeEmailholder" Visible="false">
                <div class="form-horizontal">
                    <h4>Change Email Form</h4>
                    <hr />
                    <asp:ValidationSummary runat="server" ShowModelStateErrors="true" CssClass="text-danger" />
                    <div class="form-group">
                        <asp:Label runat="server" ID="CurrentEmailLabel" AssociatedControlID="CurrentEmail" CssClass="col-md-2 control-label">Current Email</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="CurrentEmail" TextMode="Email" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="CurrentEmail"
                                CssClass="text-danger" ErrorMessage="The current email field is required."
                                ValidationGroup="ChangeEmail" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" ID="NewEmailLabel" AssociatedControlID="NewEmail" CssClass="col-md-2 control-label">New Email</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="NewEmail" TextMode="Email" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="NewEmail"
                                CssClass="text-danger" ErrorMessage="The new Email is required."
                                ValidationGroup="ChangeEmail" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" ID="PasswordLabel" AssociatedControlID="Password" CssClass="col-md-2 control-label">Current Password</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="password" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                                CssClass="text-danger" Display="Dynamic" ErrorMessage="Password is required."
                                ValidationGroup="ChangeEmail" />
                            <asp:CompareValidator runat="server" ControlToCompare="NewPassword" ControlToValidate="Password"
                                CssClass="text-danger" Display="Dynamic" ErrorMessage="Email and Password do not match."
                                ValidationGroup="ChangeEmail" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" Text="Change Email" ValidationGroup="ChangeEmail" OnClick="ChangeEmail_Click" CssClass="btn btn-default" />
                        </div>
                    </div>
                </div>
            </asp:PlaceHolder>
        </section>
    </div>
</asp:Content>
