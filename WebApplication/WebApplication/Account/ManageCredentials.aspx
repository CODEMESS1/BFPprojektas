<%@ Page Title="Keisti vartotojo duomenis" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageCredentials.aspx.cs" Inherits="WebApplication.Account.ManageCredentials" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
    input[type="number"] {
      width: 100px;
    }
    
    input + span {
      padding-right: 30px;
    }
    
    input:invalid+span:after {
      position: absolute; content: '✖';
      padding-left: 5px;
      color: #8b0000;
    }
    
    input:valid+span:after {
      position: absolute;
      content: '✓';
      padding-left: 5px;
      color: #009000;
    }
    </style>

    <h2><%: Title %>.</h2>
    <h4>Vartotojo duomenų keitimo forma</h4>
    <hr />
         <asp:PlaceHolder runat="server" ID="NameSurname" Visible="true">
<div class="form-horizontal">
        <div class="form-group">
            <asp:Label runat="server" ID="nameLabel" AssociatedControlID="name" CssClass="col-md-2 control-label">Vardas:</asp:Label>
            <div class="input-group mb-3 col-md-10">
              <asp:TextBox runat="server" ID="name" CssClass="form-control" placeholder="Vartotojo vardas" aria-label="Vartotojo vardas" aria-describedby="basic-addon2"/>
              <div class="input-group-append">
                  <asp:Button runat="server" Text="Nustatyti" CssClass="btn btn-default" OnClick="Name_Click"/>
              </div>
            </div>
        </div>           
                    <div class="form-group">
                        <asp:Label runat="server" ID="SurnameLabel" CssClass="col-md-2 control-label">Pavardė:</asp:Label>
                        <div class="input-group mb-3 col-md-10">
                            <asp:TextBox runat="server" ID="SurnameText" CssClass="form-control" placeholder="Vartotojo pavardė" aria-label="Vartotojo pavardė" aria-describedby="basic-addon2"/>
                            <div class="input-group-append">   
                            <asp:Button runat="server" Text="Nustatyti" ValidationGroup="SetSurName" OnClick="Surname_Click" CssClass="btn btn-default" OnCommand="Surname_Click" />
                            </div>
                        </div>
                    </div>             
    </div>
         </asp:PlaceHolder>
         <asp:PlaceHolder runat="server" ID="YearnPhone" Visible="true">
                <div class="form-horizontal">
                    <div class="form-group">
                        <asp:Label runat="server" ID="YearOfBirth" CssClass="col-md-2 control-label" style="left: 0px; top: 0px" >Gimimo diena:</asp:Label>
                        <div class="input-group mb-3 col-md-10" style="width: 395px">
                            <asp:TextBox ID="BirthYear" TextMode="Date" runat="server" CssClass="form-control" placeholder="Gimimo diena" aria-label="Gimimo diena" aria-describedby="basic-addon2"></asp:TextBox>                        
                            <div class="input-group-append">  
                            <asp:Button runat="server" Text="Nustatyti" ValidationGroup="SetDate" OnClick="SetDate_Click" CssClass="btn btn-default" />
                        </div>
                     </div>
                 </div>
                        <div class="form-group">
                        <asp:Label runat="server" ID="PhoneNumberLabel" CssClass="col-md-2 control-label">Telefono numeris:</asp:Label>
                        <div class="input-group mb-3 col-md-10" style="width: 395px">
                        <asp:TextBox runat="server" ID="PhoneNumberTextBox" type="number" CssClass="form-control input" placeholder="Telefono numeris" aria-label="Telefono numeris" aria-describedby="basic-addon2"/>
                        <div class="input-group-append">
                        <asp:Button runat="server" Text="Nustatyti" OnClick="SetPhoneNumber_Click" CssClass="btn btn-default" />
                     </div>
                     </div>
                 </div>
                    </div>
                    </asp:PlaceHolder>
</asp:Content>
