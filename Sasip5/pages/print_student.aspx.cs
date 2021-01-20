using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sasip5.pages
{
    public partial class print_student : System.Web.UI.Page
    {
        SqlDataAdapter sqlda = new SqlDataAdapter();
        SqlCommand com = new SqlCommand();
        DataTable dt;
        DataSet1 ds = new DataSet1();
        ReportDocument rptDoc = new ReportDocument();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EType"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            string a = Session["Branch"].ToString();

            PrintReport(a);
        }


        public ReportDocument PrintReport(string b)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);
            dt = new DataTable();
            dt.TableName = "Student";
            com.Connection = conn;

            if (b == "") {
                string sql = @"SELECT a.Stu_ID,b.Name,b.Branch,c.Name as Subject, a.Date as Reg_Date ,
                (SELECT top 1 Pay FROM S_payment as e where e.Stu_ID=a.Stu_ID and e.Sub_ID=a.Sub_ID order by e.ID DESC) as Payed,
                (SELECT top 1 e.Overdue FROM S_payment as e where e.Stu_ID=a.Stu_ID and e.Sub_ID=a.Sub_ID order by e.ID DESC) as Overdue,
                (SELECT top 1 e.Status FROM S_payment as e where e.Stu_ID=a.Stu_ID and e.Sub_ID=a.Sub_ID order by e.ID DESC) as Status
                FROM Stu_Sub as a
                inner join students as b on a.Stu_ID=b.S_id
                inner join Subject as c on a.Sub_ID=c.ID
                Order by a.Stu_ID";  // As per condition 
                com.CommandText = sql;
            }
            else { 
            string sql2 = @"SELECT a.Stu_ID,b.Name,b.Branch,c.Name as Subject, a.Date as Reg_Date ,
                (SELECT top 1 Pay FROM S_payment as e where e.Stu_ID=a.Stu_ID and e.Sub_ID=a.Sub_ID order by e.ID DESC) as Payed,
                (SELECT top 1 e.Overdue FROM S_payment as e where e.Stu_ID=a.Stu_ID and e.Sub_ID=a.Sub_ID order by e.ID DESC) as Overdue,
                (SELECT top 1 e.Status FROM S_payment as e where e.Stu_ID=a.Stu_ID and e.Sub_ID=a.Sub_ID order by e.ID DESC) as Status
                FROM Stu_Sub as a
                inner join students as b on a.Stu_ID=b.S_id
                inner join Subject as c on a.Sub_ID=c.ID
                where b.branch ='" + b + "'" +
                "Order by a.Stu_ID";
                com.CommandText = sql2;
            }

          
            sqlda = new SqlDataAdapter(com);
            sqlda.Fill(dt);

            ReportDocument rptDoc = new ReportDocument();
            rptDoc.Load(Server.MapPath("reports/Student.rpt"));
            rptDoc.SetDataSource(dt);
            CrystalReportViewer1.ReportSource = rptDoc;
            return rptDoc;
        }

    }
}