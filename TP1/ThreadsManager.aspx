﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ThreadsManager.aspx.cs" Inherits="TP1_Env.Graphique.ThreadsManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="ThreadsManager_css.css" />
    <script lang="javascript" type="text/javascript">

    </script>
    <style type="text/css">
        .auto-style2 {
            width: 5%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_Content" runat="server">

    <div class="mainDiv">
        <table>
            <tbody>
                <tr>
                    <td class="leftDiv">
                        <h3>Liste de mes discussions</h3>
                        <asp:ListBox ID="LBL_ListDiscussions" runat="server" Width="200px" Height="268px"
                            AutoPostBack="true" OnSelectedIndexChanged="LBL_ListDiscussions_SelectedIndexChanged"></asp:ListBox>
                        <br />
                        <br />
                        <asp:Button ID="BTN_New" runat="server" Text="Nouveau" CssClass="discussBTN" OnClick="BTN_New_Click" />
                        <br />
                        <br />
                        <asp:Button ID="BTN_Edit" runat="server" Text="Créer" CssClass="discussBTN" OnClick="BTN_Edit_Click" />
                        <br />
                        <br />
                        <asp:Button ID="BTN_Delete" runat="server" Text="Supprimer" CssClass="discussBTN" OnClick="BTN_Delete_Click" /> 
                    </td>
                    <td class="rightDiv">
                        <h3>Titre de la discussion</h3>
                        <asp:TextBox ID="TBX_NewThread" runat="server" Width="200px"></asp:TextBox>
                        <br />
                        <h4>Sélection des invités</h4>
                        <div class="users">
                        <asp:CheckBox ID="CBX_All"  runat="server" CssClass="CBItem_Tous" OnCheckedChanged="CBX_All_CheckedChanged"
                            AutoPostBack="true"/>
                        Tous les usagers
                        
                        <asp:Panel ID="PN_User_Content" runat="server">
                            
                        <asp:CheckBoxList ID="CBX_Users" CssClass="CBL_Users" BorderStyle="Groove" runat="server"></asp:CheckBoxList>
                            
                        </asp:Panel>
                        </div>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    </asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="Main_Content" runat="server">
        <asp:Timer ID="TimerJournal" runat="server" Interval="3000" OnTick="TimerJournal_Tick"></asp:Timer>
        <div class="mainDiv">
        <table>
            <tr>
                <td>
                    <asp:Label for="TB_UserName" runat="server" Text="Nom du sujet"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TB_UserName" runat="server" CssClass="TextBox"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RFV_TB_UserName" runat="server"
                        Text="!"
                        ErrorMessage="Le nom d'usager est vide!"
                        ControlToValidate="TB_UserName"
                        ValidationGroup="VG_Login"
                        OnServerValidate="CV_TB_UserName_ServerValidate">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td colspan="3">
                    <center><asp:ListBox ID="LB_Sujets" runat="server" OnLoad="FillListBox();"></asp:ListBox></center>
                </td>
            </tr>
            <tr>
                <td colspan="3"><center>
                    <asp:Button ID="BTN_Login" runat="server"
                        Text="Nouveau..."
                        OnClientClick="VeutQuitter()"
                        CssClass="submitBTN"
                        ValidationGroup="VG_Login" OnClick="BTN_Retour_Click" /></center>
                </td>
            </tr>
            <tr>
                <td colspan="3"><center>
                    <asp:Button ID="BTN_Inscription" runat="server"
                        Text="Créer..."
                        CssClass="submitBTN"
                        OnClientClick="VeutQuitter()"
                        OnClick="BTN_Retour_Click" /></center>
                </td>
            </tr>
            <tr>
                <td colspan="3"><center>
                    <asp:Button ID="BTN_ForgotPassword" runat="server"
                        Text="Effacer..."
                        OnClientClick="VeutQuitter()"
                        CssClass="submitBTN"
                        OnClick="BTN_Retour_Click" /></center>
                </td>
            </tr>
        </table>
        <br />
        <asp:ValidationSummary ID="ValidationSummary" runat="server"
            HeaderText="Sommaire des erreurs <hr/>"
            DisplayMode="BulletList"
            EnableClientScript="true"
            ValidationGroup="VG_Login" />
    </div>


    <asp:UpdatePanel runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="TimerJournal" EventName="Tick" />
        </Triggers>

        <ContentTemplate>

            <asp:Button ID="BTN_Retour" runat="server" Text="Retour" OnClientClick="VeutQuitter()" CssClass="SubmitButton" OnClick="BTN_Retour_Click" />
            <asp:Panel ID="PN_GridView" CssClass="gridview" runat="server"></asp:Panel>

        </ContentTemplate>

    </asp:UpdatePanel>
</asp:Content>--%>
