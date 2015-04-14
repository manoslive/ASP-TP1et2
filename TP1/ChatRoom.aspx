﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ChatRoom.aspx.cs" Inherits="TP1_Env.Graphique.ChatRoom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="http://code.jquery.com/jquery-1.10.2.js"></script>
    <script lang="javascript" type="text/javascript">
        $(document).ready(function () {
            $(window).bind("beforeunload", function () {
                return confirm("Êtes-vous sur de vouloir quitter la page?");
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_Content" runat="server">
    <asp:Timer ID="TimerChatroom" runat="server" Interval="3000" OnTick="TimerChatroom_Tick"></asp:Timer>
    <asp:UpdatePanel ID="UPN_Chatroom" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="TimerChatroom" EventName="Tick"/>
        </Triggers>
        <ContentTemplate>
            <table>
                <tr>
                    <td style="width: 15%">
                        <asp:Label ID="LBL_Threads" runat="server" Text="Vos discussions"></asp:Label></td>
                    <td style="width: 70%">
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="LBL_Title" runat="server" Text="Aucune discussion selectionée"></asp:Label></td>
                                <td style="text-align: right">
                                    <asp:Label ID="LBL_Creator" runat="server" Text="..."></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 15%">
                        <asp:Label ID="LBL_Users" runat="server" Text="Invités"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="PN_Threads" runat="server"></asp:Panel>
                    </td>
                    <td>
                        <asp:Panel ID="PN_Messages" runat="server"></asp:Panel>
                    </td>
                    <td>
                        <asp:Panel ID="PN_Users" runat="server"></asp:Panel>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Panel ID="PN_Message" runat="server">
        <table>
            <tr>
                <td id="empty" class="auto-style2"></td>
                <td class="auto-style1">
                    <asp:TextBox ID="TB_Message" runat="server" TextMode="MultiLine" Width="536px" ClientIDMode="Static"
                        onkeydown="char = (event.which || event.keyCode); if (char == 13) document.getElementById(&quot;BTN_Send&quot;).click();"></asp:TextBox></td>
                <td>
                    <asp:Button ID="BTN_Send" runat="server" Text="Envoyer" CssClass="SubmitButton" OnClick="BTN_Send_Click" ClientIDMode="Static" />
                    <br />
                    <asp:Button ID="BTN_Back" runat="server" Text="Retour" CssClass="SubmitButton" OnClick="BTN_Back_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
