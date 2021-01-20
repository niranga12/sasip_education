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
    public partial class subject_report : System.Web.UI.Page
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
                Loadsubject();
            }

        }

        //Load subject to dropdown
        public void Loadsubject()
        {
            drop_subject.DataTextField = "Name";
            Shared lc = new Shared();
            string sql = "select DISTINCT Name from Subject";
            drop_subject.DataSource = lc.getdata(sql).Tables[0];
            drop_subject.DataBind();
            drop_subject.Items.Insert(0, new ListItem("Select a Subject", "0"));
        }


        //Grid view search function
        public void SearchUser_by_Subject()
        {

            string sql = @"SELECT a.ID, a.Name,a.Branch, a.Year, a.Month, a.Fee, a.Grade,
                            (SELECT count(Stu_ID) FROM S_payment where Overdue='0.00' and Sub_ID=a.ID) as Complete_Payment,
                            (SELECT count(Stu_ID) FROM Stu_Sub where Sub_ID=a.ID) as Registered_Student
                            FROM Subject as a where Name='" + drop_subject.SelectedItem.Text+"'";

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
                string sql = @"SELECT a.ID, a.Name,a.Branch, a.Year, a.Month, a.Fee, a.Grade,
                            (SELECT count(Stu_ID) FROM S_payment where Overdue='0.00' and Sub_ID=a.ID) as Complete_Payment,
                            (SELECT count(Stu_ID) FROM Stu_Sub where Sub_ID=a.ID) as Registered_Student
                            FROM Subject as a";

                Shared gd = new Shared();
                dgvItems.DataSource = gd.getdata(sql).Tables[0];

                //Bind the fetched data to gridview           
                dgvItems.DataBind();

            }
        }
        protected void btn_clears_Click(object sender, EventArgs e)
        {
            DataLoad();
            drop_subject.ClearSelection();
            drop_branch.ClearSelection();
        }

        protected void btn_search_ID_Click(object sender, EventArgs e)
        {
            SearchUser_by_Subject();
        }

        protected void btn_filter_branch_Click(object sender, EventArgs e)
        {
            SearchUser_by_Branch();
        }

        //Grid view search function
        public void SearchUser_by_Branch()
        {

            string sql = @"SELECT a.ID, a.Name,a.Branch, a.Year, a.Month, a.Fee, a.Grade,
                            (SELECT count(Stu_ID) FROM S_payment where Overdue='0.00' and Sub_ID=a.ID) as Complete_Payment,
                            (SELECT count(Stu_ID) FROM Stu_Sub where Sub_ID=a.ID) as Registered_Student
                            FROM Subject as a where Branch='" + drop_branch.SelectedItem.Text + "'";

            Shared gd = new Shared();
            dgvItems.DataSource = gd.getdata(sql).Tables[0];

            //Bind the fetched data to gridview
            dgvItems.DataBind();

        }

        protected void btn_report_Click(object sender, EventArgs e)
        {
            Response.Redirect("print_subject.aspx");
        }
    }
}