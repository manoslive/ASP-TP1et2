using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
//using System.Drawing;
//using System.Drawing.Imaging;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1_Env.Graphique
{
    public partial class Profil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Label)Master.FindControl("LB_Page_Title")).Text = "Profil...";
            ((Label)Master.FindControl("LB_Nom_Usager")).Text = (String)Session["Username"];
            ((Image)Master.FindControl("PB_Avatar")).ImageUrl = (String)Session["Avatar"];
            Session["PAGE"] = "Profil";

            if (Session.IsNewSession)
                Server.Transfer("Login.aspx");

            if (!Page.IsPostBack)
            {
                //RemplirChamps();
                LoadUserInfo();
            }
        }
        public void LoadUserInfo()
        {
            String DBPath = Server.MapPath(@"~\App_Data\MainBD.mdf");
            String ConnectString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='" + DBPath + "';Integrated Security=True";
            String sql = @"Select Fullname,Username,Password,Email,Avatar from USERS where Id=" + (Int64)Session["USER_ID"];
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
                TB_Password1.Text = dataReader.GetString(2);
                TB_Email.Text = dataReader.GetString(3);
                TB_Email1.Text = dataReader.GetString(3);
                IMG_Avatar.ImageUrl = (String)Session["Avatar"];
                DataBase_Connection.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        public void BTN_Modifier_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                ModifierUtilisateur();
                Session["StartTime"] = DateTime.Now;
                Response.Redirect("Index.aspx");
            }

        }

        public void ModifierUtilisateur()
        {
            TableUsers modifierUser = new TableUsers((string)Application["MainBD"], this);
            modifierUser.ID = (Int64)Session["USER_ID"];
            modifierUser.Fullname = TB_FullName.Text;
            modifierUser.Username = TB_UserName.Text;
            modifierUser.Password = TB_Password.Text;
            modifierUser.Email = TB_Email.Text;
            modifierUser.Avatar = IMG_Avatar.ImageUrl;
            if (AvatarUpload.HasFile)
            {
                String avatarPath = AvatarUpload.FileName;
                String avatarMapPath;
                avatarMapPath = Server.MapPath(@"\Images\" + avatarPath);
                AvatarUpload.SaveAs(avatarMapPath);
                IMG_Avatar.ImageUrl = "~/Images/" + avatarPath;
                Session["Avatar"] = IMG_Avatar.ImageUrl;
            }
            else
            {
                Session["Avatar"] = "~/Images/Anonymous.png";
            }
            Session["Avatar"] = IMG_Avatar.ImageUrl;
            ////////////////((Image)Master.FindControl("PB_Avatar")).ImageUrl = (String)Session["Avatar"];
            modifierUser.Update();
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

        protected void CV_FullName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (TB_FullName.Text == "")
            {
                TB_FullName.BackColor = System.Drawing.Color.FromArgb(0, 255, 200, 200);
                args.IsValid = false;
            }
            else
            {
                TB_FullName.BackColor = System.Drawing.Color.White;
                args.IsValid = true;
            }
        }
        protected void CV_UserName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            TableUsers user = new TableUsers((String)Application["MainDB"], this);

            if (TB_UserName.Text == "")
            {
                TB_UserName.BackColor = System.Drawing.Color.FromArgb(0, 255, 200, 200);
                args.IsValid = false;
            }
            //else if (user.SelectByFieldName("USERNAME", TB_UserName.Text))
            //{
            //    TB_UserName.BackColor = System.Drawing.Color.FromArgb(0, 255, 200, 200);
            //    CV_Username.ErrorMessage = "Ce nom d'usager est déjà pris";
            //    args.IsValid = false;
            //}
            else
            {
                TB_UserName.BackColor = System.Drawing.Color.White;
                args.IsValid = true;
            }
        }
        protected void CV_Password_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (TB_Password.Text == "")
            {
                TB_Password.BackColor = System.Drawing.Color.FromArgb(0, 255, 200, 200);
                args.IsValid = false;
            }
            else
            {
                TB_Password.BackColor = System.Drawing.Color.White;
                args.IsValid = true;
            }
        }
        protected void CV_Password1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (TB_Password1.Text == "" || TB_Password1.Text != TB_Password.Text)
            {
                TB_Password1.BackColor = System.Drawing.Color.FromArgb(0, 255, 200, 200);
                args.IsValid = false;
            }
            else
            {
                TB_Password1.BackColor = System.Drawing.Color.White;
                args.IsValid = true;
            }
        }
        protected void CV_Email_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (TB_Email.Text == "")
            {
                TB_Email.BackColor = System.Drawing.Color.FromArgb(0, 255, 200, 200);
                args.IsValid = false;
            }
            else if (!ValiderEmail())
            {
                TB_Email.BackColor = System.Drawing.Color.FromArgb(0, 255, 200, 200);
                CV_Email.ErrorMessage = "Le courriel est syntaxiquement invalide!";
                args.IsValid = false;
            }
            else
            {
                TB_Email.BackColor = System.Drawing.Color.White;
                args.IsValid = true;
            }
        }
        protected void CV_Email1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (TB_Email1.Text == "" || TB_Email1.Text != TB_Email.Text)
            {
                TB_Email1.BackColor = System.Drawing.Color.FromArgb(0, 255, 200, 200);
                args.IsValid = false;
            }
            else
            {
                TB_Email1.BackColor = System.Drawing.Color.White;
                args.IsValid = true;
            }
        }
        private bool ValiderEmail()
        {
            //Regex rgx = new Regex(@"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b", RegexOptions.IgnoreCase);
            Regex rgx = new Regex(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            Match match = rgx.Match(TB_Email.Text);
            return match.Value == TB_Email.Text;
        }
    }
}