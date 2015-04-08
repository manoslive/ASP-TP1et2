using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP1_Env.Graphique
{
    public class TableThreadsAccess : SqlExpressWrapper
    {
        public long ID { get; set; }
        public long Threads_ID { get; set; }
        public long User_ID { get; set; }
        public TableThreadsAccess(String connexionString, System.Web.UI.Page Page)
            : base(connexionString, Page)
        {
            SQLTableName = "THREADS_ACCESS";
        }
        public override void Insert()
        {
            InsertRecord(Threads_ID, User_ID);
        }
        public override void Update()
        {
            UpdateRecord(ID, Threads_ID, User_ID);
        }
    }
}