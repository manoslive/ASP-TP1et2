using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1_Env.Graphique
{
    public partial class ThreadsManager : System.Web.UI.Page
    {
            protected void Page_Load(object sender, EventArgs e)
        {
            // Entête
            ((Label)Master.FindControl("LB_Page_Title")).Text = "Gestion des sujets de conversation...";
            ((Label)Master.FindControl("LB_Nom_Usager")).Text = (String)Session["Username"];
            ((Image)Master.FindControl("PB_Avatar")).ImageUrl = (String)Session["Avatar"];
            Session["User_Valid"] = true;
            Session["PAGE"] = "Threads";

            // Empêcher l'accès sans nom d'usager
            if (Session.IsNewSession)
                Server.Transfer("Login.aspx");

            ListThreads();
            ListUsers();

            
        }

        private void ListThreads()
        {
            TableThreads threads = new TableThreads((String)Application["MainBD"], this);

            Session["SelectedThread"] = LBL_ListDiscussions.SelectedItem;

            LBL_ListDiscussions.Items.Clear();

            if (threads.SelectByFieldName("CREATOR", ((Int64)Session["USER_ID"])))
            {
                do
                {
                    ListItem item = new ListItem(threads.Title, threads.ID.ToString());

                    if (Session["SelectedThread"] != null)
                        item.Selected = threads.ID.ToString() == ((ListItem)Session["SelectedThread"]).Value;

                    LBL_ListDiscussions.Items.Add(item);
                } while (threads.Next());
            }

            threads.EndQuerySQL();
        }

        private void ListUsers()
        {
            TableUsers user = new TableUsers((String)Application["MainBD"], this);

            if (user.SelectAll())
            {
                Table table = new Table();
                TableRow tr;
                TableCell td;

                while (user.Next())
                {
                    if (user.ID != ((TableUsers)Session["User"]).ID)
                    {
                        tr = new TableRow();
                        td = new TableCell();

                        CheckBox cb = new CheckBox();
                        cb.ID = "CB_" + user.ID.ToString();
                        td.Controls.Add(cb);
                        tr.Cells.Add(td);

                        td = new TableCell();
                        Image img = new Image();
                        img.Height = img.Width = 25;
                        img.ImageUrl = user.Avatar != "" ? user.Avatar : "~/Images/Anonymous.png";
                        td.Controls.Add(img);
                        tr.Cells.Add(td);

                        td = new TableCell();
                        td.Text = user.Fullname;
                        tr.Cells.Add(td);

                        table.Rows.Add(tr);
                    }
                }

                PN_User_Content.Controls.Clear();
                PN_User_Content.Controls.Add(table);
            }

            user.EndQuerySQL();
        }

        private bool HasAccess(String userId, String threadId)
        {
            bool hasAccess = false;
            TableThreadsAccess access = new TableThreadsAccess((String)Application["MainBD"], this);
            access.SelectByFieldName("THREAD_ID", threadId);

            do
            {
                hasAccess = access.User_ID.ToString() == userId;
            } while (!hasAccess && access.Next());

            access.EndQuerySQL();

            return hasAccess;
        }

        private void CreateNewThread()
        {
            TableThreads thread = new TableThreads((String)Application["MainBD"], this);
            thread.Creator = Convert.ToInt64(Session["USER_ID"]); //((TableUsers)Session["User"]).ID
            thread.Title = TBX_NewThread.Text;
            thread.Date_Of_Creation = DateTime.Now;

            thread.Insert();
            thread.SelectAll("Id DESC");
            thread.Next();

            String id = thread.ID.ToString();

            thread.EndQuerySQL();

            CreateThreadAccess(id);
        }

        private void CreateThreadAccess(String threadId)
        {
            Table table = (Table)PN_User_Content.Controls[0];
            TableThreadsAccess access = new TableThreadsAccess((String)Application["MainBD"], this);

            access.Thread_ID = long.Parse(threadId);

            access.User_ID = (Int64)Session["USER_ID"];
            access.Insert();

            foreach (TableRow tr in table.Rows)
            {
                TableCell td = tr.Cells[0];
                CheckBox cb = (CheckBox)td.Controls[0];
                if (cb.Checked)
                {
                    access.User_ID = long.Parse(cb.ID.Replace("CB_", ""));
                    access.Insert();
                }
            }
        }

        private void CheckInvitedUsers()
        {
            Table table = (Table)PN_User_Content.Controls[0];
            foreach (TableRow tr in table.Rows)
            {
                TableCell td = tr.Cells[0];
                CheckBox cb = (CheckBox)td.Controls[0];
                cb.Checked = HasAccess(cb.ID.Replace("CB_", ""), ((ListItem)Session["SelectedThread"]).Value);
            }
        }

        private void EditSelectedThread()
        {
            TableThreads thread = new TableThreads((String)Application["MainBD"], this);

            thread.SelectByID(((ListItem)Session["SelectedThread"]).Value);
            thread.EndQuerySQL();

            thread.Title = TBX_NewThread.Text;
            thread.Update();

            TableThreadsAccess access = new TableThreadsAccess((String)Application["MainBD"], this);
            access.NonQuerySQL("DELETE FROM " + access.SQLTableName + " WHERE THREAD_ID = " + thread.ID.ToString());
            CreateThreadAccess(thread.ID.ToString());
        }
        private void ClearForm()
        {
            Session["SelectedThread"] = null;
            LBL_ListDiscussions.ClearSelection();
            BTN_Edit.Text = "Créer";
            TBX_NewThread.Text = "";

            ListThreads();
            ListUsers();
        }

        private void DeleteThread()
        {
            TableThreads thread = new TableThreads((String)Application["MainBD"], this);
            TableThreadsAccess access = new TableThreadsAccess((String)Application["MainBD"], this);
            TableThreadsMessages messages = new TableThreadsMessages((String)Application["MainBD"], this);
            messages.NonQuerySQL("DELETE FROM " + messages.SQLTableName + " WHERE THREAD_ID = " + (((ListItem)Session["SelectedThread"]).Value));
            access.NonQuerySQL("DELETE FROM " + access.SQLTableName + " WHERE THREAD_ID = " + (((ListItem)Session["SelectedThread"]).Value));
            thread.DeleteRecordByID(((ListItem)Session["SelectedThread"]).Value);
        }

        protected void BTN_New_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        protected void BTN_Edit_Click(object sender, EventArgs e)
        {
            if (Session["SelectedThread"] == null)
                CreateNewThread();
            else
                EditSelectedThread();

            ClearForm();
        }

        protected void BTN_Delete_Click(object sender, EventArgs e)
        {
            if (Session["SelectedThread"] != null)
            {
                DeleteThread();
                ClearForm();
            }
        }

        protected void BTN_Retour_Click(object sender, EventArgs e)
        {
            Response.Redirect("Room.aspx");
        }

        protected void LBL_ListDiscussions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["SelectedThread"] != null)
            {
                CheckInvitedUsers();
                TBX_NewThread.Text = LBL_ListDiscussions.SelectedItem.Text;
                BTN_Edit.Text = "Modifier";
            }
        }

        protected void CBX_All_CheckedChanged(object sender, EventArgs e)
        {
            Table table = (Table)PN_User_Content.Controls[0];
            TableThreadsAccess access = new TableThreadsAccess((String)Application["MainBD"], this);

            foreach (TableRow tr in table.Rows)
            {
                TableCell td = tr.Cells[0];
                CheckBox cb = (CheckBox)td.Controls[0];
                cb.Checked = CBX_All.Checked;
            }
        }
        //    // Entête
        //    ((Label)Master.FindControl("LB_Page_Title")).Text = "Journal des connections...";
        //    ((Label)Master.FindControl("LB_Nom_Usager")).Text = (String)Session["Username"];
        //    ((Image)Master.FindControl("PB_Avatar")).ImageUrl = (String)Session["Avatar"];

        //    // Empêcher l'accès sans nom d'usager
        //    if (Session.IsNewSession)
        //        Server.Transfer("Login.aspx");

        //    Session["PAGE"] = "ThreadsManager";

        //    // Affichage du GridView
        //    FillListBox();
        //    AfficherGridView();
        //}
        //protected void FillListBox()
        //{
        //    //TableUsers table = new TableUsers((String)Application["MainBD"], this);
        //    //table.SelectAll();
        //    //            String DBPath = Server.MapPath(@"~\App_Data\MainBD.mdf");
        //    //String ConnectString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='" + DBPath + "';Integrated Security=True";
        //    //String sql = @"Select title From Threads where Creator = '" + (String)Session["Username"] + "'";
        //    //SqlConnection DataBase_Connection = new SqlConnection(ConnectString);

        //    //try
        //    //{
        //    //    SqlCommand sqlCommand = new SqlCommand(sql);
        //    //    sqlCommand.Connection = DataBase_Connection;
        //    //    DataBase_Connection.Open();
        //    //    SqlDataReader dataReader = sqlCommand.ExecuteReader();
        //    //    dataReader.Read();
        //    //    Session["Username"] = dataReader.GetString(1);
        //    //        table.EndQuerySQL();
        //    //}
        //    //catch(SqlException se)
        //    //{
        //    //    se.ToString();
        //    //}
        //}
        //protected void AfficherGridView()
        //{
        //    TableUsers table = new TableUsers((String)Application["MainBD"], this);
        //    table.SelectAll();
        //    table.MakeGridView(PN_GridView, "");
        //    table.EndQuerySQL();
        //}
        //protected void BTN_Retour_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("Index.aspx");
        //}
        //protected void TimerJournal_Tick(object sender, EventArgs e)
        //{
        //    // TODO : devra rafraichir la page pour voir les nouveaux threads ajoutés
        //}
    }
}