using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SqlExpressUtilities;

namespace TP1_Env.Graphique
{
    public class TableThreadsMessages : SqlExpressWrapper
    {
        public long ID { get; set; }
        public long Threads_ID { get; set; }
        public long User_ID { get; set; }
        public DateTime Date_Of_Creation { get; set; }
        public String Message { get; set; }

        public TableThreadsMessages(String connexionString, System.Web.UI.Page page)
            : base(connexionString, page)
        {
            SQLTableName = "THREADS_MESSAGES";
        }
        public override void GetValues()
        {
            ID = long.Parse(FieldsValues[0]);
            Threads_ID = long.Parse(FieldsValues[1]);
            User_ID = long.Parse(FieldsValues[2]);
            Date_Of_Creation = DateTime.Parse(FieldsValues[3]);
            Message = FieldsValues[4];
        }
        public override void Insert()
        {
            InsertRecord(Threads_ID, User_ID, Date_Of_Creation, Message);
        }
        public override void Update()
        {
            UpdateRecord(ID, Threads_ID, User_ID, Date_Of_Creation, Message);
        }

    }
}