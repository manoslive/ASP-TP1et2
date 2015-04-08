﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace TP1_Env.Graphique
{
    public class PersonnesTable : SqlExpressWrapper
    {
        public long ID { get; set; }
        public String Fullname { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String Email { get; set; }
        public String Avatar { get; set; }
        public PersonnesTable(String connexionString, System.Web.UI.Page Page)
            : base(connexionString, Page)
        {
            SQLTableName = "PERSONNES";
        }
        public override void GetValues()
        {
            ID = long.Parse(FieldsValues[0]);
            Fullname = FieldsValues[1];
            Username = FieldsValues[2];
            Password = FieldsValues[3];
            Email = FieldsValues[4];
            Avatar = FieldsValues[5];
        }
        public override void Insert()
        {
            InsertRecord(Fullname, Username, Password, Email, Avatar);
        }
        public override void Update()
        {
            UpdateRecord(ID, Fullname, Username, Password, Email, Avatar);
        }
    }
}