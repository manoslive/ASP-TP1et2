using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SqlExpressUtilities;

namespace TP1_Env.Graphique
{
    public class TableThreadsAccess : SqlExpressWrapper
    {
        public long ID { get; set; }
        public long Thread_ID { get; set; }
        public long User_ID { get; set; }
        public TableThreadsAccess(String connexionString, System.Web.UI.Page Page)
            : base(connexionString, Page)
        {
            SQLTableName = "THREADS_ACCESS";
        }
        public override void GetValues()
        {
            ID = long.Parse(FieldsValues[0]);
            Thread_ID = long.Parse(FieldsValues[1]);
            User_ID = long.Parse(FieldsValues[2]);
        }
        public override void Insert()
        {
            InsertRecord(Thread_ID, User_ID);
        }
        public override void Update()
        {
            UpdateRecord(ID, Thread_ID, User_ID);
        }
    }
}