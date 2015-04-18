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
            //string DB_Path = Server.MapPath(@"~\db\MainBD.mdf");
            // Toutes les Pages (WebForm) pourront accéder à la propriété Application["MaindDB"]
            //Application["MainBD"] = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='" + DB_Path + "';Integrated Security=False";
            //"Data Source=.\SQLEXPRESS\v11.0;Server=SQL5002.Smarterasp.net;Database=DB_9C112B_BARBUETSHAUN;User ID=DB_9C112B_barbuetshaun_admin;Password=12345Allo;Trusted_Connection=False";
            Application["MainBD"] = @"Data Source=SQL5002.Smarterasp.net;Initial Catalog=DB_9C112B_barbuetshaun;User Id=DB_9C112B_barbuetshaun_admin;Password=12345Allo;";
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
        }
    }
}