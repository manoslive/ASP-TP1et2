<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TP1_Env.Graphique.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="http://code.jquery.com/jquery-1.10.2.js"></script>
    <script lang="javascript" type="text/javascript">
        <%--        var Quit = 1;
        function VeutQuitter()
        {
            Quit = 0;
        }
        function Deconnect()
        {
            $('#<%= BTN_DeconnectionX.ClientID %>').click();
        }

        $(document).ready(function () {
            $(window).bind("beforeunload", function () {               
                if (Quit == 1)
                    return "Êtes-vous sur de vouloir quitter la page?";
            });
        });

        $(document).ready(function () {
            $(window).bind("unload", function () {
                if (Quit == 1)
                    Deconnect();
            });
        });--%>
    </script>
    <link rel="stylesheet" href="Index.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_Content" runat="server">
    <div>
        <table>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:Button ID="BTN_Profil" runat="server" Text="Gestion du profil..." OnClientClick="VeutQuitter()" class="indexBTN" OnClick="BTN_Profil_Click" />
                </td>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:Button ID="BTN_Room" runat="server" Text="Usagers en ligne..." OnClientClick="VeutQuitter()" class="indexBTN" OnClick="BTN_Room_Click" />
                </td>

                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:Button ID="BTN_ThreadsManager" runat="server" Text="Gestion des sujets..." OnClientClick="VeutQuitter()" class="indexBTN" OnClick="BTN_ThreadsManager_Click" />
                </td>

                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:Button ID="BTN_ChatRoom" runat="server" Text="Chatroom..." OnClientClick="VeutQuitter()" class="indexBTN" OnClick="BTN_ChatRoom_Click" />
                </td>

                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:Button ID="BTN_LoginsJournal" runat="server" Text="Journal des visites..." OnClientClick="VeutQuitter()" class="indexBTN" OnClick="BTN_LoginsJournal_Click" />
                </td>

                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:Button ID="BTN_Deconnection" runat="server" Text="Déconnexion..." class="indexBTN" OnClick="BTN_Deconnection_Click" />
                </td>
                <td>
                    <div style="display: none">
                        <asp:Button ID="BTN_DeconnectionX" runat="server" Text="Invisible" OnClientClick="VeutQuitter()" Style="height: 0px" OnClick="BTN_DeconnectionX_Click" />
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="Main_Content" runat="server">
    <div>
        <table>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:Button ID="BTN_Profil" runat="server" Text="Gérer votre profil..." OnClientClick="VeutQuitter()" class="indexBTN" OnClick="BTN_Profil_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:Button ID="BTN_Room" runat="server" Text="Usagers en ligne..." OnClientClick="VeutQuitter()" class="indexBTN" OnClick="BTN_Room_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:Button ID="BTN_ThreadsManager" runat="server" Text="Gestion des conversations..." OnClientClick="VeutQuitter()" class="indexBTN" OnClick="BTN_ThreadsManager_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:Button ID="BTN_ChatRoom" runat="server" Text="Salle de discussion..." OnClientClick="VeutQuitter()" class="indexBTN" OnClick="BTN_ChatRoom_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:Button ID="BTN_LoginsJournal" runat="server" Text="Journal des visites..." OnClientClick="VeutQuitter()" class="indexBTN" OnClick="BTN_LoginsJournal_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:Button ID="BTN_Deconnection" runat="server" Text="Déconnexion..." class="indexBTN" OnClick="BTN_Deconnection_Click" />
                </td>
                <td>
                    <div style="display:none">
                        <asp:Button ID="BTN_DeconnectionX" runat="server" Text="Invisible" OnClientClick="VeutQuitter()" style="height:0px" OnClick="BTN_DeconnectionX_Click" />
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>--%>
