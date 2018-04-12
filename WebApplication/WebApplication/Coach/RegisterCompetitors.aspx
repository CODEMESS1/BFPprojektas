<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCompetitors.aspx.cs" MasterPageFile="~/Site.Master" Inherits="WebApplication.Coach.RegisterCompetitors" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content runat="server" ID="AddCompetitorsContent" ContentPlaceHolderID="MainContent">
    <style>
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

        .buttonPos {
            float: right;
            margin-right: 2px;
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

        .modalBackground 
        {
            height:100%;
            background-color:#EBEBEB;
            filter:alpha(opacity=70);
            opacity:0.7;
        }

        .noBorder{
            border-right: none;
        }

        .table {
          width: 100%;
          margin-bottom: 0px;
        }


    </style>

        <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        <div>
            <table class="table table-striped text-codemess table-dark noBorder text-center">
                <tr>
                    <th>Registracija varžyboms</th>
                </tr>
            </table>
            <table class="table table-curved table-striped text-codemess table-dark noBorder">
                <tr>
                    <th>Pasirinkite varžybas:</th>
                </tr>
            </table>
            <asp:GridView ID="competitions_gridview" AllowPaging="true" runat="server" OnSelectedIndexChanged="competitions_gridview_SelectedIndexChanged1" CssClass="table table-curved table-hover table-striped text-codemess table-dark noBorder" BackColor="Gray" BorderColor="black" ForeColor="white" AutoGenerateColumns="False">
                <PagerStyle BackColor="#4A4A4A" ForeColor="Black" HorizontalAlign="Center" Font-Bold="True"  />
                <Columns>
                <asp:CommandField ShowSelectButton="True" SelectText="Pasirinkti" ControlStyle-CssClass="btn btn-success" />
                <asp:BoundField DataField="Name" HeaderText="Pavadinimas" />
                <asp:BoundField DataField="Location" HeaderText="Vieta" />
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="Date" HeaderText="Data" />
                <asp:BoundField DataField="Address" HeaderText="Adresas" />
                <asp:BoundField DataField="Registration" HeaderText="Registracija" />
                <asp:BoundField DataField="RegistrationStartDate" HeaderText="Registracijos pradžia" />
                <asp:BoundField DataField="RegistrationEndDate" HeaderText="Registracijos pabaiga" />

                
        </Columns>
            </asp:GridView>
            <br />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
            <br />
            <br />

            <div>
            <asp:LinkButton ID="fake" runat="server"></asp:LinkButton>
            </div>

            <cc1:ModalPopupExtender ID="popUpRegister" runat="server"
                TargetControlID="fake"
                PopupControlID="panelRegister"
                OkControlID="registerComp_btn"
                DropShadow="false"
                BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>

            <asp:Panel ID="panelRegister" runat="server" ScrollBars="Vertical" BorderWidth="5px" Width="30%" Height="60%" HorizontalAlign="center" BackColor="#484848" BorderColor="#33CCFF" ForeColor="White" CssClass=" alert-secondary">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                    <div>
                        <h1>Pridėti dalyvius į varžybas</h1>
                    </div>
                    <div>
                        <asp:Button ID="selectAll" runat="server" Text="Pasirinkti visus" OnClick="selectAll_Click" CssClass="btn btn-outline-info selectAllPos"/>
                        <asp:Button ID="Button1" runat="server" Text="Registruoti" OnClick="registerComp_btn_Click" CssClass="btn btn-outline-info buttonPos"/>
                        <asp:Button ID="Button2" runat="server" Text="Atšaukti" OnClick="cancel_btn_Click" CssClass="btn btn-outline-info buttonPos"/>
                        <br />
                    </div>
                    <div>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-curved table-hover table-striped text-codemess table-dark " BackColor="Gray" BorderColor="black" ForeColor="white">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="checkBox" runat="server" AutoPostBack="true"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Name" HeaderText="Vardas" />
                                <asp:BoundField DataField="Surname" HeaderText="Pavardė" />
                            </Columns>
                        </asp:GridView>
                    </div>
                        <div>
                    <br />
                    <asp:Button ID="registerComp_btn" runat="server" Text="Registruoti" OnClick="registerComp_btn_Click" CssClass="btn"/>
                    <asp:Button ID="cancel_btn" runat="server" Text="Atšaukti" OnClick="cancel_btn_Click" CssClass="btn"/>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <br />
        </div>
    </asp:Content>
