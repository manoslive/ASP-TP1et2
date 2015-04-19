using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1_Env
{
    public partial class spyWin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["RETURN"]) == 0)
            {
                Session["RETURN"] = 1;
                string script = 
                    "<script type='text/javascript' " +
                    "language='javascript'>" +
                    " function check_opener() { " +
                    " if (opener && opener.closed){ " +
                    " parent.opener=''; " +
                    " parent.close(); " +
                    " window.open('Login.aspx') " +
                    " } " +
                    " else{ " +
                    " parent.opener=''; " +
                    " parent.close(); " +
                    " } " +
                    "} " +
                    " onload = function() { " +
                    " self.blur(); " +
                    " setTimeout('check_opener()',0); " +
                    " } " +
                    " </script>";
                this.Controls.Add(new LiteralControl(script));

            }
            else
            {
                Session["RETURN"] = 0;
            }
        }
    }
}