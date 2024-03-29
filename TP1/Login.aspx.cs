﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;

namespace TP1_Env.Graphique
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Label)Master.FindControl("LB_Page_Title")).Text = "Login...";
            ((Label)Master.FindControl("LB_Nom_Usager")).Text = "Anomyme";
        }
        public void BTN_Login_Click(object sender, EventArgs e)
        {
            /////////////////////////////////////////////////
            //
            // Changer ici pour utiliser la classe tableusers
            //
            /////////////////////////////////////////////////

            // Nous créons ici une instance de TableUsers pour cette session
            Session["Utilisateur"] = new TableUsers((String)Application["MainBD"], this);
            TableUsers usager = new TableUsers((String)Application["MainBD"], this);
            // Je cherche comment affecter le username à cette session
            // ??????????

            // Nous créons une instance de TableLogins pour cette session
            Session["Login"] = new TableLogins((String)Application["MainBD"], this);

            ///////////////////////////////////////Douteux.com//Javou.ca//////////////////////////////////////////
            String DBPath = Server.MapPath(@"~\App_Data\MainBD.mdf");
            String ConnectString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='" + DBPath + "';Integrated Security=True";
            String sql = @"Select PASSWORD, USERNAME, AVATAR, ID From USERS where UserName = '" + TB_UserName.Text + "'";
            SqlConnection DataBase_Connection = new SqlConnection(ConnectString);

            try
            {
                SqlCommand sqlCommand = new SqlCommand(sql);
                sqlCommand.Connection = DataBase_Connection;
                DataBase_Connection.Open();
                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                dataReader.Read();
                Session["Username"] = dataReader.GetString(1);
                Session["Avatar"] = dataReader.GetString(2);
                Session["USER_ID"] = dataReader.GetInt64(3);
                if (TB_Password.Text == dataReader.GetString(0))
                {
                    ClientAlert(this, "Login est un succes!");
                    //((TableUsers)Session["Users"]).Online = 1;
                    //((TableUsers)Session["Users"]).Update();
                    Session["StartTime"] = DateTime.Now;
                    Session["USER_LOGIN"] = DateTime.Now;
                    usager.ID = (Int64)Session["USER_ID"];
                    usager.Enligne = true;
                    usager.userEnligne();
                    Response.Redirect("Index.aspx");
                }
                else
                    ClientAlert(this, "Mot de passe incorrect!");

                dataReader.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            //////////////////////////////////////fin de douteux.com//////////////////////////////////////
        }
        public void BTN_Inscription_Click(object sender, EventArgs e)
        {
            Session["StartTime"] = DateTime.Now;
            Response.Redirect("Inscription.aspx");
        }
        public void BTN_ForgotPassword_Click(object sender, EventArgs e)
        {
            EMail eMail = new EMail();

            eMail.From = "shaun.11.cooper@gmail.com";
            eMail.Password = "ShaunCooper11"; // EY! regarde pas mon password ! :D
            eMail.SenderName = "Shaun ou Emmanuel";
            eMail.Host = "smtp.gmail.com";
            eMail.HostPort = 587;
            eMail.SSLSecurity = true;

            String DBPath = Server.MapPath(@"~\App_Data\MainBD.mdf");
            String ConnectString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='" + DBPath + "';Integrated Security=True";
            String sql = @"Select Email,Password From USERS where UserName = '" + TB_UserName.Text + "'";
            SqlConnection DataBase_Connection = new SqlConnection(ConnectString);

            try
            {
                SqlCommand sqlCommand = new SqlCommand(sql);
                sqlCommand.Connection = DataBase_Connection;
                DataBase_Connection.Open();
                SqlDataReader dataReader = sqlCommand.ExecuteReader();

                if (dataReader.Read())
                {
                    eMail.To = dataReader.GetString(0);
                    eMail.Subject = "Mot de passe oublié";
                    eMail.Body = "Username: " + TB_UserName.Text + "<br />" +
                                 "Mot de passe: " + dataReader.GetString(1);

                    if (eMail.Send())
                    {
                        ClientAlert(this, "This eMail has been sent with success!");
                    }
                    else
                        ClientAlert(this, "An error occured while sendind this eMail!!!");
                }
                else
                {
                    ClientAlert(this, "Username introuvable!");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
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