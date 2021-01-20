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
    public partial class OverDue_Payments : System.Web.UI.Page
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
        public void SearchUser_by_ID()
        {

            string sql = @"SELECT max(a.ID) as maxx,a.Stu_ID,(select top 1 Name from students where S_id=Stu_ID) as name,c.Name,
                            (select top 1 Fee from Subject where Name = c.Name) as Fee, max(Pay) as payed,
                             min(Overdue) as Overdue ,
                            max(a.Date) as LastPayDate,
                             DATEDIFF(DAY, DATEADD(day, 0, max(a.Date)), GETDATE()) AS DateDiff
                              FROM S_payment as a
                               inner join students as b on a.Stu_ID = b.S_id inner join Subject as c on a.Sub_ID = c.ID
                                where a.Stu_ID='"+txt_ID.Text+ "' and a.Overdue <> 0.00" +
                                 "group by c.Name,a.Stu_ID";

            Shared gd = new Shared();
            dgvItems.DataSource = gd.getdata(sql).Tables[0];

            //Bind the fetched data to gridview
            dgvItems.DataBind();

        }

        //Gridview reset button
        protected void btnReset_Click1(object sender, EventArgs e)
        {
            DataLoad();

        }

        //data Load to Grid view   
        public void DataLoad()
        {

            using (SqlConnection con = new SqlConnection(cs))
            {
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

                Shared gd = new Shared();
                dgvItems.DataSource = gd.getdata(sql).Tables[0];

                //Bind the fetched data to gridview           
                dgvItems.DataBind();

            }
        }
        protected void btn_clears_Click(object sender, EventArgs e)
        {
            DataLoad();
        }


        //Student Search
        protected void btn_search_Click(object sender, EventArgs e)
        {
            SearchUser_by_ID();
        }

        protected void btn_overdue_Click(object sender, EventArgs e)
        {
            Response.Redirect("print_overdue.aspx");
        }
    }
}