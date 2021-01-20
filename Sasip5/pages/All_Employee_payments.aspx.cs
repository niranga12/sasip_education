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
    public partial class All_Employee_payments : System.Web.UI.Page
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
            
                string sql = "SELECT a.ID, a.E_ID,b.Name, a.Branch, a.Year, a.Month, a.Payment, a.Date FROM E_payment as a inner join users as b on a.E_ID=b.E_id where a.E_ID='" + txt_ID.Text+"'";


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
                string sql = "SELECT a.ID, a.E_ID,b.Name, a.Branch, a.Year, a.Month, a.Payment, a.Date FROM E_payment as a inner join users as b on a.E_ID=b.E_id";

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
            if (drop_branch.SelectedValue == "") {
                string sql = "SELECT a.ID, a.E_ID,b.Name, a.Branch, a.Year, a.Month, a.Payment, a.Date FROM E_payment as a inner join users as b on a.E_ID=b.E_id";
                Shared gd = new Shared();
                dgvItems.DataSource = gd.getdata(sql).Tables[0];
            }
            else { 
            string sql = "SELECT a.ID, a.E_ID,b.Name, a.Branch, a.Year, a.Month, a.Payment, a.Date FROM E_payment as a inner join users as b on a.E_ID=b.E_id where a.Branch='" + drop_branch.SelectedItem.Text + "'";
                Shared gd = new Shared();
                dgvItems.DataSource = gd.getdata(sql).Tables[0];
            }

            //Bind the fetched data to gridview
            dgvItems.DataBind();

            txt_ID.Text = "";
        }

       
    }
}