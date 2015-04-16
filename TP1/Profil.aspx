<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Profil.aspx.cs" Inherits="TP1_Env.Graphique.Profil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="http://code.jquery.com/jquery-1.10.2.js"></script>
    <link rel="stylesheet" href="Inscription_css.css" />
    <script type="text/javascript" src="ClientFormUtilities.js"></script>
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
<asp:Content ID="Content2" ContentPlaceHolderID="Main_Content" runat="server">
    <div id="content">
        <div id="left_content" class="left_content"">
            <table>
                <tr>
                    <td>
                        <asp:Label for="TB_FullName" runat="server" Text="Nom au complet"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TB_FullName" runat="server" CssClass="TextBox"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RFV_TB_FullName" runat="server"
                            Text="!"
                            ErrorMessage="Le nom est vide!"
                            ControlToValidate="TB_FullName"
                            ValidationGroup="VG_Profil"
                            OnServerValidate="CV_TB_UserName_ServerValidate">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label for="TB_UserName" runat="server" Text="Nom d'usager"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TB_UserName" runat="server" CssClass="TextBox" Enabled="false"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RFV_TB_UserName" runat="server"
                            Text="!"
                            ErrorMessage="Le nom d'usager est vide!"
                            ControlToValidate="TB_UserName"
                            ValidationGroup="VG_Profil"
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
                            ValidationGroup="VG_Profil"
                            OnServerValidate="CV_TB_UserName_ServerValidate">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label for="TB_Password1" runat="server" Text="Confirmation du mot de passe"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TB_Password1" runat="server" CssClass="TextBox" TextMode="Password"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RFV_TB_Password1" runat="server"
                            Text="!"
                            ErrorMessage="La confirmation du mot de passe est vide!"
                            ControlToValidate="TB_Password1"
                            ValidationGroup="VG_Profil"
                            OnServerValidate="CV_TB_UserName_ServerValidate">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label for="TB_Email" runat="server" Text="Adresse de courriel"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TB_Email" runat="server" CssClass="TextBox"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RFV_TB_Email" runat="server"
                            Text="!"
                            ErrorMessage="Le courriel est vide!"
                            ControlToValidate="TB_Email"
                            ValidationGroup="VG_Profil"
                            OnServerValidate="CV_TB_UserName_ServerValidate">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label for="TB_Email1" runat="server" Text="Confirmation de l'adresse de courriel"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TB_Email1" runat="server" CssClass="TextBox"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RFV_TB_Email1" runat="server"
                            Text="!"
                            ErrorMessage="La confirmation du courriel est vide!"
                            ControlToValidate="TB_Email1"
                            ValidationGroup="VG_Profil"
                            OnServerValidate="CV_TB_UserName_ServerValidate">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BTN_Modifier" runat="server"
                            Text="Modifier..."
                            OnClientClick="VeutQuitter()"
                            CssClass="submitBTN"
                            ValidationGroup="VG_Profil" OnClick="BTN_Modifier_Click" />
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
<%--                        <asp:Button ID="BTN_Annuler" runat="server"
                            Text="Annuler..."
                            OnClientClick="VeutQuitter()"
                            CssClass="submitBTN"
                            OnClick="BTN_Annuler_Click" />--%>
                    </td>
                    <td></td>
                </tr>
            </table>
            <br />
        </div>
        <div id="right_content">
            <div id="right_top_content">
            </div>
            <div id="right_bottom_content">
                <table>
                    <tr>
                        <td>
                            <asp:Image ID="IMG_Avatar" ImageAlign="Right" ClientIDMode="Static" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td id="Lefty">
                            <asp:FileUpload ID="AvatarUpload" onchange="PreLoadImage();" runat="server" ClientIDMode="Static"/>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
            <table class="validationSummary">
               <tr>
                  <td>
                    <asp:ValidationSummary ID="ValidationSummary" runat="server"
                                            HeaderText="Sommaire des erreurs <hr/>"
                                            DisplayMode="BulletList"
                                            EnableClientScript="true"
                                            ValidationGroup="VG_Profil" />
                    <asp:CustomValidator ID="CV_Fullname" runat="server"
                        ControlToValidate="TB_Fullname"
                        ErrorMessage="Nom complet"
                        OnServerValidate="CV_FullName_ServerValidate"
                        ValidationGroup="VG_Profil"
                        ValidateEmptyText="True"
                        Display="None">
                    </asp:CustomValidator>
                    <asp:CustomValidator runat="server"
                        ID="CV_Username"
                        ControlToValidate="TB_UserName"
                        ErrorMessage="Nom d'usager"
                        OnServerValidate="CV_UserName_ServerValidate"
                        ValidationGroup="VG_Profil"
                        ValidateEmptyText="true"
                        Display="None">
                    </asp:CustomValidator>
                    <asp:CustomValidator runat="server"
                        ID="CV_Password"
                        ControlToValidate="TB_Password"
                        ErrorMessage="Mot de passe"
                        OnServerValidate="CV_Password_ServerValidate"
                        ValidationGroup="VG_Profil"
                        ValidateEmptyText="true"
                        Display="None">
                    </asp:CustomValidator>
                    <asp:CustomValidator runat="server"
                        ID="CV_PasswordConfirm"
                        ControlToValidate="TB_Password1"
                        ErrorMessage="Confirmation du mot de passe"
                        OnServerValidate="CV_Password1_ServerValidate"
                        ValidationGroup="VG_Profil"
                        ValidateEmptyText="true"
                        Display="None">
                    </asp:CustomValidator>
                    <asp:CustomValidator runat="server"
                        ID="CV_Email"
                        ControlToValidate="TB_Email"
                        ErrorMessage="Courriel"
                        OnServerValidate="CV_Email_ServerValidate"
                        ValidationGroup="VG_Profil"
                        ValidateEmptyText="true"
                        Display="None">
                    </asp:CustomValidator>
                    <asp:CustomValidator runat="server"
                        ID="CV_EmailConfirm"
                        ControlToValidate="TB_Email1"
                        ErrorMessage="La confirmation du courriel"
                        OnServerValidate="CV_Email1_ServerValidate"
                        ValidationGroup="VG_Profil"
                        ValidateEmptyText="true"
                        Display="None">
                    </asp:CustomValidator>
                   </td>
               </tr>
            </table>
    </div>
</asp:Content>

