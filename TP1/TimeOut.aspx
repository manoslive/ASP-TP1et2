<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TimeOut.aspx.cs" Inherits="TP1_Env.Graphique.TimeOut" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="LB_TimeOut" Text="Session expirée!" Style="float: left" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="BTN_Login" runat="server"
                        Text="Login..."
                        ValidationGroup="VG_Login" OnClick="BTN_Login_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
