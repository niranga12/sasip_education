using Sasip5.pages.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sasip5.pages
{
    public partial class dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
                if (Session["EType"] == null)
                {
                    Response.Redirect("Login.aspx");
                }

            string etype = Session["EType"].ToString();

            if (etype == "Admin")
            {
                MonthlyIncome();
                MonthlyNetProfit();
                YearlyNetProfit();
            }

            else 
            {
                lbl_M_Income.InnerText = "Access Denied";
                lbl_M_Net_income.InnerText = "Access Denied";
                lbl_year_net_profit.InnerText = "Access Denied";
            }
            StudentCount();
            EmployeeCount();
            ClassCount();
           
        }

        //Get Class Count
        public void ClassCount()
        {
            Shared lc = new Shared();
            string sql = "SELECT count(ID) as C FROM Subject";

            try
            {
                lbl_courses.InnerText = lc.getdata(sql).Tables[0].Rows[0]["C"].ToString();

            }
            catch (Exception)
            {
            }
        }

        //Get Student Count
        public void StudentCount()
        {
            Shared lc = new Shared();
            string sql = "SELECT count(S_id) as C FROM students";

            try
            {
                lbl_student.InnerText = lc.getdata(sql).Tables[0].Rows[0]["C"].ToString();

            }
            catch (Exception)
            {
            }
        }

        //Get Employee Count
        public void EmployeeCount()
        {
            Shared lc = new Shared();
            string sql = "SELECT count(E_id) as C FROM users";

            try
            {
                lbl_employee.InnerText = lc.getdata(sql).Tables[0].Rows[0]["C"].ToString();

            }
            catch (Exception)
            {
            }
        }

        //Get Monthly Income
        public void MonthlyIncome()
        {
            Shared lc = new Shared();
            string sql = "SELECT sum(Pay) as total FROM S_payment where MONTH(Date) = MONTH(GETDATE())";

            try
            {
                lbl_M_Income.InnerText = lc.getdata(sql).Tables[0].Rows[0]["total"].ToString();

    }
            catch (Exception)
            {
            }
        }

        //Get Monthly Net profit
        public void MonthlyNetProfit()
        {
            Shared lc = new Shared();
            string sql = "SELECT sum(Payment) as total FROM E_payment where MONTH(Date) = MONTH(GETDATE())";

            try
            {
                string a = lc.getdata(sql).Tables[0].Rows[0]["total"].ToString();

               
                    decimal x = Convert.ToDecimal(a);
                    decimal y = Convert.ToDecimal(lbl_M_Income.InnerText);

                    lbl_M_Net_income.InnerText = (y - x).ToString();
               

            }
            catch (Exception ex)
            {
               
            }
        }

        //Get Yearly Net profit
        public void YearlyNetProfit()
        {
            Shared lc = new Shared();
            string sql = "SELECT sum(Payment) as total FROM E_payment where YEAR(Date) = YEAR(GETDATE())";

            string a = lc.getdata(sql).Tables[0].Rows[0]["total"].ToString();

            string sql2 = "SELECT sum(Pay) as total FROM S_payment where YEAR(Date) = YEAR(GETDATE())";

            string b = lc.getdata(sql2).Tables[0].Rows[0]["total"].ToString();

            try
            {

                decimal x = Convert.ToDecimal(a);
                decimal y = Convert.ToDecimal(b);

                lbl_year_net_profit.InnerText = (y - x).ToString();


            }
            catch (Exception ex)
            {
              //  throw ex;
            }
        }
    }
}