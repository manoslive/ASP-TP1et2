<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TP1_Env.Graphique.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Main.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_Content" runat="server">
    <div style="margin: auto; width: 300px; background-color: lightgray; padding: 15px 10px 0px 10px; border: 5px ridge; border-style: ridge; border-color:#00238c">
        <table>
            <tr>
                <td>
                    <asp:Label for="TB_UserName" runat="server" Text="Nom d'usager"></asp:Label>
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
                <td>
                    <asp:Label for="TB_Password" runat="server" Text="Mot de passe"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TB_Password" runat="server" CssClass="TextBox" TextMode="Password"></asp:TextBox>
                </td>
                
                <td>
                    <asp:RequiredFieldValidator ID="RFV_TB_Password" runat="server"
                        Text="!"
                        ErrorMessage="Le mot de passe est vide!"
                        ControlToValidate="TB_Password"
                        ValidationGroup="VG_Login"
                        OnServerValidate="CV_TB_UserName_ServerValidate">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr><td></td><td></td><td></td></tr>
            <tr>
                <td colspan="3"><center>
                    <asp:Button ID="BTN_Login" runat="server"
                        Text="Login..."
                        CssClass="submitBTN"
                        ValidationGroup="VG_Login" OnClick="BTN_Login_Click" /></center>
                </td>
            </tr>
            <tr>
                <td colspan="3"><center>
                    <asp:Button ID="BTN_Inscription" runat="server"
                        Text="S'inscrire..."
                        CssClass="submitBTN"
                        OnClick="BTN_Inscription_Click" /></center>
                </td>
            </tr>
            <tr>
                <td colspan="3"><center>
                    <asp:Button ID="BTN_ForgotPassword" runat="server"
                        Text="Mot de passe oublié..."
                        CssClass="submitBTN"
                        OnClick="BTN_ForgotPassword_Click" /></center>
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
</asp:Content>
