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
    public partial class student_reports : System.Web.UI.Page
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
        public void SearchUser_by_Student()
        {

            string sql = @"SELECT a.Stu_ID,b.Name,b.Branch,c.Name as Subject, a.Date as Reg_Date ,
                (SELECT top 1 Pay FROM S_payment as e where e.Stu_ID=a.Stu_ID and e.Sub_ID=a.Sub_ID order by e.ID DESC) as Payed,
                (SELECT top 1 e.Overdue FROM S_payment as e where e.Stu_ID=a.Stu_ID and e.Sub_ID=a.Sub_ID order by e.ID DESC) as Overdue,
                (SELECT top 1 e.Status FROM S_payment as e where e.Stu_ID=a.Stu_ID and e.Sub_ID=a.Sub_ID order by e.ID DESC) as Status
                FROM Stu_Sub as a
                inner join students as b on a.Stu_ID=b.S_id
                inner join Subject as c on a.Sub_ID=c.ID
                where a.Stu_ID ='" + txt_ID.Text + "'" +
             "Order by a.Stu_ID";

            Shared gd = new Shared();
            dgvItems.DataSource = gd.getdata(sql).Tables[0];

            //Bind the fetched data to gridview
            dgvItems.DataBind();

        }


        //data Load to Grid view   
        public void DataLoad()
        {

            using (SqlConnection con = new SqlConnection(cs))
            {
                string sql = @"SELECT a.Stu_ID,b.Name,b.Branch,c.Name as Subject, a.Date as Reg_Date ,
                (SELECT top 1 Pay FROM S_payment as e where e.Stu_ID=a.Stu_ID and e.Sub_ID=a.Sub_ID order by e.ID DESC) as Payed,
                (SELECT top 1 e.Overdue FROM S_payment as e where e.Stu_ID=a.Stu_ID and e.Sub_ID=a.Sub_ID order by e.ID DESC) as Overdue,
                (SELECT top 1 e.Status FROM S_payment as e where e.Stu_ID=a.Stu_ID and e.Sub_ID=a.Sub_ID order by e.ID DESC) as Status
                FROM Stu_Sub as a
                inner join students as b on a.Stu_ID=b.S_id
                inner join Subject as c on a.Sub_ID=c.ID
                Order by a.Stu_ID";

                Shared gd = new Shared();
                dgvItems.DataSource = gd.getdata(sql).Tables[0];

                //Bind the fetched data to gridview           
                dgvItems.DataBind();

            }
        }
        protected void btn_clears_Click(object sender, EventArgs e)
        {
            DataLoad();
            txt_ID.Text = "";
            drop_branch.ClearSelection();
        }

        protected void btn_search_ID_Click(object sender, EventArgs e)
        {
            SearchUser_by_Student();
        }

        protected void btn_filter_branch_Click(object sender, EventArgs e)
        {
            SearchUser_by_Branch();
        }

        //Grid view search function
        public void SearchUser_by_Branch()
        {
            string sql = @"SELECT a.Stu_ID,b.Name,b.Branch,c.Name as Subject, a.Date as Reg_Date ,
                (SELECT top 1 Pay FROM S_payment as e where e.Stu_ID=a.Stu_ID and e.Sub_ID=a.Sub_ID order by e.ID DESC) as Payed,
                (SELECT top 1 e.Overdue FROM S_payment as e where e.Stu_ID=a.Stu_ID and e.Sub_ID=a.Sub_ID order by e.ID DESC) as Overdue,
                (SELECT top 1 e.Status FROM S_payment as e where e.Stu_ID=a.Stu_ID and e.Sub_ID=a.Sub_ID order by e.ID DESC) as Status
                FROM Stu_Sub as a
                inner join students as b on a.Stu_ID=b.S_id
                inner join Subject as c on a.Sub_ID=c.ID
                where b.branch ='"+drop_branch.SelectedItem.Text+"'"+
                "Order by a.Stu_ID";

            Shared gd = new Shared();
            dgvItems.DataSource = gd.getdata(sql).Tables[0];

            //Bind the fetched data to gridview
            dgvItems.DataBind();

        }
        protected void btn_report_Click(object sender, EventArgs e)
        {

            string a = drop_branch.SelectedItem.Text;
            if (a == "Select Branch") {
                Session["Branch"] = "";
            }
            else {
                Session["Branch"] =a ;
            }
            Response.Redirect("print_student.aspx");
        }
    }
}