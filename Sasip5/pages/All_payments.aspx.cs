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
    public partial class All_payments : System.Web.UI.Page
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
            
                string sql = "SELECT a.ID, a.Stu_ID,b.Name,b.Branch, c.Name as Subject, a.Pay, a.Overdue, a.Date, a.Status FROM S_payment as a inner join students as b on a.Stu_ID=b.S_id inner join Subject as c on a.Sub_ID = c.ID  where a.Stu_ID='"+txt_ID.Text+"'";


            Shared gd = new Shared();
            dgvItems.DataSource = gd.getdata(sql).Tables[0];

            //Bind the fetched data to gridview
            dgvItems.DataBind();

            drop_branch.ClearSelection();

        }

        //Gridview reset button
        protected void btnReset_Click1(object sender, EventArgs e)
        {
            DataLoad();
            txt_ID.Text = string.Empty;
        }

        //data Load to Grid view   
        public void DataLoad()
        {

            using (SqlConnection con = new SqlConnection(cs))
            {
                string sql = "SELECT a.ID, a.Stu_ID,b.Name,b.Branch, c.Name as Subject, a.Pay, a.Overdue, a.Date, a.Status FROM S_payment as a inner join students as b on a.Stu_ID=b.S_id inner join Subject as c on a.Sub_ID = c.ID ";

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

        protected void btn_drop_search_Click(object sender, EventArgs e)
        {

            string sql = "SELECT a.ID, a.Stu_ID,b.Name,b.Branch, c.Name as Subject, a.Pay, a.Overdue, a.Date, a.Status FROM S_payment as a inner join students as b on a.Stu_ID=b.S_id inner join Subject as c on a.Sub_ID = c.ID  where b.Branch='" + drop_branch.SelectedItem.Text + "'";


            Shared gd = new Shared();
            dgvItems.DataSource = gd.getdata(sql).Tables[0];

            //Bind the fetched data to gridview
            dgvItems.DataBind();

            txt_ID.Text = "";
        }

        protected void btn_Employee_Click(object sender, EventArgs e)
        {
            Response.Redirect("All_Employee_payments.aspx");
        }
    }
}