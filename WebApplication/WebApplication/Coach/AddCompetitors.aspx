<%@ Page Language="C#" Culture="lt-LT" UICulture="lt-LT" AutoEventWireup="true" MasterPageFile="~/Site.Master" EnableEventValidation="true" CodeBehind="AddCompetitors.aspx.cs" Inherits="WebApplication.Coach.AddCompetitors" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <style>
        .errorMsg{
            color: red;
            font-size: small
        }
        .errorMsg2{
            margin-left: 30%;
            margin-right: 1%;
        }

        .gender{
          text-align:center;
          margin: 0 auto;
        }

        .rbl input[type="radio"]
        {
            margin-left: 10px;
            margin-right: 1px;
        }
        .dateBorder{
            border-color: black;
        }

        .formatText{
            display: inline-block;
            width: 160px;
            text-align: right;

        }

        .table-striped > tbody > tr:nth-child(2n+1) > td, .table-striped > tbody > tr:nth-child(2n+1) > th {
        background-color: #4A4A4A;
        }

        .tableFormat{
            border-color: #33CCFF;
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
/*.table-curved td:first-child:before {
  content: '';
  position: absolute;
  border-radius: 8px 0 0 8px;
  background-color: green;
  width: 12px;
  height: 100%;
  left: -12px;
  top: 0px;
}
.table-curved td:last-child {
  border-radius: 0 5px 5px 0;
}
.table-curved tr:hover td {
  background-color: #c5c5c5;
}
.table-curved tr.blue td:first-child:before {
  background-color: cornflowerblue;
}
.table-curved tr.green td:first-child:before {
  background-color: forestgreen;
}*/
    </style>

    <script type="text/javascript">
        function checkDate(sender,args)
        {
         if (sender._selectedDate > new Date())
                    {
                        alert("Negalima data!");
                        sender._selectedDate = new Date(); 
                        // set the date back to the current date
                        sender._textbox.set_Value("");
                    }
        }
     </script>

        <div class="panel panel-default">
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" CssClass="table table-curved table-hover table-striped text-codemess table-dark " BackColor="Gray" BorderColor="#33CCFF" ForeColor="white" OnRowDeleting="GridView1_RowDeleting" GridLines="Horizontal" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" DeleteText="Ištrinti" ControlStyle-CssClass="btn btn-danger" />
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
        <div>
            <asp:Button ID="add_btn2" runat="server" class="btn btn-default" Text="Pridėti" OnClick="add_btn_Click"/>
            <asp:LinkButton ID="fake" runat="server"></asp:LinkButton>
        </div>

        <cc1:ModalPopupExtender ID="popupAdd" runat="server"
                TargetControlID="fake"
                PopupControlID="PanelAdd"
                DropShadow="false">
            </cc1:ModalPopupExtender>

    <asp:ScriptManager ID="ScriptMngr" runat="server" EnableScriptGlobalization="true">
        </asp:ScriptManager>

        <asp:Panel ID="panelAdd" runat="server" BorderWidth="5px" Width="30%" HorizontalAlign="center" BackColor="#484848" BorderColor="#33CCFF" ForeColor="White" CssClass=" alert-secondary"  >
            <h1>Pridėti dalyvį</h1>
            <div>
                <div>
                    <asp:Label ID="gender_lbl" runat="server" Text="Lytis"></asp:Label>
                    <asp:RadioButtonList ID="gender_radbtn" runat="server" ValidationGroup="addcomp" RepeatDirection="Horizontal" CssClass="gender rbl" ForeColor="White">
                        <asp:ListItem>Vyras</asp:ListItem>
                        <asp:ListItem>Moteris</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="gendervalidator" runat="server" ControlToValidate="gender_radbtn" ErrorMessage="Pasirinkie lytį" ValidationGroup="addcomp" CssClass="errorMsg"></asp:RequiredFieldValidator>
                </div>
                <div>
                    <asp:Label ID="name_lbl" runat="server" Text="Vardas:" CssClass="formatText"></asp:Label>
                    <asp:TextBox ID="name_tb" runat="server" ValidationGroup="addcomp" CssClass="formatCell"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="namevalidator" runat="server" ControlToValidate="name_tb" ErrorMessage="Įveskite vardą" ValidationGroup="addcomp" CssClass="errorMsg errorMsg2"></asp:RequiredFieldValidator>
                    <br />
                </div>
                <div>
                    <asp:Label ID="surname_lbl" runat="server" Text="Pavardė:" CssClass="formatText"></asp:Label>
                    <asp:TextBox ID="surname_tb" runat="server" ValidationGroup="addcomp" CssClass="formatCell"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="surnamevalidator" runat="server" ControlToValidate="surname_tb" ErrorMessage="Įveskite pavardę" ValidationGroup="addcomp" CssClass="errorMsg errorMsg2"></asp:RequiredFieldValidator>
                    <br />
                </div>
                <div>
                    <asp:Label ID="year_lbl" runat="server" Text="Gim. metai:" CssClass="formatText"></asp:Label>
                    <asp:TextBox ID="year_tb" runat="server" OnTextChanged="year_tb_TextChanged"  ValidationGroup="addcomp" TextMode="DateTime"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="TextBox4_CalendarExtender" runat="server" OnClientDateSelectionChanged="checkDate"
                      Enabled="True" FirstDayOfWeek="Monday"  Format="yyyy-MM-dd" 
                      TargetControlID="year_tb" />
                    <br />
                    <asp:RequiredFieldValidator ID="yearsvalidator" runat="server" ControlToValidate="year_tb" ErrorMessage="Pasirinkite gimimo metus" ValidationGroup="addcomp" CssClass="errorMsg errorMsg2"></asp:RequiredFieldValidator>
                    <br />
                </div>
                <div>
                    <asp:Label ID="city_lbl" runat="server" Text="Miestas:" CssClass="formatText"></asp:Label>
                    <asp:TextBox ID="city_tb" runat="server" ValidationGroup="addcomp" CssClass="formatCell"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="citevalidator" runat="server" ControlToValidate="city_tb" ErrorMessage="Pasirinkite miestą" ValidationGroup="addcomp" CssClass="errorMsg errorMsg2"></asp:RequiredFieldValidator>
                    <br />
                </div>
                <div>
                    <asp:Label ID="country_lbl" runat="server" Text="Šalis:" CssClass="formatText"></asp:Label>
                    <asp:TextBox ID="country_tb" runat="server" ValidationGroup="addcomp" CssClass="formatCell"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="countryvalidator" runat="server" ControlToValidate="country_tb" ErrorMessage="Pasirinkite šalį" ValidationGroup="addcomp" CssClass="errorMsg errorMsg2"></asp:RequiredFieldValidator>
                    <br />
                </div>
                <div class="btn">
                    <asp:Button ID="create_btn" runat="server" Text="Pridėti" CausesValidation="true" ValidationGroup="addcomp" OnClick="create_btn_Click" CssClass="btn"/>
                    <asp:Button ID="cancel_btn" runat="server" Text="Atšaukti" OnClick="cancel_btn_Click" CssClass="btn"/>
                </div>
            </div>
        </asp:Panel>
    
    </asp:Content>
