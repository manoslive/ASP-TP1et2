using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1_Env.Graphique
{
    public partial class ThreadsManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Entête
            ((Label)Master.FindControl("LB_Page_Title")).Text = "Journal des connections...";
            ((Label)Master.FindControl("LB_Nom_Usager")).Text = (String)Session["Username"];
            ((Image)Master.FindControl("PB_Avatar")).ImageUrl = (String)Session["Avatar"];

            // Empêcher l'accès sans nom d'usager
            if (Session.IsNewSession)
                Server.Transfer("Login.aspx");

            // Affichage du GridView
            AfficherGridView();
        }
        protected void AfficherGridView()
        {
            TableUsers table = new TableUsers((String)Application["MainBD"], this);
            table.SelectAll();
            table.MakeGridView(PN_GridView, "");
            table.EndQuerySQL();
        }
        protected void BTN_Retour_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
    }
}