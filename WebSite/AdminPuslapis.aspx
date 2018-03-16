<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminPuslapis.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        ADMINISTRATORIAUS PUSLAPIS<br />
        Vartotojų lentelė</div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="vartotojo_id" DataSourceID="SqlDataSource_vartotojai">
            <Columns>
                <asp:BoundField DataField="vartotojo_id" HeaderText="vartotojo_id" ReadOnly="True" SortExpression="vartotojo_id" />
                <asp:BoundField DataField="vardas" HeaderText="vardas" SortExpression="vardas" />
                <asp:BoundField DataField="pavarde" HeaderText="pavarde" SortExpression="pavarde" />
                <asp:BoundField DataField="gimimo_metai" HeaderText="gimimo_metai" SortExpression="gimimo_metai" />
                <asp:BoundField DataField="elektroninis_pastas" HeaderText="elektroninis_pastas" SortExpression="elektroninis_pastas" />
                <asp:BoundField DataField="prisijungimo_vardas" HeaderText="prisijungimo_vardas" SortExpression="prisijungimo_vardas" />
                <asp:BoundField DataField="slaptazodis" HeaderText="slaptazodis" SortExpression="slaptazodis" />
                <asp:BoundField DataField="valstybe" HeaderText="valstybe" SortExpression="valstybe" />
                <asp:BoundField DataField="miestas" HeaderText="miestas" SortExpression="miestas" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource_vartotojai" runat="server" ConnectionString="<%$ ConnectionStrings:VartotojaiConnectionString %>" SelectCommand="SELECT * FROM [VARTOTOJAS]"></asp:SqlDataSource>
    </form>
</body>
</html>
