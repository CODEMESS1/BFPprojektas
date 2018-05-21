<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ResultsView.aspx.cs" Inherits="WebApplication.Results.ResultsView" %>

<asp:Content runat="server" ID="ResultsViewContent" ContentPlaceHolderID="MainContent">
    <style>
        .table-striped > tbody > tr:nth-child(2n+1) > td, .table-striped > tbody > tr:nth-child(2n+1) > th {
                background-color: #4A4A4A;
                }
                .tableFormat{
                    border-color: black;
                }
                .tableRound {
                border-radius: 4px;
                }
                .table-hover tbody tr:hover td, .table-hover tbody tr:hover th {
                  background-image:url(/Image/darken-40.png);
                }
                .table-curved {
                  border-collapse: collapse;
                 /*margin-left: 10px;*/
                }
                .table-curved th {
                  padding: 3px 10px;
                }
                .table-curved td {
                  position: relative;
                  padding: 6px 10px;
                  border-bottom: 2px solid white;
                  border-top: 2px solid white;
                }
    </style>
  <div class="form-row">
    <div class="col-md-2 mb-3">
       <asp:Button ID="CompetitionSelect_Button" Text="Varžybų pasirinkimas"  CausesValidation="false" runat="server" OnClick="CompetitionSelect_Button_Click" Visible="false" CssClass="form-control btn-light"/>
    </div>
  </div>
  <div class="form-row">
    <div class="col-md-2 mb-3">
      <asp:TextBox ID="FindResults_TextBox" runat="server" placeholder="Paieška.." Visible="false" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="SearchBox_Validator" runat="server" ControlToValidate="FindResults_TextBox"></asp:RequiredFieldValidator>
    </div>
    <div class="col-md-1">
      <asp:Button ID="FindResults_Button" runat="server" OnClick="FindResults_Button_Click" Visible="false" Text="Ieškoti" CssClass="form-control"/>
    </div>
  </div>
  
    <div>
        <asp:GridView ID="CompetitionsGridView" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="table table-curved table-hover table-striped text-codemess table-dark noBorder" BackColor="Gray" BorderColor="black" ForeColor="white" GridLines="Horizontal" DataKeyNames="Id"  OnSelectedIndexChanged="CompetitionsGridView_SelectedIndexChanged" OnPageIndexChanging="CompetitionsGridView_PageIndexChanging">
            <PagerStyle BackColor="#4A4A4A" ForeColor="Black" HorizontalAlign="Center" Font-Bold="True"  />
            <Columns>
                <asp:CommandField ShowSelectButton="True" SelectText="Pasirinkti" ControlStyle-CssClass="btn btn-success" />
                <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="Name" HeaderText="Pavadinimas" />
                <asp:BoundField DataField="Location" HeaderText="Vieta" />
                <asp:BoundField DataField="Address" HeaderText="Adresas" />
                <asp:BoundField DataField="Date" HeaderText="Date" />
                <asp:BoundField DataField="RegistrationStartDate" HeaderText="Registracijos pradžią" />
                <asp:BoundField DataField="RegistrationEndDate" HeaderText="Registracijos pabaiga" />
                <asp:CheckBoxField DataField="Registration" HeaderText="Registracija" ReadOnly="true" />
            </Columns>
        </asp:GridView>
    </div>
    <div>
        <asp:DropDownList ID="AgeGroup_List" runat="server" AutoPostBack="true" OnSelectedIndexChanged="AgeGroup_List_SelectedIndexChanged" Visible="false" CssClass="form-control col-2">
        </asp:DropDownList>
    </div>
    <hr />
    <div>
        <asp:GridView ID="ResultsGridView" runat="server" AllowPaging="true" OnPageIndexChanging="ResultsGridView_PageIndexChanging" CssClass="table table-curved table-hover table-striped text-codemess table-dark noBorder" BackColor="Gray" BorderColor="black" ForeColor="white" GridLines="Horizontal"></asp:GridView>
    </div>
</asp:Content>