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
    public partial class print_profit : System.Web.UI.Page
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
            dt.TableName = "Porfit";
            com.Connection = conn;
            string sql = @"SELECT YEAR(a.Date) as Year,MONTH(a.Date) as Month,
            SUM(b.Pay) as S_income,SUM(a.Payment) as E_Payments, (SUM(b.Pay)-SUM(a.Payment)) as Profit
            FROM E_payment as a
            inner join  S_payment as b on YEAR(a.Date) = YEAR(b.Date) and MONTH(a.Date)=MONTH(b.Date)
            group by YEAR(a.Date),MONTH(a.Date) 
            order by YEAR(a.Date) DESC";  // As per condition  
            com.CommandText = sql;
            sqlda = new SqlDataAdapter(com);
            sqlda.Fill(dt);

            ReportDocument rptDoc = new ReportDocument();
            rptDoc.Load(Server.MapPath("reports/Profit.rpt"));
            rptDoc.SetDataSource(dt);
            CrystalReportViewer1.ReportSource = rptDoc;
            return rptDoc;
        }

    }
}