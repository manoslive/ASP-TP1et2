<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Room.aspx.cs" Inherits="TP1_Env.Graphique.Room" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Room.css" />
    <script src="http://code.jquery.com/jquery-1.10.2.js"></script>
    <script lang="javascript" type="text/javascript">
        var Quit = 1;
        function VeutQuitter() {
            Quit = 0;
        }

        $(document).ready(function () {
            $(window).bind("beforeunload", function () {
                if (Quit == 1)
                    return "Êtes-vous sur de vouloir quitter la page?";
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_Content" runat="server">
    <div class="room">
        <asp:Panel ID="PN_GridView" CssClass="panelLogs" runat="server"/>
    </div>
    <asp:Button ID="BTN_Retour" runat="server" Text="Retour" OnClientClick="VeutQuitter()" CssClass="returnBTN" OnClick="BTN_Retour_Click"/>
</asp:Content>
