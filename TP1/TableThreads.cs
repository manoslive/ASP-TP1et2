using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP1_Env.Graphique
{
    public class TableThreads : SqlExpressWrapper
    {
        public long ID { get; set; }
        public long Creator { get; set; }
        public String Title { get; set; }
        public DateTime Date_Of_Creation { get; set; }

        public TableThreads(String connexionString, System.Web.UI.Page Page)
            : base(connexionString, Page)
        {
            SQLTableName = "THREADS";
        }
        public override void Insert()
        {
            InsertRecord(Creator, Title, Date_Of_Creation);
        }

        public override void Update()
        {
            UpdateRecord(ID, Creator, Title, Date_Of_Creation);
        }
    }
}