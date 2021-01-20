using Sasip5.pages.classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sasip5.pages
{
    public partial class profit_reports : System.Web.UI.Page
    {
        //get connection from web config file
        public static string cs = ConfigurationManager.ConnectionStrings["dbconn"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EType"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (IsPostBack == false)
            {
                DataLoad();
            }

        }

        //Grid view search function
        public void SearchProfit_by_Month()
        {
            try
            {
                string sql = @"SELECT YEAR(a.Date) as Year,MONTH(a.Date) as Month,
                        SUM(b.Pay) as S_income,SUM(a.Payment) as E_Payments, (SUM(b.Pay)-SUM(a.Payment)) as Profit
                        FROM E_payment as a
                        inner join  S_payment as b on YEAR(a.Date) = YEAR(b.Date) and MONTH(a.Date)=MONTH(b.Date)
                        where MONTH(a.Date)='" + drop_month.SelectedValue + "' group by YEAR(a.Date),MONTH(a.Date) order by YEAR(a.Date) DESC";

                Shared gd = new Shared();
                dgvItems.DataSource = gd.getdata(sql).Tables[0];

                if (gd.getdata(sql).Tables[0].Rows.Count == 0)
                {
                string script = "alert(\"Data Not Found!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                else {

                }
                //Bind the fetched data to gridview
                dgvItems.DataBind();
            }
            catch (Exception)
            {



            }
        

        }

        //data Load to Grid view   
        public void DataLoad()
        {

            using (SqlConnection con = new SqlConnection(cs))
            {
                string sql = @"SELECT YEAR(a.Date) as Year,MONTH(a.Date) as Month,
                                SUM(b.Pay) as S_income,SUM(a.Payment) as E_Payments, (SUM(b.Pay)-SUM(a.Payment)) as Profit
                                FROM E_payment as a
                                inner join  S_payment as b on YEAR(a.Date) = YEAR(b.Date) and MONTH(a.Date)=MONTH(b.Date)
                                group by YEAR(a.Date),MONTH(a.Date)";

                Shared gd = new Shared();
                dgvItems.DataSource = gd.getdata(sql).Tables[0];

                //Bind the fetched data to gridview           
                dgvItems.DataBind();

            }
        }
        protected void btn_clears_Click(object sender, EventArgs e)
        {
            DataLoad();
            drop_month.ClearSelection();
        }


        protected void btn_report_Click(object sender, EventArgs e)
        {
            Response.Redirect("print_profit.aspx");
        }

        protected void btn_filterMonth_Click(object sender, EventArgs e)
        {
            SearchProfit_by_Month();

        }
    }
}