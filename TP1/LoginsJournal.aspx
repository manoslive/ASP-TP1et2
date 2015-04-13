<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="LoginsJournal.aspx.cs" Inherits="TP1_Env.Graphique.LoginsJournal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="LoginsJournal.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_Content" runat="server">
    <asp:Panel ID="PN_GridView" CssClass="panelLogs" runat="server"/>
    <asp:Button ID="BTN_Retour" runat="server" Text="Retour" CssClass="returnBTN" OnClick="BTN_Retour_Click"/>
</asp:Content>
