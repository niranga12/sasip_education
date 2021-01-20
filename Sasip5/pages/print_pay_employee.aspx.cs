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
    public partial class print_pay_employee : System.Web.UI.Page
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
            dt.TableName = "e_payment";
            com.Connection = conn;
            string sql = @"SELECT TOP 1 a.ID, a.E_ID,b.Name, b.E_type,a.Branch, a.Year, a.Month, a.Payment, a.Date
                            FROM E_payment as a
                            inner join users as b on a.E_ID=b.E_id
                            order by ID DESC";  // As per condition  
            com.CommandText = sql;
            sqlda = new SqlDataAdapter(com);
            sqlda.Fill(dt);

            ReportDocument rptDoc = new ReportDocument();
            rptDoc.Load(Server.MapPath("reports/E_payment.rpt"));
            rptDoc.SetDataSource(dt);
            CrystalReportViewer1.ReportSource = rptDoc;
            return rptDoc;
        }

    }
}