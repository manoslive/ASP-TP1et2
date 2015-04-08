using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1_Env.Graphique
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Label)Master.FindControl("LB_Page_Title")).Text = "Accueil...";
            ((Label)Master.FindControl("LB_Nom_Usager")).Text = (String)Session["Username"];
            ((Image)Master.FindControl("PB_Avatar")).ImageUrl = (String)Session["Avatar"];
        }
        protected void EnregistrementSession()
        {

        }
        protected void Deconnection()
        {
            EnregistrementSession();
            //((PersonnesTable)Session["User"]).Online = 0;
            ((PersonnesTable)Session["User"]).Update();
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        protected void BTN_Profil_Click(object sender, EventArgs e)
        {
            Session["StartTime"] = DateTime.Now;
            Response.Redirect("Profil.aspx");
        }
        protected void BTN_Room_Click(object sender, EventArgs e)
        {
            Session["StartTime"] = DateTime.Now;
            Response.Redirect("Room.aspx");
        }
        protected void BTN_Discutions_Click(object sender, EventArgs e)
        {
            Session["StartTime"] = DateTime.Now;
            Response.Redirect("LoginsJournal.aspx");
        }
        protected void BTN_ChatRoom_Click(object sender, EventArgs e)
        {
            Session["StartTime"] = DateTime.Now;
            Response.Redirect("ChatRoom.aspx");
        }
        protected void BTN_LoginsJournal_Click(object sender, EventArgs e)
        {
            Session["StartTime"] = DateTime.Now;
            Response.Redirect("Profil.aspx");
        }
        protected void BTN_Deconnection_Click(object sender, EventArgs e)
        {
            Session["StartTime"] = DateTime.Now;
            Response.Redirect("Profil.aspx");
        }
    }
}