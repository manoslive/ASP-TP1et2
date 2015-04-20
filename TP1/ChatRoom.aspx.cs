using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1_Env.Graphique
{
    public partial class ChatRoom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Label)Master.FindControl("LB_Page_Title")).Text = "Chatroom...";
            ((Label)Master.FindControl("LB_Nom_Usager")).Text = (String)Session["Username"];
            ((Image)Master.FindControl("PB_Avatar")).ImageUrl = (String)Session["Avatar"];
            Session["User_Valid"] = true;
            AfficherMessages();
            AfficherUtilisateursParticipants();
            AfficherBoutonsSujet();
            Session["PAGE"] = "ChatRoom";

        }
        private void AfficherBoutonsSujet()
        {
            TableThreadsAccess access = new TableThreadsAccess((String)Application["MainBD"], this);
             TableThreads thread = new TableThreads((String)Application["MainBD"], this);

            Table table = new Table();
            TableRow tr;
            TableCell td;

            //if (access.SelectByFieldName("USER_ID", ((TableUsers)Session["User"]).ID))
            if (access.SelectByFieldName("USER_ID", ((Int64)Session["User_ID"])))
            {
                do
                {
                    thread.SelectByID(access.Thread_ID.ToString());
                    thread.EndQuerySQL();

                    tr = new TableRow();
                    td = new TableCell();

                    Button btn = new Button();
                    btn.ID = "ThreadButton_" + thread.ID.ToString();
                    btn.Text = thread.Title;
                    btn.CssClass = "BTNThread";
                    btn.Click += BTN_Thread_Click;
                    td.Controls.Add(btn);
                    tr.Cells.Add(td);

                    table.Rows.Add(tr);
                } while (access.Next());
            }


            access.EndQuerySQL();

            access.SelectByFieldName("USER_ID", 0);

            while (access.Next())
            {
                thread.SelectByID(access.Thread_ID.ToString());
                thread.EndQuerySQL();

                tr = new TableRow();
                td = new TableCell();

                Button btn = new Button();
                btn.ID = "ThreadButton_" + thread.ID.ToString();
                btn.Text = thread.Title;
                btn.Click += BTN_Thread_Click;
                td.Controls.Add(btn);
                tr.Cells.Add(td);

                table.Rows.Add(tr);
            }

            access.EndQuerySQL();
            PN_Threads.Controls.Clear();
            PN_Threads.Controls.Add(table);
        }
        private void AfficherTousUtilisateurs()
        {
            TableUsers users = new TableUsers((String)Application["MainBD"], this);
            users.SelectAll("ONLINE DESC");

            Table table = new Table();
            TableRow tr;
            TableCell td;

            while (users.Next())
            {
                tr = new TableRow();
                td = new TableCell();

                Image img = new Image();
                img.Height = img.Width = 25;
                img.ImageUrl = users.Enligne != false ? "~/Images/OnLine.png" : "~/Images/OffLine.png";
                td.Controls.Add(img);
                tr.Cells.Add(td);

                td = new TableCell();
                img = new Image();
                img.Height = img.Width = 25;
                img.ImageUrl = users.Avatar != "" ? "~/Images/" + users.Avatar + ".png" : "~/Images/Anonymous.png";
                td.Controls.Add(img);
                tr.Cells.Add(td);

                td = new TableCell();
                td.Text = users.Fullname;
                tr.Cells.Add(td);

                table.Rows.Add(tr);
            }

            users.EndQuerySQL();
            PN_Users.Controls.Clear();
            PN_Users.Controls.Add(table);
        }
        private void AfficherUtilisateursParticipants()
        {
            TableThreadsAccess access = new TableThreadsAccess((String)Application["MainBD"], this);
            if (Session["CurrentThread"] != null &&
                access.SelectByFieldName("THREAD_ID", (String)Session["CurrentThread"]))
            {
                access.EndQuerySQL();

                if (access.User_ID == 0)
                    AfficherTousUtilisateurs();
                else
                    AfficherUtilisateur();
            }
        }
        private void AfficherUtilisateur()
        {
            TableThreadsAccess access = new TableThreadsAccess((String)Application["MainBD"], this);
            access.SelectByFieldName("THREAD_ID", (String)Session["CurrentThread"]);


            TableUsers users = new TableUsers((String)Application["MainBD"], this);

            Table table = new Table();
            TableRow tr;
            TableCell td;

            do
            {
                users.SelectByID(access.User_ID.ToString());
                users.EndQuerySQL();

                tr = new TableRow();
                td = new TableCell();

                Image img = new Image();
                img.Height = img.Width = 25;
                img.ImageUrl = users.Enligne != false ? "~/Images/OnLine.png" : "~/Images/OffLine.png";
                td.Controls.Add(img);
                tr.Cells.Add(td);

                td = new TableCell();
                img = new Image();
                img.Height = img.Width = 25;
                img.ImageUrl = users.Avatar != "" ? users.Avatar : "~/Images/Anonymous.png";
                td.Controls.Add(img);
                tr.Cells.Add(td);

                td = new TableCell();
                td.Text = users.Fullname;
                tr.Cells.Add(td);

                table.Rows.Add(tr);
            } while (access.Next());

            access.EndQuerySQL();
            PN_Users.Controls.Clear();
            PN_Users.Controls.Add(table);
        }
        private void AfficherMessages()
        {
            TableThreadsMessages messages = new TableThreadsMessages((String)Application["MainBD"], this);
            if (Session["CurrentThread"] != null &&
                messages.SelectByFieldName("THREAD_ID", (String)Session["CurrentThread"]))
            {
                TableUsers user = new TableUsers((String)Application["MainBD"], this);

                Table table = new Table();
                TableRow tr;
                TableCell td;

                do
                {
                    tr = new TableRow();
                    td = new TableCell();

                    user.SelectByID(messages.User_ID.ToString());

                    // Avatar
                    Image img = new Image();
                    img.ImageUrl = user.Avatar != "" ?user.Avatar : "~/Images/Anonymous.png";
                    img.Width = img.Height = 40;
                    td.Controls.Add(img);
                    tr.Cells.Add(td);

                    // Nom et Date
                    td = new TableCell();
                    string date = messages.Date_Of_Creation.ToShortDateString() + " " + messages.Date_Of_Creation.ToShortTimeString();
                    string content = user.Fullname + "<br/>" + date + "<br/>";
                    td.Controls.Add(new LiteralControl(content));
                    tr.Cells.Add(td);

                    // Edit buttons
                    td = new TableCell();
                    if (user.ID == (((Int64)Session["User_ID"])))
                    {
                        td.Controls.Add(CreerBoutonDelete(messages.ID.ToString()));
                    }
                    tr.Cells.Add(td);

                    // Message
                    td = new TableCell();
                    td.Text = messages.Message;
                    tr.Cells.Add(td);

                    table.Rows.Add(tr);
                } while (messages.Next());

                PN_Messages.Controls.Clear();
                PN_Messages.Controls.Add(table);
            }
        }
        private void EnvoyerMessage()
        {
            TableThreadsMessages message = new TableThreadsMessages((String)Application["MainBD"], this);
            message.Threads_ID = long.Parse((String)Session["CurrentThread"]);
            message.User_ID = ((Int64)Session["User_ID"]);
            message.Date_Of_Creation = DateTime.Now;
            message.Message = TB_Message.Text;
            message.Insert();
        }
        private void AfficherBoutonSujet()
        {
            TableThreadsAccess access = new TableThreadsAccess((String)Application["MainBD"], this);
            TableThreads thread = new TableThreads((String)Application["MainBD"], this);

            Table table = new Table();
            TableRow tr;
            TableCell td;

            if (access.SelectByFieldName("USER_ID", ((Int64)Session["User_ID"])))
            {

                do
                {
                    thread.SelectByID(access.Thread_ID.ToString());
                    thread.EndQuerySQL();

                    tr = new TableRow();
                    td = new TableCell();

                    Button btn = new Button();
                    btn.ID = "ThreadButton_" + thread.ID.ToString();
                    btn.Text = thread.Title;
                    btn.Click += BTN_Thread_Click;
                    td.Controls.Add(btn);
                    tr.Cells.Add(td);

                    table.Rows.Add(tr);
                } while (access.Next());
            }


            access.EndQuerySQL();

            access.SelectByFieldName("USER_ID", 0);

            do
            {
                thread.SelectByID(access.Thread_ID.ToString());
                thread.EndQuerySQL();

                tr = new TableRow();
                td = new TableCell();

                Button btn = new Button();
                btn.ID = "ThreadButton_" + thread.ID.ToString();
                btn.Text = thread.Title;
                btn.Click += BTN_Thread_Click;
                td.Controls.Add(btn);
                tr.Cells.Add(td);

                table.Rows.Add(tr);
            } while (access.Next());

            access.EndQuerySQL();
            PN_Threads.Controls.Clear();
            PN_Threads.Controls.Add(table);
        }
        protected void TimerChatroom_Tick(object sender, EventArgs e)
        {

        }
        private ImageButton CreerBoutonDelete(String messageId)
        {
            ImageButton btn = new ImageButton();
            btn.ID = "BTN_Delete_" + messageId;
            btn.ImageUrl = @"~/Images/Delete.bmp";
            btn.Width = btn.Height = 26;
            btn.Click += BTN_Delete_Click;

            return btn;
        }
        protected void BTN_Thread_Click(object sender, EventArgs e)
        {
            String threadId = ((Button)sender).ID;

            threadId = threadId.Replace("ThreadButton_", "");

            Session["CurrentThread"] = threadId;

            TableThreads thread = new TableThreads((String)Application["MainBD"], this);
            thread.SelectByID(threadId);
            LBL_Title.Text = thread.Title;
            thread.EndQuerySQL();

            AfficherMessages();
            AfficherUtilisateursParticipants();
        }
        protected void BTN_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
        protected void BTN_Send_Click(object sender, EventArgs e)
        {
            if (TB_Message.Text != "")
                EnvoyerMessage();

            TB_Message.Text = "";
        }
        protected void BTN_Delete_Click(object sender, ImageClickEventArgs e)
        {
            String messageId = ((ImageButton)sender).ID;

            messageId = messageId.Replace("BTN_Delete_", "");

            TableThreadsMessages message = new TableThreadsMessages((String)Application["MainBD"], this);
            message.DeleteRecordByID(messageId);

            AfficherMessages();
        }
    }
}