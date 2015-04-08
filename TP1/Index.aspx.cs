using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Session["StartTime"] = DateTime.Now;
            ((Label)Master.FindControl("LB_Page_Title")).Text = "Accueil...";
            ((Label)Master.FindControl("LB_Nom_Usager")).Text = (String)Session["Username"];
            // ICI
            ((Image)Master.FindControl("PB_Avatar")).???? = (String)Session["Avatar"];
        }
    }
}