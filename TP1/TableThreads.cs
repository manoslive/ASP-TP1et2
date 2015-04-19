using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SqlExpressUtilities;

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
        public override void GetValues()
        {
            ID = long.Parse(FieldsValues[0]);
            Creator = long.Parse(FieldsValues[1]);
            Title = FieldsValues[2];
            Date_Of_Creation = DateTime.Parse(FieldsValues[3]);
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