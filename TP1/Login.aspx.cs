using System;
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
        public DateTime BanTime;
        public DateTime UnBanTime;
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Label)Master.FindControl("LB_Page_Title")).Text = "Login...";
            ((Label)Master.FindControl("LB_Nom_Usager")).Text = "Anomyme";
            ((Panel)Master.FindControl("PN_HR")).Visible = false;
            Session["PAGE"] = "Login";
            Session["User_Valid"] = false;
        }
        public void InsertBlackList()
        {
            String DBPath = Server.MapPath(@"~\App_Data\MainBD.mdf");
            String ConnectString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='" + DBPath + "';Integrated Security=True";

            System.DateTime Ban = System.DateTime.Now;
            System.TimeSpan duration = new System.TimeSpan(0, 0, 5, 0); // Unban dans 5 minutes
            System.DateTime Unban = Ban.Add(duration);
            String sqlBlackList = @"INSERT INTO Blacklist (USERNAME, DATEBAN, DATEUNBAN) VALUES 
                                  ('" + TB_UserName.Text + "','" + DateTime.Now + "','" + Unban + "')";
            SqlConnection DataBase_Connection = new SqlConnection(ConnectString);

            try
            {
                SqlCommand sqlCommand = new SqlCommand(sqlBlackList);
                sqlCommand.Connection = DataBase_Connection;
                DataBase_Connection.Open();
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        public bool PresentDansBlackList()
        {
            bool present = false;
            string username = "";
            String sql = "SELECT * FROM BlackList Where USERNAME ='" + TB_UserName.Text + "'";

            String DBPath = Server.MapPath(@"~\App_Data\MainBD.mdf");
            String ConnectString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='" + DBPath + "';Integrated Security=True";
            SqlConnection DataBase_Connection = new SqlConnection(ConnectString);

            try
            {
                SqlCommand sqlCommand = new SqlCommand(sql);
                sqlCommand.Connection = DataBase_Connection;
                DataBase_Connection.Open();
                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                dataReader.Read();   
                if(dataReader.HasRows)
                {
                    present = true;
                    username = dataReader.GetString(0);
                    BanTime = dataReader.GetDateTime(1);
                    UnBanTime = dataReader.GetDateTime(2);
                }    
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            return present;
        }
        public void DeleteBlackList()
        {
            if(PresentDansBlackList())
            {
                if(UnBanTime < DateTime.Now)
                {
                    String sql = "Delete FROM BlackList Where USERNAME ='" + TB_UserName.Text + "'";

                    String DBPath = Server.MapPath(@"~\App_Data\MainBD.mdf");
                    String ConnectString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='" + DBPath + "';Integrated Security=True";
                    SqlConnection DataBase_Connection = new SqlConnection(ConnectString);

                    try
                    {
                        SqlCommand sqlCommand = new SqlCommand(sql);
                        sqlCommand.Connection = DataBase_Connection;
                        DataBase_Connection.Open();
                        sqlCommand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);
                    }
                }
            }
        }
        public void BTN_Login_Click(object sender, EventArgs e)
        {
            DeleteBlackList();
            if (Session["Nb_Essai"] == null)
                Session["Nb_Essai"] = 0;
            else if (Session["Essai_User"] != null)
            {
                if (Session["Essai_User"].ToString() == TB_UserName.Text)
                    if (Convert.ToInt32(Session["Nb_Essai"]) > 1)
                        InsertBlackList();
            }
            if (PresentDansBlackList())
            {
                ClientAlert(this, "Vous êtes bani! Temps bani : " + BanTime + " - " + UnBanTime);
            }
            else
            {
                // Nous créons ici une instance de TableUsers pour cette session
                Session["User"] = new TableUsers((String)Application["MainBD"].ToString(), this);
                TableUsers usager = new TableUsers((String)Application["MainBD"], this);
                //((TableUsers)Session["User"]).SelectByFieldName("USERNAME", TB_UserName.Text);
                // Je cherche comment affecter le username à cette session
                // ??????????

                // Nous créons une instance de TableLogins pour cette session
                Session["Login"] = new TableLogins((String)Application["MainBD"], this);

                String DBPath = Server.MapPath(@"~\App_Data\MainBD.mdf");
                String ConnectString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='" + DBPath + "';Integrated Security=True";
                String sql = @"Select PASSWORD, USERNAME, AVATAR, ID From USERS where UserName = '" + TB_UserName.Text + "' AND Enligne = 0";
                SqlConnection DataBase_Connection = new SqlConnection(ConnectString);

                try
                {
                    SqlCommand sqlCommand = new SqlCommand(sql);
                    sqlCommand.Connection = DataBase_Connection;
                    DataBase_Connection.Open();
                    SqlDataReader dataReader = sqlCommand.ExecuteReader();
                    dataReader.Read();
                    if (dataReader.HasRows)
                    {
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
                            Session["User_Valid"] = true;
                            Response.Redirect("Room.aspx");
                        }
                        else
                        {
                            ClientAlert(this, "Mot de passe incorrect!");
                            if (Session["Essai_User"] == null)
                                Session["Essai_User"] = TB_UserName.Text;
                            if (TB_UserName.Text == Session["Essai_User"].ToString())
                            {
                                Session["Nb_Essai"] = Convert.ToInt32(Session["Nb_Essai"]) + 1;
                                Session["Essai_User"] = TB_UserName.Text;
                            }
                            else
                            {
                                Session["Nb_Essai"] = 0;
                                Session["Nb_Essai"] = Convert.ToInt32(Session["Nb_Essai"]) + 1;
                                Session["Essai_User"] = TB_UserName.Text;
                            }
                        }
                    }
                    else
                        ClientAlert(this, "Le nom d usager n existe pas ou l'usager est déja connecté");

                    dataReader.Close();
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }     
        }
        public void BTN_Inscription_Click(object sender, EventArgs e)
        {
            Session["StartTime"] = DateTime.Now;
            Response.Redirect("Inscription.aspx");
        }
        public void BTN_ForgotPassword_Click(object sender, EventArgs e)
        {
            EMail eMail = new EMail();

            eMail.From = "projetaspmaster@gmail.com";
            eMail.Password = "0123456789aA"; // EY! regarde pas mon password ! :D
            eMail.SenderName = "Shaun ou Emmanuel";
            eMail.Host = "smtp.gmail.com";
            eMail.HostPort = 587;//465
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