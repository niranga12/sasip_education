using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Sasip5.pages.classes;

namespace Sasip5.pages.classes
{
    public partial class Attendance : System.Web.UI.Page
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

        //Load Details to from
        public void LoadDetails()
        {
            Shared lc = new Shared();
            string sql = "SELECT Name FROM students where S_id='" + txt_id.Text + "'";


            try
            {
                txt_name.Text = lc.getdata(sql).Tables[0].Rows[0]["Name"].ToString();
            }
            catch (Exception)
            {
                string script = "alert(\"Student Not found..!\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);

            }
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {

            LoadDetails();

        }


        //Make payment
        protected void btn_in_click(object sender, EventArgs e)
        {
            In();
        }

        public void In() {
            Attendance_class at = new Attendance_class();
            at.ID = Int16.Parse(txt_id.Text);
            at.Date = DateTime.Now.ToString();

            at.Mark_in(at);

            clear_form();
            DataLoad();
        }

        public void clear_form()
        {
            txt_id.Text  = txt_name.Text = "";
        }


        protected void btn_clears_Click(object sender, EventArgs e)
        {
            clear_form();
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            DataLoad_by_student();
        }

        //Data Load
        public void DataLoad()
        {

            using (SqlConnection con = new SqlConnection(cs))
            {
                string sql = @"SELECT a.ID, a.SID,b.Name,b.Branch, a.Date FROM Attendance as a
                            inner join students as b on a.SID=b.S_id where CONVERT(DATE, a.Date)=CONVERT(DATE, GETDATE())";

                Shared gd = new Shared();
                dgvItems.DataSource = gd.getdata(sql).Tables[0];

                //Bind the fetched data to gridview           
                dgvItems.DataBind();

            }
        }


        public void DataLoad_by_student()
        {

            using (SqlConnection con = new SqlConnection(cs))
            {
                string sql = @"SELECT a.ID, a.SID,b.Name,b.Branch, a.Date FROM Attendance as a
                            inner join students as b on a.SID=b.S_id where a.SID='"+ txt_grid_id.Text+ "' order by a.ID DESC";

                Shared gd = new Shared();
                dgvItems.DataSource = gd.getdata(sql).Tables[0];

                //Bind the fetched data to gridview           
                dgvItems.DataBind();

            }
        }

        protected void btn_grid_reset_Click(object sender, EventArgs e)
        {
            DataLoad();
            txt_grid_id.Text = "";
        }
    }
}