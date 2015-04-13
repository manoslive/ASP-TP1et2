<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="LoginsJournal.aspx.cs" Inherits="TP1_Env.Graphique.LoginsJournal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_Content" runat="server">
    <asp:Button ID="BTN_Retour" runat="server" Text="Retour" CssClass="submitBTN" OnClick="BTN_Retour_Click"/>
    <asp:Panel ID="PN_GridView" CssClass="panelLogs" Height="500px" Width="800px" ScrollBars="Auto" runat="server"/>
</asp:Content>
