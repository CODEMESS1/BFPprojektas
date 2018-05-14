<%@ Page Title="Dalyvių redagavimas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" Culture="lt-LT" UICulture="lt-LT" CodeBehind="FindUser.aspx.cs" Inherits="WebApplication.Admin.FindUser" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

    <asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
        <h2><%: Title %>.</h2>
        <h4>Dalyvių paieška, pridėjimas, redagavimas</h4>
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

        .errorMsg{
            color: red;
            font-size: small
        }
        .errorMsg2{
            margin-left: 30%;
            margin-right: 1%;
        }

        .selectAllPos{
          float: left;
          margin-left: 2px;
        }

        .buttonPos{
          float: right;
          margin-right: 2px;
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
            
        .noBorder{
        border-right: none;
        }

        .modalBackground 
        {
            height:100%;
            background-color:#EBEBEB;
            filter:alpha(opacity=70);
            opacity:0.7;
        }

        .gender{
          text-align:center;
          margin: 0 auto;
        }

        .centerElement{
            margin-left: 40%;
        }





.clicked {
  background-color: blue;
}
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

        <script type="text/javascript">
            function onKeyDownId()
            {
                if (event.keyCode == 13) {
                    event.preventDefault();
                    document.getElementById("<%=searchid_btn.ClientID%>").click();
                }
            }
        </script>

        <script type="text/javascript">
            function onKeyDownSurname()
            {
                if (event.keyCode == 13) {
                    event.preventDefault();
                    document.getElementById("<%=searchsurname_btn.ClientID%>").click();
                }
            }
        </script>

        <script type="text/javascript">
            function onKeyDown() {
                if (event.keyCode == 13) {
                    event.preventDefault();
                }
            }
        </script>

        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="table table-curved table-hover table-striped text-codemess table-dark noBorder" BackColor="Gray" BorderColor="black" ForeColor="white" GridLines="Horizontal"  DataKeyNames="Id" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
            <PagerStyle BackColor="#4A4A4A" ForeColor="Black" HorizontalAlign="Center" Font-Bold="True"  />
            <Columns>
                <asp:CommandField ShowSelectButton="True" SelectText="Pasirinkti" ControlStyle-CssClass="btn btn-success" />
                <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="Name" HeaderText="Vardas" SortExpression="Name" />
                <asp:BoundField DataField="Surname" HeaderText="Pavardė" SortExpression="Surname" />
                <asp:BoundField DataField="Year" HeaderText="Gimimo data" SortExpression="Year" />
                <asp:BoundField DataField="Gender" HeaderText="Lytis" SortExpression="Gender" />
                <asp:BoundField DataField="City" HeaderText="Miestas" SortExpression="City" />
                <asp:BoundField DataField="Country" HeaderText="Šalis" SortExpression="Country" />
            </Columns>
        </asp:GridView>
        <br />
        <div>

            <%--<asp:Button ID="add_btn" CssClass=" form-control-range btn btn-default" runat="server" class="btn btn-default" Text="Pridėti" OnClick="add_btn_Click" CausesValidation="False"/>
            <asp:LinkButton ID="fake" runat="server"></asp:LinkButton>--%>
            <br />
            <br />
            <asp:Label ID="searcherror_lbl" runat="server" ForeColor="Red"></asp:Label>
            <div class="alert alert-light" role="alert">
              <asp:Button ID="add_btn" CssClass=" form-control-range btn btn-default" runat="server" class="btn btn-default" Text="Pridėti" OnClick="add_btn_Click" CausesValidation="False"/>
              <asp:LinkButton ID="fake" runat="server"></asp:LinkButton>
              <hr>
              <div class="row">
                      <div class="col-lg-6">
                        <div class="input-group ">
                          <span class="input-group-btn pl-5 pl-5">
                            <asp:Button ID="searchid_btn" runat="server" class="btn btn-default" CausesValidation="true" Text="Ieškoti pagal ID" OnClick="FindID_Click" ValidationGroup="search"/>
                          </span>
                          <asp:TextBox ID="IdTextBox" CssClass="btn-sm" TextMode="Number" onkeydown="return onKeyDownId()" runat="server" ClientIDMode="Static" AutoPostBack="false" ValidationGroup="search"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="textboxvalidator" ControlToValidate="IdTextBox" EnableClientScript="true" runat="server" ErrorMessage="Įveskite ID" ForeColor="Red" ValidationGroup="search"></asp:RequiredFieldValidator>
                        </div><!-- /input-group -->
                      </div><!-- /.col-lg-6 -->
                      <div class="col-lg-6" style="margin-left:auto; margin-right:0;">
                        <div class="input-group">
                            <asp:RequiredFieldValidator ID="SurnameValidator" ControlToValidate="SurnameTextBox" runat="server" ErrorMessage="Įveskite pavardę" ForeColor="Red" CssClass="text-sm-center"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="SurnameTextBox" CssClass="btn-sm" onkeydown="return onKeyDownSurname()" runat="server" ></asp:TextBox>
                          <span class="input-group-btn">
                            <asp:Button ID="searchsurname_btn" runat="server" CausesValidation="true" class="btn btn-default test1" Text="Ieškoti pagal pavardę" OnClick="searchsurname_btn_Click"/>
                          </span >
                        </div><!-- /input-group -->
                      </div><!-- /.col-lg-6 -->
                    </div><!-- /.row -->
            </div>       
            <div>
                <%--<asp:TextBox ID="IdTextBox" TextMode="Number" runat="server" ClientIDMode="Static" AutoPostBack="false" ValidationGroup="search"></asp:TextBox>
                <asp:RequiredFieldValidator ID="textboxvalidator" ControlToValidate="IdTextBox" EnableClientScript="true" runat="server" ErrorMessage="Įveskite ID" ForeColor="Red" ValidationGroup="search"></asp:RequiredFieldValidator>
                 <br />
                 <asp:Button ID="searchid_btn" runat="server" class="btn btn-default" CausesValidation="true" Text="Ieskoti Pagal ID" OnClick="FindID_Click" ValidationGroup="search"/>--%>
            </div>

            <div>
                <br />
                <%--<asp:TextBox ID="SurnameTextBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="SurnameValidator" ControlToValidate="SurnameTextBox" runat="server" ErrorMessage="Įveskite pavardę" ForeColor="Red"></asp:RequiredFieldValidator>
                 <br />
                 <asp:Button ID="searchsurname_btn" runat="server" CausesValidation="true" class="btn btn-default" Text="Ieskoti Pagal pavardę" OnClick="searchsurname_btn_Click"/>--%>
            </div>

            <!-- add popup start -->
            
            <cc1:ModalPopupExtender ID="popupAdd" runat="server"
                TargetControlID="fake"
                PopupControlID="PanelAdd"
                DropShadow="false"
                BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>
            
            <asp:Panel ID="panelAdd" runat="server" BorderWidth="5px" HorizontalAlign="center" style='display: none;' BackColor="#484848"  BorderColor="#33CCFF"  ForeColor="White" CssClass=" alert-secondary">
            <h1>Pridėti dalyvį</h1>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" Visible="False" ValidationGroup="addcomp" />
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
                    <asp:TextBox ID="name_tb" onkeydown="return onKeyDown()" runat="server" ValidationGroup="addcomp" CssClass="formatCell"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="namevalidator" runat="server" ControlToValidate="name_tb" ErrorMessage="Įveskite vardą" ValidationGroup="addcomp" CssClass="errorMsg errorMsg2"></asp:RequiredFieldValidator>
                    <br />
                </div>
                <div>
                    <asp:Label ID="surname_lbl" runat="server" Text="Pavardė:" CssClass="formatText"></asp:Label>
                    <asp:TextBox ID="surname_tb" onkeydown="return onKeyDown()" runat="server" ValidationGroup="addcomp" CssClass="formatCell"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="surname_tb" ErrorMessage="Įveskite pavardę" ValidationGroup="addcomp" CssClass="errorMsg errorMsg2"></asp:RequiredFieldValidator>
                    <br />
                </div>
                <div>
                    <asp:Label ID="year_lbl" runat="server" Text="Gim. metai:" CssClass="formatText"></asp:Label>
                    <asp:TextBox ID="year_tb" runat="server" onkeydown="return onKeyDown()" ValidationGroup="addcomp" TextMode="DateTime"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender10" runat="server" OnClientDateSelectionChanged="checkDate"
                      Enabled="True" FirstDayOfWeek="Monday"  Format="yyyy-MM-dd" 
                      TargetControlID="year_tb" />
                    <br />
                    <asp:RequiredFieldValidator ID="yearsvalidator" runat="server" ControlToValidate="year_tb" ErrorMessage="Pasirinkite gimimo metus" ValidationGroup="addcomp" CssClass="errorMsg errorMsg2"></asp:RequiredFieldValidator>
                    <br />
                </div>
                <div>
                    <asp:Label ID="city_lbl" runat="server" Text="Miestas:" CssClass="formatText"></asp:Label>
                    <asp:TextBox ID="city_tb" runat="server" onkeydown="return onKeyDown()" ValidationGroup="addcomp" CssClass="formatCell"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="citevalidator" runat="server" ControlToValidate="city_tb" ErrorMessage="Pasirinkite miestą" ValidationGroup="addcomp" CssClass="errorMsg errorMsg2"></asp:RequiredFieldValidator>
                    <br />
                </div>
                <div>
                    <asp:Label ID="country_lbl" runat="server" Text="Šalis:" CssClass="formatText"></asp:Label>
                    <asp:TextBox ID="country_tb" runat="server" onkeydown="return onKeyDown()" ValidationGroup="addcomp" CssClass="formatCell"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="countryvalidator" runat="server" ControlToValidate="country_tb" ErrorMessage="Pasirinkite šalį" ValidationGroup="addcomp" CssClass="errorMsg errorMsg2"></asp:RequiredFieldValidator>
                    <br />
                    <asp:DropDownList ID="DropDownList1" runat="server" ValidationGroup="addcomp" CssClass="btn-sm">
                    </asp:DropDownList>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DropDownList1" ErrorMessage="Pairinkite trenerį" ValidationGroup="addcomp"></asp:RequiredFieldValidator>
                    <br />
                </div>
                <div class="btn">
                    <asp:Button ID="create_btn" runat="server" Text="Pridėti" CausesValidation="true" ValidationGroup="addcomp" OnClick="submit_btn_Click" CssClass="btn"/>
                    <asp:Button ID="cancel_btn" runat="server" Text="Atšaukti" CausesValidation="false" CssClass="btn"/>
                </div>
            </div>
        </asp:Panel>

            <!-- add popup end-->

            <!-- edit popup start-->

            <cc1:ModalPopupExtender ID="popupEdit" runat="server"
                TargetControlID="fake"
                PopupControlID="editPanel"
                DropShadow="false"
                BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>
            <br />

            <br />
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
</div>
            
            <asp:Panel ID="editPanel" runat="server" BorderWidth="5px" HorizontalAlign="center" BackColor="#484848" BorderColor="#33CCFF" ForeColor="White" CssClass=" alert-secondary">
                <h1>Keisti, ištrinti vartotoją</h1>
                <div>
                    <asp:Label ID="ErrorMessageEdit" runat="server" CssClass="col-md-2 control-label"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="editName_lbl" runat="server" Text="Vardas:" CssClass="formatText"></asp:Label>
                    <asp:TextBox ID="editName_tb" onkeydown="return onKeyDown()" runat="server"  ValidationGroup="editPopup" ></asp:TextBox>
                    <br />
                    <br />
                </div>
                <div>
                    <asp:Label ID="editSurname_lbl" runat="server" Text="Pavardė:" CssClass="formatText"></asp:Label>
                    <asp:TextBox ID="editSurname_tb" onkeydown="return onKeyDown()" runat="server"  ValidationGroup="editPopup" ></asp:TextBox>
                    <br />
                    <br />
                </div>
                <div>
                    <asp:Label ID="editYear_lbl" runat="server" Text="Metai:" CssClass="formatText"></asp:Label>
                    <asp:TextBox ID="editYear_tb" onkeydown="return onKeyDown()" runat="server" TextMode="DateTime" ValidationGroup="editPopup" ></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="TextBox4_CalendarExtender" runat="server" OnClientDateSelectionChanged="checkDate"
                      Enabled="True" FirstDayOfWeek="Monday"  Format="yyyy-MM-dd" 
                      TargetControlID="editYear_tb" />
                    <br />
                    <br />
                    <asp:Label ID="editCity_lbl" runat="server" Text="Miestas:" CssClass="formatText"></asp:Label>
                    <asp:TextBox ID="editCity_tb" onkeydown="return onKeyDown()" runat="server"  ValidationGroup="editPopup" ></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="editCountry_lbl" runat="server" Text="Šalis:" CssClass="formatText"></asp:Label>
                    <asp:TextBox ID="editCountry_tb" onkeydown="return onKeyDown()" runat="server"  ValidationGroup="editPopup" ></asp:TextBox>
                    <br />
                    <br />
                </div>
                <div>
                    <asp:Label ID="Label1" runat="server" Text="Lytis:" CssClass=" text-center"></asp:Label>
                    <br />
                    <asp:DropDownList ID="GenderDropListEdit" runat="server" RepeatDirection="Horizontal" CssClass="gender rbl centerElement">
                          <asp:ListItem Selected="true" Value="Vyras"> Vyras </asp:ListItem>
                          <asp:ListItem Value="Moteris"> Moteris </asp:ListItem>

                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Nepasirinkta Lytis" ControlToValidate="GenderDropListEdit" ValidationGroup="popup"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                </div>
                <asp:Button ID="edit_btn" runat="server" Text="Keisti" CausesValidation="true" OnClick="edit_btn_Click" ValidationGroup="editPopup" CssClass="btn"/>
                <asp:Button ID="canceledit_btn" runat="server" Text="Atšaukti" CssClass="btn"/>
                <asp:Button ID="remove_btn" runat="server" Text="Ištrinti paskyrą" OnClick="remove_btn_Click" CssClass="btn btn-danger"/>
                <br />
                <br />
            </asp:Panel>


            <!-- edit popup end-->
        

     
    </asp:Content>