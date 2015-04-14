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
        protected void Page_Load(object sender, EventArgs e)
        {
            
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
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            TimeOut();
        }
    }
}