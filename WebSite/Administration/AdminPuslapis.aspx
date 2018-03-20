<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminPuslapis.aspx.cs" Inherits="_Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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
        <asp:SqlDataSource ID="SqlDataSource_vartotojai" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnectionString %>" SelectCommand="SELECT * FROM [VARTOTOJAS]" OnSelecting="SqlDataSource_vartotojai_Selecting"></asp:SqlDataSource>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<asp:GridView ID="GridView1" runat="server" Width = "550px"
AutoGenerateColumns = "False" AlternatingRowStyle-BackColor = "#C2D69B" 
HeaderStyle-BackColor = "green" AllowPaging ="True" DataSourceID="SqlDataSource_vartotojai" DataKeyNames="vartotojo_id" OnPageIndexChanging = "OnPaging" >
<Columns>
                <asp:BoundField DataField="vartotojo_id" HeaderText="vartotojo_id" ReadOnly="True" SortExpression="vartotojo_id" />
                <asp:BoundField DataField="vardas" HeaderText="vardas" SortExpression="vardas" />
                <asp:BoundField DataField="pavarde" HeaderText="pavarde" SortExpression="pavarde" />
                <asp:BoundField DataField="gimimo_metai" HeaderText="gimimo_metai yyyy mm dd" SortExpression="gimimo_metai" />
                <asp:BoundField DataField="elektroninis_pastas" HeaderText="elektroninis_pastas" SortExpression="elektroninis_pastas" />
                <asp:BoundField DataField="prisijungimo_vardas" HeaderText="prisijungimo_vardas" SortExpression="prisijungimo_vardas" />
                <asp:BoundField DataField="slaptazodis" HeaderText="slaptazodis" SortExpression="slaptazodis" />
                <asp:BoundField DataField="valstybe" HeaderText="valstybe" SortExpression="valstybe" />
                <asp:BoundField DataField="miestas" HeaderText="miestas" SortExpression="miestas" />
                <asp:BoundField DataField="role" HeaderText="role" SortExpression="role" />
    <asp:TemplateField ItemStyle-Width = "30px" HeaderText = "">
   <ItemTemplate>
       <asp:LinkButton ID="lnkEdit" runat="server" Text = "Edit" OnClick = "Edit"></asp:LinkButton>
   </ItemTemplate>
</asp:TemplateField>
</Columns>
<AlternatingRowStyle BackColor="#C2D69B" />
    <HeaderStyle BackColor="Green" />
</asp:GridView>
    <asp:LinkButton ID="lnkFake" runat="server"></asp:LinkButton>
    <cc1:ModalPopupExtender ID="popup" runat="server" BackgroundCssClass="modalBackground" DropShadow="false" PopupControlID="pnlAddEdit" TargetControlID="lnkFake">
    </cc1:ModalPopupExtender>
<asp:Button ID="btnAdd" runat="server" Text="Add" OnClick = "Add" />
 
<asp:Panel ID="pnlAddEdit" runat="server" CssClass="modalPopup" style="enable-background">
<asp:Label Font-Bold = "true" ID = "Label4" runat = "server" Text = "Customer Details" ></asp:Label>
<br />
<table align = "center" border="1" style="background:initial; background-color:aliceblue">
<tr>
<td>
<asp:Label ID = "Label1" runat = "server" Text = "VartotojoID" ></asp:Label>
</td>
<td>
<asp:TextBox ID="txtUserID" Width = "40px" MaxLength = "5" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td>
<asp:Label ID = "Label2" runat = "server" Text = "Vardas" ></asp:Label>
</td>
<td>
<asp:TextBox ID="txtName" runat="server"></asp:TextBox>   
</td>
</tr>
<tr>
<td>
<asp:Label ID = "Label3" runat = "server" Text = "Pavarde" ></asp:Label>
</td>
<td>
<asp:TextBox ID="txtSurname" runat="server"></asp:TextBox>
</td>
</tr>
    <tr>
<td>
<asp:Label ID = "Label5" runat = "server" Text = "GimimoMetai" ></asp:Label>
</td>
<td>
<asp:TextBox ID="txtBirth" runat="server"></asp:TextBox>
</td>
</tr>
    <tr>
<td>
<asp:Label ID = "Label6" runat = "server" Text = "Elektroninis Pastas" ></asp:Label>
</td>
<td>
<asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
</td>
</tr>
    <tr>
<td>
<asp:Label ID = "Label7" runat = "server" Text = "Prisijungimo Vardas" ></asp:Label>
</td>
<td>
<asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>
</td>
</tr>
    <tr>
<td>
<asp:Label ID = "Label8" runat = "server" Text = "Slaptazodis" ></asp:Label>
</td>
<td>
<asp:TextBox ID="txtPass" runat="server"></asp:TextBox>
</td>
</tr>
    <tr>
<td>
<asp:Label ID = "Label9" runat = "server" Text = "Valstybe" ></asp:Label>
</td>
<td>
<asp:TextBox ID="txtCountry" runat="server"></asp:TextBox>
</td>
</tr>
    <tr>
<td>
<asp:Label ID = "Label10" runat = "server" Text = "Miestas" ></asp:Label>
</td>
<td>
<asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
</td>
</tr>
    <tr>
<td>
<asp:Label ID = "Label11" runat = "server" Text = "Role" ></asp:Label>
</td>
<td>
<asp:TextBox ID="txtRole" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td>
<asp:Button ID="btnSave" runat="server" Text="Save" OnClick = "Save" />
</td>
<td>
<asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClientClick = "return Hidepopup()"/>
</td>
</tr>
</table>
</asp:Panel>
</ContentTemplate>

<Triggers>
<asp:AsyncPostBackTrigger ControlID = "GridView1" />
<asp:AsyncPostBackTrigger ControlID = "btnSave" />
</Triggers>
</asp:UpdatePanel>
        <br />
        <asp:Button ID="logout_btn" runat="server" Text="Atsijungti" OnClick="logout_btn_Click" />
        <br />
    </form>
</body>
</html>
