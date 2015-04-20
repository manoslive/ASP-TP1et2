<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ChatRoom.aspx.cs" Inherits="TP1_Env.Graphique.ChatRoom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="ChatRoom.css" />
    <style>
        /*#PN_Messages {
            overflow: auto;
            height: 80%;
            position: absolute;
            width: 90%;
        }*/

        /*.Msg {
            position: absolute;
            width: 90%;
            height: 90%;
        }*/
    </style>
    <script src="http://code.jquery.com/jquery-1.10.2.js"></script>
    <script lang="javascript" type="text/javascript">
        //var Quit = 1;
        //function VeutQuitter() {
        //    Quit = 0;
        //}

        //$(document).ready(function () {
        //    $(window).bind("beforeunload", function () {
        //        if (Quit == 1)
        //            return "Êtes-vous sur de vouloir quitter la page?";
        //    });
        //});
    </script>
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="Main_Content" runat="server">
    <asp:Timer ID="TimerChatroom" runat="server" Interval="2000" OnTick="TimerChatroom_Tick"></asp:Timer>
    <asp:UpdatePanel ID="UPN_Chatroom" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="TimerChatroom" EventName="Tick" />
        </Triggers>
        <ContentTemplate>
            <table>
                <tr>
                    
                    <td style="width: 15%">
                        <asp:Label ID="LBL_Threads" CssClass="Title" runat="server" Text="Vos discussions"></asp:Label></td>
                    <td style="width: 70%">

                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="LBL_Title" CssClass="Title" runat="server" Text="Aucune discussion selectionée"></asp:Label>

                                </td>
                                
                            </tr>
                        </table>
                    </td>
                    <td style="width: 15%">
                        <asp:Label ID="LBL_Users" CssClass="Title" runat="server" Text="Invités"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <div class="threads">
                            <asp:Panel ID="PN_Threads" runat="server"></asp:Panel>
                        </div>
                    </td>
                    <td>
                        <div class="message">
                            <asp:Panel ID="PN_Messages" runat="server"></asp:Panel>
                        </div>
                    </td>
                    <td>
                        <div class="users">
                            <asp:Panel ID="PN_Users" runat="server"></asp:Panel>
                        </div>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="message_Sortant">
    <asp:Panel ID="PN_Message" runat="server">
        <table>
            <tr>
                <td id="empty" class="auto-style2"></td>
                <td class="auto-style1">
                    <asp:TextBox ID="TB_Message" runat="server" TextMode="MultiLine" Width="536px" ClientIDMode="Static"></asp:TextBox></td>
                <td>
                    <asp:Button ID="BTN_Send" CssClass="submitBTN" runat="server" Text="Envoyer" OnClick="BTN_Send_Click" ClientIDMode="Static" />
                    <br />
                    <asp:Button ID="BTN_Back" CssClass="submitBTN" runat="server" Text="Retour" OnClientClick="VeutQuitter()" OnClick="BTN_Back_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    </div>
</asp:Content>--%>

<asp:Content ID="Content2" ContentPlaceHolderID="Main_Content" runat="server">
    <asp:Timer ID="TimerChatroom" runat="server" Interval="2000" OnTick="TimerChatroom_Tick"></asp:Timer>
    <asp:UpdatePanel ID="UPN_Chatroom" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="TimerChatroom" EventName="Tick" />
        </Triggers>
        <ContentTemplate>
            <div>
                <div class="divThreads">
                    <asp:Label ID="LBL_Threads" CssClass="Title" runat="server" Text="Vos discussions"></asp:Label>
                    <div>
                        <asp:Panel ID="PN_Threads" runat="server"></asp:Panel>
                    </div>
                </div>
                <div class="divMessages">
                    <asp:Label ID="LBL_Title" CssClass="Title" runat="server" Text="Aucune discussion selectionée"></asp:Label>
                    <div>
                        <asp:Panel ID="PN_Messages" runat="server"></asp:Panel>
                    </div>
                </div>
                <div class="divUsers">
                    <asp:Label ID="LBL_Users" CssClass="Title" runat="server" Text="Invités"></asp:Label>
                    <div>
                        <asp:Panel ID="PN_Users" runat="server"></asp:Panel>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="message_Sortant">
        <asp:Panel ID="PN_Message" runat="server">

            <asp:TextBox ID="TB_Message" runat="server" CssClass="TB_Message" TextMode="MultiLine"  ClientIDMode="Static"></asp:TextBox>

            <asp:Button ID="BTN_Send" runat="server" CssClass="envoyerBTN" Text="Envoyer" OnClick="BTN_Send_Click" ClientIDMode="Static" />

        </asp:Panel>
    </div>
    
</asp:Content>
