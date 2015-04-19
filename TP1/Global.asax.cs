using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace TP1_Env.Graphique
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            // Toutes les Pages (WebForm) pourront accéder à la propriété Application["MaindDB"]
            string DB_Path = Server.MapPath(@"~\App_Data\MainBD.mdf");
            Application["MainBD"] = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='" + DB_Path + "';Integrated Security=False";


            // Ce data source fonctionne avec une BD à distance
            //Application["MainBD"] = @"Data Source=SQL5002.Smarterasp.net;Initial Catalog=DB_9C1271_asp;User Id=DB_9C1271_asp_admin;Password=12345Allo;";
        }
        protected void Session_Start(object sender, EventArgs e)
        {
            Session["StartTime"] = DateTime.Now;
        }
        protected void Session_End(object sender, EventArgs e)
        {
            if ((TableLogins)Session["Utilisateur"] != null)
            {
                ((TableLogins)Session["Utilisateur"]).Update();
                ((TableLogins)Session["Utilisateur"]).EndQuerySQL();
            }
            if (Convert.ToString(Session["User"]).Length > 0)
            {
                // Reset user connection state
                LogOutUser();
                Session["User"] = null;
            }
        }
        protected void LogOutUser()
        {
            Session["USER_LOGOUT"] = DateTime.Now;
            TableUsers users = (TableUsers)Session["User"];

            // Rendre l'usager Offline
            users.ID = (Int64)Session["USER_ID"];
            users.Enligne = false;
            users.userEnligne();
        }
    }
}