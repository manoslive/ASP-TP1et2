﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ThreadsManager.aspx.cs" Inherits="TP1_Env.ThreadsManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_Content" runat="server">
    <asp:Timer ID="TimerJournal" runat="server" Interval="3000" OnTick="TimerJournal_Tick"></asp:Timer>

    <asp:UpdatePanel runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="TimerJournal" EventName="Tick" />
        </Triggers>

        <ContentTemplate>

            <asp:Button ID="BTN_Retour" runat="server" Text="Retour" CssClass="SubmitButton" OnClick="BTN_Retour_Click" />
            <asp:Panel ID="PN_GridView" CssClass="gridview" runat="server"></asp:Panel>

        </ContentTemplate>

    </asp:UpdatePanel>
</asp:Content>
