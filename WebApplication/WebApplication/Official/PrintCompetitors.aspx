<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintCompetitors.aspx.cs" Inherits="WebApplication.Official.PrintCompetitors" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                        <asp:ScriptManager EnableScriptGlobalization="true" runat="server"></asp:ScriptManager>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass=" table table-curved table-hover table-striped text-codemess table-dark noBorder" BackColor="Gray" BorderColor="black" ForeColor="white" GridLines="Horizontal" DataKeyNames="Id" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" SelectText="Pasirinkti" ControlStyle-CssClass="btn btn-success" />
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
                    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True" CssClass="table table-curved table-hover table-striped text-codemess table-dark" BackColor="Gray" BorderColor="black" ForeColor="white" OnRowDeleting="GridView1_RowDeleting" GridLines="Horizontal" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" Visible="false">
            <PagerStyle BackColor="#4A4A4A" ForeColor="Black" HorizontalAlign="Center" Font-Bold="True"  />
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="Name" HeaderText="Vardas" />
                <asp:BoundField DataField="Surname" HeaderText="Pavardė" />
                <asp:BoundField DataField="Year" HeaderText="Gimimo metai" />
                <asp:BoundField DataField="Gender" HeaderText="Lytis" />
                <asp:BoundField DataField="City" HeaderText="Miestas" />
                <asp:BoundField DataField="Country" HeaderText="Šalis" />
        </Columns>
        </asp:GridView>
        </div>
    </form>
</body>
</html>
