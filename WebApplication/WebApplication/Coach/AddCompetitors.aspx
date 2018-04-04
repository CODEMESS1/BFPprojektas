﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AddCompetitors.aspx.cs" Inherits="WebApplication.Coach.AddCompetitors" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateDeleteButton = "true" AllowPaging="True" AllowSorting="True" CssClass="table table-striped table-bordered table-hover text-primary" OnRowDeleting="GridView1_RowDeleting">
        </asp:GridView>
        <div>
            <asp:Button ID="add_btn2" runat="server" class="btn btn-default" Text="Pridėti" OnClick="add_btn_Click"/>
            <asp:LinkButton ID="fake" runat="server"></asp:LinkButton>
        </div>

        <cc1:ModalPopupExtender ID="popupAdd" runat="server"
                TargetControlID="fake"
                PopupControlID="PanelAdd"
                DropShadow="false">
            </cc1:ModalPopupExtender>

    <asp:ScriptManager ID="ScriptMngr" runat="server">
        </asp:ScriptManager>

        <asp:Panel ID="panelAdd" runat="server" CssClass="alert-primary" BorderWidth="5px" Width="30%" HorizontalAlign="center"  >
            <h1>Pridėti dalyvį</h1>
            <div>
                <asp:Label ID="ErrorMessage" runat="server" CssClass="col-md-2 control-label"></asp:Label>
                
                <div>
                    <asp:Label ID="gender_lbl" runat="server" Text="Lytis"></asp:Label>
                    <asp:RadioButtonList ID="gender_radbtn" runat="server" ValidationGroup="addcomp" RepeatDirection="Horizontal">
                        <asp:ListItem>Vyras</asp:ListItem>
                        <asp:ListItem>Moteris</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="gendervalidator" runat="server" ControlToValidate="gender_radbtn" ErrorMessage="Pasirinkie lytį" ValidationGroup="addcomp"></asp:RequiredFieldValidator>
                </div>
                <div>
                    <asp:Label ID="name_lbl" runat="server" Text="Vardas"></asp:Label>
                    <asp:TextBox ID="name_tb" runat="server" ValidationGroup="addcomp"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="namevalidator" runat="server" ControlToValidate="name_tb" ErrorMessage="Įveskite vardą" ValidationGroup="addcomp"></asp:RequiredFieldValidator>
                    <br />
                </div>
                <div>
                    <asp:Label ID="surname_lbl" runat="server" Text="Pavardė"></asp:Label>
                    <asp:TextBox ID="surname_tb" runat="server" ValidationGroup="addcomp"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="surnamevalidator" runat="server" ControlToValidate="surname_tb" ErrorMessage="Įveskite pavardę" ValidationGroup="addcomp"></asp:RequiredFieldValidator>
                    <br />
                </div>
                <div>
                    <asp:Label ID="year_lbl" runat="server" Text="Gim. metai"></asp:Label>
                    <asp:TextBox ID="year_tb" runat="server" ValidationGroup="addcomp" TextMode="Date"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="yearsvalidator" runat="server" ControlToValidate="year_tb" ErrorMessage="Pasirinkite gimimo metus" ValidationGroup="addcomp"></asp:RequiredFieldValidator>
                    <br />
                </div>
                <div>
                    <asp:Label ID="city_lbl" runat="server" Text="Miestas"></asp:Label>
                    <asp:TextBox ID="city_tb" runat="server" ValidationGroup="addcomp"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="citevalidator" runat="server" ControlToValidate="city_tb" ErrorMessage="Pasirinkite miestą" ValidationGroup="addcomp"></asp:RequiredFieldValidator>
                    <br />
                </div>
                <div>
                    <asp:Label ID="country_lbl" runat="server" Text="Šalis"></asp:Label>
                    <asp:TextBox ID="country_tb" runat="server" ValidationGroup="addcomp"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="countryvalidator" runat="server" ControlToValidate="country_tb" ErrorMessage="Pasirinkite šalį" ValidationGroup="addcomp"></asp:RequiredFieldValidator>
                    <br />
                </div>
                <div>
                    <asp:Button ID="create_btn" runat="server" Text="Pridėti" CausesValidation="true" ValidationGroup="addcomp" OnClick="create_btn_Click"/>
                    <asp:Button ID="cancel_btn" runat="server" Text="Atšaukti" OnClick="cancel_btn_Click"/>
                </div>
            </div>
        </asp:Panel>
    
    </asp:Content>
