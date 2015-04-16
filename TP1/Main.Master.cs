using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1_Env.Graphique
{
    public partial class Main : System.Web.UI.MasterPage
    {
        public bool EstLogger { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if((bool)Session["User_Valid"])
            {
                PN_Menu.Visible = true;
            }
            else
            {
                PN_Menu.Visible = false;
            }
            EstLogger = false;
        }
        public static string DurationToString(DateTime start, DateTime end)
        {
            int lesMinutes = 0;
            TimeSpan duration = end - start;
            double minutes = Math.Truncate(duration.TotalMinutes);
            double seconds = Math.Truncate(Math.Round(100 * duration.TotalSeconds) / 100);
            for (int i = 0; i < 5; i++)
            {
                if(seconds > 60)
                {
                    lesMinutes++;
                    seconds = seconds - 60;
                }
            }
            if (lesMinutes == 1 || lesMinutes == 2)
            {
                return (2 - lesMinutes).ToString() + " minutes " + (60 - seconds).ToString() + " secondes";
            }
            else if(lesMinutes >= 3)
            {
                return "TIMEOUT";
            }
            else
            {
                return "OK";
            }
        }
        protected void TimeOut()
        {
            string resultat="";
            DateTime sessionStart = (DateTime)Session["StartTime"];
            DateTime sessionEnd = DateTime.Now;
            resultat = DurationToString(sessionStart, sessionEnd);
            if (resultat == "OK")
            { }
            else if (resultat == "TIMEOUT")
            {
                TableUsers users = (TableUsers)Session["User"];
                users.Enligne = false;
                users.userEnligne();
                Response.Redirect("TimeOut.aspx");
            }
            else
                ((Label)FindControl("LB_Temps_Session")).Text = "Temps restant de cette session: " + resultat;
        }
        protected void EnregistrementLogin()
        {
            Session["USER_LOGOUT"] = DateTime.Now;
            //TableLogins logins = (TableLogins)Session["Logins"]; //Erreur, sa dit qu'il n'est jamais créé
            //TableLogins logins = new TableLogins((String)Application["MainBD"], this);
            TableUsers users = (TableUsers)Session["User"];

            // Rendre l'usager Offline
            users.ID = (Int64)Session["USER_ID"];
            users.Enligne = false;
            users.userEnligne();

            // Insertion du nouveau log
            //logins.User_ID = (Int64)Session["USER_ID"];
            //logins.Login_Date = (DateTime)Session["USER_LOGIN"];
            //logins.Logout_Date = (DateTime)Session["USER_LOGOUT"];
            //logins.IP = GetIP();
            //logins.Insert();
        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            TimeOut();
        }
        protected void Deconnection()
        {
            EnregistrementLogin();
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
        protected void BTN_ChatRoom_Click(object sender, EventArgs e)
        {
            Session["StartTime"] = DateTime.Now;
            Response.Redirect("ChatRoom.aspx");
        }
        protected void BTN_LoginsJournal_Click(object sender, EventArgs e)
        {
            Session["StartTime"] = DateTime.Now;
            Response.Redirect("LoginsJournal.aspx");
        }
        protected void BTN_ThreadsManager_Click(object sender, EventArgs e)
        {
            Session["StartTime"] = DateTime.Now;
            Response.Redirect("ThreadsManager.aspx");
        }
        protected void BTN_Deconnection_Click(object sender, EventArgs e)
        {
            Session["StartTime"] = DateTime.Now;
            Deconnection();
        }

        public void BTN_DeconnectionX_Click(object sender, EventArgs e)
        {
            EnregistrementLogin();
            Session.Abandon();
            Response.Redirect("Login.aspx"); //testing
        }
    }
}