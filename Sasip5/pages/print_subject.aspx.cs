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
    public partial class print_subject : System.Web.UI.Page
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


        public ReportDocument PrintReport()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);
            dt = new DataTable();
            dt.TableName = "Subject";
            com.Connection = conn;
            string sql = @"SELECT a.ID, a.Name,a.Branch, a.Year, a.Month, a.Fee, a.Grade,
                            (SELECT count(Stu_ID) FROM S_payment where Overdue='0.00' and Sub_ID=a.ID) as Complete_Payment,
                            (SELECT count(Stu_ID) FROM Stu_Sub where Sub_ID=a.ID) as Registered_Student
                            FROM Subject as a";  // As per condition  
            com.CommandText = sql;
            sqlda = new SqlDataAdapter(com);
            sqlda.Fill(dt);

            ReportDocument rptDoc = new ReportDocument();
            rptDoc.Load(Server.MapPath("reports/subject.rpt"));
            rptDoc.SetDataSource(dt);
            CrystalReportViewer1.ReportSource = rptDoc;
            return rptDoc;
        }

    }
}