using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP1_Env.Graphique
{
    public class TableLogins : SqlExpressWrapper
    {
        public long ID { get; set; }
        public long User_ID { get; set; }
        public DateTime Login_Date { get; set; }
        public DateTime Logout_Date { get; set; }
        public String IP { get; set; }
        public TableLogins(String connexionString, System.Web.UI.Page Page)
            : base(connexionString, Page)
        {
            SQLTableName = "LOGINS";
        }

        public override void Insert()
        {
            InsertRecord(User_ID, Login_Date, Logout_Date, IP);
        }
        public override void Update()
        {
            UpdateRecord(ID, User_ID, Login_Date, Logout_Date, IP);
        }
    }
}