using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace TP1_Env.Graphique
{
    public partial class Profil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Label)Master.FindControl("LB_Page_Title")).Text = "Profil...";
            ((Label)Master.FindControl("LB_Nom_Usager")).Text = (String)Session["Username"];
            //((Image)Master.FindControl("PB_Avatar")).ImageUrl = (String)Session["Avatar"];
            LoadUserInfo();
        }
        public void LoadUserInfo()
        {
            String DBPath = Server.MapPath(@"~\App_Data\MainBD.mdf");
            String ConnectString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='" + DBPath + "';Integrated Security=True";
            String sql = @"Select Username,Password,Fullname,Email,Avatar from USERS where Id=" + (Int64)Session["USER_ID"];
            SqlConnection DataBase_Connection = new SqlConnection(ConnectString);

            try
            {
                SqlCommand sqlCommand = new SqlCommand(sql);
                sqlCommand.Connection = DataBase_Connection;
                DataBase_Connection.Open();
                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                dataReader.Read();
                TB_FullName.Text = dataReader.GetString(0);
                TB_UserName.Text = dataReader.GetString(1);
                TB_Password.Text = dataReader.GetString(2);
                TB_Email.Text = dataReader.GetString(3);
                IMG_Avatar.ImageUrl = dataReader.GetString(4);
                DataBase_Connection.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        public void BTN_Modifier_Click(object sender, EventArgs e)
        {
            TableUsers modifierUser = new TableUsers((string)Application["MainBD"], this);
            modifierUser.ID = (Int64)Session["USER_ID"];
            modifierUser.Fullname = TB_FullName.Text;
            modifierUser.Username = TB_UserName.Text;
            modifierUser.Password = TB_Password.Text;
            modifierUser.Email = TB_Email.Text;
            modifierUser.Avatar = IMG_Avatar.ImageUrl;
            modifierUser.Update();
            //String DBPath = Server.MapPath(@"~\App_Data\MainBD.mdf");
            //String ConnectString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='" + DBPath + "';Integrated Security=True";
            //String sql = @"Update USERS SET Username='" + TB_UserName.Text + "', Password='" + TB_Password.Text + "', Fullname= '"+ TB_FullName.Text +"',Email='"+ TB_Email.Text + "',Avatar= '"+IMG_Avatar.ImageUrl+ "'";
            //SqlConnection DataBase_Connection = new SqlConnection(ConnectString);

            //try
            //{
            //    SqlCommand sqlCommand = new SqlCommand(sql);
            //    sqlCommand.Connection = DataBase_Connection;
            //    DataBase_Connection.Open();
            //    sqlCommand.ExecuteNonQuery();
            //    Session["StartTime"] = DateTime.Now;
            //    Response.Redirect("Index.aspx");
            //    DataBase_Connection.Close();
            //}
            //catch (Exception ex)
            //{
            //    Response.Write(ex.Message);
            //}
        }
        public void BTN_Annuler_Click(object sender, EventArgs e)
        {
            Session["StartTime"] = DateTime.Now;
            Response.Redirect("Index.aspx");
        }
        public static void ClientAlert(System.Web.UI.Page page, string message)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "alert", "alert('" + message + "');", true);
        }

        protected void CV_UserName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //USERS users = (USERS)Session["CurrentUser"];
            //args.IsValid = users.Exist(TB_UserName.Text);
        }

        protected void CV_Password_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //USERS users = (USERS)Session["CurrentUser"];
            //args.IsValid = users.Valid(TB_UserName.Text, TB_Password.Text);
        }
    }
}