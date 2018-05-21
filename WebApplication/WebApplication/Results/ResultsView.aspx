<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ResultsView.aspx.cs" Inherits="WebApplication.Results.ResultsView" %>

<asp:Content runat="server" ID="ResultsViewContent" ContentPlaceHolderID="MainContent">
    <div>
        <asp:Button ID="CompetitionSelect_Button" Text="Varžybų pasirinkimas" runat="server" OnClick="CompetitionSelect_Button_Click" Visible="false"/>
    </div>
    <div>
        <asp:TextBox ID="FindResults_TextBox" runat="server" Visible="false"></asp:TextBox>
        <asp:RequiredFieldValidator ID="SearchBox_Validator" runat="server" ControlToValidate="FindResults_TextBox"></asp:RequiredFieldValidator>
        <asp:Button ID="FindResults_Button" runat="server" OnClick="FindResults_Button_Click" Visible="false" Text="Ieškoti"/>
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
        <asp:DropDownList ID="AgeGroup_List" runat="server" AutoPostBack="true" OnSelectedIndexChanged="AgeGroup_List_SelectedIndexChanged" Visible="false">
        </asp:DropDownList>
    </div>
    <div>
        <asp:GridView ID="ResultsGridView" runat="server" AllowPaging="true" OnPageIndexChanging="ResultsGridView_PageIndexChanging"></asp:GridView>
    </div>
</asp:Content>