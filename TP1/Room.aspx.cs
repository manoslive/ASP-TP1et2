using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1_Env.Graphique
{
    public partial class Room : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Entête
            ((Label)Master.FindControl("LB_Page_Title")).Text = "Room...";
            ((Label)Master.FindControl("LB_Nom_Usager")).Text = (String)Session["Username"];
            ((Image)Master.FindControl("PB_Avatar")).ImageUrl = (String)Session["Avatar"];
            Session["PAGE"] = "Room";

            // Empêcher l'accès sans nom d'usager
            if (Session.IsNewSession)
                Server.Transfer("Login.aspx");

            // Affichage du gridview
            AfficherGridView();
        }
        protected void BTN_Retour_Click(object sender, EventArgs e)
        {
            Session["StartTime"] = DateTime.Now;
            Response.Redirect("Index.aspx");
        }
        protected void AfficherGridView()
        {
            TableUsers table = new TableUsers((String)Application["MainBD"], this);
            table.Room = true;
            table.SelectRoom();
            table.MakeGridView(PN_GridView, "");//Jai du mettre une ligne en commentaire(dans SQLExpressUtilities) pour que sa fonctionne, a vérifier!
            table.EndQuerySQL();
            table.Room = false;
        }
    }
}