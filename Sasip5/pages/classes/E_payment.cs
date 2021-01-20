using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sasip5.pages.classes
{
    public class E_payment
    {
        public int Em_ID { get; set; }
        public string Branch { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public decimal Pay { get; set; }
        public string Date { get; set; }

        public void pay(E_payment em)
        {
            string sql = "INSERT INTO E_payment(E_ID, Branch, Year, Month, Payment, Date) VALUES ('"+em.Em_ID+ "','" + em.Branch + "','" + em.Year + "','" + em.Month + "','" + em.Pay + "','" + em.Date + "')";
            Shared share = new Shared();
            share.ExecuteQuery(sql);
        }
    }
}