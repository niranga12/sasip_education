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
    public partial class print_overdue : System.Web.UI.Page
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
            PrintReport();
        }

        // Genarate Overdue payment details report
        public ReportDocument PrintReport()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);
            dt = new DataTable();
            dt.TableName = "overdue";
            com.Connection = conn;
            string sql = @"SELECT a.Stu_ID as SID,(select top 1 Name from students where S_id=Stu_ID) as Name,
                                (select top 1 Branch from students where S_id=Stu_ID) as Branch,c.Name as Subject,
                            (select top 1 Fee from Subject where Name = c.Name) as Fee, sum(Pay) as payed,
                             min(Overdue) as Overdue ,
                            max(a.Date) as LastPayDate,
                             DATEDIFF(DAY, DATEADD(day, 0, max(a.Date)), GETDATE()) AS DateDiff
                              FROM S_payment as a
                               inner join students as b on a.Stu_ID = b.S_id inner join Subject as c on a.Sub_ID = c.ID
                                where a.Overdue <> 0.00 
                                group by c.Name,a.Stu_ID";  
            com.CommandText = sql;
            sqlda = new SqlDataAdapter(com);
            sqlda.Fill(dt);

            ReportDocument rptDoc = new ReportDocument();
            rptDoc.Load(Server.MapPath("reports/overdue.rpt"));
            rptDoc.SetDataSource(dt);
            CrystalReportViewer1.ReportSource = rptDoc;
            return rptDoc;
        }

    }
}