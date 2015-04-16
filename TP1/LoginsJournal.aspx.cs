using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1_Env.Graphique
{
    public partial class LoginsJournal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Entête
            ((Label)Master.FindControl("LB_Page_Title")).Text = "Journal des visites...";
            ((Label)Master.FindControl("LB_Nom_Usager")).Text = (String)Session["Username"];
            ((Image)Master.FindControl("PB_Avatar")).ImageUrl = (String)Session["Avatar"];
            Session["User_Valid"] = true;
            Session["PAGE"] = "Journal";

            // Empêcher l'accès sans nom d'usager
            if (Session.IsNewSession)
                Server.Transfer("Login.aspx");

            // Affichage du gridview
            AfficherGridView();
        }
        protected void BTN_Retour_Click(object sender, EventArgs e)
        {
            Session["StartTime"] = DateTime.Now;
            Response.Redirect("Room.aspx");
        }
        protected void AfficherGridView()
        {
            TableLogins table = new TableLogins((String)Application["MainBD"], this);
            table.User_ID = (Int64)Session["USER_ID"];
            table.SelectAllLogs();
            table.MakeGridView(PN_GridView, "");
            table.EndQuerySQL();
        }
    }
}