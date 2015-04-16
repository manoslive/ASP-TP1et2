<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Inscription.aspx.cs" Inherits="TP1_Env.Graphique.Inscription" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Inscription_css.css" />
    <script type="text/javascript" src="ClientFormUtilities.js"></script>

    <script src="http://code.jquery.com/jquery-1.10.2.js"></script>
    <script lang="javascript" type="text/javascript">
        var Quit = 1;
        function VeutQuitter() {
            Quit = 0;
        }

        $(document).ready(function () {
            $(window).bind("beforeunload", function () {
                if (Quit == 1)
                    return confirm("Êtes-vous sur de vouloir quitter la page?");
            });
        });
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
                            ValidationGroup="VG_Login"
                            OnServerValidate="CV_TB_UserName_ServerValidate">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
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
                            ValidationGroup="VG_Login"
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
                            ValidationGroup="VG_Login"
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
                            ValidationGroup="VG_Login"
                            OnServerValidate="CV_TB_UserName_ServerValidate">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BTN_Inscription" runat="server"
                            Text="Inscription..."
                            OnClientClick="VeutQuitter()"
                            CssClass="submitBTN"
                            ValidationGroup="VG_Login" OnClick="BTN_Inscription_Click" />
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BTN_Annuler" runat="server"
                            Text="Annuler..."
                            OnClientClick="VeutQuitter()"
                            CssClass="submitBTN"
                            OnClick="BTN_Annuler_Click" />
                    </td>
                    <td></td>
                </tr>
<%--                <tr>
                    <td>
                <asp:ValidationSummary ID="ValidationSummary" runat="server"
                HeaderText="Sommaire des erreurs <hr/>"
                DisplayMode="BulletList"
                EnableClientScript="true"
                ValidationGroup="VG_Login" />
                    &nbsp;
                        </td>
                </tr>--%>
            </table>
            <br />
        </div>
        <div id="right_content">
            <div id="right_top_content">
        <div>
            <table>
                <tr>    
                    <td colspan="2">
                        <asp:UpdatePanel ID="PN_Captcha" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                        <table>
                            <tr>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:ImageButton    ID="RegenarateCaptcha" runat="server" 
                                                        ImageUrl="~/Images/RegenerateCaptcha.png" 
                                                        CausesValidation="False" 
                                                        onclick="RegenarateCaptcha_Click" 
                                                        ValidationGroup="Subscribe_Validation" 
                                                        width="48"
                                                        ToolTip="Regénérer le captcha..." />  
                                    </td>

                                    <td>
                                        <asp:Image ID="IMGCaptcha" imageurl="~/captcha.png" runat="server" />
                                    </td>
                                </tr>
                        </table>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>      
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:TextBox ID="TB_Captcha" runat="server" MaxLength="5" ></asp:TextBox>
                        <asp:CustomValidator    ID="CV_Captcha" runat="server" 
                                                ErrorMessage="Code captcha incorrect!" 
                                                ValidationGroup="Subscribe_Validation"
                                                Text="!" 
                                                ControlToValidate="TB_Captcha" 
                                                onservervalidate="CV_Captcha_ServerValidate" 
                                                ValidateEmptyText="True">
                        </asp:CustomValidator>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RFV_TB_Captcha" runat="server"
                            Text="!"
                            ErrorMessage="Le captcha est vide!"
                            ControlToValidate="TB_Captcha"
                            ValidationGroup="VG_Login"
                            OnServerValidate="CV_TB_Captcha_ServerValidate">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
        <%--<asp:ValidationSummary ID="Subscribe_Validation" runat="server" ValidationGroup="Subscribe_Validation" />--%>
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
                                            ValidationGroup="VG_Login" />
                   </td>
               </tr>
            </table>
    </div>
</asp:Content>
