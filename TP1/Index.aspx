<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TP1.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_Content" runat="server">
    <div>
        <table>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="BTN_Profil" runat="server" Text="Gérer votre profil..." class="submitBTN" OnClick="BTN_Profil_Click" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="BTN_Room" runat="server" Text="Usagers en ligne..." class="submitBTN" OnClick="BTN_Room_Click" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="BTN_Discutions" runat="server" Text="Gérer mes discussions..." class="submitBTN" OnClick="BTN_Discutions_Click" />
                </td>
            </tr>
                        <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="BTN_ChatRoom" runat="server" Text="Salle de discussion..." class="submitBTN" OnClick="BTN_ChatRoom_Click" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="BTN_LoginsJournal" runat="server" Text="Journal des visites..." class="submitBTN" OnClick="BTN_LoginsJournal_Click" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="BTN_Deconnection" runat="server" Text="Déconnexion" class="submitBTN" OnClick="BTN_Deconnection_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
