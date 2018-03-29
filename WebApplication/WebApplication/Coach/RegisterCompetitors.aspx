<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCompetitors.aspx.cs" MasterPageFile="~/Site.Master" Inherits="WebApplication.Coach.RegisterCompetitors" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

    <asp:Content runat="server" ID="AddCompetitorsContent" ContentPlaceHolderID="MainContent">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        <div>
            Registracija varžyboms<br />
            <br />
            Pasirinkite varžybas:<br />
            <br />
            <asp:Label ID="error_lbl" runat="server"></asp:Label>
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            </asp:GridView>
            <br />
            <br />

            <div>
            <asp:LinkButton ID="fake" runat="server"></asp:LinkButton>
            </div>

            <cc1:ModalPopupExtender ID="popUpRegister" runat="server"
                TargetControlID="fake"
                PopupControlID="panelRegister"
                OkControlID="registerComp_btn"
                DropShadow="false">
            </cc1:ModalPopupExtender>

            <script type="text/javascript" src="js/ListViewMultipleSelect.js"></script>

            <asp:Panel ID="panelRegister" runat="server" ScrollBars="Vertical">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                    <div>
                        <h1>Pridėti dalyvius į varžybas</h1>
                    </div>
                    <div>
                        <asp:Button ID="selectAll" runat="server" Text="Pasirinkti visus" OnClick="selectAll_Click"/>
                        <br />
                    </div>
                    <div>
                        <asp:ListBox runat="server" ID="competitors_lstbox" onclick="ListBoxClient_SelectionChanged(this, event);" SelectionMode="Multiple" Width="400px" >
                        </asp:ListBox>
                    </div>
                    <br />
                    <asp:Button ID="registerComp_btn" runat="server" Text="Registruoti" OnClick="registerComp_btn_Click" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <br />
        </div>
    </asp:Content>
