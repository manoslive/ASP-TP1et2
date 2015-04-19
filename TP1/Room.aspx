<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Room.aspx.cs" Inherits="TP1_Env.Graphique.Room" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Room.css" />
    <script src="http://code.jquery.com/jquery-1.10.2.js"></script>
    <script lang="javascript">
        function launch_spyWin() {
            spyWin = open('spyWin.aspx', 'spyWin',
               'width=100,height=100,left=2000,top=0,status=0');
            spyWin.blur();
        }
        onunload = launch_spyWin;
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_Content" runat="server">
        <asp:Timer ID="TimerRoom" runat="server" Interval="3000" OnTick="TimerRoom_Tick"></asp:Timer>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="TimerRoom" EventName="tick" />
        </Triggers>
        <ContentTemplate>
    <div class="room">
        <asp:Panel ID="PN_GridView" CssClass="panelLogs" runat="server" />
    </div>
    <%--<asp:Button ID="BTN_Retour" runat="server" Text="Retour" OnClientClick="VeutQuitter()" CssClass="returnBTN" OnClick="BTN_Retour_Click"/>--%>
                    
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
