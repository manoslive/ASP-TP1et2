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
    public partial class Inscription : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["captcha"] = BuildCaptcha();
            }
            ((Label)Master.FindControl("LB_Page_Title")).Text = "Inscription...";
            ((Label)Master.FindControl("LB_Nom_Usager")).Text = "Anomyme";
        }
        public void BTN_Inscription_Click(object sender, EventArgs e)
        {
            //PersonnesTable personnesTable = new PersonnesTable((string)Application["MainBD"], this);
            //personnesTable.Fullname = TB_FullName.Text;
            //personnesTable.Username = TB_UserName.Text;
            //personnesTable.Password = TB_Password.Text;
            //personnesTable.Email = TB_Email.Text;
            //personnesTable.Avatar = IMG_Avatar.ImageUrl;
            ////personnesTable.Insert();
            String DBPath = Server.MapPath(@"~\App_Data\MainBD.mdf");
            String ConnectString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='" + DBPath + "';Integrated Security=True";
            String sql = @"Insert INTO USERS (Username, Password, Fullname,Email,Avatar) 
                           Values ('" + TB_UserName.Text + "','" + TB_Password.Text + "','" + TB_FullName.Text + "','" + TB_Email.Text + "','" + IMG_Avatar.ImageUrl + "')";
            SqlConnection DataBase_Connection = new SqlConnection(ConnectString);

            try
            {
                SqlCommand sqlCommand = new SqlCommand(sql);
                sqlCommand.Connection = DataBase_Connection;
                DataBase_Connection.Open();
                sqlCommand.ExecuteNonQuery();
                Session["StartTime"] = DateTime.Now;
                Response.Redirect("Login.aspx");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        public void BTN_Annuler_Click(object sender, EventArgs e)
        {
            Session["StartTime"] = DateTime.Now;
            Response.Redirect("Login.aspx");
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
        Random random = new Random();
        char RandomChar()
        {
            // les lettres comportant des ambiguïtées ne sont pas dans la liste
            // exmple: 0 et O ont été retirés
            string chars = "abcdefghkmnpqrstuvwvxyzABCDEFGHKMNPQRSTUVWXYZ23456789";
            return chars[random.Next(0, chars.Length)];
        }

        Color RandomColor(int min, int max)
        {
            return Color.FromArgb(255, random.Next(min, max), random.Next(min, max), random.Next(min, max));
        }

        string Captcha()
        {
            string captcha = "";

            for (int i = 0; i < 5; i++)
                captcha += RandomChar();
            return captcha;//.ToLower();
        }

        string BuildCaptcha()
        {
            int width = 200;
            int height = 70;
            Bitmap bitmap = new Bitmap(width, height);
            Graphics DC = Graphics.FromImage(bitmap);
            SolidBrush brush = new SolidBrush(RandomColor(0, 127));
            SolidBrush pen = new SolidBrush(RandomColor(172, 255));
            DC.FillRectangle(brush, 0, 0, 200, 100);
            Font font = new Font("Snap ITC", 32, FontStyle.Regular);
            PointF location = new PointF(5f, 5f);
            DC.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            string captcha = Captcha();
            DC.DrawString(captcha, font, pen, location);

            // noise generation
            for (int i = 0; i < 5000; i++)
            {
                bitmap.SetPixel(random.Next(0, width), random.Next(0, height), RandomColor(127, 255));
            }
            bitmap.Save(Server.MapPath("Captcha.png"), ImageFormat.Png);
            return captcha;
        }

        protected void RegenarateCaptcha_Click(object sender, ImageClickEventArgs e)
        {
            Session["captcha"] = BuildCaptcha();
            // + DateTime.Now.ToString() pour forcer le fureteur recharger le fichier
            IMGCaptcha.ImageUrl = "~/Captcha.png?ID=" + DateTime.Now.ToString();
            PN_Captcha.Update();
        }
        protected void BTN_Submit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Session["message"] = "(Inscription réussie - complétez maintenant votre profil...)";
                //Response.Redirect("Profil.aspx");
            }
        }
        protected void CV_Captcha_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (TB_Captcha.Text == (string)Session["captcha"]);//
        } 
    }
}