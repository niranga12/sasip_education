using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Sasip5.pages
{
    public partial class print_pay : System.Web.UI.Page
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
         //   ReportDocument cryrpt = new ReportDocument();
        //    cryrpt.Load(Server.MapPath("reports/S_payment.rpt"));

        //    CrystalReportViewer1.ReportSource = cryrpt;
       //     return cryrpt;


            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);
            dt = new DataTable();
            dt.TableName = "Last_payment";
            com.Connection = conn;
            string sql = @"SELECT TOP 1 a.ID, a.Stu_ID,b.Name,c.Name as Subject,c.Branch,c.Fee,((c.Fee)-(a.Overdue)) as total_Payed, a.Pay, a.Overdue, a.Date, a.Status
            FROM S_payment as a
            inner join students as b on  a.Stu_ID=b.S_id
            inner join Subject as c on a.Sub_ID=c.ID
            order by ID DESC"; ; // As per condition  
            com.CommandText = sql;
            sqlda = new SqlDataAdapter(com);
            sqlda.Fill(dt);

            ReportDocument rptDoc = new ReportDocument();
            rptDoc.Load(Server.MapPath("reports/S_payment.rpt"));
            rptDoc.SetDataSource(dt);
            CrystalReportViewer1.ReportSource = rptDoc;
            return rptDoc;
        }
    }
}