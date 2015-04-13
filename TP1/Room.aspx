<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Room.aspx.cs" Inherits="TP1_Env.Graphique.Room" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Room.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_Content" runat="server">
    <asp:Button ID="BTN_Retour" runat="server" Text="Retour" CssClass="submitBTN" OnClick="BTN_Retour_Click"/>
    <asp:Panel ID="PN_GridView" CssClass="panelLogs" runat="server"/>
</asp:Content>
