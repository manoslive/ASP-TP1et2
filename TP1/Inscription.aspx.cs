using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace TP1_Env.Graphique
{
    public partial class Inscription : System.Web.UI.Page
    {
        Random random = new Random();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                IMG_Avatar.ImageUrl = "~/Images/Anonymous.png";
                Session["captcha"] = BuildCaptcha();
            }
            ((Label)Master.FindControl("LB_Page_Title")).Text = "Inscription...";
            ((Label)Master.FindControl("LB_Nom_Usager")).Text = "Anomyme";
            Session["PAGE"] = "Inscription";
        }
        public void BTN_Inscription_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                AjouterUtilisateur();
                Session["StartTime"] = DateTime.Now;
                Response.Redirect("Login.aspx");
            }

        }
        public void AjouterUtilisateur()
        {
            if (!VerifierExistanceUser(TB_UserName.Text))
            {
                TableUsers table_users = new TableUsers((string)Application["MainBD"], this);
                table_users.Fullname = TB_FullName.Text;
                table_users.Username = TB_UserName.Text;
                table_users.Password = TB_Password.Text;
                table_users.Email = TB_Email.Text;
                if (AvatarUpload.HasFile)
                {
                    String avatarPath = AvatarUpload.FileName;
                    String avatarMapPath;
                    avatarMapPath = Server.MapPath(@"\Images\" + avatarPath);
                    AvatarUpload.SaveAs(avatarMapPath);
                    IMG_Avatar.ImageUrl = "~/Images/" + avatarPath;
                    table_users.Avatar = IMG_Avatar.ImageUrl;
                }
                else
                {
                    table_users.Avatar = "~/Images/Anonymous.png";
                }
                table_users.Avatar = IMG_Avatar.ImageUrl;
                table_users.Insert();
            }
            else
            {
                ClientAlert(this, "Le Username est déjà utilisé!");
            }
        }
        public bool VerifierExistanceUser(string userName)
        {
            bool userExist = false;
            TableUsers leUser = new TableUsers((String)Application["MainBD"], this);
            leUser.Username = userName;
            if (leUser.userExists())
                userExist = true;
            return userExist;
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
        protected void CV_Captcha_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (TB_Captcha.Text != (string)Session["captcha"])
            {
                TB_Captcha.BackColor = System.Drawing.Color.FromArgb(0, 255, 200, 200);
                args.IsValid = false;
            }
            else
            {
                TB_Captcha.BackColor = System.Drawing.Color.White;
                args.IsValid = true;
            }
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
            Regex rgx = new Regex(@"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b", RegexOptions.IgnoreCase);
            Match match = rgx.Match(TB_Email.Text);
            return match.Value == TB_Email.Text;
        }
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
    }
}