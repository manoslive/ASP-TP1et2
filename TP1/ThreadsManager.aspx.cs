using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

            Session["PAGE"] = "ThreadsManager";

            // Affichage du GridView
            FillListBox();
            AfficherGridView();
        }
        protected void FillListBox()
        {
            //TableUsers table = new TableUsers((String)Application["MainBD"], this);
            //table.SelectAll();
            //            String DBPath = Server.MapPath(@"~\App_Data\MainBD.mdf");
            //String ConnectString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='" + DBPath + "';Integrated Security=True";
            //String sql = @"Select title From Threads where Creator = '" + (String)Session["Username"] + "'";
            //SqlConnection DataBase_Connection = new SqlConnection(ConnectString);

            //try
            //{
            //    SqlCommand sqlCommand = new SqlCommand(sql);
            //    sqlCommand.Connection = DataBase_Connection;
            //    DataBase_Connection.Open();
            //    SqlDataReader dataReader = sqlCommand.ExecuteReader();
            //    dataReader.Read();
            //    Session["Username"] = dataReader.GetString(1);
            //        table.EndQuerySQL();
            //}
            //catch(SqlException se)
            //{
            //    se.ToString();
            //}
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
        protected void TimerJournal_Tick(object sender, EventArgs e)
        {
            // TODO : devra rafraichir la page pour voir les nouveaux threads ajoutés
        }
    }
}