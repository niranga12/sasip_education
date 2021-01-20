using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sasip5.pages.classes
{
    public class S_Payment
    {
        public int Stu_ID { get; set; }
        public int Sub_ID { get; set; }
        public decimal Pay { get; set; }
        public decimal OverDue { get; set; }
        public string Status { get; set; }
        public string Date { get; set; }

        public void pay(S_Payment sp)
        {
            string sql = "INSERT INTO S_payment(Stu_ID, Sub_ID, Pay, Overdue, Date, Status) VALUES ('"+sp.Stu_ID+"','"+sp.Sub_ID+"','"+sp.Pay+"','"+sp.OverDue+"','"+sp.Date+"','"+sp.Status+"')";
            Shared share = new Shared();
            share.ExecuteQuery(sql);
        }
    }
}